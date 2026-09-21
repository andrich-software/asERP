using System.Net;
using System.Net.Sockets;
using System.Text;
using asERP.Application.Models.Email;
using asERP.Domain.Enums;
using asERP.Infrastructure.EmailService;
using asERP.Infrastructure.EmailService.Providers;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Xunit;

namespace asERP.Server.Tests.Features.TenantEmailSettings;

/// <summary>
/// SmtpEnableSsl used to choose the SMTP transport, and it is written through a plain [Authorize]
/// endpoint: false selected SecureSocketOptions.None outright, and true selected Auto, which MailKit
/// documents as continuing without any encryption when the server does not advertise STARTTLS. Either
/// way the AUTH exchange and the message body — password-reset and confirmation tokens among them —
/// could end up readable on the wire.
///
/// The transport is the operator's decision now, in all three of its dimensions (host, port and the
/// flag itself, each the operator's only while the tenant row supplies nothing for it). These tests
/// pin what each endpoint is dialled with, and the ends of it against a fake SMTP server on loopback:
/// a server that drops STARTTLS fails closed before authenticating, and the local relay a developer
/// configured for Mailpit still authenticates and sends.
///
/// Offline and deterministic: every address is a literal on loopback or in RFC 5737 documentation
/// space, and the only server dialled is the one the test starts itself.
/// </summary>
public class SmtpTransportSecurityTests
{
    private const string PublicHost = "203.0.113.10";
    private const string LanRelayHost = "192.168.10.5";

    private static SmtpEndpointGuard Guard(SmtpHostPolicyOptions? options = null) =>
        new(options is null ? SmtpHostPolicy.Default : new SmtpHostPolicy(options));

    [Theory]
    [InlineData(25)]
    [InlineData(587)]
    [InlineData(2525)]
    [InlineData(1025)]
    public async Task EndpointATenantChose_IsEncryptedEvenWhenTheRowDisablesSsl(int port)
    {
        // The finding's first route: PUT /api/v1/TenantEmailSettings with smtpEnableSsl=false. No
        // operator mark survives a tenant-supplied endpoint, so there is nothing to opt out of.
        var settings = Endpoint(PublicHost, port, enableSsl: false);

        Assert.Equal(SecureSocketOptions.StartTls, await Guard().ResolveTransportAsync(settings));
    }

    [Theory]
    [InlineData(25)]
    [InlineData(587)]
    [InlineData(2525)]
    public async Task SubmissionPorts_AreUpgradedWithStartTls(int port)
    {
        // Not Auto: a missing STARTTLS has to be a failure, not a cleartext session.
        Assert.Equal(
            SecureSocketOptions.StartTls,
            await Guard().ResolveTransportAsync(Endpoint(PublicHost, port, enableSsl: true)));
    }

    [Theory]
    [InlineData(true, false, false, false)]
    [InlineData(false, false, false, false)]
    [InlineData(false, true, true, true)]
    public async Task ImplicitTlsPort_ConnectsWithTls_WhoeverConfiguredIt(
        bool enableSsl, bool operatorHost, bool operatorPort, bool operatorSsl)
    {
        // 465 is implicit TLS (RFC 8314): the session is encrypted by connecting, and no SMTP server
        // there speaks plain — so the port decides, not the flag and not the provenance.
        var settings = Endpoint(PublicHost, 465, enableSsl, operatorHost, operatorPort, operatorSsl);

        Assert.Equal(SecureSocketOptions.SslOnConnect, await Guard().ResolveTransportAsync(settings));
    }

