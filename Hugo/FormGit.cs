using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hugo
{
    public partial class FormGit : Form
    {
        public FormGit()
        {
            InitializeComponent();
        }

        private void FormGit_Load(object sender, EventArgs e)
        {
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

        private void buttonCommit_Click(object sender, EventArgs e)
        {

        }

        private void buttonPush_Click(object sender, EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {

        }

        private void buttonGitManual_Click(object sender, EventArgs e)
        {
            string script = $"Set-Location {AppConfig.HugoRootDir}";

            ProcessStartInfo PSGitInfo = new ProcessStartInfo
            {
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // 指定要启动的文件名
                Arguments = $"-Command \"{script}\";read-host",
                RedirectStandardInput = true, // 重定向标准输入
                RedirectStandardOutput = false, // 重定向标准输出
                UseShellExecute = true, // 不使用系统外壳程序启动
                CreateNoWindow = false // 不创建窗口
            };

            using (Process process = new Process { StartInfo = PSGitInfo })
            {
                try
                {
                    process.Start();

                    //process.WaitForExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


        }
    }
}
