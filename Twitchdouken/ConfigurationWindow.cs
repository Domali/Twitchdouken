using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twitchdouken
{
    public partial class ConfigurationWindow : Form
    {
        private Twitchdouken parent;
        private string twitchdouken_config_file;
        public ConfigurationWindow(Twitchdouken parent)
        {
            InitializeComponent();
            this.parent = parent;
            this.twitchdouken_config_file = @"D:\TwitchdoukenConfigStuff\twitchdouken.cfg";
            this.loadTotalConfig();
            if (this.runAtStartBox.Checked == true)
            {
                //this.parent.clickStarStopButton();   
            }
        }

        private string getFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "SWF Movie|*.swf";
            openFileDialog1.ShowDialog();
            return openFileDialog1.FileName;
        }

        private void followerBtn_Click(object sender, EventArgs e)
        {
            followerTxtBox.Text = getFile();
        }

        private void hostBtn_Click(object sender, EventArgs e)
        {
            hostTxtBox.Text = getFile();
        }

        private void donationBtn_Click(object sender, EventArgs e)
        {
            donationTxtBox.Text = getFile();
        }

        private void subscriberBtn_Click(object sender, EventArgs e)
        {
            subscriberTxtBox.Text = getFile();
        }

        private void ConfigurationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void testFollowerBtn_Click(object sender, EventArgs e)
        {
            parent.playFollower("Domalix,Nvmlulz,bdc_iceman");
        }

        private void testHostBtn_Click(object sender, EventArgs e)
        {
            parent.playHost("Domalix", "9000");
        }

        private void testDonationButton_Click(object sender, EventArgs e)
        {
            parent.playDonation("Domalix", "$5");
        }

        private void testSubscriberBtn_Click(object sender, EventArgs e)
        {
            parent.playSubscriber("Zuludian", "45 Months");
        }

        private void newMovieCfgBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Configuration File|*.cfg";
            saveFileDialog1.Title = "Configuration File Name";
            saveFileDialog1.ShowDialog();
            movieConfigBox.Text = saveFileDialog1.FileName;
            subscriberTxtBox.Text = "";
            donationTxtBox.Text = "";
            hostTxtBox.Text = "";
            followerTxtBox.Text = "";
        }

        private void saveMovieConfigurationFile(String filename)
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
            {
                file.WriteLine(generateMovieConfig().ToString());
            }
        }

        private void loadMovieConfigurationFile(String filename)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                {
                    String json = file.ReadToEnd();
                    JToken token = JObject.Parse(json).SelectToken("movie_config");
                    string follower = (string)token.SelectToken("follower_movie");
                    string subscriber = (string)token.SelectToken("subscriber_movie");
                    string host = (string)token.SelectToken("host_movie");
                    string donation = (string)token.SelectToken("donation_movie");
                    followerTxtBox.Text = follower;
                    subscriberTxtBox.Text = subscriber;
                    hostTxtBox.Text = host;
                    donationTxtBox.Text = donation;
                }
                movieConfigBox.Text = filename;
            }
            catch (System.IO.FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show("Configuration file not found - please select another file and try again.", "Configuration File Not Found");
            }
            catch (System.NullReferenceException e)
            {
                System.Windows.Forms.MessageBox.Show("The movie configuration file is malformed.  Please correct this issue and try again", "Malformed Movie Configuration File");
            }
        }

        private void saveMovieCfgBtn_Click(object sender, EventArgs e)
        {
            saveMovieConfigurationFile(movieConfigBox.Text);
        }

        private void loadMovieCfgBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Configuration File|*.cfg";
            openFileDialog1.Title = "Configuration File Name";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                loadMovieConfigurationFile(openFileDialog1.FileName);
            }
        }

        private  JObject generateMovieConfig()
        {
            JObject config = JObject.FromObject(new
            {
                movie_config = new
                {
                    follower_movie = followerTxtBox.Text,
                    subscriber_movie = subscriberTxtBox.Text,
                    host_movie = hostTxtBox.Text,
                    donation_movie = donationTxtBox.Text
                }

            });
            return config;
        }

        private JObject generateTwitchConfig()
        {
            JObject config = JObject.FromObject(new
            {
                twitch_config = new
                {
                    channel_name = channelBox.Text,
                    irc_oauth = ircOAuthBox.Text,
                    subscriber_oauth = subscriberOAuthBox.Text
                }
            });
            return config;
        }

        private JObject generateTwitchAlertConfig()
        {
            JObject config = JObject.FromObject(new
            {
                twitch_alert_config = new
                {
                    ta_access_token = TAAccessTokenBox.Text
                }
            });
            return config;
        }

        private JObject generateGeneralConfig()
        {
            JObject config = JObject.FromObject(new
            {
                general_config = new
                {
                    default_movie_config = this.defaultMovieCfgBox.Text,
                    play_followers = this.followerBox.Checked,
                    play_subscribers = this.subscriberBox.Checked,
                    play_donations = this.donationBox.Checked,
                    play_hosts = this.hostBox.Checked,
                    run_at_start = this.runAtStartBox.Checked
                }
            });
            return config;
        }

        private void defaultMovieCfgBtn_Click(object sender, EventArgs e)
        {
            defaultMovieCfgBox.Text = movieConfigBox.Text;
        }

        private void saveTotalConfig()
        {
            JObject config = new JObject();
            config.Merge(generateGeneralConfig());
            config.Merge(generateTwitchConfig());
            config.Merge(generateTwitchAlertConfig());
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.twitchdouken_config_file))
            {
                file.WriteLine(config.ToString());
            }
        }
        public void loadTotalConfig()
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(this.twitchdouken_config_file))
                {
                    String json = file.ReadToEnd();
                    JToken token = JObject.Parse(json);
                    this.channelBox.Text = (string)token["twitch_config"]["channel_name"];
                    this.ircOAuthBox.Text = (string)token["twitch_config"]["irc_oauth"];
                    this.subscriberOAuthBox.Text = (string)token["twitch_config"]["subscriber_oauth"];
                    this.defaultMovieCfgBox.Text = (string)token["general_config"]["default_movie_config"];
                    this.loadMovieConfigurationFile(this.defaultMovieCfgBox.Text);
                    this.TAAccessTokenBox.Text = (string)token["twitch_alert_config"]["ta_access_token"];
                    this.followerBox.Checked = (bool)token["general_config"]["play_followers"];
                    this.subscriberBox.Checked = (bool)token["general_config"]["play_subscribers"];
                    this.donationBox.Checked = (bool)token["general_config"]["play_donations"];
                    this.hostBox.Checked = (bool)token["general_config"]["play_hosts"];
                    this.runAtStartBox.Checked = (bool)token["general_config"]["run_at_start"];
                }
            }
            catch(System.IO.FileNotFoundException e)
            {
                System.Windows.Forms.MessageBox.Show("Configuration file not found - creating blank configuration file.","Configuration File Not Found");
                this.saveTotalConfig();
            }
            catch(System.NullReferenceException e)
            {
                System.Windows.Forms.MessageBox.Show("Please either fix or delete the configuration file to continue loading the program." +
                    " The program will now terminate", "Error - Malformed Configuration File");
                Environment.Exit(0);
            }
        }
        private void saveAllBtn_Click(object sender, EventArgs e)
        {
            this.saveTotalConfig();
        }

        private void setDefaultMovieBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "Configuration File|*.cfg";
            openFileDialog1.Title = "Configuration File Name";
            openFileDialog1.ShowDialog();
            this.defaultMovieCfgBox.Text = openFileDialog1.FileName;
        }
    }
}
