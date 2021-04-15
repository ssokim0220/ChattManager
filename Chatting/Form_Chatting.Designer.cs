
namespace Chatting
{
    partial class Form_Chatting
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbRecieve = new System.Windows.Forms.TextBox();
            this.btSend = new System.Windows.Forms.Button();
            this.tbSend = new System.Windows.Forms.TextBox();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sb_IP = new System.Windows.Forms.ToolStripStatusLabel();
            this.sb_Port = new System.Windows.Forms.ToolStripStatusLabel();
            this.sb_Port1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(361, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sb_IP,
            this.sb_Port,
            this.sb_Port1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(361, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.tbPort);
            this.splitContainer1.Panel1.Controls.Add(this.tbIP);
            this.splitContainer1.Panel1.Controls.Add(this.tbRecieve);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btSend);
            this.splitContainer1.Panel2.Controls.Add(this.tbSend);
            this.splitContainer1.Size = new System.Drawing.Size(361, 404);
            this.splitContainer1.SplitterDistance = 336;
            this.splitContainer1.TabIndex = 3;
            // 
            // tbRecieve
            // 
            this.tbRecieve.Location = new System.Drawing.Point(4, 30);
            this.tbRecieve.Multiline = true;
            this.tbRecieve.Name = "tbRecieve";
            this.tbRecieve.Size = new System.Drawing.Size(354, 303);
            this.tbRecieve.TabIndex = 0;
            // 
            // btSend
            // 
            this.btSend.Location = new System.Drawing.Point(283, 3);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(75, 58);
            this.btSend.TabIndex = 1;
            this.btSend.Text = "전송";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // tbSend
            // 
            this.tbSend.Location = new System.Drawing.Point(3, 3);
            this.tbSend.Multiline = true;
            this.tbSend.Name = "tbSend";
            this.tbSend.Size = new System.Drawing.Size(277, 58);
            this.tbSend.TabIndex = 0;
            this.tbSend.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbSend_KeyDown);
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(59, 3);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(184, 21);
            this.tbIP.TabIndex = 1;
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(243, 3);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(106, 21);
            this.tbPort.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Server";
            // 
            // sb_IP
            // 
            this.sb_IP.AutoSize = false;
            this.sb_IP.Name = "sb_IP";
            this.sb_IP.Size = new System.Drawing.Size(120, 17);
            // 
            // sb_Port
            // 
            this.sb_Port.AutoSize = false;
            this.sb_Port.Name = "sb_Port";
            this.sb_Port.Size = new System.Drawing.Size(0, 17);
            // 
            // sb_Port1
            // 
            this.sb_Port1.AutoSize = false;
            this.sb_Port1.Name = "sb_Port1";
            this.sb_Port1.Size = new System.Drawing.Size(50, 17);
            // 
            // Form_Chatting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 450);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Chatting";
            this.Text = "Chatting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Chatting_FormClosing);
            this.Load += new System.EventHandler(this.Form_Chatting_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tbRecieve;
        private System.Windows.Forms.TextBox tbSend;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.ToolStripStatusLabel sb_IP;
        private System.Windows.Forms.ToolStripStatusLabel sb_Port;
        private System.Windows.Forms.ToolStripStatusLabel sb_Port1;
    }
}