    [Fact]
    public async Task OperatorLoopbackRelay_MaySendInTheClear()
    {
        // The Mailpit of docker-compose.mail.yml after a developer configured it in the Superadmin
        // settings: Email.SmtpHost=localhost, Email.SmtpPort=1025, Email.SmtpEnableSsl=False. All
        // three dimensions are the operator's by provenance and the session never leaves the machine.
        // (A fresh install has none of this: the migration seeds an empty host, 587 and "true" —
        // StockInstallSeed_SendsNoMailAtAll.)
        var byName = MailpitEndpoint("localhost");
        var literal = MailpitEndpoint("127.0.0.1");
        var ipv6 = MailpitEndpoint("::1");

        Assert.Equal(SecureSocketOptions.None, await Guard().ResolveTransportAsync(byName));
        Assert.Equal(SecureSocketOptions.None, await Guard().ResolveTransportAsync(literal));
        Assert.Equal(SecureSocketOptions.None, await Guard().ResolveTransportAsync(ipv6));
    }

    [Fact]
    public async Task OperatorLoopbackRelay_ThatAsksForTls_GetsIt()
    {
        // The seeded value left in place (Email.SmtpEnableSsl = "true") against Mailpit: STARTTLS is
        // required, Mailpit does not offer it, and the send fails — which is why docker-compose.mail.yml
        // and the area CLAUDE.md name all three settings a developer has to write.
        var settings = Endpoint(
            "127.0.0.1", 1025, enableSsl: true, operatorHost: true, operatorPort: true, operatorSsl: true);

        Assert.Equal(SecureSocketOptions.StartTls, await Guard().ResolveTransportAsync(settings));
    }

    [Theory]
    [InlineData(true, false)]   // the tenant named the port
    [InlineData(false, true)]   // the tenant named the host — echoing localhost buys nothing
    [InlineData(false, false)]  // the tenant named both
    public async Task LoopbackWithoutBothOperatorMarks_IsEncrypted(bool operatorHost, bool operatorPort)
    {
        var settings = Endpoint(
            "127.0.0.1", 1025, enableSsl: false, operatorHost, operatorPort, operatorSsl: true);

        Assert.Equal(SecureSocketOptions.StartTls, await Guard().ResolveTransportAsync(settings));
    }

    [Fact]
    public async Task TenantSuppliedTransportFlag_LosesTheOperatorMark_AndIsEncrypted()
    {
        // The third provenance dimension: the endpoint is the operator's own loopback relay, but the
        // tenant row supplied SmtpEnableSsl itself, so the answer to "no TLS?" is the tenant's and the
        // session is encrypted. Without this mark a tenant could flip even this endpoint to cleartext.
        var tenantSaidFalse = Endpoint(
            "127.0.0.1", 1025, enableSsl: false, operatorHost: true, operatorPort: true, operatorSsl: false);

        Assert.Equal(SecureSocketOptions.StartTls, await Guard().ResolveTransportAsync(tenantSaidFalse));

        // And it does not help the tenant anywhere the switch is on either.
        var permissive = Guard(new SmtpHostPolicyOptions { AllowInsecureTransport = true });
        Assert.Equal(SecureSocketOptions.StartTls, await permissive.ResolveTransportAsync(tenantSaidFalse));
        Assert.Equal(
            SecureSocketOptions.StartTls,
            await permissive.ResolveTransportAsync(
                Endpoint(PublicHost, 587, enableSsl: false, operatorSsl: false)));
    }

    [Fact]
    public async Task OperatorRelayOffLoopback_IsEncryptedUntilTheOperatorSaysOtherwise()
    {
        // A LAN Postfix on 192.168.10.5:25, the operator's own, with SmtpEnableSsl=False: cleartext
        // here does travel a network, so it needs the explicit switch and not the loopback exemption.
        var settings = Endpoint(
            LanRelayHost, 25, enableSsl: false, operatorHost: true, operatorPort: true, operatorSsl: true);

        Assert.Equal(SecureSocketOptions.StartTls, await Guard().ResolveTransportAsync(settings));

        var permissive = Guard(new SmtpHostPolicyOptions { AllowInsecureTransport = true });
        Assert.Equal(SecureSocketOptions.None, await permissive.ResolveTransportAsync(settings));
    }

