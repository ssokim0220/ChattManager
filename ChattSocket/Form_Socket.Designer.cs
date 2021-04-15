
namespace ChattSocket
{
    partial class Form_Socket
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuServerPort = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientIP = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuClientPort = new System.Windows.Forms.ToolStripMenuItem();
            this.communicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSendEX = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tbPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuSend = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbRecieve = new System.Windows.Forms.TextBox();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.communicationToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(333, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuStart,
            this.mnuStop,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuStart
            // 
            this.mnuStart.Name = "mnuStart";
            this.mnuStart.Size = new System.Drawing.Size(180, 22);
            this.mnuStart.Text = "Start Server";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Name = "mnuStop";
            this.mnuStop.Size = new System.Drawing.Size(180, 22);
            this.mnuStop.Text = "Stop";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(180, 22);
            this.mnuExit.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerConfig,
            this.mnuClientConfig});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuServerConfig
            // 
            this.mnuServerConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuServerIP,
            this.mnuServerPort});
            this.mnuServerConfig.Name = "mnuServerConfig";
            this.mnuServerConfig.Size = new System.Drawing.Size(180, 22);
            this.mnuServerConfig.Text = "Server Config";
            // 
            // mnuServerIP
            // 
            this.mnuServerIP.Name = "mnuServerIP";
            this.mnuServerIP.Size = new System.Drawing.Size(133, 22);
            this.mnuServerIP.Text = "Server IP";
            this.mnuServerIP.Click += new System.EventHandler(this.mnuServerIP_Click);
            // 
            // mnuServerPort
            // 
            this.mnuServerPort.Name = "mnuServerPort";
            this.mnuServerPort.Size = new System.Drawing.Size(133, 22);
            this.mnuServerPort.Text = "Server Port";
            this.mnuServerPort.Click += new System.EventHandler(this.mnuServerPort_Click);
            // 
            // mnuClientConfig
            // 
            this.mnuClientConfig.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuClientIP,
            this.mnuClientPort});
            this.mnuClientConfig.Name = "mnuClientConfig";
            this.mnuClientConfig.Size = new System.Drawing.Size(180, 22);
            this.mnuClientConfig.Text = "Client Config";
            // 
            // mnuClientIP
            // 
            this.mnuClientIP.Name = "mnuClientIP";
            this.mnuClientIP.Size = new System.Drawing.Size(131, 22);
            this.mnuClientIP.Text = "Client IP";
            this.mnuClientIP.Click += new System.EventHandler(this.mnuClientIP_Click);
            // 
            // mnuClientPort
            // 
            this.mnuClientPort.Name = "mnuClientPort";
            this.mnuClientPort.Size = new System.Drawing.Size(131, 22);
            this.mnuClientPort.Text = "Client Port";
            this.mnuClientPort.Click += new System.EventHandler(this.mnuClientPort_Click);
            // 
            // communicationToolStripMenuItem
            // 
            this.communicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSendEX});
            this.communicationToolStripMenuItem.Name = "communicationToolStripMenuItem";
            this.communicationToolStripMenuItem.Size = new System.Drawing.Size(106, 20);
            this.communicationToolStripMenuItem.Text = "Communication";
            // 
            // mnuSendEX
            // 
            this.mnuSendEX.Name = "mnuSendEX";
            this.mnuSendEX.Size = new System.Drawing.Size(180, 22);
            this.mnuSendEX.Text = "Send";
            this.mnuSendEX.Click += new System.EventHandler(this.mnuSendEX_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbPort});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(333, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tbPort
            // 
            this.tbPort.AutoSize = false;
            this.tbPort.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(50, 17);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuSend});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(102, 26);
            // 
            // mnuSend
            // 
            this.mnuSend.Name = "mnuSend";
            this.mnuSend.Size = new System.Drawing.Size(101, 22);
            this.mnuSend.Text = "Send";
            this.mnuSend.Click += new System.EventHandler(this.mnuSend_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tbRecieve);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbSend);
            this.splitContainer1.Size = new System.Drawing.Size(333, 394);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.TabIndex = 3;
            // 
            // tbRecieve
            // 
            this.tbRecieve.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRecieve.Location = new System.Drawing.Point(3, 3);
            this.tbRecieve.Multiline = true;
            this.tbRecieve.Name = "tbRecieve";
            this.tbRecieve.Size = new System.Drawing.Size(327, 332);
            this.tbRecieve.TabIndex = 0;
            // 
            // tbSend
            // 
            this.tbSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSend.ContextMenuStrip = this.contextMenuStrip1;
            this.tbSend.Location = new System.Drawing.Point(3, 3);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(327, 46);
            this.tbSend.TabIndex = 0;
            this.tbSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSend_KeyDown);
            // 
            // Form_Socket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 440);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Socket";
            this.Text = "Chatt Socket";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Socket_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuStart;
        private System.Windows.Forms.ToolStripMenuItem mnuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuServerConfig;
        private System.Windows.Forms.ToolStripMenuItem communicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuSendEX;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tbPort;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.TextBox tbRecieve;
        private System.Windows.Forms.ToolStripMenuItem mnuSend;
        private System.Windows.Forms.ToolStripMenuItem mnuServerIP;
        private System.Windows.Forms.ToolStripMenuItem mnuServerPort;
        private System.Windows.Forms.ToolStripMenuItem mnuClientConfig;
        private System.Windows.Forms.ToolStripMenuItem mnuClientIP;
        private System.Windows.Forms.ToolStripMenuItem mnuClientPort;
    }
}

