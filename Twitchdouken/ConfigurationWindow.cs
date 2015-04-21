using System;
using System.Diagnostics;
using System.Drawing;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twitchdouken
{
    public partial class ConfigurationWindow : Form
    {
        private Twitchdouken    parent;
        private AlertWindow     alertWindow;

        private SortedDictionary<string, MovieProfile> movieProfiles;
        private BindingSource bs;

        private string configFilePath;
        private string movieProfileFilePath;

        private bool initialized;

        public ConfigurationWindow(Twitchdouken parent, AlertWindow alertWindow)
        {
            InitializeComponent();

            this.parent = parent;
            this.alertWindow = alertWindow;

            configFilePath = @"settings.cfg";
            movieProfileFilePath = @"profiles.cfg";

            movieProfiles = new SortedDictionary<string, MovieProfile>();

            initialized = false;

            loadTotalConfig();
            loadMovieProfiles();
            updateAlertChromaKey();
        }

        private void ConfigurationWindow_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            LinkLabel.Link ircOAuthLink = new LinkLabel.Link();

            ircOAuthLink.LinkData = "http://twitchapps.com/tmi/";
            linkIrcGetOAuth.Links.Add(ircOAuthLink);
        }

        private void ConfigurationWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            parent.menuWindowsConfiguration.Checked = false;

            this.Hide();
            e.Cancel = true;
        }

        // ALL CODE FOR CONTROLS BELOW THIS LINE
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

        private void linkIrcGetOAuth_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }

        private void movieProfileCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadMovieProfileSettings();
        }

        private void newMovieProfileBtn_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Please enter a name for your new profile.", "New Profile", "Default");

            if (name != "")
            {
                MovieProfile profile = new MovieProfile();

                profile.name = name;
                profile.settings.chroma = chromaHexBox.Text;
                profile.settings.width = (int)alertWidthNum.Value;
                profile.settings.height = (int)alertHeightNum.Value;
                profile.path.follower = followerTxtBox.Text;
                profile.path.host = hostTxtBox.Text;
                profile.path.donation = donationTxtBox.Text;
                profile.path.subscriber = subscriberTxtBox.Text;

                try
                {
                    movieProfiles.Add(profile.name, profile);
                }
                catch (ArgumentException)
                {
                    // means we have a duplicate named profile, add a random number at the end
                    Random r = new Random();
                    int n = r.Next();

                    profile.name = profile.name + "_" + n.ToString();

                    movieProfiles.Add(profile.name, profile);
                }

                resetMovieProfileDataSource(profile.name);
            }
        }

        private void updateMovieProfileBtn_Click(object sender, EventArgs e)
        {
            updateMovieProfileSettings(movieProfileCmb.Text);
        }

        private void saveMovieProfilesBtn_Click(object sender, EventArgs e)
        {
            saveMovieProfiles();
        }

        private void renameMovieProfileBtn_Click(object sender, EventArgs e)
        {
            string name = Interaction.InputBox("Please enter a new name for the selected profile.", "Rename Profile", "");

            if (name != "")
            {
                foreach (KeyValuePair<string, MovieProfile> entry in movieProfiles)
                {
                    if (entry.Value.name == name)
                    {
                        MessageBox.Show(null, "This profile name already exists, please try a different name.", "Duplicate Profile", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                MovieProfile profile = (MovieProfile)getCurrentMovieProfile();

                movieProfiles.Remove(profile.name);
                profile.name = name;
                movieProfiles.Add(profile.name, profile);

                resetMovieProfileDataSource(profile.name);
            }
        }

        private void deleteMovieProfileBtn_Click(object sender, EventArgs e)
        {
            Object profileObject = getCurrentMovieProfile();

            if (profileObject != null)
            {
                MovieProfile profile = (MovieProfile)getCurrentMovieProfile();

                movieProfiles.Remove(profile.name);

                resetMovieProfileDataSource(null);
            }
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
            else
            {
                MessageBox.Show(null, "The hex value you attempted to enter is null or malformed. Please enter a valid hex value or use the color picker.",
                    "Invalid Hex Value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void alertWidthNum_ValueChanged(object sender, EventArgs e)
        {
            if (alertWidthNum.Value >= alertWidthNum.Maximum)
                alertWidthNum.Value = alertWidthNum.Maximum;

            this.alertWindow.setSize((int)alertWidthNum.Value, (int)alertHeightNum.Value);
        }

        private void alertHeightNum_ValueChanged(object sender, EventArgs e)
        {
            if (alertHeightNum.Value >= alertHeightNum.Maximum)
                alertHeightNum.Value = alertHeightNum.Maximum;

            this.alertWindow.setSize((int)alertWidthNum.Value, (int)alertHeightNum.Value);
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
        // ALL CODE FOR CONTROLS ABOVE THIS LINE

        private void setMovie(TextBox textbox)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "SWF Movie|*.swf";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
                textbox.Text = openFileDialog.FileName;
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
                return false;

            return true;
        }

        private void updateAlertChromaKey()
        {
            this.alertWindow.BackColor = chromaKeySample.BackColor;
            this.alertWindow.flashAlert.BGColor = colorToHex(chromaKeySample.BackColor);
        }

        // ALL CODE DEALING WITH CONFIGURATION FILES BELOW THIS LINE
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
                    play_followers = followerBox.Checked,
                    play_subscribers = subscriberBox.Checked,
                    play_donations = donationBox.Checked,
                    play_hosts = hostBox.Checked,
                    run_at_start = runAtStartBox.Checked
                }
            });
            return config;
        }

        public void loadTotalConfig()
        {
            try
            {
                using (StreamReader file = new StreamReader(configFilePath))
                {
                    string data = file.ReadToEnd();

                    string guid = data.Remove(36, data.Length - 36);
                    string json = Encryption.Decrypt(data.Remove(0, 36), guid);

                    JToken token = JObject.Parse(json);

                    // JToken token = JObject.Parse(data);

                    followerBox.Checked = (bool)token["general_config"]["play_followers"];
                    subscriberBox.Checked = (bool)token["general_config"]["play_subscribers"];
                    donationBox.Checked = (bool)token["general_config"]["play_donations"];
                    hostBox.Checked = (bool)token["general_config"]["play_hosts"];
                    runAtStartBox.Checked = (bool)token["general_config"]["run_at_start"];

                    channelBox.Text = (string)token["twitch_config"]["channel_name"];
                    ircOAuthBox.Text = (string)token["twitch_config"]["irc_oauth"];
                    subscriberOAuthBox.Text = (string)token["twitch_config"]["subscriber_oauth"];

                    TAAccessTokenBox.Text = (string)token["twitch_alert_config"]["ta_access_token"];
                }

                initialized = true;

            }
            catch (FileNotFoundException)
            {
                MessageBox.Show(null, "Configuration file not found - creating blank configuration file.", "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                followerBox.Checked = true;
                subscriberBox.Checked = true;
                donationBox.Checked = true;
                hostBox.Checked = true;

                initialized = true;

                saveTotalConfig();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show(null, "Please either fix or delete the current configuration file to continue loading the program." +
                                " The program will now terminate",
                                "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void saveTotalConfig()
        {
            JObject config = new JObject();

            config.Merge(generateGeneralConfig());
            config.Merge(generateTwitchConfig());
            config.Merge(generateTwitchAlertConfig());

            using (StreamWriter file = new StreamWriter(configFilePath))
            {
                string guid = Guid.NewGuid().ToString();
                string data = guid + Encryption.Encrypt(config.ToString(), guid);

                // string data = config.toString();

                file.WriteLine(data);
                MessageBox.Show(null, "Configuration file has been saved successfully.", "Configuration File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        // ALL CODE DEALING WITH CONFIGURATION ABOVE THIS LINE

        // ALL CODE DEALING WITH MOVIE PROFILES BELOW
        struct MovieProfile
        {
            public string name { get; set; }
            public MovieSettings settings;
            public MoviePath path;
        }

        struct MovieSettings
        {
            public string chroma;
            public int width;
            public int height;
        }

        struct MoviePath
        {
            public string follower;
            public string subscriber;
            public string host;
            public string donation;
        }

        private void loadMovieProfileSettings()
        {
            try
            {
                Object profileObject = getCurrentMovieProfile();

                if (profileObject != null)
                {
                    MovieProfile profile = (MovieProfile)profileObject;

                    chromaHexBox.Text = profile.settings.chroma;
                    chromaKeySample.BackColor = hexToColor(chromaHexBox.Text);

                    updateAlertChromaKey();

                    alertWidthNum.Value = profile.settings.width;
                    alertHeightNum.Value = profile.settings.height;

                    followerTxtBox.Text = profile.path.follower;
                    hostTxtBox.Text = profile.path.host;
                    donationTxtBox.Text = profile.path.donation;
                    subscriberTxtBox.Text = profile.path.subscriber;
                }
            }
            catch (InvalidCastException)
            {
                return;
            }
        }

        private void updateMovieProfileSettings(string name)
        {
            MovieProfile profile = movieProfiles[name];

            profile.settings.chroma = chromaHexBox.Text;
            profile.settings.width = (int)alertWidthNum.Value;
            profile.settings.height = (int)alertHeightNum.Value;

            profile.path.follower = followerTxtBox.Text;
            profile.path.host = hostTxtBox.Text;
            profile.path.donation = donationTxtBox.Text;
            profile.path.subscriber = subscriberTxtBox.Text;

            movieProfiles[name] = profile;

            resetMovieProfileDataSource(name);
        }

        private void resetMovieProfileDataSource(string name)
        {
            bs = new BindingSource();
            bs.DataSource = movieProfiles;

            int index = -1;

            if (name != null)
            {

                foreach (KeyValuePair<string, MovieProfile> entry in movieProfiles)
                {
                    index++;
                    if (entry.Value.name == name)
                    {
                        break;
                    }
                }
            }

            movieProfileCmb.DataSource = bs;
            movieProfileCmb.DisplayMember = "Key";

            if (index != -1)
                movieProfileCmb.SelectedIndex = index;
        }

        private Object getCurrentMovieProfile()
        {
            Object profileObject;

            try
            {
                profileObject = ((KeyValuePair<string, MovieProfile>)movieProfileCmb.SelectedItem).Value;
            }
            catch (Exception)
            {
                profileObject = null;
            }

            return profileObject;
        }

        private void loadMovieProfiles()
        {
            try
            {
                using (StreamReader sr = new StreamReader(movieProfileFilePath))
                {
                    string json = sr.ReadToEnd();
                    List<MovieProfile> profiles = JsonConvert.DeserializeObject<List<MovieProfile>>(json);

                    foreach (MovieProfile profile in profiles)
                    {
                        movieProfiles.Add(profile.name, profile);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                saveMovieProfiles();
            }

            resetMovieProfileDataSource(null);
        }

        private void saveMovieProfiles()
        {
            List<MovieProfile> profiles = new List<MovieProfile>();

            foreach (KeyValuePair<string, MovieProfile> entry in movieProfiles)
            {
                profiles.Add(entry.Value);
            }

            using (FileStream fs = File.Open(movieProfileFilePath, FileMode.Create))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, profiles.ToArray());
            }

            MessageBox.Show(null, "All movie profiles have been successfully saved.", "Movie Profiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ALL CODE DEALING WITH MOVIE PROFILES ABOVE THIS LINE
    }
}
