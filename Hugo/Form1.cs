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
            FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // ָ��Ҫ�������ļ���
            RedirectStandardInput = true, // �ض����׼����
            RedirectStandardOutput = true, // �ض����׼���
            UseShellExecute = false, // ��ʹ��ϵͳ��ǳ�������
            CreateNoWindow = true // ����������
        };


        private void button1_Click(object sender, EventArgs e)
        {
            // ��ȡ��ǰ���ڲ���ʽ��Ϊ YYYYMMDD
            string fileName = DateTime.Now.ToString("yyyyMMddHHmmss");

            using (Process process = new Process { StartInfo = PSStartInfo })
            {
                try
                {
                    process.Start(); // ���� PowerShell ����

                    // �� PowerShell ���Ͷ�������
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine("Set-Location -Path 'D:\\Tools\\hugot\\BST'"); // ��ȡ���н��̵���Ϣ
                            streamWriter.WriteLine($"hugo new content {fileName}.md --contentDir 'C:\\Users\\15641\\Documents\\Blog'"); // ��ȡ���з������Ϣ
                        }
                    }

                    // ��ȡ PowerShell ��������
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit(); // �ȴ� PowerShell �����˳�

                    // ��ʾ����������ѡ��
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
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // ָ��Ҫ�������ļ���
                RedirectStandardInput = true, // �ض����׼����
                RedirectStandardOutput = false, // �ض����׼���
                UseShellExecute = false, // ��ʹ��ϵͳ��ǳ�������
                CreateNoWindow = false // ��������
            };

            using (Process process = new Process { StartInfo = PS_Window })
            {
                try
                {
                    //buttonBuild.Enable
                    process.Start(); // ���� PowerShell ����

                    // �� PowerShell ���Ͷ�������
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine("Set-Location -Path 'D:\\Tools\\hugot\\BST'"); // ��ȡ���н��̵���Ϣ
                            streamWriter.WriteLine("hugo server --port 6138 --contentDir \"C:\\Users\\15641\\Documents\\Blog\""); // ��ȡ���з������Ϣ
                        }
                    }

                    await Task.Run(() => process.WaitForExit()); // �ȴ� PowerShell �����˳�

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
                    process.Start(); // ���� PowerShell ����

                    // �� PowerShell ���Ͷ�������
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine("Set-Location -Path 'D:\\Tools\\hugot\\BST'"); // ��ȡ���н��̵���Ϣ
                            streamWriter.WriteLine($"hugo --contentDir 'C:\\Users\\15641\\Documents\\Blog'"); // ��ȡ���з������Ϣ
                        }
                    }

                    // ��ȡ PowerShell ��������
                    string output = process.StandardOutput.ReadToEnd();
                    process.WaitForExit(); // �ȴ� PowerShell �����˳�

                    // ��ʾ����������ѡ��
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