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
            using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
            {
                String json = file.ReadToEnd();
                JToken token = JObject.Parse(json).SelectToken("movie_config");
                followerTxtBox.Text = (string)token.SelectToken("follower_movie");
                subscriberTxtBox.Text = (string)token.SelectToken("subscriber_movie");
                hostTxtBox.Text = (string)token.SelectToken("host_movie");
                donationTxtBox.Text = (string)token.SelectToken("donation_movie");
            }
            movieConfigBox.Text = filename;
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
            loadMovieConfigurationFile(openFileDialog1.FileName);
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
                    default_movie_config = defaultMovieCfgBox.Text
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
            }
        }
        private void saveAllBtn_Click(object sender, EventArgs e)
        {
            this.saveTotalConfig();
        }
    }
}
