using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Twitchdouken
{
    public partial class ConfigurationWindow : Form
    {
        private Twitchdouken parent;
        public ConfigurationWindow(Twitchdouken parent)
        {
            InitializeComponent();
            this.parent = parent;
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
    }
}
