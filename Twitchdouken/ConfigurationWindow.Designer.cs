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
            this.movieCfg = new System.Windows.Forms.TabPage();
            this.defaultMovieCfgBtn = new System.Windows.Forms.Button();
            this.follower_movie_label = new System.Windows.Forms.Label();
            this.followerTxtBox = new System.Windows.Forms.TextBox();
            this.subscriberTxtBox = new System.Windows.Forms.TextBox();
            this.movieConfigBox = new System.Windows.Forms.TextBox();
            this.donationTxtBox = new System.Windows.Forms.TextBox();
            this.hostTxtBox = new System.Windows.Forms.TextBox();
            this.newMovieCfgBtn = new System.Windows.Forms.Button();
            this.subscriberBtn = new System.Windows.Forms.Button();
            this.subscriber_movie_label = new System.Windows.Forms.Label();
            this.configuration_label = new System.Windows.Forms.Label();
            this.testFollowerBtn = new System.Windows.Forms.Button();
            this.followerBtn = new System.Windows.Forms.Button();
            this.donationBtn = new System.Windows.Forms.Button();
            this.testHostBtn = new System.Windows.Forms.Button();
            this.host_movie_label = new System.Windows.Forms.Label();
            this.saveMovieCfgBtn = new System.Windows.Forms.Button();
            this.testDonationButton = new System.Windows.Forms.Button();
            this.donation_movie_label = new System.Windows.Forms.Label();
            this.loadMovieCfgBtn = new System.Windows.Forms.Button();
            this.testSubscriberBtn = new System.Windows.Forms.Button();
            this.hostBtn = new System.Windows.Forms.Button();
            this.twitchAlertCfg = new System.Windows.Forms.TabPage();
            this.TAAccessTokenBox = new System.Windows.Forms.TextBox();
            this.TAAccessTokenLabel = new System.Windows.Forms.Label();
            this.twitchAPICfg = new System.Windows.Forms.TabPage();
            this.subscriberOAuthBox = new System.Windows.Forms.TextBox();
            this.ircOAuthBox = new System.Windows.Forms.TextBox();
            this.channelBox = new System.Windows.Forms.TextBox();
            this.subscriberOAuthLabel = new System.Windows.Forms.Label();
            this.ircOAuthLabel = new System.Windows.Forms.Label();
            this.channelLabel = new System.Windows.Forms.Label();
            this.generalCfg = new System.Windows.Forms.TabPage();
            this.activeAlertBox = new System.Windows.Forms.GroupBox();
            this.donationBox = new System.Windows.Forms.CheckBox();
            this.activeDonationLabel = new System.Windows.Forms.Label();
            this.hostBox = new System.Windows.Forms.CheckBox();
            this.activeHostLabel = new System.Windows.Forms.Label();
            this.subscriberBox = new System.Windows.Forms.CheckBox();
            this.followerBox = new System.Windows.Forms.CheckBox();
            this.activeSubscriberLabel = new System.Windows.Forms.Label();
            this.activeFollowerLabel = new System.Windows.Forms.Label();
            this.saveAllBtn = new System.Windows.Forms.Button();
            this.setDefaultMovieBtn = new System.Windows.Forms.Button();
            this.defaultMovieCfgBox = new System.Windows.Forms.TextBox();
            this.defaultMovieLabel = new System.Windows.Forms.Label();
            this.configTabCtrl = new System.Windows.Forms.TabControl();
            this.runAtStartBox = new System.Windows.Forms.CheckBox();
            this.runAtStartLabel = new System.Windows.Forms.Label();
            this.movieCfg.SuspendLayout();
            this.twitchAlertCfg.SuspendLayout();
            this.twitchAPICfg.SuspendLayout();
            this.generalCfg.SuspendLayout();
            this.activeAlertBox.SuspendLayout();
            this.configTabCtrl.SuspendLayout();
            this.SuspendLayout();
            // 
            // movieCfg
            // 
            this.movieCfg.Controls.Add(this.defaultMovieCfgBtn);
            this.movieCfg.Controls.Add(this.follower_movie_label);
            this.movieCfg.Controls.Add(this.followerTxtBox);
            this.movieCfg.Controls.Add(this.subscriberTxtBox);
            this.movieCfg.Controls.Add(this.movieConfigBox);
            this.movieCfg.Controls.Add(this.donationTxtBox);
            this.movieCfg.Controls.Add(this.hostTxtBox);
            this.movieCfg.Controls.Add(this.newMovieCfgBtn);
            this.movieCfg.Controls.Add(this.subscriberBtn);
            this.movieCfg.Controls.Add(this.subscriber_movie_label);
            this.movieCfg.Controls.Add(this.configuration_label);
            this.movieCfg.Controls.Add(this.testFollowerBtn);
            this.movieCfg.Controls.Add(this.followerBtn);
            this.movieCfg.Controls.Add(this.donationBtn);
            this.movieCfg.Controls.Add(this.testHostBtn);
            this.movieCfg.Controls.Add(this.host_movie_label);
            this.movieCfg.Controls.Add(this.saveMovieCfgBtn);
            this.movieCfg.Controls.Add(this.testDonationButton);
            this.movieCfg.Controls.Add(this.donation_movie_label);
            this.movieCfg.Controls.Add(this.loadMovieCfgBtn);
            this.movieCfg.Controls.Add(this.testSubscriberBtn);
            this.movieCfg.Controls.Add(this.hostBtn);
            this.movieCfg.Location = new System.Drawing.Point(4, 22);
            this.movieCfg.Name = "movieCfg";
            this.movieCfg.Padding = new System.Windows.Forms.Padding(3);
            this.movieCfg.Size = new System.Drawing.Size(399, 243);
            this.movieCfg.TabIndex = 0;
            this.movieCfg.Text = "Movie";
            this.movieCfg.UseVisualStyleBackColor = true;
            // 
            // defaultMovieCfgBtn
            // 
            this.defaultMovieCfgBtn.Location = new System.Drawing.Point(316, 177);
            this.defaultMovieCfgBtn.Name = "defaultMovieCfgBtn";
            this.defaultMovieCfgBtn.Size = new System.Drawing.Size(77, 23);
            this.defaultMovieCfgBtn.TabIndex = 22;
            this.defaultMovieCfgBtn.Text = "Set Default";
            this.defaultMovieCfgBtn.UseVisualStyleBackColor = true;
            this.defaultMovieCfgBtn.Click += new System.EventHandler(this.defaultMovieCfgBtn_Click);
            // 
            // follower_movie_label
            // 
            this.follower_movie_label.AutoSize = true;
            this.follower_movie_label.Location = new System.Drawing.Point(3, 3);
            this.follower_movie_label.Name = "follower_movie_label";
            this.follower_movie_label.Size = new System.Drawing.Size(78, 13);
            this.follower_movie_label.TabIndex = 0;
            this.follower_movie_label.Text = "Follower Movie";
            // 
            // followerTxtBox
            // 
            this.followerTxtBox.Location = new System.Drawing.Point(6, 21);
            this.followerTxtBox.Name = "followerTxtBox";
            this.followerTxtBox.Size = new System.Drawing.Size(304, 20);
            this.followerTxtBox.TabIndex = 1;
            // 
            // subscriberTxtBox
            // 
            this.subscriberTxtBox.Location = new System.Drawing.Point(6, 136);
            this.subscriberTxtBox.Name = "subscriberTxtBox";
            this.subscriberTxtBox.Size = new System.Drawing.Size(304, 20);
            this.subscriberTxtBox.TabIndex = 10;
            // 
            // movieConfigBox
            // 
            this.movieConfigBox.Location = new System.Drawing.Point(6, 179);
            this.movieConfigBox.Name = "movieConfigBox";
            this.movieConfigBox.ReadOnly = true;
            this.movieConfigBox.Size = new System.Drawing.Size(304, 20);
            this.movieConfigBox.TabIndex = 18;
            // 
            // donationTxtBox
            // 
            this.donationTxtBox.Location = new System.Drawing.Point(6, 97);
            this.donationTxtBox.Name = "donationTxtBox";
            this.donationTxtBox.Size = new System.Drawing.Size(304, 20);
            this.donationTxtBox.TabIndex = 7;
            // 
            // hostTxtBox
            // 
            this.hostTxtBox.Location = new System.Drawing.Point(6, 58);
            this.hostTxtBox.Name = "hostTxtBox";
            this.hostTxtBox.Size = new System.Drawing.Size(304, 20);
            this.hostTxtBox.TabIndex = 4;
            // 
            // newMovieCfgBtn
            // 
            this.newMovieCfgBtn.Location = new System.Drawing.Point(6, 212);
            this.newMovieCfgBtn.Name = "newMovieCfgBtn";
            this.newMovieCfgBtn.Size = new System.Drawing.Size(75, 23);
            this.newMovieCfgBtn.TabIndex = 21;
            this.newMovieCfgBtn.Text = "New Config";
            this.newMovieCfgBtn.UseVisualStyleBackColor = true;
            this.newMovieCfgBtn.Click += new System.EventHandler(this.newMovieCfgBtn_Click);
            // 
            // subscriberBtn
            // 
            this.subscriberBtn.Location = new System.Drawing.Point(316, 135);
            this.subscriberBtn.Name = "subscriberBtn";
            this.subscriberBtn.Size = new System.Drawing.Size(32, 23);
            this.subscriberBtn.TabIndex = 11;
            this.subscriberBtn.Text = "...";
            this.subscriberBtn.UseVisualStyleBackColor = true;
            this.subscriberBtn.Click += new System.EventHandler(this.subscriberBtn_Click);
            // 
            // subscriber_movie_label
            // 
            this.subscriber_movie_label.AutoSize = true;
            this.subscriber_movie_label.Location = new System.Drawing.Point(3, 120);
            this.subscriber_movie_label.Name = "subscriber_movie_label";
            this.subscriber_movie_label.Size = new System.Drawing.Size(89, 13);
            this.subscriber_movie_label.TabIndex = 9;
            this.subscriber_movie_label.Text = "Subscriber Movie";
            // 
            // configuration_label
            // 
            this.configuration_label.AutoSize = true;
            this.configuration_label.Location = new System.Drawing.Point(6, 163);
            this.configuration_label.Name = "configuration_label";
            this.configuration_label.Size = new System.Drawing.Size(88, 13);
            this.configuration_label.TabIndex = 19;
            this.configuration_label.Text = "Configuration File";
            // 
            // testFollowerBtn
            // 
            this.testFollowerBtn.Location = new System.Drawing.Point(354, 19);
            this.testFollowerBtn.Name = "testFollowerBtn";
            this.testFollowerBtn.Size = new System.Drawing.Size(39, 23);
            this.testFollowerBtn.TabIndex = 12;
            this.testFollowerBtn.Text = "Test";
            this.testFollowerBtn.UseVisualStyleBackColor = true;
            this.testFollowerBtn.Click += new System.EventHandler(this.testFollowerBtn_Click);
            // 
            // followerBtn
            // 
            this.followerBtn.Location = new System.Drawing.Point(316, 19);
            this.followerBtn.Name = "followerBtn";
            this.followerBtn.Size = new System.Drawing.Size(32, 23);
            this.followerBtn.TabIndex = 2;
            this.followerBtn.Text = "...";
            this.followerBtn.UseVisualStyleBackColor = true;
            this.followerBtn.Click += new System.EventHandler(this.followerBtn_Click);
            // 
            // donationBtn
            // 
            this.donationBtn.Location = new System.Drawing.Point(316, 95);
            this.donationBtn.Name = "donationBtn";
            this.donationBtn.Size = new System.Drawing.Size(32, 23);
            this.donationBtn.TabIndex = 8;
            this.donationBtn.Text = "...";
            this.donationBtn.UseVisualStyleBackColor = true;
            this.donationBtn.Click += new System.EventHandler(this.donationBtn_Click);
            // 
            // testHostBtn
            // 
            this.testHostBtn.Location = new System.Drawing.Point(354, 56);
            this.testHostBtn.Name = "testHostBtn";
            this.testHostBtn.Size = new System.Drawing.Size(39, 23);
            this.testHostBtn.TabIndex = 13;
            this.testHostBtn.Text = "Test";
            this.testHostBtn.UseVisualStyleBackColor = true;
            this.testHostBtn.Click += new System.EventHandler(this.testHostBtn_Click);
            // 
            // host_movie_label
            // 
            this.host_movie_label.AutoSize = true;
            this.host_movie_label.Location = new System.Drawing.Point(3, 42);
            this.host_movie_label.Name = "host_movie_label";
            this.host_movie_label.Size = new System.Drawing.Size(61, 13);
            this.host_movie_label.TabIndex = 3;
            this.host_movie_label.Text = "Host Movie";
            // 
            // saveMovieCfgBtn
            // 
            this.saveMovieCfgBtn.Location = new System.Drawing.Point(168, 212);
            this.saveMovieCfgBtn.Name = "saveMovieCfgBtn";
            this.saveMovieCfgBtn.Size = new System.Drawing.Size(75, 23);
            this.saveMovieCfgBtn.TabIndex = 17;
            this.saveMovieCfgBtn.Text = "Save Config";
            this.saveMovieCfgBtn.UseVisualStyleBackColor = true;
            this.saveMovieCfgBtn.Click += new System.EventHandler(this.saveMovieCfgBtn_Click);
            // 
            // testDonationButton
            // 
            this.testDonationButton.Location = new System.Drawing.Point(354, 95);
            this.testDonationButton.Name = "testDonationButton";
            this.testDonationButton.Size = new System.Drawing.Size(39, 23);
            this.testDonationButton.TabIndex = 14;
            this.testDonationButton.Text = "Test";
            this.testDonationButton.UseVisualStyleBackColor = true;
            this.testDonationButton.Click += new System.EventHandler(this.testDonationButton_Click);
            // 
            // donation_movie_label
            // 
            this.donation_movie_label.AutoSize = true;
            this.donation_movie_label.Location = new System.Drawing.Point(3, 81);
            this.donation_movie_label.Name = "donation_movie_label";
            this.donation_movie_label.Size = new System.Drawing.Size(82, 13);
            this.donation_movie_label.TabIndex = 6;
            this.donation_movie_label.Text = "Donation Movie";
            // 
            // loadMovieCfgBtn
            // 
            this.loadMovieCfgBtn.Location = new System.Drawing.Point(87, 212);
            this.loadMovieCfgBtn.Name = "loadMovieCfgBtn";
            this.loadMovieCfgBtn.Size = new System.Drawing.Size(75, 23);
            this.loadMovieCfgBtn.TabIndex = 16;
            this.loadMovieCfgBtn.Text = "Load Config";
            this.loadMovieCfgBtn.UseVisualStyleBackColor = true;
            this.loadMovieCfgBtn.Click += new System.EventHandler(this.loadMovieCfgBtn_Click);
            // 
            // testSubscriberBtn
            // 
            this.testSubscriberBtn.Location = new System.Drawing.Point(354, 135);
            this.testSubscriberBtn.Name = "testSubscriberBtn";
            this.testSubscriberBtn.Size = new System.Drawing.Size(39, 23);
            this.testSubscriberBtn.TabIndex = 15;
            this.testSubscriberBtn.Text = "Test";
            this.testSubscriberBtn.UseVisualStyleBackColor = true;
            this.testSubscriberBtn.Click += new System.EventHandler(this.testSubscriberBtn_Click);
            // 
            // hostBtn
            // 
            this.hostBtn.Location = new System.Drawing.Point(316, 56);
            this.hostBtn.Name = "hostBtn";
            this.hostBtn.Size = new System.Drawing.Size(32, 23);
            this.hostBtn.TabIndex = 5;
            this.hostBtn.Text = "...";
            this.hostBtn.UseVisualStyleBackColor = true;
            this.hostBtn.Click += new System.EventHandler(this.hostBtn_Click);
            // 
            // twitchAlertCfg
            // 
            this.twitchAlertCfg.Controls.Add(this.TAAccessTokenBox);
            this.twitchAlertCfg.Controls.Add(this.TAAccessTokenLabel);
            this.twitchAlertCfg.Location = new System.Drawing.Point(4, 22);
            this.twitchAlertCfg.Name = "twitchAlertCfg";
            this.twitchAlertCfg.Size = new System.Drawing.Size(399, 243);
            this.twitchAlertCfg.TabIndex = 3;
            this.twitchAlertCfg.Text = "TwitchAlert";
            this.twitchAlertCfg.UseVisualStyleBackColor = true;
            // 
            // TAAccessTokenBox
            // 
            this.TAAccessTokenBox.Location = new System.Drawing.Point(7, 21);
            this.TAAccessTokenBox.Name = "TAAccessTokenBox";
            this.TAAccessTokenBox.Size = new System.Drawing.Size(307, 20);
            this.TAAccessTokenBox.TabIndex = 1;
            // 
            // TAAccessTokenLabel
            // 
            this.TAAccessTokenLabel.AutoSize = true;
            this.TAAccessTokenLabel.Location = new System.Drawing.Point(4, 4);
            this.TAAccessTokenLabel.Name = "TAAccessTokenLabel";
            this.TAAccessTokenLabel.Size = new System.Drawing.Size(76, 13);
            this.TAAccessTokenLabel.TabIndex = 0;
            this.TAAccessTokenLabel.Text = "Access Token";
            // 
            // twitchAPICfg
            // 
            this.twitchAPICfg.Controls.Add(this.subscriberOAuthBox);
            this.twitchAPICfg.Controls.Add(this.ircOAuthBox);
            this.twitchAPICfg.Controls.Add(this.channelBox);
            this.twitchAPICfg.Controls.Add(this.subscriberOAuthLabel);
            this.twitchAPICfg.Controls.Add(this.ircOAuthLabel);
            this.twitchAPICfg.Controls.Add(this.channelLabel);
            this.twitchAPICfg.Location = new System.Drawing.Point(4, 22);
            this.twitchAPICfg.Name = "twitchAPICfg";
            this.twitchAPICfg.Size = new System.Drawing.Size(399, 243);
            this.twitchAPICfg.TabIndex = 2;
            this.twitchAPICfg.Text = "TwitchAPI";
            this.twitchAPICfg.UseVisualStyleBackColor = true;
            // 
            // subscriberOAuthBox
            // 
            this.subscriberOAuthBox.Location = new System.Drawing.Point(6, 105);
            this.subscriberOAuthBox.Name = "subscriberOAuthBox";
            this.subscriberOAuthBox.Size = new System.Drawing.Size(297, 20);
            this.subscriberOAuthBox.TabIndex = 5;
            // 
            // ircOAuthBox
            // 
            this.ircOAuthBox.Location = new System.Drawing.Point(6, 65);
            this.ircOAuthBox.Name = "ircOAuthBox";
            this.ircOAuthBox.Size = new System.Drawing.Size(297, 20);
            this.ircOAuthBox.TabIndex = 4;
            // 
            // channelBox
            // 
            this.channelBox.Location = new System.Drawing.Point(6, 26);
            this.channelBox.Name = "channelBox";
            this.channelBox.Size = new System.Drawing.Size(297, 20);
            this.channelBox.TabIndex = 3;
            // 
            // subscriberOAuthLabel
            // 
            this.subscriberOAuthLabel.AutoSize = true;
            this.subscriberOAuthLabel.Location = new System.Drawing.Point(3, 88);
            this.subscriberOAuthLabel.Name = "subscriberOAuthLabel";
            this.subscriberOAuthLabel.Size = new System.Drawing.Size(90, 13);
            this.subscriberOAuthLabel.TabIndex = 2;
            this.subscriberOAuthLabel.Text = "Subscriber OAuth";
            // 
            // ircOAuthLabel
            // 
            this.ircOAuthLabel.AutoSize = true;
            this.ircOAuthLabel.Location = new System.Drawing.Point(3, 49);
            this.ircOAuthLabel.Name = "ircOAuthLabel";
            this.ircOAuthLabel.Size = new System.Drawing.Size(58, 13);
            this.ircOAuthLabel.TabIndex = 1;
            this.ircOAuthLabel.Text = "IRC OAuth";
            // 
            // channelLabel
            // 
            this.channelLabel.AutoSize = true;
            this.channelLabel.Location = new System.Drawing.Point(3, 10);
            this.channelLabel.Name = "channelLabel";
            this.channelLabel.Size = new System.Drawing.Size(46, 13);
            this.channelLabel.TabIndex = 0;
            this.channelLabel.Text = "Channel";
            // 
            // generalCfg
            // 
            this.generalCfg.Controls.Add(this.runAtStartLabel);
            this.generalCfg.Controls.Add(this.runAtStartBox);
            this.generalCfg.Controls.Add(this.activeAlertBox);
            this.generalCfg.Controls.Add(this.saveAllBtn);
            this.generalCfg.Controls.Add(this.setDefaultMovieBtn);
            this.generalCfg.Controls.Add(this.defaultMovieCfgBox);
            this.generalCfg.Controls.Add(this.defaultMovieLabel);
            this.generalCfg.Location = new System.Drawing.Point(4, 22);
            this.generalCfg.Name = "generalCfg";
            this.generalCfg.Padding = new System.Windows.Forms.Padding(3);
            this.generalCfg.Size = new System.Drawing.Size(399, 243);
            this.generalCfg.TabIndex = 1;
            this.generalCfg.Text = "General";
            this.generalCfg.UseVisualStyleBackColor = true;
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
            this.activeAlertBox.Location = new System.Drawing.Point(10, 50);
            this.activeAlertBox.Name = "activeAlertBox";
            this.activeAlertBox.Size = new System.Drawing.Size(222, 60);
            this.activeAlertBox.TabIndex = 5;
            this.activeAlertBox.TabStop = false;
            this.activeAlertBox.Text = "Active Alerts";
            // 
            // donationBox
            // 
            this.donationBox.AutoSize = true;
            this.donationBox.Location = new System.Drawing.Point(196, 37);
            this.donationBox.Name = "donationBox";
            this.donationBox.Size = new System.Drawing.Size(15, 14);
            this.donationBox.TabIndex = 7;
            this.donationBox.UseVisualStyleBackColor = true;
            // 
            // activeDonationLabel
            // 
            this.activeDonationLabel.AutoSize = true;
            this.activeDonationLabel.Location = new System.Drawing.Point(121, 37);
            this.activeDonationLabel.Name = "activeDonationLabel";
            this.activeDonationLabel.Size = new System.Drawing.Size(74, 13);
            this.activeDonationLabel.TabIndex = 6;
            this.activeDonationLabel.Text = "Donation Alert";
            // 
            // hostBox
            // 
            this.hostBox.AutoSize = true;
            this.hostBox.Location = new System.Drawing.Point(196, 15);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(15, 14);
            this.hostBox.TabIndex = 5;
            this.hostBox.UseVisualStyleBackColor = true;
            // 
            // activeHostLabel
            // 
            this.activeHostLabel.AutoSize = true;
            this.activeHostLabel.Location = new System.Drawing.Point(137, 16);
            this.activeHostLabel.Name = "activeHostLabel";
            this.activeHostLabel.Size = new System.Drawing.Size(53, 13);
            this.activeHostLabel.TabIndex = 4;
            this.activeHostLabel.Text = "Host Alert";
            // 
            // subscriberBox
            // 
            this.subscriberBox.AutoSize = true;
            this.subscriberBox.Location = new System.Drawing.Point(98, 37);
            this.subscriberBox.Name = "subscriberBox";
            this.subscriberBox.Size = new System.Drawing.Size(15, 14);
            this.subscriberBox.TabIndex = 3;
            this.subscriberBox.UseVisualStyleBackColor = true;
            // 
            // followerBox
            // 
            this.followerBox.AutoSize = true;
            this.followerBox.Location = new System.Drawing.Point(98, 16);
            this.followerBox.Name = "followerBox";
            this.followerBox.Size = new System.Drawing.Size(15, 14);
            this.followerBox.TabIndex = 2;
            this.followerBox.UseVisualStyleBackColor = true;
            // 
            // activeSubscriberLabel
            // 
            this.activeSubscriberLabel.AutoSize = true;
            this.activeSubscriberLabel.Location = new System.Drawing.Point(10, 37);
            this.activeSubscriberLabel.Name = "activeSubscriberLabel";
            this.activeSubscriberLabel.Size = new System.Drawing.Size(81, 13);
            this.activeSubscriberLabel.TabIndex = 1;
            this.activeSubscriberLabel.Text = "Subscriber Alert";
            // 
            // activeFollowerLabel
            // 
            this.activeFollowerLabel.AutoSize = true;
            this.activeFollowerLabel.Location = new System.Drawing.Point(21, 16);
            this.activeFollowerLabel.Name = "activeFollowerLabel";
            this.activeFollowerLabel.Size = new System.Drawing.Size(70, 13);
            this.activeFollowerLabel.TabIndex = 0;
            this.activeFollowerLabel.Text = "Follower Alert";
            // 
            // saveAllBtn
            // 
            this.saveAllBtn.Location = new System.Drawing.Point(238, 87);
            this.saveAllBtn.Name = "saveAllBtn";
            this.saveAllBtn.Size = new System.Drawing.Size(105, 23);
            this.saveAllBtn.TabIndex = 3;
            this.saveAllBtn.Text = "Save Configuration";
            this.saveAllBtn.UseVisualStyleBackColor = true;
            this.saveAllBtn.Click += new System.EventHandler(this.saveAllBtn_Click);
            // 
            // setDefaultMovieBtn
            // 
            this.setDefaultMovieBtn.Location = new System.Drawing.Point(349, 22);
            this.setDefaultMovieBtn.Name = "setDefaultMovieBtn";
            this.setDefaultMovieBtn.Size = new System.Drawing.Size(44, 23);
            this.setDefaultMovieBtn.TabIndex = 2;
            this.setDefaultMovieBtn.Text = "Set";
            this.setDefaultMovieBtn.UseVisualStyleBackColor = true;
            this.setDefaultMovieBtn.Click += new System.EventHandler(this.setDefaultMovieBtn_Click);
            // 
            // defaultMovieCfgBox
            // 
            this.defaultMovieCfgBox.Location = new System.Drawing.Point(10, 24);
            this.defaultMovieCfgBox.Name = "defaultMovieCfgBox";
            this.defaultMovieCfgBox.ReadOnly = true;
            this.defaultMovieCfgBox.Size = new System.Drawing.Size(333, 20);
            this.defaultMovieCfgBox.TabIndex = 1;
            // 
            // defaultMovieLabel
            // 
            this.defaultMovieLabel.AutoSize = true;
            this.defaultMovieLabel.Location = new System.Drawing.Point(7, 7);
            this.defaultMovieLabel.Name = "defaultMovieLabel";
            this.defaultMovieLabel.Size = new System.Drawing.Size(157, 13);
            this.defaultMovieLabel.TabIndex = 0;
            this.defaultMovieLabel.Text = "Default Movie Configuration File";
            // 
            // configTabCtrl
            // 
            this.configTabCtrl.Controls.Add(this.generalCfg);
            this.configTabCtrl.Controls.Add(this.twitchAPICfg);
            this.configTabCtrl.Controls.Add(this.twitchAlertCfg);
            this.configTabCtrl.Controls.Add(this.movieCfg);
            this.configTabCtrl.Location = new System.Drawing.Point(12, 12);
            this.configTabCtrl.Name = "configTabCtrl";
            this.configTabCtrl.SelectedIndex = 0;
            this.configTabCtrl.Size = new System.Drawing.Size(407, 269);
            this.configTabCtrl.TabIndex = 25;
            // 
            // runAtStartBox
            // 
            this.runAtStartBox.AutoSize = true;
            this.runAtStartBox.Location = new System.Drawing.Point(328, 65);
            this.runAtStartBox.Name = "runAtStartBox";
            this.runAtStartBox.Size = new System.Drawing.Size(15, 14);
            this.runAtStartBox.TabIndex = 6;
            this.runAtStartBox.UseVisualStyleBackColor = true;
            // 
            // runAtStartLabel
            // 
            this.runAtStartLabel.AutoSize = true;
            this.runAtStartLabel.Location = new System.Drawing.Point(257, 65);
            this.runAtStartLabel.Name = "runAtStartLabel";
            this.runAtStartLabel.Size = new System.Drawing.Size(65, 13);
            this.runAtStartLabel.TabIndex = 7;
            this.runAtStartLabel.Text = "Run At Start";
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(427, 286);
            this.Controls.Add(this.configTabCtrl);
            this.Name = "ConfigurationWindow";
            this.Text = "Twitchdouken - Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigurationWindow_FormClosing);
            this.movieCfg.ResumeLayout(false);
            this.movieCfg.PerformLayout();
            this.twitchAlertCfg.ResumeLayout(false);
            this.twitchAlertCfg.PerformLayout();
            this.twitchAPICfg.ResumeLayout(false);
            this.twitchAPICfg.PerformLayout();
            this.generalCfg.ResumeLayout(false);
            this.generalCfg.PerformLayout();
            this.activeAlertBox.ResumeLayout(false);
            this.activeAlertBox.PerformLayout();
            this.configTabCtrl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage movieCfg;
        private System.Windows.Forms.Button defaultMovieCfgBtn;
        private System.Windows.Forms.Label follower_movie_label;
        internal System.Windows.Forms.TextBox followerTxtBox;
        internal System.Windows.Forms.TextBox subscriberTxtBox;
        private System.Windows.Forms.TextBox movieConfigBox;
        internal System.Windows.Forms.TextBox donationTxtBox;
        internal System.Windows.Forms.TextBox hostTxtBox;
        private System.Windows.Forms.Button newMovieCfgBtn;
        private System.Windows.Forms.Button subscriberBtn;
        private System.Windows.Forms.Label subscriber_movie_label;
        private System.Windows.Forms.Label configuration_label;
        private System.Windows.Forms.Button testFollowerBtn;
        private System.Windows.Forms.Button followerBtn;
        private System.Windows.Forms.Button donationBtn;
        private System.Windows.Forms.Button testHostBtn;
        private System.Windows.Forms.Label host_movie_label;
        private System.Windows.Forms.Button saveMovieCfgBtn;
        private System.Windows.Forms.Button testDonationButton;
        private System.Windows.Forms.Label donation_movie_label;
        private System.Windows.Forms.Button loadMovieCfgBtn;
        private System.Windows.Forms.Button testSubscriberBtn;
        private System.Windows.Forms.Button hostBtn;
        private System.Windows.Forms.TabPage twitchAlertCfg;
        private System.Windows.Forms.TabPage twitchAPICfg;
        private System.Windows.Forms.Label subscriberOAuthLabel;
        private System.Windows.Forms.Label ircOAuthLabel;
        private System.Windows.Forms.Label channelLabel;
        private System.Windows.Forms.TabPage generalCfg;
        private System.Windows.Forms.Button saveAllBtn;
        private System.Windows.Forms.Button setDefaultMovieBtn;
        private System.Windows.Forms.Label defaultMovieLabel;
        private System.Windows.Forms.TabControl configTabCtrl;
        private System.Windows.Forms.Label TAAccessTokenLabel;
        internal System.Windows.Forms.TextBox defaultMovieCfgBox;
        internal System.Windows.Forms.TextBox TAAccessTokenBox;
        internal System.Windows.Forms.TextBox subscriberOAuthBox;
        internal System.Windows.Forms.TextBox ircOAuthBox;
        internal System.Windows.Forms.TextBox channelBox;
        private System.Windows.Forms.GroupBox activeAlertBox;
        private System.Windows.Forms.Label activeDonationLabel;
        private System.Windows.Forms.Label activeHostLabel;
        private System.Windows.Forms.Label activeSubscriberLabel;
        private System.Windows.Forms.Label activeFollowerLabel;
        internal System.Windows.Forms.CheckBox donationBox;
        internal System.Windows.Forms.CheckBox hostBox;
        internal System.Windows.Forms.CheckBox subscriberBox;
        internal System.Windows.Forms.CheckBox followerBox;
        private System.Windows.Forms.Label runAtStartLabel;
        internal System.Windows.Forms.CheckBox runAtStartBox;

    }
}