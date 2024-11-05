namespace Hugo
{
    partial class FormGit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonCommit = new System.Windows.Forms.Button();
            this.buttonPush = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 158);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(241, 85);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(134, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(522, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "在进行Git操作前，一定记得先生成静态文件";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(211, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(368, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "不要把localhost发上去！！！";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAdd.Location = new System.Drawing.Point(147, 291);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(111, 56);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "添加全部";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonCommit
            // 
            this.buttonCommit.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCommit.Location = new System.Drawing.Point(305, 291);
            this.buttonCommit.Name = "buttonCommit";
            this.buttonCommit.Size = new System.Drawing.Size(111, 56);
            this.buttonCommit.TabIndex = 2;
            this.buttonCommit.Text = "提交";
            this.buttonCommit.UseVisualStyleBackColor = true;
            this.buttonCommit.Click += new System.EventHandler(this.buttonCommit_Click);
            // 
            // buttonPush
            // 
            this.buttonPush.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonPush.Location = new System.Drawing.Point(461, 291);
            this.buttonPush.Name = "buttonPush";
            this.buttonPush.Size = new System.Drawing.Size(111, 56);
            this.buttonPush.TabIndex = 2;
            this.buttonPush.Text = "推送";
            this.buttonPush.UseVisualStyleBackColor = true;
            this.buttonPush.Click += new System.EventHandler(this.buttonPush_Click);
            // 
            // FormGit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonPush);
            this.Controls.Add(this.buttonCommit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "FormGit";
            this.Text = "Git";
            this.Load += new System.EventHandler(this.FormGit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button buttonAdd;
        private Button buttonCommit;
        private Button buttonPush;
    }
}