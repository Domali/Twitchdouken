using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twitchdouken
{
    public class TwitchAPIHelper
    {
        private string twitch_api;
        private string follower_api;
        private string subscriber_api;
        private string channel_name;
        private string client_id;
        private string sub_access_token;
        private int total_followers;
        private int total_subscribers;
        private string follower_file;
        private string subscriber_file;
        private string follow_update_time;
        private string subscriber_update_time;
        private bool update_followers;
        private bool update_subscribers;
        private bool run_thread;
        private int update_sleep_time;
        private List<Follower> follower_list;
        private List<Follower> new_follower_queue;
        private List<Subscriber> subscriber_list;
        private List<Subscriber> new_subscriber_queue;
        private Random rand;
        public TwitchAPIHelper(string channel_name, string sub_access_token)
        {
            rand = new Random();
            this.twitch_api = "https://api.twitch.tv/kraken/";
            this.follow_update_time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            this.subscriber_update_time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            this.follower_api = "channels/" + channel_name + "/follows";
            this.subscriber_api = "channels/" + channel_name + "/subscriptions";
            this.channel_name = channel_name;
            this.client_id = "qp3ucacbwu3thy6015demf8r8fn43ht";
            this.sub_access_token = sub_access_token;
            this.new_follower_queue = new List<Follower>();
            this.new_subscriber_queue = new List<Subscriber>();
            this.update_sleep_time = 30 * 1000;
            //Following files are obviously just placeholders for now
            //Maybe even look into using a database for this stuff
            this.follower_file = @"C:\Users\Sean\Desktop\current_followers.data";
            this.subscriber_file = @"C:\Users\Sean\Desktop\current_subscribers.data";
        }

        public void runAsThread()
        {
            this.run_thread = true;
            this.update_followers = true;
            this.update_subscribers = true;
            this.syncFollowerList();
            this.syncSubscriberList();
            while (this.run_thread)
            {
                if (this.update_followers)
                {
                    this.findNewFollowers();
                }
                if (this.update_subscribers)
                {
                    this.findNewSubscribers();
                }
                System.Threading.Thread.Sleep(this.update_sleep_time);
            }
            return;
        }

        public bool newFollowerCheck()
        {
            return this.new_follower_queue.Any();
        }

        public bool newSubscriberCheck()
        {
            return this.new_subscriber_queue.Any();
        }

        public List<Follower> getFollowerQueue()
        {
            //Returns the follow queue when requested and then empties it
            List<Follower> copy;
            lock(this.new_follower_queue)
            {
                copy = new List<Follower>(this.new_follower_queue);
                this.new_follower_queue.Clear();
            }
            return copy;
        }

        public string getFollowUpdateTime()
        {
            return this.follow_update_time;
        }

        public string getSubscriberUpdateTime()
        {
            return this.subscriber_update_time;
        }

        public Subscriber getSubscriber()
        {
            //Returns the subscriber queue when requested and then empties it
            Subscriber sub;
            lock(this.new_subscriber_queue)
            {
                sub = this.new_subscriber_queue.ElementAt(0);
                this.new_subscriber_queue.RemoveAt(0);
            }
            return sub;
        }

        private void queueFollowers(List<Follower> list)
        {
            lock(this.new_follower_queue)
            {
                this.new_follower_queue.AddRange(list);
            }
            return;
        }

        private void queueSubscribers(List<Subscriber> list)
        {
            lock(this.new_subscriber_queue)
            {
                this.new_subscriber_queue.AddRange(list);
            }
            return;
        }
        public List<Follower> getFollowerList()
        {
            return this.follower_list;
        }

        private List<Subscriber> getRecentSubscribers()
        {
            string api_request = this.subscriber_api + "?direction=DESC&limit=25";
            string subscriber_data = this.PollAPI(api_request);
            return this.parseSubscribers(subscriber_data);
        }

        private List<Subscriber> parseSubscribers(string data)
        {
            List<Subscriber> subscribers = new List<Subscriber>();
            JObject parsed_data = JObject.Parse(data);
            IList<JToken> results = parsed_data["subscriptions"].Children().ToList();
            foreach (JToken result in results)
            {
                Subscriber subscriber = new Subscriber();
                subscriber.name = (string)result["user"]["display_name"];
                subscribers.Add(subscriber);
            }
            return subscribers;
        }

        private void updateSubscriberTotal()
        {
            string data = this.PollAPI(this.subscriber_api + "?limit=1");
            JObject parsed_data = JObject.Parse(data);
            this.total_subscribers = (int)parsed_data["_total"];
            return;
        }

        private List<Subscriber> getAllSubscribers()
        {
            List<Subscriber> subscribers = new List<Subscriber>();
            this.updateSubscriberTotal();
            int end_offset = this.total_subscribers;
            for (int offset = 0; offset <= end_offset; offset += 100)
            {
                string api_request = this.subscriber_api + "?direction=DESC&limit=100&offset=" + offset.ToString();
                string data = this.PollAPI(api_request);
                subscribers.AddRange(this.parseSubscribers(data));
            }
            return subscribers;
        }

        public void syncSubscriberList()
        {
            List<Subscriber> subscriber_list = this.getAllSubscribers();
            this.subscriber_list = subscriber_list;
            return;

        }

        private void findNewSubscribers()
        {
            List<Subscriber> subscriber_list = this.getRecentSubscribers();
            List<Subscriber> new_subscriber_list = new List<Subscriber>();
            this.subscriber_update_time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            foreach (Subscriber subscriber in subscriber_list)
            {
                bool found = this.subscriber_list.Any(x => x.name.ToLower() == subscriber.name.ToLower());
                if (!found)
                {
                    new_subscriber_list.Add(subscriber);
                }
            }
            this.subscriber_list.AddRange(new_subscriber_list);
            this.queueSubscribers(new_subscriber_list);
            return;
        }

        private List<Follower> getRecentFollowers()
        {
            string api_request = this.follower_api + "?direction=DESC&limit=100&offset=0";
            string follower_data = this.PollAPI(api_request);
            return this.parseFollowers(follower_data);
        }

        private List<Follower> parseFollowers(string data)
        {
            List<Follower> followers = new List<Follower>();
            JObject parsed_data = JObject.Parse(data);
            IList<JToken> results = parsed_data["follows"].Children().ToList();
            foreach (JToken result in results)
            {
                Follower follower = new Follower();
                follower.name = (string)result["user"]["display_name"];
                followers.Add(follower);
            }
            return followers;
        }

        private void updateFollowerTotal()
        {
            string data = this.PollAPI(this.follower_api + "?limit=1");
            JObject parsed_data = JObject.Parse(data);
            this.total_followers = (int)parsed_data["_total"];
            return;
        }

        private List<Follower> getAllFollowers()
        {
            List<Follower> followers = new List<Follower>();
            this.updateFollowerTotal();
            //Block this out to only get the first 200 until twitch fixes their api.
            int end_offset = 1600;//this.total_followers;
            for (int offset = 0; offset <= end_offset; offset += 100)
            {
                string api_request = this.follower_api + "?direction=DESC&limit=100&offset=" + offset.ToString();
                string data = this.PollAPI(api_request);
                followers.AddRange(this.parseFollowers(data));
            }
            return followers;
        }

        public void syncFollowerList()
        {
            List<Follower> follower_list = this.getAllFollowers();
            this.follower_list = follower_list;
            return;
        }

        private void findNewFollowers()
        {
            List<Follower> follower_list = this.getRecentFollowers();
            List<Follower> new_follower_list = new List<Follower>();
            this.follow_update_time = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            foreach (Follower follower in follower_list)
            {
                bool found = this.follower_list.Any(x => x.name.ToLower() == follower.name.ToLower());
                if (!found)
                {
                    new_follower_list.Add(follower);
                }
            }
            this.follower_list.AddRange(new_follower_list);
            this.queueFollowers(new_follower_list);
            return;
        }

        private void saveFollowers()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.follower_file))
            {
                foreach (Follower follower in this.follower_list)
                {
                    file.WriteLine(follower.name);
                }
            }
            return;
        }

        private void saveSubscribers()
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(this.subscriber_file))
            {
                foreach (Subscriber subscriber in this.subscriber_list)
                {
                    file.WriteLine(subscriber.name);
                }
            }
            return;
        }

        private string PollAPI(string api_request)
        {
            bool keepTrying = true;
            string responseFromServer = "";
            
            while (keepTrying)
            {
                try
                {
                    string random_string = "&" + this.rand.Next(1, 99999999).ToString();
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.twitch_api + api_request + random_string);
                    request.Accept = "application/vnd.twitchtv.v3+json";
                    request.Headers.Add("Authorization", "OAuth " + this.sub_access_token);
                    request.Headers.Add("Client-ID", this.client_id);
                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();
                    keepTrying = false;
                }
                catch
                {
                    Console.WriteLine("Webrequest failed, waiting and trying again.");
                    System.Threading.Thread.Sleep(4000);
                }
            }
            return responseFromServer;
        }
    }

    public struct Follower
    {
        public string name;
    }

    public struct Subscriber
    {
        public string name;
        public string months;
    }
}
