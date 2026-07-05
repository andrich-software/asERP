namespace asERP.Server.Tray;

internal static class Program
{
    // Also referenced by the installer's AppMutex directive — keep in sync with the .iss file.
    internal const string MutexName = "Global\\asERP.Server.Tray.SingleInstance";

    [STAThread]
    private static void Main()
    {
        using var mutex = new Mutex(initiallyOwned: true, MutexName, out var createdNew);
        if (!createdNew)
        {
            // Already running — tray icons have no meaningful window to activate.
            return;
        }

        ApplicationConfiguration.Initialize();
        Application.Run(new TrayApplicationContext());
    }
}
