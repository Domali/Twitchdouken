using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IrcDotNet;
using System.Threading;

namespace Twitchdouken
{
    class TwitchIRCHelper
    {
        private static TwitchIrcClient client;
        private static string channel_name;
        private static List<Host> new_host_queue;
        private static List<Subscriber> new_subscriber_queue;
        private static string user;
        private static string credentials;
        public static bool update_subscribers {get; set; }
        public static bool update_hosts { get; set; }
        public TwitchIRCHelper(string username, string password)
        {
            new_host_queue = new List<Host>();
            new_subscriber_queue = new List<Subscriber>();
            update_subscribers = false;
            update_hosts = false;
            user = username;
            credentials = password; 
        }

        public static void stopClient()
        {
            client.Disconnect();
        }

        public static void connectToIRC()
        {
            string server = "irc.twitch.tv";
            channel_name = "#" + user;
            client = new IrcDotNet.TwitchIrcClient();
            client.FloodPreventer = new IrcStandardFloodPreventer(4, 2000);
            client.Disconnected += IrcClient_Disconnected;
            client.Connected += IrcClient_Connected;
            client.Registered += IrcClient_Registered;
            using (var registeredEvent = new ManualResetEventSlim(false))
            {
                using (var connectedEvent = new ManualResetEventSlim(false))
                {
                    client.Connected += (sender2, e2) => connectedEvent.Set();
                    client.Registered += (sender2, e2) => registeredEvent.Set();
                    client.Connect(server, false,
                        new IrcUserRegistrationInfo()
                        {
                            NickName = user,
                            Password = credentials,
                            UserName = user
                        });
                    if (!connectedEvent.Wait(10000))
                    {
                        // Not being able to connect to the server.
                    }
                }
                if (!registeredEvent.Wait(10000))
                {
                    // If Registration fails
                }
            }
            client.Channels.Join(channel_name);
            client.SendRawMessage("twitchclient 3");      
        }
        private static void IrcClient_Registered(object sender, EventArgs e)
        {
            var client = (IrcClient)sender;

            client.LocalUser.NoticeReceived += IrcClient_LocalUser_NoticeReceived;
            client.LocalUser.MessageReceived += IrcClient_LocalUser_MessageReceived;
            client.LocalUser.JoinedChannel += IrcClient_LocalUser_JoinedChannel;
            client.LocalUser.LeftChannel += IrcClient_LocalUser_LeftChannel;
        }

        private static void IrcClient_LocalUser_LeftChannel(object sender, IrcChannelEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;

            e.Channel.UserJoined -= IrcClient_Channel_UserJoined;
            e.Channel.UserLeft -= IrcClient_Channel_UserLeft;
            e.Channel.MessageReceived -= IrcClient_Channel_MessageReceived;
            e.Channel.NoticeReceived -= IrcClient_Channel_NoticeReceived;

        }

        private static void IrcClient_LocalUser_JoinedChannel(object sender, IrcChannelEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;

            e.Channel.UserJoined += IrcClient_Channel_UserJoined;
            e.Channel.UserLeft += IrcClient_Channel_UserLeft;
            e.Channel.MessageReceived += IrcClient_Channel_MessageReceived;
            e.Channel.NoticeReceived += IrcClient_Channel_NoticeReceived;
        }

        private static void IrcClient_Channel_NoticeReceived(object sender, IrcMessageEventArgs e)
        {
            var channel = (IrcChannel)sender;
        }

        private static void IrcClient_Channel_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            var channel = (IrcChannel)sender;
            if(update_subscribers == true && channel.Name.ToLower() == channel_name && e.Source.Name.ToLower() == "twitchnotify")
            {
                string temp_string = e.Text;
                string[] sArray = temp_string.Split(new Char[] { ' ' });
                if(sArray.Length >=5 && sArray[4] == "months" )
                {
                    Subscriber sub = new Subscriber();
                    sub.name = sArray[0];
                    sub.months = sArray[3];
                    queueSubscriber(sub);
                }
            }
        }

        private static void IrcClient_Channel_UserLeft(object sender, IrcChannelUserEventArgs e)
        {
            var channel = (IrcChannel)sender;
        }

        private static void IrcClient_Channel_UserJoined(object sender, IrcChannelUserEventArgs e)
        {
            var channel = (IrcChannel)sender;
        }

        private static void IrcClient_LocalUser_MessageReceived(object sender, IrcMessageEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;
            if (update_hosts == true && e.Source is IrcUser && e.Source.Name.ToLower() == "jtv")
            {
                string temp_string = e.Text;
                string[] sArray = temp_string.Split(new Char[]{' '});
                if(sArray.Length >= 7 && sArray[3] == "hosting")
                {
                    Host host = new Host();
                    host.name = sArray[0];
                    host.viewers = sArray[6];
                    queueHost(host);
                }
            }   
        }

        private static void IrcClient_LocalUser_NoticeReceived(object sender, IrcMessageEventArgs e)
        {
            var localUser = (IrcLocalUser)sender;
        }

        private static void IrcClient_Disconnected(object sender, EventArgs e)
        {
            var client = (IrcClient)sender;
        }

        private static void IrcClient_Connected(object sender, EventArgs e)
        {
            var client = (IrcClient)sender;
        }

        private static void queueHost(Host host)
        {
            lock(new_host_queue)
            {
                new_host_queue.Add(host);
            }
        }

        private static void queueSubscriber(Subscriber subscriber)
        {
            lock (new_subscriber_queue)
            {
                new_subscriber_queue.Add(subscriber);
            }
        }

        public Subscriber getSubscriber()
        {
            Subscriber sub;
            lock (new_subscriber_queue)
            {
                sub = new_subscriber_queue.ElementAt(0);
                new_subscriber_queue.RemoveAt(0);
            }
            return sub;
        }

        public Host getHost()
        {
            Host host;
            lock(new_host_queue)
            {
                host = new_host_queue.ElementAt(0);
                new_host_queue.RemoveAt(0);
            }
            return host;
        }

        public bool newHostCheck()
        {
            return new_host_queue.Any();
        }

        public bool newSubscriberCheck()
        {
            return new_subscriber_queue.Any();
        }

    }
    public struct Host
    {
        public string name;
        public string viewers;
    }
}
