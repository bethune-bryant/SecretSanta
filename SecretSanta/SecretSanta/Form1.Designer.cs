﻿namespace SecretSanta
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
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtParticipants = new System.Windows.Forms.RichTextBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.progressStatus = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupEmail = new System.Windows.Forms.GroupBox();
            this.groupPassword = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupMessage = new System.Windows.Forms.GroupBox();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.groupParticipants = new System.Windows.Forms.GroupBox();
            this.updatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendUpdateTOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendUpdateFROMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupEmail.SuspendLayout();
            this.groupPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupMessage.SuspendLayout();
            this.groupParticipants.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtEmail
            // 
            this.txtEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtEmail.Location = new System.Drawing.Point(3, 16);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(631, 29);
            this.txtEmail.TabIndex = 1;
            // 
            // txtPassword
            // 
            this.txtPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.txtPassword.Location = new System.Drawing.Point(3, 16);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '❄';
            this.txtPassword.Size = new System.Drawing.Size(631, 29);
            this.txtPassword.TabIndex = 2;
            // 
            // txtParticipants
            // 
            this.txtParticipants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtParticipants.Location = new System.Drawing.Point(3, 16);
            this.txtParticipants.Name = "txtParticipants";
            this.txtParticipants.Size = new System.Drawing.Size(631, 436);
            this.txtParticipants.TabIndex = 3;
            this.txtParticipants.Text = "";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressStatus,
            this.lblStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 732);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(637, 22);
            this.statusStrip.TabIndex = 4;
            this.statusStrip.Text = "statusStrip1";
            // 
            // progressStatus
            // 
            this.progressStatus.Name = "progressStatus";
            this.progressStatus.Size = new System.Drawing.Size(100, 16);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.testToolStripMenuItem,
            this.updatesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(637, 24);
            this.menuStrip.TabIndex = 5;
            this.menuStrip.Text = "menuStrip1";
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(637, 708);
            this.splitContainer1.SplitterDistance = 101;
            this.splitContainer1.TabIndex = 6;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupEmail);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupPassword);
            this.splitContainer2.Size = new System.Drawing.Size(637, 101);
            this.splitContainer2.TabIndex = 3;
            // 
            // groupEmail
            // 
            this.groupEmail.Controls.Add(this.txtEmail);
            this.groupEmail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupEmail.Location = new System.Drawing.Point(0, 0);
            this.groupEmail.Name = "groupEmail";
            this.groupEmail.Size = new System.Drawing.Size(637, 50);
            this.groupEmail.TabIndex = 0;
            this.groupEmail.TabStop = false;
            this.groupEmail.Text = "Gmail Address";
            // 
            // groupPassword
            // 
            this.groupPassword.Controls.Add(this.txtPassword);
            this.groupPassword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPassword.Location = new System.Drawing.Point(0, 0);
            this.groupPassword.Name = "groupPassword";
            this.groupPassword.Size = new System.Drawing.Size(637, 47);
            this.groupPassword.TabIndex = 0;
            this.groupPassword.TabStop = false;
            this.groupPassword.Text = "Password";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupMessage);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.groupParticipants);
            this.splitContainer3.Size = new System.Drawing.Size(637, 603);
            this.splitContainer3.SplitterDistance = 144;
            this.splitContainer3.TabIndex = 5;
            // 
            // groupMessage
            // 
            this.groupMessage.Controls.Add(this.txtMessage);
            this.groupMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupMessage.Location = new System.Drawing.Point(0, 0);
            this.groupMessage.Name = "groupMessage";
            this.groupMessage.Size = new System.Drawing.Size(637, 144);
            this.groupMessage.TabIndex = 5;
            this.groupMessage.TabStop = false;
            this.groupMessage.Text = "Message";
            // 
            // txtMessage
            // 
            this.txtMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMessage.Location = new System.Drawing.Point(3, 16);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(631, 125);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "";
            // 
            // groupParticipants
            // 
            this.groupParticipants.Controls.Add(this.txtParticipants);
            this.groupParticipants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupParticipants.Location = new System.Drawing.Point(0, 0);
            this.groupParticipants.Name = "groupParticipants";
            this.groupParticipants.Size = new System.Drawing.Size(637, 455);
            this.groupParticipants.TabIndex = 4;
            this.groupParticipants.TabStop = false;
            this.groupParticipants.Text = "Participants";
            // 
            // updatesToolStripMenuItem
            // 
            this.updatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sendUpdateTOToolStripMenuItem,
            this.sendUpdateFROMToolStripMenuItem});
            this.updatesToolStripMenuItem.Name = "updatesToolStripMenuItem";
            this.updatesToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.updatesToolStripMenuItem.Text = "Updates";
            // 
            // sendUpdateTOToolStripMenuItem
            // 
            this.sendUpdateTOToolStripMenuItem.Name = "sendUpdateTOToolStripMenuItem";
            this.sendUpdateTOToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendUpdateTOToolStripMenuItem.Text = "Send Update TO";
            this.sendUpdateTOToolStripMenuItem.Click += new System.EventHandler(this.sendUpdateTOToolStripMenuItem_Click);
            // 
            // sendUpdateFROMToolStripMenuItem
            // 
            this.sendUpdateFROMToolStripMenuItem.Name = "sendUpdateFROMToolStripMenuItem";
            this.sendUpdateFROMToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendUpdateFROMToolStripMenuItem.Text = "Send Update FROM";
            this.sendUpdateFROMToolStripMenuItem.Click += new System.EventHandler(this.sendUpdateFROMToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 754);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Secret Santa Name Drawer";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupEmail.ResumeLayout(false);
            this.groupEmail.PerformLayout();
            this.groupPassword.ResumeLayout(false);
            this.groupPassword.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupMessage.ResumeLayout(false);
            this.groupParticipants.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.RichTextBox txtParticipants;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar progressStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupEmail;
        private System.Windows.Forms.GroupBox groupPassword;
        private System.Windows.Forms.GroupBox groupParticipants;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupMessage;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.ToolStripMenuItem updatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendUpdateTOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sendUpdateFROMToolStripMenuItem;
    }
}

