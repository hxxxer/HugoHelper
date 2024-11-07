using System;
using System.Diagnostics;
using System.Configuration;
using System.IO;
using System.CodeDom.Compiler;

namespace Hugo
{
    public partial class Form1 : Form
    {
        private FormGit? GitWindow;
        private FormCreateContent? CreateContentWindow;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppConfig.Initialize();

            if (string.IsNullOrWhiteSpace(AppConfig.HugoRootDir))
            {
                FormError formError = new FormError();
                formError.ShowDialog();

                Close();
            }

        }

        readonly ProcessStartInfo PSStartInfo = new ProcessStartInfo
        {
            FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // 指定要启动的文件名
            RedirectStandardInput = true, // 重定向标准输入
            RedirectStandardOutput = true, // 重定向标准输出
            UseShellExecute = false, // 不使用系统外壳程序启动
            CreateNoWindow = true // 不创建窗口
        };

        private void buttonCreateContent_Click(object sender, EventArgs e)
        {

            if (CreateContentWindow is null || CreateContentWindow.IsDisposed)
            {
                CreateContentWindow = new FormCreateContent();
                CreateContentWindow.FormClosed += (s, args) => CreateContentWindow = null; // 处理新窗口关闭事件
                CreateContentWindow.Show();
            }
            else
            {
                CreateContentWindow.Activate();
            }
        }

        private async void buttonServer_Click(object sender, EventArgs e)
        {
            buttonBuild.Enabled = false;

            ProcessStartInfo PS_Window = new ProcessStartInfo
            {
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // 指定要启动的文件名
                RedirectStandardInput = true, // 重定向标准输入
                RedirectStandardOutput = false,
                UseShellExecute = false, // 不使用系统外壳程序启动
                CreateNoWindow = false // 创建窗口
            };

            using (Process process = new Process { StartInfo = PS_Window })
            {
                try
                {

                    process.Start(); // 启动 PowerShell 进程

                    // 向 PowerShell 发送多条命令
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine($"Set-Location {AppConfig.HugoRootDir}");
                            streamWriter.WriteLine($"hugo server {AppConfig.Port} {AppConfig.BlogRootDir} {AppConfig.ThemesDir}");
                        }
                    }

                    await Task.Run(() => process.WaitForExit()); // 等待 PowerShell 进程退出

                }
               
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }

            buttonBuild.Enabled = true;
        }

        private void buttonBuild_Click(object sender, EventArgs e)
        {
            using (Process process = new Process { StartInfo = PSStartInfo })
            {
                try
                {
                    process.Start(); // 启动 PowerShell 进程

                    // 向 PowerShell 发送多条命令
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine($"Set-Location {AppConfig.HugoRootDir}");
                            streamWriter.WriteLine($"hugo {AppConfig.BlogRootDir} {AppConfig.ThemesDir}");
                        }
                    }

                    // 读取 PowerShell 命令的输出
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit(); // 等待 PowerShell 进程退出

                    // 显示输出结果（可选）
                    MessageBox.Show(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void buttonGit_Click(object sender, EventArgs e)
        {
            if (GitWindow is null || GitWindow.IsDisposed)
            {
                GitWindow = new FormGit();
                GitWindow.FormClosed += (s, args) => GitWindow = null; // 处理新窗口关闭事件
                GitWindow.Show();
            }
            else
            {
                GitWindow.Activate();
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            Opacity= 0.91;

            using (Process process = new Process { StartInfo = PSStartInfo })
            {
                try
                {
                    process.Start(); // 启动 PowerShell 进程

                    // 向 PowerShell 发送多条命令
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine($"Set-Location {AppConfig.HugoRootDir}"); // 获取所有进程的信息
                            streamWriter.WriteLine($"hugo --cleanDestinationDir {AppConfig.BlogRootDir} {AppConfig.ThemesDir}"); // 获取所有服务的信息
                        }
                    }

                    // 读取 PowerShell 命令的输出
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit(); // 等待 PowerShell 进程退出

                    // 显示输出结果（可选）
                    MessageBox.Show(output);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }

                Opacity = 1;
            }
        }
    }
}