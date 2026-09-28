using System.ComponentModel;
using System.Diagnostics;
using System.ServiceProcess;

namespace TechZone.Data.Services;

public static class DatabaseService
{
    private const string ServiceName = "MSSQLSERVER";

    public static async Task<bool> EnsureRunningAsync()
    {
        try
        {
            using var service = new ServiceController(ServiceName);

            service.Refresh();

            if (service.Status == ServiceControllerStatus.Running)
                return true;

            if (service.Status == ServiceControllerStatus.StartPending)
                return await WaitForRunningAsync(service);

            if (!await RequestElevationAsync())
                return false;

            return await WaitForRunningAsync(service);
        }
        catch
        {
            return false;
        }
    }

    private static async Task<bool> RequestElevationAsync()
    {
        try
        {
            using var process = new Process();

            process.StartInfo = new ProcessStartInfo
            {
                FileName = "net.exe",
                Arguments = $"start \"{ServiceName}\"",
                Verb = "runas",
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            process.Start();

            await process.WaitForExitAsync();

            return true;
        }
        catch (Win32Exception)
        {
            return false;
        }
        catch
        {
            return false;
        }
    }

    private static async Task<bool> WaitForRunningAsync(
        ServiceController service)
    {
        const int maxAttempts = 60;

        for (int attempt = 0; attempt < maxAttempts; attempt++)
        {
            try
            {
                service.Refresh();

                if (service.Status ==
                    ServiceControllerStatus.Running)
                {
                    return true;
                }

                if (service.Status ==
                    ServiceControllerStatus.Stopped &&
                    attempt > 5)
                {
                    return false;
                }
            }
            catch
            {
            }

            await Task.Delay(500);
        }

        service.Refresh();

        return service.Status ==
               ServiceControllerStatus.Running;
    }
}