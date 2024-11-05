using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    }
}
