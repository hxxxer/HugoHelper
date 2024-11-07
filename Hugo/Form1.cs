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
            FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // ָ��Ҫ�������ļ���
            RedirectStandardInput = true, // �ض����׼����
            RedirectStandardOutput = true, // �ض����׼���
            UseShellExecute = false, // ��ʹ��ϵͳ��ǳ�������
            CreateNoWindow = true // ����������
        };

        private void buttonCreateContent_Click(object sender, EventArgs e)
        {

            if (CreateContentWindow is null || CreateContentWindow.IsDisposed)
            {
                CreateContentWindow = new FormCreateContent();
                CreateContentWindow.FormClosed += (s, args) => CreateContentWindow = null; // �����´��ڹر��¼�
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
                FileName = "C:\\Program Files\\PowerShell\\7\\pwsh.exe", // ָ��Ҫ�������ļ���
                RedirectStandardInput = true, // �ض����׼����
                RedirectStandardOutput = false,
                UseShellExecute = false, // ��ʹ��ϵͳ��ǳ�������
                CreateNoWindow = false // ��������
            };

            using (Process process = new Process { StartInfo = PS_Window })
            {
                try
                {

                    process.Start(); // ���� PowerShell ����

                    // �� PowerShell ���Ͷ�������
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine($"Set-Location {AppConfig.HugoRootDir}");
                            streamWriter.WriteLine($"hugo server {AppConfig.Port} {AppConfig.BlogRootDir} {AppConfig.ThemesDir}");
                        }
                    }

                    await Task.Run(() => process.WaitForExit()); // �ȴ� PowerShell �����˳�

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
                    process.Start(); // ���� PowerShell ����

                    // �� PowerShell ���Ͷ�������
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine($"Set-Location {AppConfig.HugoRootDir}");
                            streamWriter.WriteLine($"hugo {AppConfig.BlogRootDir} {AppConfig.ThemesDir}");
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

        private void buttonGit_Click(object sender, EventArgs e)
        {
            if (GitWindow is null || GitWindow.IsDisposed)
            {
                GitWindow = new FormGit();
                GitWindow.FormClosed += (s, args) => GitWindow = null; // �����´��ڹر��¼�
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
                    process.Start(); // ���� PowerShell ����

                    // �� PowerShell ���Ͷ�������
                    using (StreamWriter streamWriter = process.StandardInput)
                    {
                        if (streamWriter.BaseStream.CanWrite)
                        {
                            streamWriter.WriteLine($"Set-Location {AppConfig.HugoRootDir}"); // ��ȡ���н��̵���Ϣ
                            streamWriter.WriteLine($"hugo --cleanDestinationDir {AppConfig.BlogRootDir} {AppConfig.ThemesDir}"); // ��ȡ���з������Ϣ
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

                Opacity = 1;
            }
        }
    }
}