using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;

namespace asERP.Server.Tray.Services;

/// <summary>
/// Controls the asERP Windows service. Direct ServiceController calls work without
/// elevation because the installer loosens the service's DACL (Authenticated Users may
/// start/stop this one service); on access-denied the fallback shells an elevated
/// sc.exe, costing one UAC prompt per action.
/// </summary>
internal sealed class ServiceControlService(string serviceName)
{
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(60);

    /// <summary>Returns null when the service is not installed.</summary>
    public ServiceControllerStatus? QueryStatus()
    {
        try
        {
            using var controller = new ServiceController(serviceName);
            return controller.Status;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    public Task StartAsync() => Task.Run(() =>
    {
        using var controller = new ServiceController(serviceName);
        if (controller.Status is ServiceControllerStatus.Running)
        {
            return;
        }

        try
        {
            controller.Start();
        }
        catch (InvalidOperationException ex) when (IsAccessDenied(ex))
        {
            RunElevatedScCommand($"start \"{serviceName}\"");
        }
        controller.WaitForStatus(ServiceControllerStatus.Running, DefaultTimeout);
    });

    public Task StopAsync() => Task.Run(() =>
    {
        using var controller = new ServiceController(serviceName);
        if (controller.Status is ServiceControllerStatus.Stopped)
        {
            return;
        }

        try
        {
            controller.Stop();
        }
        catch (InvalidOperationException ex) when (IsAccessDenied(ex))
        {
            RunElevatedScCommand($"stop \"{serviceName}\"");
        }
        controller.WaitForStatus(ServiceControllerStatus.Stopped, DefaultTimeout);
    });

    public async Task RestartAsync()
    {
        await StopAsync();
        await StartAsync();
    }

    private static bool IsAccessDenied(Exception exception) =>
        exception.InnerException is Win32Exception { NativeErrorCode: 5 };

    private static void RunElevatedScCommand(string arguments)
    {
        var startInfo = new ProcessStartInfo("sc.exe", arguments)
        {
            Verb = "runas",
            UseShellExecute = true,
            WindowStyle = ProcessWindowStyle.Hidden
        };

        try
        {
            using var process = Process.Start(startInfo)
                ?? throw new InvalidOperationException("Failed to start sc.exe.");
            process.WaitForExit();
        }
        catch (Win32Exception ex) when (ex.NativeErrorCode == 1223)
        {
            throw new OperationCanceledException("The elevation prompt was cancelled.", ex);
        }
    }
}