    [Fact]
    public async Task AllowInsecureTransport_PermitsCleartext_ItDoesNotForceIt()
    {
        var permissive = Guard(new SmtpHostPolicyOptions { AllowInsecureTransport = true });

        // Settings that ask for TLS still get it, and 465 is still implicit TLS.
        Assert.Equal(
            SecureSocketOptions.StartTls,
            await permissive.ResolveTransportAsync(
                Endpoint(PublicHost, 587, enableSsl: true, operatorSsl: true)));
        Assert.Equal(
            SecureSocketOptions.SslOnConnect,
            await permissive.ResolveTransportAsync(
                Endpoint(PublicHost, 465, enableSsl: false, operatorSsl: true)));
    }

    [Fact]
    public void DefaultPolicy_DoesNotAllowInsecureTransport()
    {
        // The switch is operator configuration (SmtpHostPolicy:AllowInsecureTransport, bound in
        // InfrastructureServiceRegistration and injected as a singleton), so no request can set it —
        // and an installation that never configures the section does not have it.
        Assert.False(SmtpHostPolicy.Default.AllowInsecureTransport);
        Assert.False(new SmtpHostPolicy(new SmtpHostPolicyOptions()).AllowInsecureTransport);
    }

    [Fact]
    public async Task ServerThatDropsStartTls_FailsClosedBeforeAuthenticating()
    {
        // The finding's second route: an attacker on the path answers EHLO without the STARTTLS
        // capability. Under Auto, MailKit continued in the clear and the provider handed over the
        // credentials and the body; StartTls makes it a failed send instead. This is also F3's
        // authentication rule — no separate check enforces it, the transport does.
        using var server = FakeSmtpServer.Start();
        var logger = new CapturingLogger<SmtpEmailProvider>();
        var provider = new SmtpEmailProvider(logger, Guard());

        var settings = Endpoint(
            "127.0.0.1", server.Port, enableSsl: true, operatorHost: true, operatorPort: true,
            operatorSsl: true, username: "relay-user", password: "relay-secret");

        var sent = await provider.SendAsync(TestMessage(), settings);
        var commands = await server.StopAsync();

        Assert.False(sent);
        Assert.Contains(commands, command => command.StartsWith("EHLO", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(commands, command => command.StartsWith("AUTH", StringComparison.OrdinalIgnoreCase));
        Assert.DoesNotContain(commands, command => command.StartsWith("MAIL FROM", StringComparison.OrdinalIgnoreCase));

        // Log-only, like every other refusal on this path: the caller sees the same false.
        Assert.Contains(logger.Entries, entry => entry.Level == LogLevel.Error);
    }

    [Fact]
    public async Task MailpitConfiguredByTheOperator_AuthenticatesAndSends()
    {
        // The corrected developer flow, end to end: the three Superadmin settings point the server at
        // Mailpit, which accepts any credentials over a plain connection (MP_SMTP_AUTH_ACCEPT_ANY,
        // MP_SMTP_AUTH_ALLOW_INSECURE in docker-compose.mail.yml). This is the one session that still
        // authenticates unencrypted, and the loopback carve-out is what keeps it to this one.
        using var server = FakeSmtpServer.Start();
        var provider = new SmtpEmailProvider(new CapturingLogger<SmtpEmailProvider>(), Guard());

        var settings = Endpoint(
            "127.0.0.1", server.Port, enableSsl: false, operatorHost: true, operatorPort: true,
            operatorSsl: true, username: "mailpit", password: "anything");

        Assert.Equal(SecureSocketOptions.None, await Guard().ResolveTransportAsync(settings));

        var sent = await provider.SendAsync(TestMessage(), settings);
        var commands = await server.StopAsync();

        Assert.True(sent);
        Assert.Contains(commands, command => command.StartsWith("AUTH", StringComparison.OrdinalIgnoreCase));
        Assert.Contains(commands, command => command.StartsWith("DATA", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task MailpitWithTheSeededSslFlag_SendsNothing()
    {
        // The trap the documentation now names: a developer sets host and port but leaves the seeded
        // Email.SmtpEnableSsl = "true", so the transport is STARTTLS, Mailpit offers none, and the
        // mail silently stops — silently for the caller, that is; the reason is in the server log.
        using var server = FakeSmtpServer.Start();
        var logger = new CapturingLogger<SmtpEmailProvider>();
        var provider = new SmtpEmailProvider(logger, Guard());

        var settings = Endpoint(
            "127.0.0.1", server.Port, enableSsl: true, operatorHost: true, operatorPort: true,
            operatorSsl: true, username: "mailpit", password: "anything");

        Assert.Equal(SecureSocketOptions.StartTls, await Guard().ResolveTransportAsync(settings));

        var sent = await provider.SendAsync(TestMessage(), settings);
        var commands = await server.StopAsync();

        Assert.False(sent);
        Assert.DoesNotContain(commands, command => command.StartsWith("DATA", StringComparison.OrdinalIgnoreCase));
        Assert.Contains(logger.Entries, entry => entry.Level == LogLevel.Error);
    }

    [Fact]
    public async Task StockInstallSeed_SendsNoMailAtAll()
    {
        // What a fresh installation actually runs on: the migration seeds Email.SmtpHost = "",
        // SmtpPort = "587", SmtpEnableSsl = "true" (SettingsSeeder in InitDb), and SettingsInitializer
        // only adds keys that are missing, after Migrate() — its localhost/1025/False values never
        // reach a migrated database. So no socket is opened here, before or after this change, and no
        // installation can be broken by the transport it would have chosen.
        var logger = new CapturingLogger<SmtpEmailProvider>();
        var provider = new SmtpEmailProvider(logger, Guard());

        var seeded = Endpoint(
            host: string.Empty, port: 587, enableSsl: true, operatorHost: true, operatorPort: true,
            operatorSsl: true);

        Assert.False(await provider.SendAsync(TestMessage(), seeded));
        Assert.Contains(logger.Entries, entry => entry.Message.Contains("incomplete", StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// The Mailpit endpoint a developer configures in the Superadmin settings: host, port and
    /// SmtpEnableSsl=False, all three the operator's own and therefore marked by provenance.
    /// </summary>
    private static EmailSettings MailpitEndpoint(string host) => Endpoint(
        host, 1025, enableSsl: false, operatorHost: true, operatorPort: true, operatorSsl: true);

    private static EmailSettings Endpoint(
        string host,
        int port,
        bool enableSsl = false,
        bool operatorHost = false,
        bool operatorPort = false,
        bool operatorSsl = false,
        string? username = null,
        string? password = null) => new()
        {
            ProviderType = EmailProviderType.Smtp,
            SmtpHost = host,
            SmtpPort = port,
            SmtpUsername = username,
            SmtpPassword = password,
            SmtpEnableSsl = enableSsl,
            SmtpHostIsOperatorConfigured = operatorHost,
            SmtpPortIsOperatorConfigured = operatorPort,
            SmtpEnableSslIsOperatorConfigured = operatorSsl,
            FromAddress = "server@example.com",
            FromName = "Server"
        };

    private static EmailMessage TestMessage() => new()
    {
        To = "to@example.com",
        ToName = "To",
        Subject = "Subject",
        Body = "Body"
    };

    /// <summary>
    /// A minimal ESMTP server on loopback that never advertises STARTTLS — the stripped EHLO response
    /// of the exploit scenario, and at the same time exactly what Mailpit offers. It records the
    /// command lines it received (not the SASL continuations, which carry the credentials), so a test
    /// can assert what the provider did and did not send.
    /// </summary>
    private sealed class FakeSmtpServer : IDisposable
    {
        private readonly TcpListener _listener;
        private readonly CancellationTokenSource _cancellation = new();
        private readonly List<string> _commands = [];
        private readonly Task _session;
        private bool _disposed;

        private FakeSmtpServer(TcpListener listener)
        {
            _listener = listener;
            Port = ((IPEndPoint)listener.LocalEndpoint).Port;
            _session = Task.Run(RunAsync);
        }

        public int Port { get; }

        public static FakeSmtpServer Start()
        {
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            return new FakeSmtpServer(listener);
        }

        /// <summary>Waits for the session to end and returns the command lines it saw.</summary>
        public async Task<IReadOnlyList<string>> StopAsync()
        {
            await Task.WhenAny(_session, Task.Delay(TimeSpan.FromSeconds(10)));
            Dispose();

            lock (_commands)
            {
                return _commands.ToArray();
            }
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            _disposed = true;
            _cancellation.Cancel();
            _listener.Stop();
            _cancellation.Dispose();
        }

        private async Task RunAsync()
        {
            try
            {
                using var client = await _listener.AcceptTcpClientAsync(_cancellation.Token);
                await using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.ASCII);
                await using var writer = new StreamWriter(stream, Encoding.ASCII)
                {
                    AutoFlush = true,
                    NewLine = "\r\n"
                };

                await writer.WriteLineAsync("220 fake-smtp ESMTP");

                string? line;
                while ((line = await reader.ReadLineAsync()) != null)
                {
                    lock (_commands)
                    {
                        _commands.Add(line);
                    }

                    if (StartsWith(line, "EHLO") || StartsWith(line, "HELO"))
                    {
                        await writer.WriteLineAsync("250-fake-smtp");
                        await writer.WriteLineAsync("250-AUTH PLAIN LOGIN");
                        await writer.WriteLineAsync("250 HELP");
                    }
                    else if (StartsWith(line, "AUTH"))
                    {
                        await AuthenticateAsync(line, reader, writer);
                    }
                    else if (StartsWith(line, "DATA"))
                    {
                        await writer.WriteLineAsync("354 End data with <CR><LF>.<CR><LF>");
                        while (await reader.ReadLineAsync() is { } body && body != ".")
                        {
                            // The message itself is not what these tests assert on.
                        }

                        await writer.WriteLineAsync("250 2.0.0 Ok: queued");
                    }
                    else if (StartsWith(line, "QUIT"))
                    {
                        await writer.WriteLineAsync("221 2.0.0 Bye");
                        break;
                    }
                    else
                    {
                        await writer.WriteLineAsync("250 2.0.0 Ok");
                    }
                }
            }
            catch (Exception ex) when (ex is IOException or SocketException or OperationCanceledException or ObjectDisposedException)
            {
                // The client hung up — which is what one of these tests is about.
            }
        }

        private static async Task AuthenticateAsync(string command, StreamReader reader, StreamWriter writer)
        {
            if (StartsWith(command, "AUTH LOGIN"))
            {
                await writer.WriteLineAsync("334 VXNlcm5hbWU6");
                await reader.ReadLineAsync();
                await writer.WriteLineAsync("334 UGFzc3dvcmQ6");
                await reader.ReadLineAsync();
            }
            else if (command.Trim().Equals("AUTH PLAIN", StringComparison.OrdinalIgnoreCase))
            {
                await writer.WriteLineAsync("334 ");
                await reader.ReadLineAsync();
            }

            await writer.WriteLineAsync("235 2.7.0 Authentication successful");
        }

        private static bool StartsWith(string line, string command) =>
            line.StartsWith(command, StringComparison.OrdinalIgnoreCase);
    }

    private sealed class CapturingLogger<T> : ILogger<T>
    {
        public List<(LogLevel Level, string Message, Exception? Exception)> Entries { get; } = [];

        public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(
            LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception?, string> formatter)
            => Entries.Add((logLevel, formatter(state, exception), exception));
    }
}
