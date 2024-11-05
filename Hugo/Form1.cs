using System;
using System.Diagnostics;
using System.IO;

namespace Hugo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        readonly ProcessStartInfo PSStartInfo = new ProcessStartInfo
        {
            FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // 指定要启动的文件名
            RedirectStandardInput = true, // 重定向标准输入
            RedirectStandardOutput = true, // 重定向标准输出
            UseShellExecute = false, // 不使用系统外壳程序启动
            CreateNoWindow = true // 不创建窗口
        };


        private void button1_Click(object sender, EventArgs e)
        {
            // 获取当前日期并格式化为 YYYYMMDD
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

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
                            streamWriter.WriteLine("Set-Location -Path 'D:\\Tools\\hugot\\BST'"); // 获取所有进程的信息
                            streamWriter.WriteLine($"hugo new content {fileName}.md --contentDir 'C:\\Users\\15641\\Documents\\Blog'"); // 获取所有服务的信息
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void buttonServer_Click(object sender, EventArgs e)
        {
            ProcessStartInfo PS_Window = new ProcessStartInfo
            {
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // 指定要启动的文件名
                RedirectStandardInput = true, // 重定向标准输入
                RedirectStandardOutput = false, // 重定向标准输出
                UseShellExecute = false, // 不使用系统外壳程序启动
                CreateNoWindow = false // 创建窗口
            };

            using (Process process = new Process { StartInfo = PS_Window })
            {
                try
                {
                    //buttonBuild.Enable
                    process.Start(); // 启动 PowerShell 进程

                    // 向 PowerShell 发送多条命令
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine("Set-Location -Path 'D:\\Tools\\hugot\\BST'"); // 获取所有进程的信息
                            streamWriter.WriteLine("hugo server --port 6138 --contentDir \"C:\\Users\\15641\\Documents\\Blog\""); // 获取所有服务的信息
                        }
                    }

                    await Task.Run(() => process.WaitForExit()); // 等待 PowerShell 进程退出

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                            streamWriter.WriteLine("Set-Location -Path 'D:\\Tools\\hugot\\BST'"); // 获取所有进程的信息
                            streamWriter.WriteLine($"hugo --contentDir 'C:\\Users\\15641\\Documents\\Blog'"); // 获取所有服务的信息
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
    }
}