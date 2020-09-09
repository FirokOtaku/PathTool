namespace PathTool
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCurrent = new System.Windows.Forms.TextBox();
            this.tbReg = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnRegedit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前启动路径";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "注册表注册路路径";
            // 
            // tbCurrent
            // 
            this.tbCurrent.Location = new System.Drawing.Point(146, 6);
            this.tbCurrent.Name = "tbCurrent";
            this.tbCurrent.ReadOnly = true;
            this.tbCurrent.Size = new System.Drawing.Size(769, 29);
            this.tbCurrent.TabIndex = 2;
            // 
            // tbReg
            // 
            this.tbReg.Location = new System.Drawing.Point(146, 41);
            this.tbReg.Name = "tbReg";
            this.tbReg.ReadOnly = true;
            this.tbReg.Size = new System.Drawing.Size(769, 29);
            this.tbReg.TabIndex = 3;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(921, 5);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(51, 65);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "注册";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Location = new System.Drawing.Point(978, 6);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(51, 65);
            this.btnAbout.TabIndex = 5;
            this.btnAbout.Text = "说明";
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // btnRegedit
            // 
            this.btnRegedit.Location = new System.Drawing.Point(1035, 6);
            this.btnRegedit.Name = "btnRegedit";
            this.btnRegedit.Size = new System.Drawing.Size(73, 65);
            this.btnRegedit.TabIndex = 6;
            this.btnRegedit.Text = "注册表编辑器";
            this.btnRegedit.UseVisualStyleBackColor = true;
            this.btnRegedit.Click += new System.EventHandler(this.btnRegedit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 76);
            this.Controls.Add(this.btnRegedit);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.btnReg);
            this.Controls.Add(this.tbReg);
            this.Controls.Add(this.tbCurrent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PathTool 1.0 by Firok";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbCurrent;
        private System.Windows.Forms.TextBox tbReg;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnRegedit;
    }
}

