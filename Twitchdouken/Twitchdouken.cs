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

        static string flash_xml = "<invoke name=\"{0}\" returntype=\"xml\"><arguments><string>{1}</string></arguments></invoke>";

        public Twitchdouken()
        {
            InitializeComponent();
            alertWindow = new AlertWindow();
            configWindow = new ConfigurationWindow(this);
            alertWindow.Show();
            donationBox.DisplayMember = "name";
            this.twitchHelper = new TwitchAPIHelper(this.configWindow.channelBox.Text, this.configWindow.subscriberOAuthBox.Text);
            this.ircHelper = new TwitchIRCHelper(this.configWindow.channelBox.Text.ToLower(), this.configWindow.ircOAuthBox.Text);
            taHelper = new TwitchAlertAPIHelper(this.configWindow.TAAccessTokenBox.Text);
            Thread twitchAPIThread = new Thread(this.twitchHelper.runAsThread);
            Thread taThread = new Thread(this.taHelper.runAsThread);
            taThread.IsBackground = true;
            twitchAPIThread.IsBackground = true;
            taThread.Start();
            twitchAPIThread.Start();

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
            followTimeLabel.Text = this.twitchHelper.getFollowUpdateTime();
            subscriberTimeLabel.Text = this.twitchHelper.getSubscriberUpdateTime();
            checkAndPlayALerts();

        }

        private void checkAndPlayALerts()
        {
            if (!alertWindow.flashAlert.IsPlaying())
            {
                if (this.twitchHelper.newSubscriberCheck())
                {
                    Subscriber new_subscriber = this.twitchHelper.getSubscriber();
                    this.subscriberBox.Items.Insert(0, new_subscriber.name);
                    this.playSubscriber(new_subscriber.name, "");
                }
                else if (this.ircHelper.newSubscriberCheck())
                {
                    Subscriber new_subscriber = this.ircHelper.getSubscriber();
                    this.playSubscriber(new_subscriber.name, new_subscriber.months + " months");
                    this.subscriberBox.Items.Insert(0, new_subscriber.name + " (" + new_subscriber.months + ")");
                }
                else if (this.taHelper.newDonationCheck())
                {
                    Donation new_donation = this.taHelper.getDonation();
                    this.playDonation(new_donation.name, "$" + new_donation.amount);
                    this.donationBox.Items.Insert(0, new_donation);
                    this.donationBox.SetSelected(0, true);
                }
                else if (this.ircHelper.newHostCheck())
                {
                    Host new_host = this.ircHelper.getHost();
                    this.playHost(new_host.name, new_host.viewers);
                    this.hostBox.Items.Insert(0, new_host.name + " " + new_host.viewers);
                }
                else if (this.twitchHelper.newFollowerCheck())
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

        private void startStopBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
