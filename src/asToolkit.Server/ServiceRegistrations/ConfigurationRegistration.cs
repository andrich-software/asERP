using System.Reflection;

namespace asToolkit.Server.ServiceRegistrations;

public static class ConfigurationRegistration
{
    public static string CurrentPath = Path.GetDirectoryName(Assembly.GetEntryAssembly()!.Location)!;
    public static IConfiguration AppSetting { get; }

    static ConfigurationRegistration()
    {
        AppSetting = new ConfigurationBuilder()
           .SetBasePath(CurrentPath)
           .AddJsonFile("Settings/appsettings.json")
           .Build();
    }
}