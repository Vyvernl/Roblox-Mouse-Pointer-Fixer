using System;
using System.Diagnostics;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.Title = "Roblox Mouse Pointer Fixer";
        Console.WriteLine("Roblox Mouse Pointer fixer.");
        await Task.Delay(500);
        Console.WriteLine("Fixing your Mouse Pointer..");
        await Task.Delay(1000);
        string processName = "SynTPEnhService.exe";

        if (IsProcessRunning(processName))
        {
            if (TerminateProcess(processName))
            {
                Console.WriteLine($"Successful! We've fixed your Mouse Pointer, now the mouse shouldn't be moving around in Roblox.");
            }
            else
            {
                Console.WriteLine($"Program Failed.");
            }
        }
        else
        {
            Console.WriteLine($"🙃 Your mouse pointer has no issue.");
        }
        Console.ReadKey();
    }

    static bool IsProcessRunning(string processName)
    {
        Process[] processes = Process.GetProcessesByName(processName.Replace(".exe", ""));
        return processes.Length > 0;
    }

    static bool TerminateProcess(string processName)
    {
        try
        {
            Process[] processes = Process.GetProcessesByName(processName.Replace(".exe", ""));
            foreach (Process process in processes)
            {
                process.Kill();
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"We were unable to proceed with the procedure, Error Message: {ex.Message}");
            return false;
        }
    }
}
