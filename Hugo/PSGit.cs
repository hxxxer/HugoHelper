using System;
using System.Diagnostics;

namespace Hugo
{
    public class PSGit
    {
        public void Initialize()
        {
            string script = $"Set-Location {AppConfig.HugoRootDir};cd public";

            ProcessStartInfo PSGitInfo = new ProcessStartInfo
            {
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe",
                Arguments = $"-NoExit -Command {script}",
                RedirectStandardOutput = false, // 重定向标准输出
                UseShellExecute = false, // 不使用系统外壳程序启动
                CreateNoWindow = false // 创建窗口
            };

            using (var PSGitProcess = new Process { StartInfo = PSGitInfo })
            {
                try
                {
                    PSGitProcess.Start();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}
