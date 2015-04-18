using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twitchdouken
{
    public partial class ConfigurationWindow : Form
    {
        private Twitchdouken    parent;
        private AlertWindow     alertWindow;

        private string configFilePath;
        private bool initialized;

        public ConfigurationWindow(Twitchdouken parent, AlertWindow alertWindow)
        {
            InitializeComponent();

            this.parent = parent;
            this.alertWindow = alertWindow;

            configFilePath = @"settings.cfg";

            initialized = false;

            loadTotalConfig();
            updateAlertChromaKey();
        }

        private void setMovie(TextBox textbox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "SWF Movie|*.swf";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
                textbox.Text = openFileDialog.FileName;
        }

        private void followerBtn_Click(object sender, EventArgs e)
        {
            setMovie(followerTxtBox);
        }

        private void hostBtn_Click(object sender, EventArgs e)
        {
            setMovie(hostTxtBox);
        }

        private void donationBtn_Click(object sender, EventArgs e)
        {
            setMovie(donationTxtBox);
        }

        private void subscriberBtn_Click(object sender, EventArgs e)
        {
            setMovie(subscriberTxtBox);
        }

        private void ConfigurationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.menuWindowsConfiguration.Checked = false;

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

        private void testDonationBtn_Click(object sender, EventArgs e)
        {
            parent.playDonation("Domalix", "$5");
        }

        private void testSubscriberBtn_Click(object sender, EventArgs e)
        {
            parent.playSubscriber("Zuludian", "45 Months");
        }

        private void newMovieCfgBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Configuration File|*.cfg";
            saveFileDialog.Title = "Configuration File Name";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK) {
                movieConfigBox.Text = saveFileDialog.FileName;
                subscriberTxtBox.Text = "";
                donationTxtBox.Text = "";
                hostTxtBox.Text = "";
                followerTxtBox.Text = "";

                chromaKeySample.BackColor = Color.White;
                updateAlertChromaKey();
            }
        }

        private void saveMovieConfigurationFile(String filename)
        {
            if (filename != "")
            {
                JObject config = new JObject();

                config.Merge(generateMoviePaths());
                config.Merge(generateMovieConfig());

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(filename))
                {
                    file.WriteLine(config.ToString());
                    MessageBox.Show(null, "Movie Configuration file has been saved successfully.", "Movie Configuration", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void loadMovieConfigurationFile(String filename)
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(filename))
                {
                    String json = file.ReadToEnd();
                    JToken token = JObject.Parse(json);

                    followerTxtBox.Text = (string)token["movie_paths"]["follower_movie"];
                    subscriberTxtBox.Text = (string)token["movie_paths"]["subscriber_movie"];
                    hostTxtBox.Text = (string)token["movie_paths"]["host_movie"];
                    donationTxtBox.Text = (string)token["movie_paths"]["donation_movie"];

                    chromaHexBox.Text = (string)token["movie_config"]["chroma_key"];
                    chromaKeySample.BackColor = hexToColor(chromaHexBox.Text);                    
                    int width = (int)token["movie_config"]["width"];
                    int height = (int)token["movie_config"]["height"];

                    alertWidthNum.Value = width;
                    alertHeightNum.Value = height;

                    this.alertWindow.windowResize(width, height);
                }

                movieConfigBox.Text = filename;
            }
            catch (System.IO.DirectoryNotFoundException)
            {
                MessageBox.Show(null, "Movie configuration file not found - please select another file and try again.", "Movie Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                movieConfigBox.Text = "";
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(null, "Movie configuration file not found - please select another file and try again.", "Movie Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
                movieConfigBox.Text = "";
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show(null, "The movie configuration file is malformed. Please correct this issue and try again", "Movie Configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveMovieCfgBtn_Click(object sender, EventArgs e)
        {
            saveMovieConfigurationFile(movieConfigBox.Text);
        }

        private void loadMovieCfgBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "Configuration File|*.cfg";
            openFileDialog.Title = "Configuration File Name";
            
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                loadMovieConfigurationFile(openFileDialog.FileName);
            }
        }

        private JObject generateMoviePaths()
        {
            JObject config = JObject.FromObject(new
            {
                movie_paths = new
                {
                    follower_movie = followerTxtBox.Text,
                    subscriber_movie = subscriberTxtBox.Text,
                    host_movie = hostTxtBox.Text,
                    donation_movie = donationTxtBox.Text
                }
            });
            return config;
        }

        private JObject generateMovieConfig()
        {
            JObject config = JObject.FromObject(new
            {
                movie_config = new
                {
                    chroma_key = colorToHex(chromaKeySample.BackColor),
                    width = (int)alertWidthNum.Value,
                    height = (int)alertHeightNum.Value
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
                    movie_config = movieConfigBox.Text,
                    play_followers = followerBox.Checked,
                    play_subscribers = subscriberBox.Checked,
                    play_donations = donationBox.Checked,
                    play_hosts = hostBox.Checked,
                    run_at_start = runAtStartBox.Checked
                }
            });
            return config;
        }

        private void saveTotalConfig()
        {
            JObject config = new JObject();

            config.Merge(generateGeneralConfig());
            config.Merge(generateTwitchConfig());
            config.Merge(generateTwitchAlertConfig());

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.configFilePath))
            {
                file.WriteLine(config.ToString());
                MessageBox.Show(null, "Configuration file has been saved successfully.", "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void loadTotalConfig()
        {
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(this.configFilePath))
                {
                    String json = file.ReadToEnd();
                    JToken token = JObject.Parse(json);

                    followerBox.Checked = (bool)token["general_config"]["play_followers"];
                    subscriberBox.Checked = (bool)token["general_config"]["play_subscribers"];
                    donationBox.Checked = (bool)token["general_config"]["play_donations"];
                    hostBox.Checked = (bool)token["general_config"]["play_hosts"];
                    runAtStartBox.Checked = (bool)token["general_config"]["run_at_start"];
                    movieConfigBox.Text = (string)token["general_config"]["movie_config"];

                    channelBox.Text = (string)token["twitch_config"]["channel_name"];
                    ircOAuthBox.Text = (string)token["twitch_config"]["irc_oauth"];
                    subscriberOAuthBox.Text = (string)token["twitch_config"]["subscriber_oauth"];

                    TAAccessTokenBox.Text = (string)token["twitch_alert_config"]["ta_access_token"];

                    if (movieConfigBox.Text != "")
                        loadMovieConfigurationFile(movieConfigBox.Text);
                }

                initialized = true;

            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show(null, "Configuration file not found - creating blank configuration file.", "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                followerBox.Checked = true;
                subscriberBox.Checked = true;
                donationBox.Checked = true;
                hostBox.Checked = true;

                initialized = true;

                saveTotalConfig();
            }
            catch (System.NullReferenceException)
            {
                MessageBox.Show(null, "Please either fix or delete the current configuration file to continue loading the program." + 
                                " The program will now terminate", 
                                "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }
        private void saveAllBtn_Click(object sender, EventArgs e)
        {
            saveTotalConfig();
        }

        private void followerBox_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized)
                parent.updateGUIElements();
        }

        private void hostBox_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized)
                parent.updateGUIElements();
        }

        private void subscriberBox_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized)
                parent.updateGUIElements();
        }

        private void donationBox_CheckedChanged(object sender, EventArgs e)
        {
            if (initialized)
                parent.updateGUIElements();
        }

        private void ConfigurationWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private string colorToHex(Color color)
        {
            return color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }

        private Color hexToColor(string hex)
        {
            return ColorTranslator.FromHtml("#" + hex.ToUpper());
        }

        private bool checkHex(string hex)
        {
            bool result = true;

            if (hex == "")
                result = false;

            if (hex.Length < 6)
            {
                result = false;
            }
            else 
            {
                foreach (char c in hex.ToUpper())
                {
                    if (c < '0' || c > 'F')
                        result = false;
                }
            }

            if (!result)
            {
                MessageBox.Show(null, "The hex value you attempted to enter is null or malformed. Please enter a valid hex value or use the color picker.",
                    "Invalid Hex Value", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }

            return true;
        }

        private void updateAlertChromaKey()
        {
            this.alertWindow.BackColor = chromaKeySample.BackColor;
            this.alertWindow.flashAlert.BGColor = colorToHex(chromaKeySample.BackColor);
        }

        private void colorPickerBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();

            DialogResult result = colorDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                chromaHexBox.Text = colorToHex(colorDialog.Color);
                chromaKeySample.BackColor = colorDialog.Color;
            }
        }

        private void chromaTestBtn_Click(object sender, EventArgs e)
        {
            if (checkHex(chromaHexBox.Text))
            {
                chromaKeySample.BackColor = hexToColor(chromaHexBox.Text);
                updateAlertChromaKey();
            }
        }

        private void alertResizeBtn_Click(object sender, EventArgs e)
        {
            this.alertWindow.windowResize((int)alertWidthNum.Value, (int)alertHeightNum.Value);
        }

        private void alertWidthNum_ValueChanged(object sender, EventArgs e)
        {
            if (alertWidthNum.Value >= alertWidthNum.Maximum)
                alertWidthNum.Value = alertWidthNum.Maximum;
        }

        private void alertHeightNum_ValueChanged(object sender, EventArgs e)
        {
            if (alertHeightNum.Value >= alertHeightNum.Maximum)
                alertHeightNum.Value = alertHeightNum.Maximum;
        }
    }
}
