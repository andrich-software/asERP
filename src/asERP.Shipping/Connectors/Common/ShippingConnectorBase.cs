using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using asERP.Shipping.Abstractions;
using Polly.CircuitBreaker;

namespace asERP.Shipping.Connectors.Common;

/// <summary>
/// Shared plumbing for carrier connectors: config parsing, auth header helpers and the
/// transient/permanent classification of HTTP failures.
/// </summary>
public abstract class ShippingConnectorBase
{
    protected static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    /// <summary>Parses the provider's AdditionalConfigJson into the connector's config record.</summary>
    protected static T ParseConfig<T>(ShippingCarrierContext context) where T : new()
    {
        if (string.IsNullOrWhiteSpace(context.Provider.AdditionalConfigJson))
        {
            return new T();
        }

        try
        {
            return JsonSerializer.Deserialize<T>(context.Provider.AdditionalConfigJson, JsonOptions) ?? new T();
        }
        catch (JsonException ex)
        {
            throw new InvalidOperationException(
                $"AdditionalConfigJson of shipping provider '{context.Provider.Name}' is not valid JSON: {ex.Message}");
        }
    }

    protected static AuthenticationHeaderValue BasicAuth(string username, string password)
        => new("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}")));

    /// <summary>4xx responses (except 408/429) are carrier-side validation errors — retrying is pointless.</summary>
    protected static bool IsPermanentStatusCode(HttpStatusCode statusCode)
    {
        var code = (int)statusCode;
        return code is >= 400 and < 500 && statusCode is not (HttpStatusCode.RequestTimeout or HttpStatusCode.TooManyRequests);
    }

    /// <summary>Runs a label call and classifies network-level failures as transient.</summary>
    protected static async Task<CarrierLabelResult> ExecuteLabelCallAsync(Func<Task<CarrierLabelResult>> call, string carrierName)
    {
        try
        {
            return await call();
        }
        catch (BrokenCircuitException)
        {
            return CarrierLabelResult.Transient($"{carrierName} API circuit is open — the carrier appears to be down.");
        }
        catch (HttpRequestException ex)
        {
            return CarrierLabelResult.Transient($"{carrierName} API is unreachable: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return CarrierLabelResult.Transient($"{carrierName} API request timed out.");
        }
        catch (InvalidOperationException ex)
        {
            // Configuration problems (missing knobs, bad JSON) never fix themselves by retrying.
            return CarrierLabelResult.Permanent(ex.Message);
        }
    }

    protected static async Task<CarrierTrackingResult> ExecuteTrackingCallAsync(Func<Task<CarrierTrackingResult>> call, string carrierName)
    {
        try
        {
            return await call();
        }
        catch (BrokenCircuitException)
        {
            return CarrierTrackingResult.Failed($"{carrierName} tracking API circuit is open.");
        }
        catch (HttpRequestException ex)
        {
            return CarrierTrackingResult.Failed($"{carrierName} tracking API is unreachable: {ex.Message}");
        }
        catch (TaskCanceledException)
        {
            return CarrierTrackingResult.Failed($"{carrierName} tracking request timed out.");
        }
        catch (InvalidOperationException ex)
        {
            return CarrierTrackingResult.Failed(ex.Message);
        }
    }

    protected static string Truncate(string value, int maxLength)
        => value.Length <= maxLength ? value : value[..maxLength];

    /// <summary>Opt-in default for the return-label capability — connectors override per carrier.</summary>
    public virtual bool SupportsReturnLabels => false;

    public virtual Task<CarrierLabelResult> CreateReturnLabelAsync(ShippingCarrierContext context, ReturnLabelRequest request)
        => Task.FromResult(CarrierLabelResult.Permanent(
            $"Return labels are not supported for carrier {context.Provider.Type} yet."));
}
