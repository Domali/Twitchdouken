using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;

namespace Twitchdouken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TwitchAPIHelper twitchHelper;
        public MainWindow()
        {
            InitializeComponent();
            System.Windows.Threading.DispatcherTimer UIUpdaterTimer = new System.Windows.Threading.DispatcherTimer();
            UIUpdaterTimer.Tick += new EventHandler(UIUpdater_Tick);
            UIUpdaterTimer.Interval = new TimeSpan(0, 0, 1);
                        string channel_name = "domalix";
            string client_id = "qp3ucacbwu3thy6015demf8r8fn43ht";
            string oauth_token = "63zypnqeg3edq0xgyza99mrrlpass6";
            this.twitchHelper = new TwitchAPIHelper(channel_name, client_id, oauth_token);
            Thread t = new Thread(this.twitchHelper.runAsThread);
            t.Start();
            //example code for twitchalert access - this is my access token :)
            //string ta_acccess_token = "442DC86CCD9855FC";
            //TwitchAlertAPIHelper taHelper = new TwitchAlertAPIHelper(ta_acccess_token);
            //*/

            UIUpdaterTimer.Start();
            /*twitchHelper.syncFollowerList();
            List<Follower> list = twitchHelper.getFollowerList();
            foreach (Follower follower in list)
            {
                ListBoxItem itm = new ListBoxItem();
                itm.Content = follower.name;
                fb.Items.Add(itm);
            }*/
            
        }

        private void UIUpdater_Tick(object sender, EventArgs e)
        {
            fb_time.Content = this.twitchHelper.getFollowUpdateTime();
            sb_time.Content = this.twitchHelper.getSubscriberUpdateTime();
            List<Follower> new_followers = this.twitchHelper.getFollowerQueue();
            if(new_followers.Any())
            {
                foreach (Follower follower in new_followers)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = follower.name;
                    fb.Items.Insert(0, itm);
                }
            }
            List<Subscriber> new_subscribers = this.twitchHelper.getSubscriberQueue();
            if(new_subscribers.Any())
            {
                foreach (Subscriber subscriber in new_subscribers)
                {
                    ListBoxItem itm = new ListBoxItem();
                    itm.Content = subscriber.name;
                    sb.Items.Insert(0, itm);
                }
            }
        }
    }
}
