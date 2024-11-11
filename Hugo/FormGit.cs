using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Diagnostics;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

namespace Hugo
{
    public partial class FormGit : Form
    {

        public FormGit()
        {
            InitializeComponent();
        }

        private readonly ProcessStartInfo PSGitInfo = new()
        {
            FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe",
            Arguments = $"-NoExit -Command Set-Location {AppConfig.HugoRootDir};cd public",
            RedirectStandardInput = true, // 重定向标准输入
            RedirectStandardOutput = false, // 重定向标准输出
            UseShellExecute = false, // 不使用系统外壳程序启动
            CreateNoWindow = false // 创建窗口
        };

        private void FormGit_Load(object sender, EventArgs e)
        {
            textBox1.Text = "1Blog";
            // 初始化按钮状态
            UpdateButtonState();
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // 更新按钮状态
            UpdateButtonState();
        }

        private void UpdateButtonState()
        {
            // 根据文本框的内容更新按钮状态
            buttonCommit.Enabled = !string.IsNullOrWhiteSpace(textBox1.Text);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            using (Process PSGitProcess = new () { StartInfo = PSGitInfo })
            {
                try
                {
                    PSGitProcess.Start();

                    using (StreamWriter sw = PSGitProcess.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("git add .");
                            sw.WriteLine("Start-Sleep -Seconds 100000");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void buttonCommit_Click(object sender, EventArgs e)
        {
            string Commit = textBox1.Text;

            using (Process PSGitProcess = new() { StartInfo = PSGitInfo })
            {
                try
                {
                    PSGitProcess.Start();

                    using (StreamWriter sw = PSGitProcess.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine($"git commit -m '{Commit}'");
                            sw.WriteLine("Start-Sleep -Seconds 100000");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void buttonPush_Click(object sender, EventArgs e)
        {
            using (Process PSGitProcess = new() { StartInfo = PSGitInfo })
            {
                try
                {
                    PSGitProcess.Start();

                    using (StreamWriter sw = PSGitProcess.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine("git push");
                            sw.WriteLine("Start-Sleep -Seconds 100000");
                        }
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }

        private void buttonGitManual_Click(object sender, EventArgs e)
        {
            string script = $"Set-Location {AppConfig.HugoRootDir};cd public";

            ProcessStartInfo PSGitInfo = new ProcessStartInfo
            {
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe",
                Arguments = $"-NoExit -Command {script}",
                RedirectStandardOutput = false, // 重定向标准输出
                UseShellExecute = false, // 不使用系统外壳程序启动
                CreateNoWindow = false // 不创建窗口
            };

            using (Process process = new Process { StartInfo = PSGitInfo })
            {
                try
                {
                    process.Start();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


        }
    }
}
