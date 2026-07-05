using asERP.Server.Infrastructure.Configuration;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace asERP.Server.Tests;

public class ExternalSettingsTests : IDisposable
{
    private readonly string _tempDir;

    public ExternalSettingsTests()
    {
        _tempDir = Path.Combine(Path.GetTempPath(), "asERP-extsettings-tests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_tempDir);
    }

    public void Dispose()
    {
        try
        {
            Directory.Delete(_tempDir, recursive: true);
        }
        catch (IOException)
        {
            // Best-effort cleanup of temp files.
        }
    }

    private string WriteJson(string name, string content)
    {
        var path = Path.Combine(_tempDir, name);
        File.WriteAllText(path, content);
        return path;
    }

    [Fact]
    public void AddFile_ExternalOverridesAppsettings_ButEnvStyleSourcesStillWin()
    {
        var appsettings = WriteJson("appsettings.json",
            """{ "Key1": "appsettings", "Key2": "appsettings" }""");
        var external = WriteJson("settings.json",
            """{ "Key1": "external", "Key2": "external", "Key3": "external" }""");

        var builder = new ConfigurationBuilder();
        builder.AddJsonFile(appsettings);
        // Stand-in for the environment-variable source that Program.cs adds after all JSON files.
        builder.AddInMemoryCollection(new Dictionary<string, string?> { ["Key2"] = "environment" });

        ExternalSettings.AddFile(builder, external);
        var configuration = builder.Build();

        Assert.Equal("external", configuration["Key1"]);
        Assert.Equal("environment", configuration["Key2"]);
        Assert.Equal("external", configuration["Key3"]);
    }

    [Fact]
    public void AddFile_WithoutJsonSources_AppendsAtEnd()
    {
        var external = WriteJson("settings.json", """{ "Key1": "external" }""");

        var builder = new ConfigurationBuilder();
        ExternalSettings.AddFile(builder, external);
        var configuration = builder.Build();

        Assert.Equal("external", configuration["Key1"]);
    }

    [Fact]
    public void AddTo_MissingFile_IsIgnored()
    {
        // No ASERP_SETTINGS_PATH is set in the test environment and the ProgramData
        // fallback is disabled — AddTo must be a no-op.
        var builder = new ConfigurationBuilder();
        ExternalSettings.AddTo(builder, allowProgramDataFallback: false);

        Assert.Empty(builder.Sources);
    }
}
