namespace Twitchdouken
{
    partial class Twitchdouken
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Twitchdouken));
            this.UIUpdater = new System.Windows.Forms.Timer(this.components);
            this.NotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.followGroupBox = new System.Windows.Forms.GroupBox();
            this.followBox = new System.Windows.Forms.ListBox();
            this.subscriberGroupBox = new System.Windows.Forms.GroupBox();
            this.subscriberBox = new System.Windows.Forms.ListBox();
            this.hostGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.minViewerHost = new System.Windows.Forms.NumericUpDown();
            this.hostBox = new System.Windows.Forms.ListBox();
            this.donationGroupBox = new System.Windows.Forms.GroupBox();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.commentLabel = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.amountLabel = new System.Windows.Forms.Label();
            this.donationBox = new System.Windows.Forms.ListBox();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindows = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowsConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.menuWindowsAlert = new System.Windows.Forms.ToolStripMenuItem();
            this.followGroupBox.SuspendLayout();
            this.subscriberGroupBox.SuspendLayout();
            this.hostGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minViewerHost)).BeginInit();
            this.donationGroupBox.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // UIUpdater
            // 
            this.UIUpdater.Tick += new System.EventHandler(this.UIUpdater_Tick);
            // 
            // NotifyIcon
            // 
            this.NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.NotifyIcon.BalloonTipText = "MotoDouken!";
            this.NotifyIcon.BalloonTipTitle = "DomDouken!";
            this.NotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("NotifyIcon.Icon")));
            this.NotifyIcon.Text = "TwitchDouken!";
            this.NotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.NotifyIcon_MouseDoubleClick);
            // 
            // followGroupBox
            // 
            this.followGroupBox.Controls.Add(this.followBox);
            this.followGroupBox.Location = new System.Drawing.Point(8, 28);
            this.followGroupBox.Name = "followGroupBox";
            this.followGroupBox.Size = new System.Drawing.Size(172, 285);
            this.followGroupBox.TabIndex = 28;
            this.followGroupBox.TabStop = false;
            this.followGroupBox.Text = "Recent Followers";
            // 
            // followBox
            // 
            this.followBox.FormattingEnabled = true;
            this.followBox.Location = new System.Drawing.Point(4, 15);
            this.followBox.Name = "followBox";
            this.followBox.Size = new System.Drawing.Size(163, 264);
            this.followBox.TabIndex = 17;
            // 
            // subscriberGroupBox
            // 
            this.subscriberGroupBox.Controls.Add(this.subscriberBox);
            this.subscriberGroupBox.Location = new System.Drawing.Point(186, 28);
            this.subscriberGroupBox.Name = "subscriberGroupBox";
            this.subscriberGroupBox.Size = new System.Drawing.Size(172, 285);
            this.subscriberGroupBox.TabIndex = 29;
            this.subscriberGroupBox.TabStop = false;
            this.subscriberGroupBox.Text = "Recent Subscribers";
            // 
            // subscriberBox
            // 
            this.subscriberBox.FormattingEnabled = true;
            this.subscriberBox.Location = new System.Drawing.Point(4, 15);
            this.subscriberBox.Name = "subscriberBox";
            this.subscriberBox.Size = new System.Drawing.Size(163, 264);
            this.subscriberBox.TabIndex = 33;
            // 
            // hostGroupBox
            // 
            this.hostGroupBox.Controls.Add(this.label1);
            this.hostGroupBox.Controls.Add(this.minViewerHost);
            this.hostGroupBox.Controls.Add(this.hostBox);
            this.hostGroupBox.Location = new System.Drawing.Point(364, 28);
            this.hostGroupBox.Name = "hostGroupBox";
            this.hostGroupBox.Size = new System.Drawing.Size(172, 285);
            this.hostGroupBox.TabIndex = 30;
            this.hostGroupBox.TabStop = false;
            this.hostGroupBox.Text = "Recent Hosts";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 262);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Minimum Viewers:";
            // 
            // minViewerHost
            // 
            this.minViewerHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.minViewerHost.InterceptArrowKeys = false;
            this.minViewerHost.Location = new System.Drawing.Point(124, 259);
            this.minViewerHost.Name = "minViewerHost";
            this.minViewerHost.ReadOnly = true;
            this.minViewerHost.Size = new System.Drawing.Size(42, 20);
            this.minViewerHost.TabIndex = 17;
            // 
            // hostBox
            // 
            this.hostBox.FormattingEnabled = true;
            this.hostBox.Location = new System.Drawing.Point(4, 15);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(163, 238);
            this.hostBox.TabIndex = 16;
            // 
            // donationGroupBox
            // 
            this.donationGroupBox.Controls.Add(this.commentBox);
            this.donationGroupBox.Controls.Add(this.commentLabel);
            this.donationGroupBox.Controls.Add(this.amountBox);
            this.donationGroupBox.Controls.Add(this.amountLabel);
            this.donationGroupBox.Controls.Add(this.donationBox);
            this.donationGroupBox.Location = new System.Drawing.Point(542, 28);
            this.donationGroupBox.Name = "donationGroupBox";
            this.donationGroupBox.Size = new System.Drawing.Size(344, 285);
            this.donationGroupBox.TabIndex = 31;
            this.donationGroupBox.TabStop = false;
            this.donationGroupBox.Text = "Recent Donation";
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(175, 54);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(163, 225);
            this.commentBox.TabIndex = 25;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(175, 38);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(51, 13);
            this.commentLabel.TabIndex = 24;
            this.commentLabel.Text = "Comment";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(175, 15);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(163, 20);
            this.amountBox.TabIndex = 23;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(175, -1);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(43, 13);
            this.amountLabel.TabIndex = 22;
            this.amountLabel.Text = "Amount";
            // 
            // donationBox
            // 
            this.donationBox.FormattingEnabled = true;
            this.donationBox.Location = new System.Drawing.Point(5, 15);
            this.donationBox.Name = "donationBox";
            this.donationBox.Size = new System.Drawing.Size(163, 264);
            this.donationBox.TabIndex = 17;
            this.donationBox.SelectedIndexChanged += new System.EventHandler(this.donationBox_SelectedIndexChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuStart,
            this.menuWindows});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(895, 24);
            this.menuStrip.TabIndex = 32;
            this.menuStrip.Text = "menuStrip1";
            // 
            // menuStart
            // 
            this.menuStart.Name = "menuStart";
            this.menuStart.Size = new System.Drawing.Size(43, 20);
            this.menuStart.Text = "&Start";
            this.menuStart.Click += new System.EventHandler(this.menuStart_Click);
            // 
            // menuWindows
            // 
            this.menuWindows.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuWindowsConfiguration,
            this.menuWindowsAlert});
            this.menuWindows.Name = "menuWindows";
            this.menuWindows.Size = new System.Drawing.Size(68, 20);
            this.menuWindows.Text = "Windows";
            // 
            // menuWindowsConfiguration
            // 
            this.menuWindowsConfiguration.Name = "menuWindowsConfiguration";
            this.menuWindowsConfiguration.Size = new System.Drawing.Size(148, 22);
            this.menuWindowsConfiguration.Text = "Configuration";
            this.menuWindowsConfiguration.Click += new System.EventHandler(this.menuWindowsConfiguration_Click);
            // 
            // menuWindowsAlert
            // 
            this.menuWindowsAlert.Checked = true;
            this.menuWindowsAlert.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuWindowsAlert.Name = "menuWindowsAlert";
            this.menuWindowsAlert.Size = new System.Drawing.Size(148, 22);
            this.menuWindowsAlert.Text = "Alert";
            this.menuWindowsAlert.Click += new System.EventHandler(this.menuWindowsAlert_Click);
            // 
            // Twitchdouken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 322);
            this.Controls.Add(this.followGroupBox);
            this.Controls.Add(this.hostGroupBox);
            this.Controls.Add(this.donationGroupBox);
            this.Controls.Add(this.subscriberGroupBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.Name = "Twitchdouken";
            this.Text = "Twitchdouken";
            this.Load += new System.EventHandler(this.Twitchdouken_Load);
            this.SizeChanged += new System.EventHandler(this.Twitchdouken_Resize);
            this.followGroupBox.ResumeLayout(false);
            this.subscriberGroupBox.ResumeLayout(false);
            this.hostGroupBox.ResumeLayout(false);
            this.hostGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.minViewerHost)).EndInit();
            this.donationGroupBox.ResumeLayout(false);
            this.donationGroupBox.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer UIUpdater;
        private System.Windows.Forms.NotifyIcon NotifyIcon;
        private System.Windows.Forms.GroupBox followGroupBox;
        private System.Windows.Forms.ListBox followBox;
        private System.Windows.Forms.GroupBox subscriberGroupBox;
        private System.Windows.Forms.ListBox subscriberBox;
        private System.Windows.Forms.GroupBox hostGroupBox;
        private System.Windows.Forms.ListBox hostBox;
        private System.Windows.Forms.GroupBox donationGroupBox;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.ListBox donationBox;
        private System.Windows.Forms.ToolStripMenuItem menuStart;
        private System.Windows.Forms.ToolStripMenuItem menuWindows;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown minViewerHost;
        private System.Windows.Forms.MenuStrip menuStrip;
        internal System.Windows.Forms.ToolStripMenuItem menuWindowsConfiguration;
        internal System.Windows.Forms.ToolStripMenuItem menuWindowsAlert;

    }
}

