namespace Hugo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.buttonCreateContent = new System.Windows.Forms.Button();
            this.buttonServer = new System.Windows.Forms.Button();
            this.buttonBuild = new System.Windows.Forms.Button();
            this.buttonGit = new System.Windows.Forms.Button();
            this.buttonClean = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCreateContent
            // 
            this.buttonCreateContent.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateContent.Location = new System.Drawing.Point(47, 30);
            this.buttonCreateContent.Name = "buttonCreateContent";
            this.buttonCreateContent.Size = new System.Drawing.Size(296, 64);
            this.buttonCreateContent.TabIndex = 0;
            this.buttonCreateContent.Text = "创建新Blog";
            this.buttonCreateContent.UseVisualStyleBackColor = true;
            this.buttonCreateContent.Click += new System.EventHandler(this.buttonCreateContent_Click);
            // 
            // buttonServer
            // 
            this.buttonServer.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonServer.Location = new System.Drawing.Point(47, 120);
            this.buttonServer.Name = "buttonServer";
            this.buttonServer.Size = new System.Drawing.Size(296, 64);
            this.buttonServer.TabIndex = 1;
            this.buttonServer.Text = "开启Server";
            this.buttonServer.UseVisualStyleBackColor = true;
            this.buttonServer.Click += new System.EventHandler(this.buttonServer_Click);
            // 
            // buttonBuild
            // 
            this.buttonBuild.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonBuild.Location = new System.Drawing.Point(47, 210);
            this.buttonBuild.Name = "buttonBuild";
            this.buttonBuild.Size = new System.Drawing.Size(296, 64);
            this.buttonBuild.TabIndex = 3;
            this.buttonBuild.Text = "构建网页";
            this.buttonBuild.UseVisualStyleBackColor = true;
            this.buttonBuild.Click += new System.EventHandler(this.buttonBuild_Click);
            // 
            // buttonGit
            // 
            this.buttonGit.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonGit.Location = new System.Drawing.Point(47, 390);
            this.buttonGit.Name = "buttonGit";
            this.buttonGit.Size = new System.Drawing.Size(296, 64);
            this.buttonGit.TabIndex = 4;
            this.buttonGit.Text = "Git";
            this.buttonGit.UseVisualStyleBackColor = true;
            this.buttonGit.Click += new System.EventHandler(this.buttonGit_Click);
            // 
            // buttonClean
            // 
            this.buttonClean.Font = new System.Drawing.Font("Microsoft YaHei UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonClean.Location = new System.Drawing.Point(47, 300);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(296, 64);
            this.buttonClean.TabIndex = 5;
            this.buttonClean.Text = "清理垃圾";
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 490);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.buttonGit);
            this.Controls.Add(this.buttonBuild);
            this.Controls.Add(this.buttonServer);
            this.Controls.Add(this.buttonCreateContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Hugo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonCreateContent;
        private Button buttonServer;
        private Button buttonBuild;
        private Button buttonGit;
        private Button buttonClean;
    }
}