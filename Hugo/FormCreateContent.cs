using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Windows.Forms.Design;

namespace Hugo
{
    public partial class FormCreateContent : Form
    {
        public FormCreateContent()
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

        private void FormCreateContent_Load(object sender, EventArgs e)
        {
            TitlePreinput();
        }

        private void TitlePreinput()
        {
            // 获取当前日期并格式化为 YYYYMMDD
            string preinputName = DateTime.Now.ToString("yyyyMMddHHmmss");

            TitleInput.Text = preinputName;
        }

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            string fileName;

            if (string.IsNullOrWhiteSpace(TitleInput.Text))
            {
                // 获取当前日期并格式化为 YYYYMMDD
                fileName = DateTime.Now.ToString("yyyyMMddHHmmss");
            }
            else
            {
                fileName = TitleInput.Text;
            }

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
                            streamWriter.WriteLine($"hugo new content {fileName}.md {AppConfig.BlogRootDir}");
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

            TitlePreinput();

        }

        private void TitleInput_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
