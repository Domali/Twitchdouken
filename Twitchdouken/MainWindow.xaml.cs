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

namespace Twitchdouken
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            string channel_name = "domalix";
            string client_id = "qp3ucacbwu3thy6015demf8r8fn43ht";
            string oauth_token = "63zypnqeg3edq0xgyza99mrrlpass6";
            TwitchAPIHelper twitchHelper = new TwitchAPIHelper(channel_name, client_id, oauth_token);*/
            //example code for twitchalert access - this is my access token :)
            string ta_acccess_token = "442DC86CCD9855FC";
            TwitchAlertAPIHelper taHelper = new TwitchAlertAPIHelper(ta_acccess_token);
            //*/
        }
    }
}
