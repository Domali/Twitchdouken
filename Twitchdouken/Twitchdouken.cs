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

        internal void playFlash(string file_name, List<string> function_calls)
        {
            alertWindow.flashAlert.LoadMovie(0, file_name);
            alertWindow.flashAlert.Loop = false;
            alertWindow.flashAlert.Quality = 0;

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
                checkAndPlayAlerts();
            }
            else if (!taThread.IsAlive && !twitchAPIThread.IsAlive) 
            {
                // Once the two threads are joined after a stop we have to finish killing everything
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

        private void checkAndPlayAlerts()
        {
            if (!alertWindow.flashAlert.IsPlaying())
            {
                // new subscription
                if (this.twitchHelper.newSubscriberCheck() && this.configWindow.subscriberBox.Checked == true)
                {
                    Subscriber new_subscriber = this.twitchHelper.getSubscriber();
                    this.subscriberBox.Items.Insert(0, new_subscriber.name);
                    this.playSubscriber(new_subscriber.name, "");
                }
                // subsequent subscription
                else if (this.ircHelper.newSubscriberCheck() && this.configWindow.subscriberBox.Checked == true)
                {
                    Subscriber new_subscriber = this.ircHelper.getSubscriber();
                    this.playSubscriber(new_subscriber.name, new_subscriber.months + " months");
                    this.subscriberBox.Items.Insert(0, new_subscriber.name + " (" + new_subscriber.months + ")");
                }
                // donation
                else if (this.taHelper.newDonationCheck() && this.configWindow.donationBox.Checked == true)
                {
                    Donation new_donation = this.taHelper.getDonation();
                    this.playDonation(new_donation.name, "$" + new_donation.amount);
                    this.donationBox.Items.Insert(0, new_donation);
                    this.donationBox.SetSelected(0, true);
                }
                // host
                else if (this.ircHelper.newHostCheck() && this.configWindow.hostBox.Checked == true)
                {
                    Host new_host = this.ircHelper.getHost();
                    this.playHost(new_host.name, new_host.viewers);
                    this.hostBox.Items.Insert(0, new_host.name + " " + new_host.viewers);
                }
                // follow
                else if (this.twitchHelper.newFollowerCheck() && this.configWindow.followerBox.Checked == true)
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

        public void clickStartStopButton()
        {
            if (running == false)
            {
                this.twitchHelper = new TwitchAPIHelper(this.configWindow.channelBox.Text, this.configWindow.subscriberOAuthBox.Text);
                this.ircHelper = new TwitchIRCHelper(this.configWindow.channelBox.Text.ToLower(), this.configWindow.ircOAuthBox.Text);
                this.taHelper = new TwitchAlertAPIHelper(this.configWindow.TAAccessTokenBox.Text);

                twitchAPIThread = new Thread(this.twitchHelper.runAsThread);
                twitchAPIThread.IsBackground = true;

                taThread = new Thread(this.taHelper.runAsThread);
                taThread.IsBackground = true;

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

                if (this.configWindow.hostBox.Checked)
                {
                    TwitchIRCHelper.stopClient();
                }
            }
        }

        private void startStopBtn_Click(object sender, EventArgs e)
        {
            this.clickStartStopButton();
        }

        private void Twitchdouken_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (this.configWindow.runAtStartBox.Checked)
            {
                this.clickStartStopButton();
            }

            this.updateGUIElements();
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

        /////////////////   GUI real-time update code   /////////////////
        /// <summary>
        /// DO NOT PASS GO, DO NOT COLLECT $200. THIS CODE IS GROSS
        /// </summary>

        private void updateGUIVisibility()
        {
            // GUI adjustments based on settings (dom can enjoy looking at this)
            // EleGiggle... this shit.
            // UI visibility
            this.followBox.Visible = this.followLabel.Visible = this.followerChkBox.Visible = this.configWindow.followerBox.Checked;
            this.subscriberBox.Visible = this.subscriberLabel.Visible = this.subscriberChkBox.Visible = this.configWindow.subscriberBox.Checked;
            this.hostBox.Visible = this.hostLabel.Visible = this.hostChkBox.Visible = this.configWindow.hostBox.Checked;
            this.donationBox.Visible = this.donationLabel.Visible = this.donationChkBox.Visible = this.configWindow.donationBox.Checked;
            this.amountBox.Visible = this.amountLabel.Visible = this.commentBox.Visible = this.commentLabel.Visible = this.configWindow.donationBox.Checked;
        }

        private void resetGUI()
        {
            // everything is visible
            if (this.followBox.Visible && this.subscriberBox.Visible && this.hostBox.Visible && this.donationBox.Visible)
            {
                this.Width = 876;
                // re-adjust positions for everything but follow box (as it never moves)
                this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left + 169;
                this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.subscriberBox.Left + 169;
                this.hostChkBox.Left = this.hostBox.Left + 148;
                this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.hostBox.Left + 169;
                this.donationChkBox.Left = this.donationBox.Left + 148;
                this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
            }
        }

        // position adjustments are made based on case to case basis
        // but im breaking them into subsets to be more managable
        private void updateGUIFollowSubset()
        {
            if (this.followBox.Visible == false)
            {
                // everything else visible
                if (this.subscriberBox.Visible && this.hostBox.Visible && this.donationBox.Visible)
                {
                    this.Width = 706;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.subscriberBox.Left + 169;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.hostBox.Left + 169;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                } // sub box isnt visible
                else if (this.subscriberBox.Visible == false && this.hostBox.Visible && this.donationBox.Visible)
                {
                    this.Width = 538;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.followBox.Left;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.hostBox.Left + 169;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                } // sub and host box arent visible
                else if (this.subscriberBox.Visible == false && this.hostBox.Visible == false && this.donationBox.Visible)
                {
                    this.Width = 368;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.followBox.Left;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                
                } // only sub box visible
                else if (this.subscriberBox.Visible && this.hostBox.Visible == false && this.donationBox.Visible == false)
                {
                    this.Width = 368;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                }
            }
        }

        private void updateGUISubscriptionSubset()
        {
            if (this.subscriberBox.Visible == false)
            {
                // everything else visible
                if (this.followBox.Visible && this.hostBox.Visible && this.donationBox.Visible)
                {
                    this.Width = 706;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.followBox.Left + 169;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.hostBox.Left + 169;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                } // host box not visible
                else if (this.followBox.Visible && this.hostBox.Visible == false && this.donationBox.Visible)
                {
                    this.Width = 538;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.followBox.Left + 169;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                } // donation box not visible
                else if (this.followBox.Visible && this.hostBox.Visible && this.donationBox.Visible == false)
                {
                    this.Width = 368;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.followBox.Left + 169;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                }
            }
        }

        private void updateGUIHostSubset()
        {
            if (this.hostBox.Visible == false)
            {
                // everything else visible
                if (this.followBox.Visible && this.subscriberBox.Visible && this.donationBox.Visible)
                {
                    this.Width = 706;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left + 169;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.subscriberBox.Left + 169;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                } // follow box not visible
                else if (this.followBox.Visible == false && this.subscriberBox.Visible && this.donationBox.Visible)
                {
                    this.Width = 538;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                    this.donationBox.Left = this.donationLabel.Left = this.donationTimeLabel.Left = this.subscriberBox.Left + 169;
                    this.donationChkBox.Left = this.donationBox.Left + 148;
                    this.amountBox.Left = this.amountLabel.Left = this.commentBox.Left = this.commentLabel.Left = this.donationBox.Left + 169;
                } // donation box not visible
                else if (this.followBox.Visible && this.subscriberBox.Visible && this.donationBox.Visible == false)
                {
                    this.Width = 368;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left + 169;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                }
            }
        }

        private void updateGUIDonationSubset()
        {
            if (this.donationBox.Visible == false)
            {
                // everything else visible
                if (this.followBox.Visible && this.subscriberBox.Visible && this.hostBox.Visible)
                {
                    this.Width = 538;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left + 169;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.subscriberBox.Left + 169;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                } // follow box not visible
                else if (this.followBox.Visible == false && this.subscriberBox.Visible && this.hostBox.Visible)
                {
                    this.Width = 368;
                    this.subscriberBox.Left = this.subscriberLabel.Left = this.subscriberTimeLabel.Left = this.followBox.Left;
                    this.subscriberChkBox.Left = this.subscriberBox.Left + 148;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.subscriberBox.Left + 169;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                } // sub and host box not visible
                else if (this.followBox.Visible && this.subscriberBox.Visible == false && this.hostBox.Visible == false)
                {
                    this.Width = 368;
                    // nothing else should be required
                } // follow and sub box not visible
                else if (this.followBox.Visible == false && this.subscriberBox.Visible == false && this.hostBox.Visible)
                {
                    this.Width = 368;
                    this.hostBox.Left = this.hostTimeLabel.Left = this.hostLabel.Left = this.followBox.Left;
                    this.hostChkBox.Left = this.hostBox.Left + 148;
                }
            }
        }

        private void updateGUIAllHidden()
        {
            if (this.followBox.Visible == false && this.subscriberBox.Visible == false && this.hostBox.Visible == false && this.donationBox.Visible == false)
            {
                // dont resize below two sections of displayed info otherwise start button will be covered by other buttons
                this.Width = 368;
            }
        }

        public void updateGUIElements()
        {
            updateGUIVisibility();
            resetGUI();

            updateGUIFollowSubset();
            updateGUISubscriptionSubset();
            updateGUIHostSubset();
            updateGUIDonationSubset();

            updateGUIAllHidden();

            // dont forget to re-position the start button into proper positioning
            this.startStopBtn.Left = this.Width - (this.startStopBtn.Width) - 24;
        }
    }
}
