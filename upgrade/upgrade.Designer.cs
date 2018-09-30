namespace upgrade
{
    partial class upgrade
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
            this.FileButton = new System.Windows.Forms.Button();
            this.FilePath = new System.Windows.Forms.TextBox();
            this.FilePushButton = new System.Windows.Forms.Button();
            this.IPADDR = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PORT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CliendID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.DeviceID = new System.Windows.Forms.TextBox();
            this.SubMsg = new System.Windows.Forms.TextBox();
            this.SubTopic = new System.Windows.Forms.Label();
            this.Sub = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Times = new System.Windows.Forms.TextBox();
            this.UpgradeButton = new System.Windows.Forms.Button();
            this.UpgradeTimes = new System.Windows.Forms.Label();
            this.PubTopic = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // FileButton
            // 
            this.FileButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileButton.Location = new System.Drawing.Point(25, 210);
            this.FileButton.Name = "FileButton";
            this.FileButton.Size = new System.Drawing.Size(164, 30);
            this.FileButton.TabIndex = 1;
            this.FileButton.Text = "File";
            this.FileButton.UseVisualStyleBackColor = true;
            this.FileButton.Click += new System.EventHandler(this.FileButton_Click);
            // 
            // FilePath
            // 
            this.FilePath.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath.Location = new System.Drawing.Point(198, 213);
            this.FilePath.Name = "FilePath";
            this.FilePath.Size = new System.Drawing.Size(608, 26);
            this.FilePath.TabIndex = 2;
            this.FilePath.TextChanged += new System.EventHandler(this.FilePath_TextChanged);
            // 
            // FilePushButton
            // 
            this.FilePushButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePushButton.Location = new System.Drawing.Point(25, 249);
            this.FilePushButton.Name = "FilePushButton";
            this.FilePushButton.Size = new System.Drawing.Size(164, 31);
            this.FilePushButton.TabIndex = 3;
            this.FilePushButton.Text = "FilePush";
            this.FilePushButton.UseVisualStyleBackColor = true;
            this.FilePushButton.Click += new System.EventHandler(this.FilePushButton_Click);
            // 
            // IPADDR
            // 
            this.IPADDR.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IPADDR.Location = new System.Drawing.Point(26, 12);
            this.IPADDR.Name = "IPADDR";
            this.IPADDR.Size = new System.Drawing.Size(164, 24);
            this.IPADDR.TabIndex = 4;
            this.IPADDR.Text = "39.108.231.83";
            this.IPADDR.TextChanged += new System.EventHandler(this.IPADDR_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "服务器";
            // 
            // PORT
            // 
            this.PORT.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PORT.Location = new System.Drawing.Point(26, 42);
            this.PORT.Name = "PORT";
            this.PORT.Size = new System.Drawing.Size(164, 24);
            this.PORT.TabIndex = 6;
            this.PORT.Text = "1885";
            this.PORT.TextChanged += new System.EventHandler(this.PORT_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "端口号";
            // 
            // CliendID
            // 
            this.CliendID.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CliendID.Location = new System.Drawing.Point(26, 72);
            this.CliendID.Name = "CliendID";
            this.CliendID.Size = new System.Drawing.Size(164, 24);
            this.CliendID.TabIndex = 8;
            this.CliendID.TextChanged += new System.EventHandler(this.ClientID_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(196, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "ClientID";
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(25, 170);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(164, 33);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.Text = "connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // DeviceID
            // 
            this.DeviceID.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeviceID.Location = new System.Drawing.Point(198, 293);
            this.DeviceID.Name = "DeviceID";
            this.DeviceID.Size = new System.Drawing.Size(124, 26);
            this.DeviceID.TabIndex = 11;
            this.DeviceID.Text = "0015832A6F2C";
            this.DeviceID.TextChanged += new System.EventHandler(this.DeviceID_TextChanged);
            // 
            // SubMsg
            // 
            this.SubMsg.Location = new System.Drawing.Point(26, 353);
            this.SubMsg.Multiline = true;
            this.SubMsg.Name = "SubMsg";
            this.SubMsg.Size = new System.Drawing.Size(781, 291);
            this.SubMsg.TabIndex = 12;
            // 
            // SubTopic
            // 
            this.SubTopic.AutoSize = true;
            this.SubTopic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SubTopic.Location = new System.Drawing.Point(22, 331);
            this.SubTopic.Name = "SubTopic";
            this.SubTopic.Size = new System.Drawing.Size(81, 19);
            this.SubTopic.TabIndex = 13;
            this.SubTopic.Text = "SubTopic";
            // 
            // Sub
            // 
            this.Sub.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Sub.Location = new System.Drawing.Point(26, 102);
            this.Sub.Name = "Sub";
            this.Sub.Size = new System.Drawing.Size(164, 24);
            this.Sub.TabIndex = 14;
            this.Sub.Text = "UP";
            this.Sub.TextChanged += new System.EventHandler(this.Sub_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "SubTopic";
            // 
            // Times
            // 
            this.Times.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Times.Location = new System.Drawing.Point(26, 135);
            this.Times.Name = "Times";
            this.Times.Size = new System.Drawing.Size(163, 26);
            this.Times.TabIndex = 16;
            this.Times.Text = "0";
            // 
            // UpgradeButton
            // 
            this.UpgradeButton.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpgradeButton.Location = new System.Drawing.Point(25, 288);
            this.UpgradeButton.Name = "UpgradeButton";
            this.UpgradeButton.Size = new System.Drawing.Size(164, 31);
            this.UpgradeButton.TabIndex = 17;
            this.UpgradeButton.Text = "upgrade";
            this.UpgradeButton.UseVisualStyleBackColor = true;
            this.UpgradeButton.Click += new System.EventHandler(this.UpgradeButton_Click);
            // 
            // UpgradeTimes
            // 
            this.UpgradeTimes.AutoSize = true;
            this.UpgradeTimes.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UpgradeTimes.Location = new System.Drawing.Point(195, 140);
            this.UpgradeTimes.Name = "UpgradeTimes";
            this.UpgradeTimes.Size = new System.Drawing.Size(104, 17);
            this.UpgradeTimes.TabIndex = 18;
            this.UpgradeTimes.Text = "UpgradeTimes";
            // 
            // PubTopic
            // 
            this.PubTopic.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PubTopic.Location = new System.Drawing.Point(198, 254);
            this.PubTopic.Name = "PubTopic";
            this.PubTopic.Size = new System.Drawing.Size(124, 26);
            this.PubTopic.TabIndex = 19;
            this.PubTopic.Text = "vs1801";
            // 
            // upgrade
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 669);
            this.Controls.Add(this.PubTopic);
            this.Controls.Add(this.UpgradeTimes);
            this.Controls.Add(this.UpgradeButton);
            this.Controls.Add(this.Times);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Sub);
            this.Controls.Add(this.SubTopic);
            this.Controls.Add(this.SubMsg);
            this.Controls.Add(this.DeviceID);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CliendID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PORT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.IPADDR);
            this.Controls.Add(this.FilePushButton);
            this.Controls.Add(this.FilePath);
            this.Controls.Add(this.FileButton);
            this.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "upgrade";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "stm32 upgrade";
            this.Load += new System.EventHandler(this.upgrade_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FileButton;
        private System.Windows.Forms.TextBox FilePath;
        private System.Windows.Forms.Button FilePushButton;
        private System.Windows.Forms.TextBox IPADDR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PORT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CliendID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox DeviceID;
        private System.Windows.Forms.TextBox SubMsg;
        private System.Windows.Forms.Label SubTopic;
        private System.Windows.Forms.TextBox Sub;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Times;
        private System.Windows.Forms.Button UpgradeButton;
        private System.Windows.Forms.Label UpgradeTimes;
        private System.Windows.Forms.TextBox PubTopic;
    }
}

