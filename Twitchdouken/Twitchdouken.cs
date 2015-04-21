using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitchdouken
{
    public partial class Twitchdouken : Form
    {
        private AlertWindow             alertWindow;
        private ConfigurationWindow     configWindow;

        private TwitchAPIHelper         twitchHelper;
        private TwitchAlertAPIHelper    taHelper;
        private TwitchIRCHelper         ircHelper;

        private Thread                  twitchAPIThread;
        private Thread                  taThread;

        private bool                    running = false;
        private static string           flashXML = "<invoke name=\"{0}\" returntype=\"xml\"><arguments><string>{1}</string></arguments></invoke>";

        public Twitchdouken()
        {
            InitializeComponent();

            alertWindow = new AlertWindow(this);
            configWindow = new ConfigurationWindow(this, alertWindow);

            alertWindow.Show();
            donationBox.DisplayMember = "name";
        }

        internal void playSubscriber(string subscriber, string months)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flashXML, "setSubscriber", subscriber));
            function_calls.Add(string.Format(flashXML, "setMonths", months));

            playFlash(configWindow.subscriberTxtBox.Text, function_calls);
        }

        internal void playFollower(string followers)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flashXML, "setFollowers", followers));

            playFlash(configWindow.followerTxtBox.Text, function_calls);
        }

        internal void playHost(string name, string viewers)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flashXML, "setLevel", viewers));
            function_calls.Add(string.Format(flashXML, "setUser", name));

            playFlash(configWindow.hostTxtBox.Text, function_calls);
        }

        internal void playDonation(string name, string amount)
        {
            List<string> function_calls = new List<string>();
            function_calls.Add(string.Format(flashXML, "setAmount", amount));
            function_calls.Add(string.Format(flashXML, "setDonator", name));

            playFlash(configWindow.donationTxtBox.Text, function_calls);
        }

        internal void playFlash(string fileName, List<string> functionCalls)
        {
            if (fileName != string.Empty)
            {
                if (!File.Exists(fileName))
                    return;

                alertWindow.flashAlert.LoadMovie(0, fileName);
                alertWindow.flashAlert.Loop = false;
                alertWindow.flashAlert.Quality = 0;

                // need to figure out how to catch exceptions here for the wrong call functions being used on certain flash files
                // EXAMPLE: using an .sfw made for the follower section in the host section (causes a crash)

                foreach (string function in functionCalls)
                {
                    alertWindow.flashAlert.CallFunction(function);
                }

                alertWindow.flashAlert.Play();
            }
        }

        private void UIUpdater_Tick(object sender, EventArgs e)
        {
            if (running)
            {
                checkAndPlayAlerts();
            }
            else if (!taThread.IsAlive && !twitchAPIThread.IsAlive) 
            {
                // Once the two threads are joined after a stop we have to finish killing everything
                // This is done in the timer so that we don't get an unresponsive GUI.
                ircHelper = null;
                twitchHelper = null;
                taHelper = null;

                configReadOnlyToggle();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                menuStart.Enabled = true;
                menuStart.Text = "&Start";
                UIUpdater.Enabled = false;
            }       
        }

        private void checkAndPlayAlerts()
        {
            if (!alertWindow.flashAlert.IsPlaying())
            {
                // new subscription
                if (twitchHelper.newSubscriberCheck() && configWindow.subscriberBox.Checked)
                {
                    Subscriber subscriber = twitchHelper.getSubscriber();

                    subscriberBox.Items.Insert(0, subscriber.name);
                    playSubscriber(subscriber.name, string.Empty);
                }
                // subsequent subscription
                else if (ircHelper.newSubscriberCheck() && configWindow.subscriberBox.Checked)
                {
                    Subscriber subscriber = ircHelper.getSubscriber();

                    playSubscriber(subscriber.name, subscriber.months + " months");
                    subscriberBox.Items.Insert(0, subscriber.name + " (" + subscriber.months + ")");
                }
                // donation
                else if (taHelper.newDonationCheck() && configWindow.donationBox.Checked)
                {
                    Donation donation = taHelper.getDonation();

                    playDonation(donation.name, "$" + donation.amount);
                    donationBox.Items.Insert(0, donation);
                    donationBox.SetSelected(0, true);
                }
                // host
                else if (ircHelper.newHostCheck() && configWindow.hostBox.Checked)
                {
                    Host host = ircHelper.getHost();

                    if (Int32.Parse(host.viewers) >= (int)minViewerHost.Value)
                        playHost(host.name, host.viewers);

                    hostBox.Items.Insert(0, host.name + " " + host.viewers);
                }
                // follow
                else if (twitchHelper.newFollowerCheck() && configWindow.followerBox.Checked)
                {
                    List<Follower> newFollowers = twitchHelper.getFollowerQueue();
                    List<string> followerList = new List<string>();

                    foreach (Follower follower in newFollowers)
                    {
                        followerList.Add(follower.name);
                        followBox.Items.Insert(0, follower.name);
                    }

                    string followers = string.Join(",", followerList.ToArray());
                    playFollower(followers);
                }
            }
        }

        private void donationBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Donation donation = (Donation)donationBox.SelectedItem;
            amountBox.Text = donation.amount;
            commentBox.Text = donation.comment;
        }

        public void clickStartStopButton()
        {
            if (!running)
            {
                twitchHelper = new TwitchAPIHelper(configWindow.channelBox.Text, configWindow.subscriberOAuthBox.Text);
                ircHelper = new TwitchIRCHelper(configWindow.channelBox.Text.ToLower(), configWindow.ircOAuthBox.Text);
                taHelper = new TwitchAlertAPIHelper(configWindow.TAAccessTokenBox.Text);

                twitchAPIThread = new Thread(twitchHelper.runAsThread);
                twitchAPIThread.IsBackground = true;

                taThread = new Thread(taHelper.runAsThread);
                taThread.IsBackground = true;

                twitchHelper.updateFollowers = configWindow.followerBox.Checked;
                twitchHelper.updateSubscribers = configWindow.subscriberBox.Checked;

                TwitchIRCHelper.update_hosts = configWindow.hostBox.Checked;
                TwitchIRCHelper.update_subscribers = configWindow.subscriberBox.Checked;

                if (configWindow.subscriberBox.Checked || configWindow.followerBox.Checked)
                    twitchAPIThread.Start();

                if (configWindow.donationBox.Checked)
                    taThread.Start();

                if (configWindow.hostBox.Checked || configWindow.subscriberBox.Checked)
                    TwitchIRCHelper.connectToIRC();

                UIUpdater.Enabled = true;

                configReadOnlyToggle();
                
                menuStart.Text = "&Stop";
                running = true;
            }
            else
            {
                menuStart.Enabled = false;
                running = false;

                twitchHelper.stopThread();
                taHelper.stopThread();

                if (configWindow.hostBox.Checked)
                {
                    TwitchIRCHelper.stopClient();
                }
            }
        }

        private void configReadOnlyToggle()
        {
            configWindow.channelBox.ReadOnly = !configWindow.channelBox.ReadOnly;
            configWindow.ircOAuthBox.ReadOnly = !configWindow.ircOAuthBox.ReadOnly;
            configWindow.subscriberOAuthBox.ReadOnly = !configWindow.subscriberOAuthBox.ReadOnly;
            configWindow.TAAccessTokenBox.ReadOnly = !configWindow.TAAccessTokenBox.ReadOnly;
            configWindow.subscriberBox.Enabled = !configWindow.subscriberBox.Enabled;
            configWindow.followerBox.Enabled = !configWindow.followerBox.Enabled;
            configWindow.hostBox.Enabled = !configWindow.hostBox.Enabled;
            configWindow.donationBox.Enabled = !configWindow.donationBox.Enabled;
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            clickStartStopButton();
        }

        private void Twitchdouken_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (configWindow.runAtStartBox.Checked)
                clickStartStopButton();

            updateGUIElements();

            alertWindow.Show();
        }

        private void Twitchdouken_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                NotifyIcon.Visible = true;
                NotifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            NotifyIcon.Visible = false;
        }

        private int isFollowDisplayed(int offset)
        {
            if (followGroupBox.Visible)
                offset += 178;

            return offset;
        }

        private int isSubscriberDisplayed(int offset)
        {
            if (subscriberGroupBox.Visible)
                offset += 178;

            return offset;
        }

        private int isHostDisplayed(int offset)
        {
            if (hostGroupBox.Visible)
                offset += 178;

            return offset;
        }

        private int isDonationDisplayed(int offset)
        {
            if (donationGroupBox.Visible)
                offset += 350;

            return offset;
        }

        public void updateGUIElements()
        {
            int offset = 8;

            followGroupBox.Visible = configWindow.followerBox.Checked;
            subscriberGroupBox.Visible = configWindow.subscriberBox.Checked;
            hostGroupBox.Visible = configWindow.hostBox.Checked;
            donationGroupBox.Visible = configWindow.donationBox.Checked;

            offset = isFollowDisplayed(offset);
            subscriberGroupBox.Left = offset;
            offset = isSubscriberDisplayed(offset);
            hostGroupBox.Left = offset;
            offset = isHostDisplayed(offset);
            donationGroupBox.Left = offset;
            offset = isDonationDisplayed(offset);

            this.Width = offset + 14;

            if (this.Width <= 200)
                this.Width = 200;
        }

        private void menuStart_Click(object sender, EventArgs e)
        {
            clickStartStopButton();
        }

        private void menuWindowsConfiguration_Click(object sender, EventArgs e)
        {
            configWindow.Visible = !configWindow.Visible;
            menuWindowsConfiguration.Checked = configWindow.Visible;
        }

        private void menuWindowsAlert_Click(object sender, EventArgs e)
        {
            alertWindow.Visible = !alertWindow.Visible;
            menuWindowsAlert.Checked = alertWindow.Visible;
        }
    }
}
