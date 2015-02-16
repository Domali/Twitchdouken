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
        private List<Follower> follower_list;
        private List<Follower> new_follower_queue;
        private List<Subscriber> subscriber_list;
        private List<Subscriber> new_subscriber_queue;

        public TwitchAPIHelper(string channel_name, string client_id, string sub_access_token)
        {
            this.twitch_api = "https://api.twitch.tv/kraken/";
            this.follower_api = "channels/" + channel_name + "/follows";
            this.subscriber_api = "channels/" + channel_name + "/subscriptions";
            this.channel_name = channel_name;
            this.client_id = client_id;
            this.sub_access_token = sub_access_token;
            this.new_follower_queue = new List<Follower>();
            this.new_subscriber_queue = new List<Subscriber>();
            //Following files are obviously just placeholders for now
            //Maybe even look into using a database for this stuff
            this.follower_file = @"C:\Users\Sean\Desktop\current_followers.data";
            this.subscriber_file = @"C:\Users\Sean\Desktop\current_subscribers.data";
        }

        public void printRecentSubscribers()
        {
            List<Subscriber> subscriber_list = this.getRecentSubscribers();
            foreach (Subscriber subscriber in subscriber_list)
            {
                Console.WriteLine(subscriber.name);
            }
            return;
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
        public void printSubscriberTotal()
        {
            this.updateSubscriberTotal();
            Console.WriteLine(this.total_subscribers);
            return;
        }

        public void printAllSubscribers()
        {
            foreach (Subscriber subscriber in this.subscriber_list)
            {
                Console.WriteLine(subscriber.name);
            }
            return;
        }

        private void findNewSubscribers()
        {
            List<Subscriber> new_subscriber_list = this.getRecentSubscribers();
            foreach (Subscriber subscriber in new_subscriber_list)
            {
                bool found = this.subscriber_list.Any(x => x.name.ToLower() == subscriber.name.ToLower());
                if (!found)
                {
                    this.new_subscriber_queue.Add(subscriber);
                }
            }
            return;
        }

        private List<Follower> getRecentFollowers()
        {
            string api_request = this.follower_api + "?direction=DESC&limit=100";
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

        public void printFollowerTotal()
        {
            this.updateFollowerTotal();
            Console.WriteLine(this.total_followers);
            return;
        }

        private List<Follower> getAllFollowers()
        {
            List<Follower> followers = new List<Follower>();
            this.updateFollowerTotal();
            int end_offset = this.total_followers;
            for (int offset = 0; offset <= end_offset; offset += 100)
            {
                Console.WriteLine(offset.ToString());
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
            List<Follower> new_follower_list = this.getRecentFollowers();
            foreach (Follower follower in new_follower_list)
            {
                bool found = this.follower_list.Any(x => x.name.ToLower() == follower.name.ToLower());
                if (!found)
                {
                    this.new_follower_queue.Add(follower);                
                }
            }
            return;
        }

        public void printAllFollowers()
        {
            foreach (Follower follower in this.follower_list)
            {
                Console.WriteLine(follower.name);
            }
            return;
        }
        
        public void printRecentFollowers()
        {
            foreach (Follower follower in follower_list)
            {
                Console.WriteLine(follower.name);
            }
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
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.twitch_api + api_request);
            request.Accept = "application/vnd.twitchtv.v3+json";
            request.Headers.Add("Authorization", "OAuth " + this.sub_access_token);
            request.Headers.Add("Client-ID", this.client_id);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
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
    }
}
