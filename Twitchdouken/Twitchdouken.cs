using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitchdouken
{
    public partial class Twitchdouken : Form
    {
        private AlertWindow alertWindow;
        private ConfigurationWindow configWindow;
        private TwitchAPIHelper twitchHelper;
        private TwitchAlertAPIHelper taHelper;
        private TwitchIRCHelper ircHelper;
        private Thread twitchAPIThread;
        private Thread taThread;
        private bool running = false;
        static string flash_xml = "<invoke name=\"{0}\" returntype=\"xml\"><arguments><string>{1}</string></arguments></invoke>";

        public Twitchdouken()
        {
            InitializeComponent();
            alertWindow = new AlertWindow();
            configWindow = new ConfigurationWindow(this);
            alertWindow.Show();
            donationBox.DisplayMember = "name";
        }

        private void cfgBtn_Click(object sender, EventArgs e)
        {
            configWindow.Show();
        }

        private void alertBtn_Click(object sender, EventArgs e)
        {
            alertWindow.Show();
        }

        internal void playSubscriber(string subscriber, string months)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flash_xml, "setSubscriber", subscriber));
            function_calls.Add(string.Format(flash_xml, "setMonths", months));
            playFlash(configWindow.subscriberTxtBox.Text, function_calls);
        }

        internal void playFollower(string followers)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flash_xml, "setFollowers", followers));
            playFlash(configWindow.followerTxtBox.Text, function_calls);
        }

        internal void playHost(string name, string viewers)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flash_xml, "setLevel", viewers));
            function_calls.Add(string.Format(flash_xml, "setUser", name));
            playFlash(configWindow.hostTxtBox.Text, function_calls);
        }

        internal void playDonation(string name, string amount)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flash_xml, "setAmount", amount));
            function_calls.Add(string.Format(flash_xml, "setDonator", name));
            playFlash(configWindow.donationTxtBox.Text, function_calls);
        }

        internal void playFlash(string file_name, List<string> function_calls)
        {
            alertWindow.flashAlert.LoadMovie(0, file_name);
            alertWindow.flashAlert.Loop = false;
            foreach(string function_call in function_calls)
            {
                alertWindow.flashAlert.CallFunction(function_call);
            }
            alertWindow.flashAlert.Play();
        }

        private void UIUpdater_Tick(object sender, EventArgs e)
        {
            if(running == true)
            {
                followTimeLabel.Text = this.twitchHelper.getFollowUpdateTime();
                subscriberTimeLabel.Text = this.twitchHelper.getSubscriberUpdateTime();
                checkAndPlayALerts();
            }
            else if (!taThread.IsAlive && !twitchAPIThread.IsAlive) 
            {
                // Once the two threds are joined after a stop we have to finish killing everything
                // This is done in the timer so that we don't get an unresponsive GUI.
                this.ircHelper = null;
                this.twitchHelper = null;
                this.taHelper = null;
                this.configWindow.channelBox.ReadOnly = false;
                this.configWindow.ircOAuthBox.ReadOnly = false;
                this.configWindow.subscriberOAuthBox.ReadOnly = false;
                this.configWindow.TAAccessTokenBox.ReadOnly = false;
                this.configWindow.subscriberBox.Enabled = true;
                this.configWindow.followerBox.Enabled = true;
                this.configWindow.hostBox.Enabled = true;
                this.configWindow.donationBox.Enabled = true;
                GC.Collect();
                GC.WaitForPendingFinalizers();
                startStopBtn.Enabled = true;
                startStopBtn.Text = "Start";
                UIUpdater.Enabled = false;
            }       
        }

        private void checkAndPlayALerts()
        {
            if (!alertWindow.flashAlert.IsPlaying())
            {
                if (this.twitchHelper.newSubscriberCheck() && this.configWindow.subscriberBox.Checked == true)
                {
                    Subscriber new_subscriber = this.twitchHelper.getSubscriber();
                    this.subscriberBox.Items.Insert(0, new_subscriber.name);
                    this.playSubscriber(new_subscriber.name, "");
                }
                else if (this.ircHelper.newSubscriberCheck() && this.configWindow.subscriberBox.Checked == true)
                {
                    Subscriber new_subscriber = this.ircHelper.getSubscriber();
                    this.playSubscriber(new_subscriber.name, new_subscriber.months + " months");
                    this.subscriberBox.Items.Insert(0, new_subscriber.name + " (" + new_subscriber.months + ")");
                }
                else if (this.taHelper.newDonationCheck() && this.configWindow.donationBox.Checked == true)
                {
                    Donation new_donation = this.taHelper.getDonation();
                    this.playDonation(new_donation.name, "$" + new_donation.amount);
                    this.donationBox.Items.Insert(0, new_donation);
                    this.donationBox.SetSelected(0, true);
                }
                else if (this.ircHelper.newHostCheck() && this.configWindow.hostBox.Checked == true)
                {
                    Host new_host = this.ircHelper.getHost();
                    this.playHost(new_host.name, new_host.viewers);
                    this.hostBox.Items.Insert(0, new_host.name + " " + new_host.viewers);
                }
                else if (this.twitchHelper.newFollowerCheck() && this.configWindow.hostBox.Checked == true)
                {
                    List<Follower> new_followers = this.twitchHelper.getFollowerQueue();
                    List<string> follower_list = new List<string>();
                    foreach (Follower follower in new_followers)
                    {
                        follower_list.Add(follower.name);
                        this.followBox.Items.Insert(0, follower.name);
                    }
                    string followers = string.Join(",", follower_list.ToArray());
                    this.playFollower(followers);
                }
            }
        }

        private void donationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Donation donation = (Donation)this.donationBox.SelectedItem;
            this.amountBox.Text = donation.amount;
            this.commentBox.Text = donation.comment;
        }

        public void clickStarStopButton()
        {
            if (running == false)
            {
                this.twitchHelper = new TwitchAPIHelper(this.configWindow.channelBox.Text,
                    this.configWindow.subscriberOAuthBox.Text);
                this.ircHelper = new TwitchIRCHelper(this.configWindow.channelBox.Text.ToLower(),
                    this.configWindow.ircOAuthBox.Text);
                this.taHelper = new TwitchAlertAPIHelper(this.configWindow.TAAccessTokenBox.Text);
                twitchAPIThread = new Thread(this.twitchHelper.runAsThread);
                taThread = new Thread(this.taHelper.runAsThread);
                taThread.IsBackground = true;
                twitchAPIThread.IsBackground = true;
                twitchHelper.update_followers = this.configWindow.followerBox.Checked;
                twitchHelper.update_subscribers = this.configWindow.subscriberBox.Checked;
                TwitchIRCHelper.update_hosts = this.configWindow.hostBox.Checked;
                TwitchIRCHelper.update_subscribers = this.configWindow.subscriberBox.Checked;
                if (this.configWindow.subscriberBox.Checked == true || this.configWindow.followerBox.Checked == true)
                {
                    twitchAPIThread.Start();
                }

                if (this.configWindow.donationBox.Checked == true)
                {
                    taThread.Start();
                }

                if (this.configWindow.hostBox.Checked == true || this.configWindow.subscriberBox.Checked == true)
                {
                    TwitchIRCHelper.connectToIRC();
                }

                UIUpdater.Enabled = true;
                this.configWindow.channelBox.ReadOnly = true;
                this.configWindow.ircOAuthBox.ReadOnly = true;
                this.configWindow.subscriberOAuthBox.ReadOnly = true;
                this.configWindow.TAAccessTokenBox.ReadOnly = true;
                this.configWindow.subscriberBox.Enabled = false;
                this.configWindow.followerBox.Enabled = false;
                this.configWindow.hostBox.Enabled = false;
                this.configWindow.donationBox.Enabled = false;
                startStopBtn.Text = "Stop";
                running = true;
            }
            else
            {
                startStopBtn.Enabled = false;
                running = false;
                this.twitchHelper.stopThread();
                this.taHelper.stopThread();
                TwitchIRCHelper.stopClient();
            }
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            this.clickStarStopButton();
        }

        private void Twitchdouken_Load(object sender, EventArgs e)
        {
            if(this.configWindow.runAtStartBox.Checked)
            {
                this.clickStarStopButton();
            }
        }
    }
}
