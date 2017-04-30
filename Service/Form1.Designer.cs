namespace Service
{
    partial class Server
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnStartService = new System.Windows.Forms.Button();
            this.lblPname = new System.Windows.Forms.Label();
            this.lblPcount = new System.Windows.Forms.Label();
            this.lblIssue = new System.Windows.Forms.Label();
            this.txtPname = new System.Windows.Forms.TextBox();
            this.txtPcount = new System.Windows.Forms.TextBox();
            this.txtPIssue = new System.Windows.Forms.TextBox();
            this.txtPoint = new System.Windows.Forms.TextBox();
            this.lblPoint = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblLeftOver = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPissue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 160);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(420, 252);
            this.textBox1.TabIndex = 1;
            // 
            // btnStartService
            // 
            this.btnStartService.Location = new System.Drawing.Point(420, 491);
            this.btnStartService.Name = "btnStartService";
            this.btnStartService.Size = new System.Drawing.Size(75, 23);
            this.btnStartService.TabIndex = 2;
            this.btnStartService.Text = "启动服务";
            this.btnStartService.UseVisualStyleBackColor = true;
            this.btnStartService.Click += new System.EventHandler(this.btnStartService_Click);
            // 
            // lblPname
            // 
            this.lblPname.AutoSize = true;
            this.lblPname.Location = new System.Drawing.Point(34, 27);
            this.lblPname.Name = "lblPname";
            this.lblPname.Size = new System.Drawing.Size(59, 12);
            this.lblPname.TabIndex = 3;
            this.lblPname.Text = "产品名称:";
            // 
            // lblPcount
            // 
            this.lblPcount.AutoSize = true;
            this.lblPcount.Location = new System.Drawing.Point(34, 70);
            this.lblPcount.Name = "lblPcount";
            this.lblPcount.Size = new System.Drawing.Size(59, 12);
            this.lblPcount.TabIndex = 3;
            this.lblPcount.Text = "参与人次:";
            // 
            // lblIssue
            // 
            this.lblIssue.AutoSize = true;
            this.lblIssue.Location = new System.Drawing.Point(34, 111);
            this.lblIssue.Name = "lblIssue";
            this.lblIssue.Size = new System.Drawing.Size(83, 12);
            this.lblIssue.TabIndex = 3;
            this.lblIssue.Text = "开始夺宝期数:";
            // 
            // txtPname
            // 
            this.txtPname.Location = new System.Drawing.Point(130, 24);
            this.txtPname.Name = "txtPname";
            this.txtPname.Size = new System.Drawing.Size(100, 21);
            this.txtPname.TabIndex = 4;
            // 
            // txtPcount
            // 
            this.txtPcount.Location = new System.Drawing.Point(130, 61);
            this.txtPcount.Name = "txtPcount";
            this.txtPcount.Size = new System.Drawing.Size(100, 21);
            this.txtPcount.TabIndex = 4;
            // 
            // txtPIssue
            // 
            this.txtPIssue.Location = new System.Drawing.Point(130, 102);
            this.txtPIssue.Name = "txtPIssue";
            this.txtPIssue.Size = new System.Drawing.Size(100, 21);
            this.txtPIssue.TabIndex = 4;
            // 
            // txtPoint
            // 
            this.txtPoint.Location = new System.Drawing.Point(239, 491);
            this.txtPoint.Name = "txtPoint";
            this.txtPoint.Size = new System.Drawing.Size(100, 21);
            this.txtPoint.TabIndex = 5;
            // 
            // lblPoint
            // 
            this.lblPoint.AutoSize = true;
            this.lblPoint.Location = new System.Drawing.Point(178, 496);
            this.lblPoint.Name = "lblPoint";
            this.lblPoint.Size = new System.Drawing.Size(47, 12);
            this.lblPoint.TabIndex = 6;
            this.lblPoint.Text = "端口号:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "还剩号码数量:";
            // 
            // lblLeftOver
            // 
            this.lblLeftOver.AutoSize = true;
            this.lblLeftOver.Location = new System.Drawing.Point(415, 70);
            this.lblLeftOver.Name = "lblLeftOver";
            this.lblLeftOver.Size = new System.Drawing.Size(17, 12);
            this.lblLeftOver.TabIndex = 9;
            this.lblLeftOver.Text = "10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "现在进行夺宝期数:";
            // 
            // lblPissue
            // 
            this.lblPissue.AutoSize = true;
            this.lblPissue.Location = new System.Drawing.Point(415, 27);
            this.lblPissue.Name = "lblPissue";
            this.lblPissue.Size = new System.Drawing.Size(11, 12);
            this.lblPissue.TabIndex = 11;
            this.lblPissue.Text = "0";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 542);
            this.Controls.Add(this.lblPissue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLeftOver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPoint);
            this.Controls.Add(this.txtPoint);
            this.Controls.Add(this.txtPIssue);
            this.Controls.Add(this.txtPcount);
            this.Controls.Add(this.txtPname);
            this.Controls.Add(this.lblIssue);
            this.Controls.Add(this.lblPcount);
            this.Controls.Add(this.lblPname);
            this.Controls.Add(this.btnStartService);
            this.Controls.Add(this.textBox1);
            this.Name = "Server";
            this.Text = "服务器端";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStartService;
        private System.Windows.Forms.Label lblPname;
        private System.Windows.Forms.Label lblPcount;
        private System.Windows.Forms.Label lblIssue;
        private System.Windows.Forms.TextBox txtPname;
        private System.Windows.Forms.TextBox txtPcount;
        private System.Windows.Forms.TextBox txtPIssue;
        private System.Windows.Forms.TextBox txtPoint;
        private System.Windows.Forms.Label lblPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblLeftOver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblPissue;

    }
}

