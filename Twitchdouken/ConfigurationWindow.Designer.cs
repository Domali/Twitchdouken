namespace Twitchdouken
{
    partial class ConfigurationWindow
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
            this.saveMovieCfgBtn = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.activeAlertBox = new System.Windows.Forms.GroupBox();
            this.donationBox = new System.Windows.Forms.CheckBox();
            this.activeDonationLabel = new System.Windows.Forms.Label();
            this.hostBox = new System.Windows.Forms.CheckBox();
            this.activeHostLabel = new System.Windows.Forms.Label();
            this.subscriberBox = new System.Windows.Forms.CheckBox();
            this.followerBox = new System.Windows.Forms.CheckBox();
            this.activeSubscriberLabel = new System.Windows.Forms.Label();
            this.activeFollowerLabel = new System.Windows.Forms.Label();
            this.runAtStartLabel = new System.Windows.Forms.Label();
            this.runAtStartBox = new System.Windows.Forms.CheckBox();
            this.saveAllBtn = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.ircOAuthBox = new System.Windows.Forms.TextBox();
            this.channelBox = new System.Windows.Forms.TextBox();
            this.ircOAuthLabel = new System.Windows.Forms.Label();
            this.channelLabel = new System.Windows.Forms.Label();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.subscriberOAuthBox = new System.Windows.Forms.TextBox();
            this.subscriberOAuthLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.TAAccessTokenBox = new System.Windows.Forms.TextBox();
            this.TAAccessTokenLabel = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.alertHeightNum = new System.Windows.Forms.NumericUpDown();
            this.alertWidthNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.alertResizeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.loadMovieCfgBtn = new System.Windows.Forms.Button();
            this.newMovieCfgBtn = new System.Windows.Forms.Button();
            this.movieConfigBox = new System.Windows.Forms.TextBox();
            this.configuration_label = new System.Windows.Forms.Label();
            this.testChromaKeyBtn = new System.Windows.Forms.GroupBox();
            this.chromaTestBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.chromaHexBox = new System.Windows.Forms.TextBox();
            this.colorPickerBtn = new System.Windows.Forms.Button();
            this.chromaKeySample = new System.Windows.Forms.Label();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.follower_movie_label = new System.Windows.Forms.Label();
            this.followerTxtBox = new System.Windows.Forms.TextBox();
            this.subscriberTxtBox = new System.Windows.Forms.TextBox();
            this.donationTxtBox = new System.Windows.Forms.TextBox();
            this.hostTxtBox = new System.Windows.Forms.TextBox();
            this.subscriberBtn = new System.Windows.Forms.Button();
            this.subscriber_movie_label = new System.Windows.Forms.Label();
            this.testFollowerBtn = new System.Windows.Forms.Button();
            this.followerBtn = new System.Windows.Forms.Button();
            this.donationBtn = new System.Windows.Forms.Button();
            this.testHostBtn = new System.Windows.Forms.Button();
            this.host_movie_label = new System.Windows.Forms.Label();
            this.testDonationBtn = new System.Windows.Forms.Button();
            this.donation_movie_label = new System.Windows.Forms.Label();
            this.testSubscriberBtn = new System.Windows.Forms.Button();
            this.hostBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.activeAlertBox.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertHeightNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertWidthNum)).BeginInit();
            this.testChromaKeyBtn.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveMovieCfgBtn
            // 
            this.saveMovieCfgBtn.Location = new System.Drawing.Point(255, 162);
            this.saveMovieCfgBtn.Name = "saveMovieCfgBtn";
            this.saveMovieCfgBtn.Size = new System.Drawing.Size(105, 23);
            this.saveMovieCfgBtn.TabIndex = 17;
            this.saveMovieCfgBtn.Text = "Save Configuration";
            this.saveMovieCfgBtn.UseVisualStyleBackColor = true;
            this.saveMovieCfgBtn.Click += new System.EventHandler(this.saveMovieCfgBtn_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(412, 268);
            this.tabControl1.TabIndex = 26;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.activeAlertBox);
            this.tabPage1.Controls.Add(this.runAtStartLabel);
            this.tabPage1.Controls.Add(this.runAtStartBox);
            this.tabPage1.Controls.Add(this.saveAllBtn);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(404, 242);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // activeAlertBox
            // 
            this.activeAlertBox.Controls.Add(this.donationBox);
            this.activeAlertBox.Controls.Add(this.activeDonationLabel);
            this.activeAlertBox.Controls.Add(this.hostBox);
            this.activeAlertBox.Controls.Add(this.activeHostLabel);
            this.activeAlertBox.Controls.Add(this.subscriberBox);
            this.activeAlertBox.Controls.Add(this.followerBox);
            this.activeAlertBox.Controls.Add(this.activeSubscriberLabel);
            this.activeAlertBox.Controls.Add(this.activeFollowerLabel);
            this.activeAlertBox.Location = new System.Drawing.Point(11, 12);
            this.activeAlertBox.Name = "activeAlertBox";
            this.activeAlertBox.Size = new System.Drawing.Size(124, 98);
            this.activeAlertBox.TabIndex = 10;
            this.activeAlertBox.TabStop = false;
            this.activeAlertBox.Text = "Current Display Data";
            // 
            // donationBox
            // 
            this.donationBox.AutoSize = true;
            this.donationBox.Location = new System.Drawing.Point(85, 78);
            this.donationBox.Name = "donationBox";
            this.donationBox.Size = new System.Drawing.Size(14, 13);
            this.donationBox.TabIndex = 7;
            this.donationBox.UseVisualStyleBackColor = true;
            this.donationBox.CheckedChanged += new System.EventHandler(this.donationBox_CheckedChanged);
            // 
            // activeDonationLabel
            // 
            this.activeDonationLabel.AutoSize = true;
            this.activeDonationLabel.Location = new System.Drawing.Point(26, 76);
            this.activeDonationLabel.Name = "activeDonationLabel";
            this.activeDonationLabel.Size = new System.Drawing.Size(58, 13);
            this.activeDonationLabel.TabIndex = 6;
            this.activeDonationLabel.Text = "Donations:";
            // 
            // hostBox
            // 
            this.hostBox.AutoSize = true;
            this.hostBox.Location = new System.Drawing.Point(85, 58);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(14, 13);
            this.hostBox.TabIndex = 5;
            this.hostBox.UseVisualStyleBackColor = true;
            this.hostBox.CheckedChanged += new System.EventHandler(this.hostBox_CheckedChanged);
            // 
            // activeHostLabel
            // 
            this.activeHostLabel.AutoSize = true;
            this.activeHostLabel.Location = new System.Drawing.Point(47, 56);
            this.activeHostLabel.Name = "activeHostLabel";
            this.activeHostLabel.Size = new System.Drawing.Size(37, 13);
            this.activeHostLabel.TabIndex = 4;
            this.activeHostLabel.Text = "Hosts:";
            // 
            // subscriberBox
            // 
            this.subscriberBox.AutoSize = true;
            this.subscriberBox.Location = new System.Drawing.Point(85, 38);
            this.subscriberBox.Name = "subscriberBox";
            this.subscriberBox.Size = new System.Drawing.Size(14, 13);
            this.subscriberBox.TabIndex = 3;
            this.subscriberBox.UseVisualStyleBackColor = true;
            this.subscriberBox.CheckedChanged += new System.EventHandler(this.subscriberBox_CheckedChanged);
            // 
            // followerBox
            // 
            this.followerBox.AutoSize = true;
            this.followerBox.Location = new System.Drawing.Point(85, 18);
            this.followerBox.Name = "followerBox";
            this.followerBox.Size = new System.Drawing.Size(14, 13);
            this.followerBox.TabIndex = 2;
            this.followerBox.UseVisualStyleBackColor = true;
            this.followerBox.CheckedChanged += new System.EventHandler(this.followerBox_CheckedChanged);
            // 
            // activeSubscriberLabel
            // 
            this.activeSubscriberLabel.AutoSize = true;
            this.activeSubscriberLabel.Location = new System.Drawing.Point(19, 36);
            this.activeSubscriberLabel.Name = "activeSubscriberLabel";
            this.activeSubscriberLabel.Size = new System.Drawing.Size(65, 13);
            this.activeSubscriberLabel.TabIndex = 1;
            this.activeSubscriberLabel.Text = "Subscribers:";
            // 
            // activeFollowerLabel
            // 
            this.activeFollowerLabel.AutoSize = true;
            this.activeFollowerLabel.Location = new System.Drawing.Point(30, 17);
            this.activeFollowerLabel.Name = "activeFollowerLabel";
            this.activeFollowerLabel.Size = new System.Drawing.Size(54, 13);
            this.activeFollowerLabel.TabIndex = 0;
            this.activeFollowerLabel.Text = "Followers:";
            // 
            // runAtStartLabel
            // 
            this.runAtStartLabel.AutoSize = true;
            this.runAtStartLabel.Location = new System.Drawing.Point(8, 222);
            this.runAtStartLabel.Name = "runAtStartLabel";
            this.runAtStartLabel.Size = new System.Drawing.Size(68, 13);
            this.runAtStartLabel.TabIndex = 9;
            this.runAtStartLabel.Text = "Run At Start:";
            // 
            // runAtStartBox
            // 
            this.runAtStartBox.AutoSize = true;
            this.runAtStartBox.Location = new System.Drawing.Point(76, 223);
            this.runAtStartBox.Name = "runAtStartBox";
            this.runAtStartBox.Size = new System.Drawing.Size(14, 13);
            this.runAtStartBox.TabIndex = 8;
            this.runAtStartBox.UseVisualStyleBackColor = true;
            // 
            // saveAllBtn
            // 
            this.saveAllBtn.Location = new System.Drawing.Point(292, 212);
            this.saveAllBtn.Name = "saveAllBtn";
            this.saveAllBtn.Size = new System.Drawing.Size(105, 23);
            this.saveAllBtn.TabIndex = 4;
            this.saveAllBtn.Text = "Save Configuration";
            this.saveAllBtn.UseVisualStyleBackColor = true;
            this.saveAllBtn.Click += new System.EventHandler(this.saveAllBtn_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tabControl3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(404, 242);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "OAuth";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage7);
            this.tabControl3.Controls.Add(this.tabPage8);
            this.tabControl3.Location = new System.Drawing.Point(12, 10);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(377, 220);
            this.tabControl3.TabIndex = 12;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.ircOAuthBox);
            this.tabPage7.Controls.Add(this.channelBox);
            this.tabPage7.Controls.Add(this.ircOAuthLabel);
            this.tabPage7.Controls.Add(this.channelLabel);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(369, 194);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "IRC";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // ircOAuthBox
            // 
            this.ircOAuthBox.Location = new System.Drawing.Point(9, 65);
            this.ircOAuthBox.Name = "ircOAuthBox";
            this.ircOAuthBox.Size = new System.Drawing.Size(297, 20);
            this.ircOAuthBox.TabIndex = 14;
            // 
            // channelBox
            // 
            this.channelBox.Location = new System.Drawing.Point(9, 27);
            this.channelBox.Name = "channelBox";
            this.channelBox.Size = new System.Drawing.Size(297, 20);
            this.channelBox.TabIndex = 13;
            // 
            // ircOAuthLabel
            // 
            this.ircOAuthLabel.AutoSize = true;
            this.ircOAuthLabel.Location = new System.Drawing.Point(8, 50);
            this.ircOAuthLabel.Name = "ircOAuthLabel";
            this.ircOAuthLabel.Size = new System.Drawing.Size(58, 13);
            this.ircOAuthLabel.TabIndex = 12;
            this.ircOAuthLabel.Text = "IRC OAuth";
            // 
            // channelLabel
            // 
            this.channelLabel.AutoSize = true;
            this.channelLabel.Location = new System.Drawing.Point(8, 11);
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(46, 13);
            this.channelLabel.TabIndex = 11;
            this.channelLabel.Text = "Channel";
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.subscriberOAuthBox);
            this.tabPage8.Controls.Add(this.subscriberOAuthLabel);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(369, 194);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Twitch";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // subscriberOAuthBox
            // 
            this.subscriberOAuthBox.Location = new System.Drawing.Point(9, 27);
            this.subscriberOAuthBox.Name = "subscriberOAuthBox";
            this.subscriberOAuthBox.Size = new System.Drawing.Size(297, 20);
            this.subscriberOAuthBox.TabIndex = 13;
            // 
            // subscriberOAuthLabel
            // 
            this.subscriberOAuthLabel.AutoSize = true;
            this.subscriberOAuthLabel.Location = new System.Drawing.Point(7, 11);
            this.subscriberOAuthLabel.Name = "subscriberOAuthLabel";
            this.subscriberOAuthLabel.Size = new System.Drawing.Size(90, 13);
            this.subscriberOAuthLabel.TabIndex = 12;
            this.subscriberOAuthLabel.Text = "Subscriber OAuth";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.TAAccessTokenBox);
            this.tabPage3.Controls.Add(this.TAAccessTokenLabel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(404, 242);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Donations";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // TAAccessTokenBox
            // 
            this.TAAccessTokenBox.Location = new System.Drawing.Point(9, 23);
            this.TAAccessTokenBox.Name = "TAAccessTokenBox";
            this.TAAccessTokenBox.Size = new System.Drawing.Size(297, 20);
            this.TAAccessTokenBox.TabIndex = 3;
            // 
            // TAAccessTokenLabel
            // 
            this.TAAccessTokenLabel.AutoSize = true;
            this.TAAccessTokenLabel.Location = new System.Drawing.Point(7, 7);
            this.TAAccessTokenLabel.Name = "TAAccessTokenLabel";
            this.TAAccessTokenLabel.Size = new System.Drawing.Size(76, 13);
            this.TAAccessTokenLabel.TabIndex = 2;
            this.TAAccessTokenLabel.Text = "Access Token";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(404, 242);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Alerts";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Controls.Add(this.tabPage6);
            this.tabControl2.Location = new System.Drawing.Point(12, 10);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(377, 220);
            this.tabControl2.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.groupBox1);
            this.tabPage5.Controls.Add(this.saveMovieCfgBtn);
            this.tabPage5.Controls.Add(this.loadMovieCfgBtn);
            this.tabPage5.Controls.Add(this.newMovieCfgBtn);
            this.tabPage5.Controls.Add(this.movieConfigBox);
            this.tabPage5.Controls.Add(this.configuration_label);
            this.tabPage5.Controls.Add(this.testChromaKeyBtn);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(369, 194);
            this.tabPage5.TabIndex = 0;
            this.tabPage5.Text = "General";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.alertHeightNum);
            this.groupBox1.Controls.Add(this.alertWidthNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.alertResizeBtn);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(188, 60);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 90);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alert Window Settings";
            // 
            // alertHeightNum
            // 
            this.alertHeightNum.Location = new System.Drawing.Point(94, 32);
            this.alertHeightNum.Maximum = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.alertHeightNum.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.alertHeightNum.Name = "alertHeightNum";
            this.alertHeightNum.ReadOnly = true;
            this.alertHeightNum.Size = new System.Drawing.Size(68, 20);
            this.alertHeightNum.TabIndex = 33;
            this.alertHeightNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alertHeightNum.Value = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.alertHeightNum.ValueChanged += new System.EventHandler(this.alertHeightNum_ValueChanged);
            // 
            // alertWidthNum
            // 
            this.alertWidthNum.Location = new System.Drawing.Point(10, 32);
            this.alertWidthNum.Maximum = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.alertWidthNum.Minimum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.alertWidthNum.Name = "alertWidthNum";
            this.alertWidthNum.ReadOnly = true;
            this.alertWidthNum.Size = new System.Drawing.Size(68, 20);
            this.alertWidthNum.TabIndex = 32;
            this.alertWidthNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.alertWidthNum.Value = new decimal(new int[] {
            512,
            0,
            0,
            0});
            this.alertWidthNum.ValueChanged += new System.EventHandler(this.alertWidthNum_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(81, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "x";
            // 
            // alertResizeBtn
            // 
            this.alertResizeBtn.Location = new System.Drawing.Point(48, 58);
            this.alertResizeBtn.Name = "alertResizeBtn";
            this.alertResizeBtn.Size = new System.Drawing.Size(73, 23);
            this.alertResizeBtn.TabIndex = 30;
            this.alertResizeBtn.Text = "Resize";
            this.alertResizeBtn.UseVisualStyleBackColor = true;
            this.alertResizeBtn.Click += new System.EventHandler(this.alertResizeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(109, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Width";
            // 
            // loadMovieCfgBtn
            // 
            this.loadMovieCfgBtn.Location = new System.Drawing.Point(314, 22);
            this.loadMovieCfgBtn.Name = "loadMovieCfgBtn";
            this.loadMovieCfgBtn.Size = new System.Drawing.Size(46, 23);
            this.loadMovieCfgBtn.TabIndex = 23;
            this.loadMovieCfgBtn.Text = "Load";
            this.loadMovieCfgBtn.UseVisualStyleBackColor = true;
            this.loadMovieCfgBtn.Click += new System.EventHandler(this.loadMovieCfgBtn_Click);
            // 
            // newMovieCfgBtn
            // 
            this.newMovieCfgBtn.Location = new System.Drawing.Point(262, 22);
            this.newMovieCfgBtn.Name = "newMovieCfgBtn";
            this.newMovieCfgBtn.Size = new System.Drawing.Size(46, 23);
            this.newMovieCfgBtn.TabIndex = 22;
            this.newMovieCfgBtn.Text = "New";
            this.newMovieCfgBtn.UseVisualStyleBackColor = true;
            this.newMovieCfgBtn.Click += new System.EventHandler(this.newMovieCfgBtn_Click);
            // 
            // movieConfigBox
            // 
            this.movieConfigBox.Location = new System.Drawing.Point(9, 25);
            this.movieConfigBox.Name = "movieConfigBox";
            this.movieConfigBox.ReadOnly = true;
            this.movieConfigBox.Size = new System.Drawing.Size(246, 20);
            this.movieConfigBox.TabIndex = 20;
            // 
            // configuration_label
            // 
            this.configuration_label.AutoSize = true;
            this.configuration_label.Location = new System.Drawing.Point(7, 8);
            this.configuration_label.Name = "configuration_label";
            this.configuration_label.Size = new System.Drawing.Size(91, 13);
            this.configuration_label.TabIndex = 21;
            this.configuration_label.Text = "Configuration File:";
            // 
            // testChromaKeyBtn
            // 
            this.testChromaKeyBtn.Controls.Add(this.chromaTestBtn);
            this.testChromaKeyBtn.Controls.Add(this.label1);
            this.testChromaKeyBtn.Controls.Add(this.chromaHexBox);
            this.testChromaKeyBtn.Controls.Add(this.colorPickerBtn);
            this.testChromaKeyBtn.Controls.Add(this.chromaKeySample);
            this.testChromaKeyBtn.Location = new System.Drawing.Point(9, 60);
            this.testChromaKeyBtn.Name = "testChromaKeyBtn";
            this.testChromaKeyBtn.Size = new System.Drawing.Size(172, 90);
            this.testChromaKeyBtn.TabIndex = 9;
            this.testChromaKeyBtn.TabStop = false;
            this.testChromaKeyBtn.Text = "Chroma Key";
            // 
            // chromaTestBtn
            // 
            this.chromaTestBtn.Location = new System.Drawing.Point(13, 58);
            this.chromaTestBtn.Name = "chromaTestBtn";
            this.chromaTestBtn.Size = new System.Drawing.Size(58, 23);
            this.chromaTestBtn.TabIndex = 26;
            this.chromaTestBtn.Text = "Test";
            this.chromaTestBtn.UseVisualStyleBackColor = true;
            this.chromaTestBtn.Click += new System.EventHandler(this.chromaTestBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Hex Value";
            // 
            // chromaHexBox
            // 
            this.chromaHexBox.Location = new System.Drawing.Point(86, 32);
            this.chromaHexBox.MaxLength = 6;
            this.chromaHexBox.Name = "chromaHexBox";
            this.chromaHexBox.Size = new System.Drawing.Size(73, 20);
            this.chromaHexBox.TabIndex = 24;
            this.chromaHexBox.Text = "FFFFFF";
            this.chromaHexBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colorPickerBtn
            // 
            this.colorPickerBtn.Location = new System.Drawing.Point(86, 58);
            this.colorPickerBtn.Name = "colorPickerBtn";
            this.colorPickerBtn.Size = new System.Drawing.Size(73, 23);
            this.colorPickerBtn.TabIndex = 3;
            this.colorPickerBtn.Text = "Color Picker";
            this.colorPickerBtn.UseVisualStyleBackColor = true;
            this.colorPickerBtn.Click += new System.EventHandler(this.colorPickerBtn_Click);
            // 
            // chromaKeySample
            // 
            this.chromaKeySample.BackColor = System.Drawing.Color.White;
            this.chromaKeySample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chromaKeySample.Location = new System.Drawing.Point(13, 18);
            this.chromaKeySample.Name = "chromaKeySample";
            this.chromaKeySample.Size = new System.Drawing.Size(58, 34);
            this.chromaKeySample.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.follower_movie_label);
            this.tabPage6.Controls.Add(this.followerTxtBox);
            this.tabPage6.Controls.Add(this.subscriberTxtBox);
            this.tabPage6.Controls.Add(this.donationTxtBox);
            this.tabPage6.Controls.Add(this.hostTxtBox);
            this.tabPage6.Controls.Add(this.subscriberBtn);
            this.tabPage6.Controls.Add(this.subscriber_movie_label);
            this.tabPage6.Controls.Add(this.testFollowerBtn);
            this.tabPage6.Controls.Add(this.followerBtn);
            this.tabPage6.Controls.Add(this.donationBtn);
            this.tabPage6.Controls.Add(this.testHostBtn);
            this.tabPage6.Controls.Add(this.host_movie_label);
            this.tabPage6.Controls.Add(this.testDonationBtn);
            this.tabPage6.Controls.Add(this.donation_movie_label);
            this.tabPage6.Controls.Add(this.testSubscriberBtn);
            this.tabPage6.Controls.Add(this.hostBtn);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(369, 194);
            this.tabPage6.TabIndex = 1;
            this.tabPage6.Text = "Movies";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // follower_movie_label
            // 
            this.follower_movie_label.AutoSize = true;
            this.follower_movie_label.Location = new System.Drawing.Point(7, 8);
            this.follower_movie_label.Name = "follower_movie_label";
            this.follower_movie_label.Size = new System.Drawing.Size(78, 13);
            this.follower_movie_label.TabIndex = 16;
            this.follower_movie_label.Text = "Follower Movie";
            // 
            // followerTxtBox
            // 
            this.followerTxtBox.Location = new System.Drawing.Point(9, 25);
            this.followerTxtBox.Name = "followerTxtBox";
            this.followerTxtBox.ReadOnly = true;
            this.followerTxtBox.Size = new System.Drawing.Size(265, 20);
            this.followerTxtBox.TabIndex = 17;
            // 
            // subscriberTxtBox
            // 
            this.subscriberTxtBox.Location = new System.Drawing.Point(9, 140);
            this.subscriberTxtBox.Name = "subscriberTxtBox";
            this.subscriberTxtBox.ReadOnly = true;
            this.subscriberTxtBox.Size = new System.Drawing.Size(265, 20);
            this.subscriberTxtBox.TabIndex = 26;
            // 
            // donationTxtBox
            // 
            this.donationTxtBox.Location = new System.Drawing.Point(9, 101);
            this.donationTxtBox.Name = "donationTxtBox";
            this.donationTxtBox.ReadOnly = true;
            this.donationTxtBox.Size = new System.Drawing.Size(265, 20);
            this.donationTxtBox.TabIndex = 23;
            // 
            // hostTxtBox
            // 
            this.hostTxtBox.Location = new System.Drawing.Point(9, 62);
            this.hostTxtBox.Name = "hostTxtBox";
            this.hostTxtBox.ReadOnly = true;
            this.hostTxtBox.Size = new System.Drawing.Size(265, 20);
            this.hostTxtBox.TabIndex = 20;
            // 
            // subscriberBtn
            // 
            this.subscriberBtn.Location = new System.Drawing.Point(280, 138);
            this.subscriberBtn.Name = "subscriberBtn";
            this.subscriberBtn.Size = new System.Drawing.Size(32, 23);
            this.subscriberBtn.TabIndex = 27;
            this.subscriberBtn.Text = "...";
            this.subscriberBtn.UseVisualStyleBackColor = true;
            this.subscriberBtn.Click += new System.EventHandler(this.subscriberBtn_Click);
            // 
            // subscriber_movie_label
            // 
            this.subscriber_movie_label.AutoSize = true;
            this.subscriber_movie_label.Location = new System.Drawing.Point(7, 124);
            this.subscriber_movie_label.Name = "subscriber_movie_label";
            this.subscriber_movie_label.Size = new System.Drawing.Size(89, 13);
            this.subscriber_movie_label.TabIndex = 25;
            this.subscriber_movie_label.Text = "Subscriber Movie";
            // 
            // testFollowerBtn
            // 
            this.testFollowerBtn.Location = new System.Drawing.Point(318, 22);
            this.testFollowerBtn.Name = "testFollowerBtn";
            this.testFollowerBtn.Size = new System.Drawing.Size(39, 23);
            this.testFollowerBtn.TabIndex = 28;
            this.testFollowerBtn.Text = "Test";
            this.testFollowerBtn.UseVisualStyleBackColor = true;
            this.testFollowerBtn.Click += new System.EventHandler(this.testFollowerBtn_Click);
            // 
            // followerBtn
            // 
            this.followerBtn.Location = new System.Drawing.Point(280, 22);
            this.followerBtn.Name = "followerBtn";
            this.followerBtn.Size = new System.Drawing.Size(32, 23);
            this.followerBtn.TabIndex = 18;
            this.followerBtn.Text = "...";
            this.followerBtn.UseVisualStyleBackColor = true;
            this.followerBtn.Click += new System.EventHandler(this.followerBtn_Click);
            // 
            // donationBtn
            // 
            this.donationBtn.Location = new System.Drawing.Point(280, 98);
            this.donationBtn.Name = "donationBtn";
            this.donationBtn.Size = new System.Drawing.Size(32, 23);
            this.donationBtn.TabIndex = 24;
            this.donationBtn.Text = "...";
            this.donationBtn.UseVisualStyleBackColor = true;
            this.donationBtn.Click += new System.EventHandler(this.donationBtn_Click);
            // 
            // testHostBtn
            // 
            this.testHostBtn.Location = new System.Drawing.Point(318, 59);
            this.testHostBtn.Name = "testHostBtn";
            this.testHostBtn.Size = new System.Drawing.Size(39, 23);
            this.testHostBtn.TabIndex = 29;
            this.testHostBtn.Text = "Test";
            this.testHostBtn.UseVisualStyleBackColor = true;
            this.testHostBtn.Click += new System.EventHandler(this.testHostBtn_Click);
            // 
            // host_movie_label
            // 
            this.host_movie_label.AutoSize = true;
            this.host_movie_label.Location = new System.Drawing.Point(7, 46);
            this.host_movie_label.Name = "host_movie_label";
            this.host_movie_label.Size = new System.Drawing.Size(61, 13);
            this.host_movie_label.TabIndex = 19;
            this.host_movie_label.Text = "Host Movie";
            // 
            // testDonationBtn
            // 
            this.testDonationBtn.Location = new System.Drawing.Point(318, 98);
            this.testDonationBtn.Name = "testDonationBtn";
            this.testDonationBtn.Size = new System.Drawing.Size(39, 23);
            this.testDonationBtn.TabIndex = 30;
            this.testDonationBtn.Text = "Test";
            this.testDonationBtn.UseVisualStyleBackColor = true;
            this.testDonationBtn.Click += new System.EventHandler(this.testDonationBtn_Click);
            // 
            // donation_movie_label
            // 
            this.donation_movie_label.AutoSize = true;
            this.donation_movie_label.Location = new System.Drawing.Point(7, 85);
            this.donation_movie_label.Name = "donation_movie_label";
            this.donation_movie_label.Size = new System.Drawing.Size(82, 13);
            this.donation_movie_label.TabIndex = 22;
            this.donation_movie_label.Text = "Donation Movie";
            // 
            // testSubscriberBtn
            // 
            this.testSubscriberBtn.Location = new System.Drawing.Point(318, 138);
            this.testSubscriberBtn.Name = "testSubscriberBtn";
            this.testSubscriberBtn.Size = new System.Drawing.Size(39, 23);
            this.testSubscriberBtn.TabIndex = 31;
            this.testSubscriberBtn.Text = "Test";
            this.testSubscriberBtn.UseVisualStyleBackColor = true;
            this.testSubscriberBtn.Click += new System.EventHandler(this.testSubscriberBtn_Click);
            // 
            // hostBtn
            // 
            this.hostBtn.Location = new System.Drawing.Point(280, 59);
            this.hostBtn.Name = "hostBtn";
            this.hostBtn.Size = new System.Drawing.Size(32, 23);
            this.hostBtn.TabIndex = 21;
            this.hostBtn.Text = "...";
            this.hostBtn.UseVisualStyleBackColor = true;
            this.hostBtn.Click += new System.EventHandler(this.hostBtn_Click);
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 292);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigurationWindow";
            this.Text = "Twitchdouken - Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationWindow_FormClosing);
            this.Load += new System.EventHandler(this.ConfigurationWindow_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.activeAlertBox.ResumeLayout(false);
            this.activeAlertBox.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.tabPage8.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alertHeightNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertWidthNum)).EndInit();
            this.testChromaKeyBtn.ResumeLayout(false);
            this.testChromaKeyBtn.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.tabPage6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveMovieCfgBtn;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        internal System.Windows.Forms.TextBox TAAccessTokenBox;
        private System.Windows.Forms.Label TAAccessTokenLabel;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox testChromaKeyBtn;
        private System.Windows.Forms.Button colorPickerBtn;
        public System.Windows.Forms.Label chromaKeySample;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Label follower_movie_label;
        internal System.Windows.Forms.TextBox followerTxtBox;
        internal System.Windows.Forms.TextBox subscriberTxtBox;
        internal System.Windows.Forms.TextBox donationTxtBox;
        internal System.Windows.Forms.TextBox hostTxtBox;
        private System.Windows.Forms.Button subscriberBtn;
        private System.Windows.Forms.Label subscriber_movie_label;
        private System.Windows.Forms.Button testFollowerBtn;
        private System.Windows.Forms.Button followerBtn;
        private System.Windows.Forms.Button donationBtn;
        private System.Windows.Forms.Button testHostBtn;
        private System.Windows.Forms.Label host_movie_label;
        private System.Windows.Forms.Button testDonationBtn;
        private System.Windows.Forms.Label donation_movie_label;
        private System.Windows.Forms.Button testSubscriberBtn;
        private System.Windows.Forms.Button hostBtn;
        private System.Windows.Forms.Button loadMovieCfgBtn;
        private System.Windows.Forms.Button newMovieCfgBtn;
        private System.Windows.Forms.TextBox movieConfigBox;
        private System.Windows.Forms.Label configuration_label;
        private System.Windows.Forms.Button saveAllBtn;
        private System.Windows.Forms.GroupBox activeAlertBox;
        internal System.Windows.Forms.CheckBox donationBox;
        private System.Windows.Forms.Label activeDonationLabel;
        internal System.Windows.Forms.CheckBox hostBox;
        private System.Windows.Forms.Label activeHostLabel;
        internal System.Windows.Forms.CheckBox subscriberBox;
        internal System.Windows.Forms.CheckBox followerBox;
        private System.Windows.Forms.Label activeSubscriberLabel;
        private System.Windows.Forms.Label activeFollowerLabel;
        private System.Windows.Forms.Label runAtStartLabel;
        internal System.Windows.Forms.CheckBox runAtStartBox;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage7;
        internal System.Windows.Forms.TextBox ircOAuthBox;
        internal System.Windows.Forms.TextBox channelBox;
        private System.Windows.Forms.Label ircOAuthLabel;
        private System.Windows.Forms.Label channelLabel;
        private System.Windows.Forms.TabPage tabPage8;
        internal System.Windows.Forms.TextBox subscriberOAuthBox;
        private System.Windows.Forms.Label subscriberOAuthLabel;
        private System.Windows.Forms.TextBox chromaHexBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button chromaTestBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button alertResizeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown alertHeightNum;
        private System.Windows.Forms.NumericUpDown alertWidthNum;

    }
}