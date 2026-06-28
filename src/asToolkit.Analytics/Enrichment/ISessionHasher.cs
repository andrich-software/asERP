namespace asToolkit.Analytics.Enrichment;

internal interface ISessionHasher
{
    /// <summary>Computes the daily-salted session id for a visitor request.</summary>
    string Compute(string host, string visitorIp, string userAgent);
}
