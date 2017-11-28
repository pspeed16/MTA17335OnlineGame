namespace Server
{
    partial class Form1
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
            this.ipLabel = new System.Windows.Forms.Label();
            this.ipLabel2 = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portLabel2 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.threadReceiver = new System.ComponentModel.BackgroundWorker();
            this.threadSender = new System.ComponentModel.BackgroundWorker();
            this.textChat = new System.Windows.Forms.TextBox();
            this.textMessage = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.clientIP = new System.Windows.Forms.TextBox();
            this.clientPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel.Location = new System.Drawing.Point(12, 31);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(170, 24);
            this.ipLabel.TabIndex = 0;
            this.ipLabel.Text = "Current IP address:";
            // 
            // ipLabel2
            // 
            this.ipLabel2.AutoSize = true;
            this.ipLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLabel2.Location = new System.Drawing.Point(207, 31);
            this.ipLabel2.Name = "ipLabel2";
            this.ipLabel2.Size = new System.Drawing.Size(98, 24);
            this.ipLabel2.TabIndex = 1;
            this.ipLabel2.Text = "IP address";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel.Location = new System.Drawing.Point(12, 85);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(115, 24);
            this.portLabel.TabIndex = 2;
            this.portLabel.Text = "Current Port:";
            // 
            // portLabel2
            // 
            this.portLabel2.AutoSize = true;
            this.portLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.portLabel2.Location = new System.Drawing.Point(207, 85);
            this.portLabel2.Name = "portLabel2";
            this.portLabel2.Size = new System.Drawing.Size(40, 24);
            this.portLabel2.TabIndex = 3;
            this.portLabel2.Text = "123";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(16, 327);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(149, 50);
            this.StartButton.TabIndex = 4;
            this.StartButton.Text = "Start Server";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // threadReceiver
            // 
            this.threadReceiver.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadReceiver_DoWork);
            // 
            // threadSender
            // 
            this.threadSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.threadSender_DoWork);
            // 
            // textChat
            // 
            this.textChat.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.textChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textChat.Location = new System.Drawing.Point(12, 191);
            this.textChat.Multiline = true;
            this.textChat.Name = "textChat";
            this.textChat.Size = new System.Drawing.Size(327, 62);
            this.textChat.TabIndex = 6;
            this.textChat.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textMessage
            // 
            this.textMessage.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.textMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textMessage.Location = new System.Drawing.Point(12, 274);
            this.textMessage.Multiline = true;
            this.textMessage.Name = "textMessage";
            this.textMessage.Size = new System.Drawing.Size(327, 36);
            this.textMessage.TabIndex = 7;
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.Location = new System.Drawing.Point(195, 327);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(148, 50);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectButton.Location = new System.Drawing.Point(16, 124);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(149, 52);
            this.ConnectButton.TabIndex = 9;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // clientIP
            // 
            this.clientIP.Location = new System.Drawing.Point(188, 58);
            this.clientIP.Name = "clientIP";
            this.clientIP.Size = new System.Drawing.Size(155, 20);
            this.clientIP.TabIndex = 10;
            // 
            // clientPort
            // 
            this.clientPort.Location = new System.Drawing.Point(188, 133);
            this.clientPort.Name = "clientPort";
            this.clientPort.Size = new System.Drawing.Size(154, 20);
            this.clientPort.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(355, 389);
            this.Controls.Add(this.clientPort);
            this.Controls.Add(this.clientIP);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.textMessage);
            this.Controls.Add(this.textChat);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.portLabel2);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.ipLabel2);
            this.Controls.Add(this.ipLabel);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Label ipLabel2;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.Label portLabel2;
        private System.Windows.Forms.Button StartButton;
        private System.ComponentModel.BackgroundWorker threadReceiver;
        private System.ComponentModel.BackgroundWorker threadSender;
        private System.Windows.Forms.TextBox textChat;
        private System.Windows.Forms.TextBox textMessage;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.TextBox clientIP;
        private System.Windows.Forms.TextBox clientPort;
    }
}

