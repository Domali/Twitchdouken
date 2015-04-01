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
            this.cfgBtn = new System.Windows.Forms.Button();
            this.alertBtn = new System.Windows.Forms.Button();
            this.followBox = new System.Windows.Forms.ListBox();
            this.followLabel = new System.Windows.Forms.Label();
            this.followTimeLabel = new System.Windows.Forms.Label();
            this.subscriberBox = new System.Windows.Forms.ListBox();
            this.subscriberLabel = new System.Windows.Forms.Label();
            this.hostBox = new System.Windows.Forms.ListBox();
            this.hostLabel = new System.Windows.Forms.Label();
            this.subscriberTimeLabel = new System.Windows.Forms.Label();
            this.hostTimeLabel = new System.Windows.Forms.Label();
            this.donationBox = new System.Windows.Forms.ListBox();
            this.donationLabel = new System.Windows.Forms.Label();
            this.followerChkBox = new System.Windows.Forms.CheckBox();
            this.subscriberChkBox = new System.Windows.Forms.CheckBox();
            this.hostChkBox = new System.Windows.Forms.CheckBox();
            this.donationChkBox = new System.Windows.Forms.CheckBox();
            this.donationTimeLabel = new System.Windows.Forms.Label();
            this.amountLabel = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.commentLabel = new System.Windows.Forms.Label();
            this.commentBox = new System.Windows.Forms.TextBox();
            this.UIUpdater = new System.Windows.Forms.Timer(this.components);
            this.startStopBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cfgBtn
            // 
            this.cfgBtn.Location = new System.Drawing.Point(14, 308);
            this.cfgBtn.Name = "cfgBtn";
            this.cfgBtn.Size = new System.Drawing.Size(119, 23);
            this.cfgBtn.TabIndex = 0;
            this.cfgBtn.Text = "Show Configuration";
            this.cfgBtn.UseVisualStyleBackColor = true;
            this.cfgBtn.Click += new System.EventHandler(this.cfgBtn_Click);
            // 
            // alertBtn
            // 
            this.alertBtn.Location = new System.Drawing.Point(139, 308);
            this.alertBtn.Name = "alertBtn";
            this.alertBtn.Size = new System.Drawing.Size(119, 23);
            this.alertBtn.TabIndex = 1;
            this.alertBtn.Text = "Show Alert";
            this.alertBtn.UseVisualStyleBackColor = true;
            this.alertBtn.Click += new System.EventHandler(this.alertBtn_Click);
            // 
            // followBox
            // 
            this.followBox.FormattingEnabled = true;
            this.followBox.Location = new System.Drawing.Point(12, 25);
            this.followBox.Name = "followBox";
            this.followBox.Size = new System.Drawing.Size(163, 264);
            this.followBox.TabIndex = 2;
            // 
            // followLabel
            // 
            this.followLabel.AutoSize = true;
            this.followLabel.Location = new System.Drawing.Point(11, 9);
            this.followLabel.Name = "followLabel";
            this.followLabel.Size = new System.Drawing.Size(89, 13);
            this.followLabel.TabIndex = 3;
            this.followLabel.Text = "Recent Followers";
            // 
            // followTimeLabel
            // 
            this.followTimeLabel.AutoSize = true;
            this.followTimeLabel.Location = new System.Drawing.Point(12, 292);
            this.followTimeLabel.Name = "followTimeLabel";
            this.followTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.followTimeLabel.TabIndex = 4;
            // 
            // subscriberBox
            // 
            this.subscriberBox.FormattingEnabled = true;
            this.subscriberBox.Location = new System.Drawing.Point(181, 25);
            this.subscriberBox.Name = "subscriberBox";
            this.subscriberBox.Size = new System.Drawing.Size(163, 264);
            this.subscriberBox.TabIndex = 5;
            // 
            // subscriberLabel
            // 
            this.subscriberLabel.AutoSize = true;
            this.subscriberLabel.Location = new System.Drawing.Point(180, 9);
            this.subscriberLabel.Name = "subscriberLabel";
            this.subscriberLabel.Size = new System.Drawing.Size(100, 13);
            this.subscriberLabel.TabIndex = 6;
            this.subscriberLabel.Text = "Recent Subscribers";
            // 
            // hostBox
            // 
            this.hostBox.FormattingEnabled = true;
            this.hostBox.Location = new System.Drawing.Point(350, 25);
            this.hostBox.Name = "hostBox";
            this.hostBox.Size = new System.Drawing.Size(163, 264);
            this.hostBox.TabIndex = 7;
            // 
            // hostLabel
            // 
            this.hostLabel.AutoSize = true;
            this.hostLabel.Location = new System.Drawing.Point(347, 9);
            this.hostLabel.Name = "hostLabel";
            this.hostLabel.Size = new System.Drawing.Size(72, 13);
            this.hostLabel.TabIndex = 8;
            this.hostLabel.Text = "Recent Hosts";
            // 
            // subscriberTimeLabel
            // 
            this.subscriberTimeLabel.AutoSize = true;
            this.subscriberTimeLabel.Location = new System.Drawing.Point(180, 292);
            this.subscriberTimeLabel.Name = "subscriberTimeLabel";
            this.subscriberTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.subscriberTimeLabel.TabIndex = 9;
            // 
            // hostTimeLabel
            // 
            this.hostTimeLabel.AutoSize = true;
            this.hostTimeLabel.Location = new System.Drawing.Point(350, 292);
            this.hostTimeLabel.Name = "hostTimeLabel";
            this.hostTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.hostTimeLabel.TabIndex = 10;
            // 
            // donationBox
            // 
            this.donationBox.FormattingEnabled = true;
            this.donationBox.Location = new System.Drawing.Point(519, 25);
            this.donationBox.Name = "donationBox";
            this.donationBox.Size = new System.Drawing.Size(163, 264);
            this.donationBox.TabIndex = 11;
            this.donationBox.SelectedIndexChanged += new System.EventHandler(this.donationBox_SelectedIndexChanged);
            // 
            // donationLabel
            // 
            this.donationLabel.AutoSize = true;
            this.donationLabel.Location = new System.Drawing.Point(516, 9);
            this.donationLabel.Name = "donationLabel";
            this.donationLabel.Size = new System.Drawing.Size(93, 13);
            this.donationLabel.TabIndex = 12;
            this.donationLabel.Text = "Recent Donations";
            // 
            // followerChkBox
            // 
            this.followerChkBox.AutoSize = true;
            this.followerChkBox.Location = new System.Drawing.Point(160, 292);
            this.followerChkBox.Name = "followerChkBox";
            this.followerChkBox.Size = new System.Drawing.Size(15, 14);
            this.followerChkBox.TabIndex = 13;
            this.followerChkBox.UseVisualStyleBackColor = true;
            // 
            // subscriberChkBox
            // 
            this.subscriberChkBox.AutoSize = true;
            this.subscriberChkBox.Location = new System.Drawing.Point(329, 291);
            this.subscriberChkBox.Name = "subscriberChkBox";
            this.subscriberChkBox.Size = new System.Drawing.Size(15, 14);
            this.subscriberChkBox.TabIndex = 14;
            this.subscriberChkBox.UseVisualStyleBackColor = true;
            // 
            // hostChkBox
            // 
            this.hostChkBox.AutoSize = true;
            this.hostChkBox.Location = new System.Drawing.Point(498, 292);
            this.hostChkBox.Name = "hostChkBox";
            this.hostChkBox.Size = new System.Drawing.Size(15, 14);
            this.hostChkBox.TabIndex = 15;
            this.hostChkBox.UseVisualStyleBackColor = true;
            // 
            // donationChkBox
            // 
            this.donationChkBox.AutoSize = true;
            this.donationChkBox.Location = new System.Drawing.Point(667, 291);
            this.donationChkBox.Name = "donationChkBox";
            this.donationChkBox.Size = new System.Drawing.Size(15, 14);
            this.donationChkBox.TabIndex = 16;
            this.donationChkBox.UseVisualStyleBackColor = true;
            // 
            // donationTimeLabel
            // 
            this.donationTimeLabel.AutoSize = true;
            this.donationTimeLabel.Location = new System.Drawing.Point(519, 292);
            this.donationTimeLabel.Name = "donationTimeLabel";
            this.donationTimeLabel.Size = new System.Drawing.Size(0, 13);
            this.donationTimeLabel.TabIndex = 17;
            // 
            // amountLabel
            // 
            this.amountLabel.AutoSize = true;
            this.amountLabel.Location = new System.Drawing.Point(688, 9);
            this.amountLabel.Name = "amountLabel";
            this.amountLabel.Size = new System.Drawing.Size(43, 13);
            this.amountLabel.TabIndex = 18;
            this.amountLabel.Text = "Amount";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(688, 25);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(163, 20);
            this.amountBox.TabIndex = 19;
            // 
            // commentLabel
            // 
            this.commentLabel.AutoSize = true;
            this.commentLabel.Location = new System.Drawing.Point(688, 48);
            this.commentLabel.Name = "commentLabel";
            this.commentLabel.Size = new System.Drawing.Size(51, 13);
            this.commentLabel.TabIndex = 20;
            this.commentLabel.Text = "Comment";
            // 
            // commentBox
            // 
            this.commentBox.Location = new System.Drawing.Point(688, 64);
            this.commentBox.Multiline = true;
            this.commentBox.Name = "commentBox";
            this.commentBox.Size = new System.Drawing.Size(163, 225);
            this.commentBox.TabIndex = 21;
            // 
            // UIUpdater
            // 
            this.UIUpdater.Tick += new System.EventHandler(this.UIUpdater_Tick);
            // 
            // startStopBtn
            // 
            this.startStopBtn.Location = new System.Drawing.Point(776, 308);
            this.startStopBtn.Name = "startStopBtn";
            this.startStopBtn.Size = new System.Drawing.Size(75, 23);
            this.startStopBtn.TabIndex = 22;
            this.startStopBtn.Text = "Start";
            this.startStopBtn.UseVisualStyleBackColor = true;
            this.startStopBtn.Click += new System.EventHandler(this.startStopBtn_Click);
            // 
            // Twitchdouken
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 337);
            this.Controls.Add(this.startStopBtn);
            this.Controls.Add(this.commentBox);
            this.Controls.Add(this.commentLabel);
            this.Controls.Add(this.amountBox);
            this.Controls.Add(this.amountLabel);
            this.Controls.Add(this.donationTimeLabel);
            this.Controls.Add(this.donationChkBox);
            this.Controls.Add(this.hostChkBox);
            this.Controls.Add(this.subscriberChkBox);
            this.Controls.Add(this.followerChkBox);
            this.Controls.Add(this.donationLabel);
            this.Controls.Add(this.donationBox);
            this.Controls.Add(this.hostTimeLabel);
            this.Controls.Add(this.subscriberTimeLabel);
            this.Controls.Add(this.hostLabel);
            this.Controls.Add(this.hostBox);
            this.Controls.Add(this.subscriberLabel);
            this.Controls.Add(this.subscriberBox);
            this.Controls.Add(this.followTimeLabel);
            this.Controls.Add(this.followLabel);
            this.Controls.Add(this.followBox);
            this.Controls.Add(this.alertBtn);
            this.Controls.Add(this.cfgBtn);
            this.Name = "Twitchdouken";
            this.Text = "Twitchdouken";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cfgBtn;
        private System.Windows.Forms.Button alertBtn;
        private System.Windows.Forms.ListBox followBox;
        private System.Windows.Forms.Label followLabel;
        private System.Windows.Forms.Label followTimeLabel;
        private System.Windows.Forms.ListBox subscriberBox;
        private System.Windows.Forms.Label subscriberLabel;
        private System.Windows.Forms.ListBox hostBox;
        private System.Windows.Forms.Label hostLabel;
        private System.Windows.Forms.Label subscriberTimeLabel;
        private System.Windows.Forms.Label hostTimeLabel;
        private System.Windows.Forms.ListBox donationBox;
        private System.Windows.Forms.Label donationLabel;
        private System.Windows.Forms.CheckBox followerChkBox;
        private System.Windows.Forms.CheckBox subscriberChkBox;
        private System.Windows.Forms.CheckBox hostChkBox;
        private System.Windows.Forms.CheckBox donationChkBox;
        private System.Windows.Forms.Label donationTimeLabel;
        private System.Windows.Forms.Label amountLabel;
        private System.Windows.Forms.TextBox amountBox;
        private System.Windows.Forms.Label commentLabel;
        private System.Windows.Forms.TextBox commentBox;
        private System.Windows.Forms.Timer UIUpdater;
        internal System.Windows.Forms.Button startStopBtn;

    }
}

