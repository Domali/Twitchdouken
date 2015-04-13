using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Twitchdouken
{
    public class TwitchAPIHelper
    {
        private string twitchAPI;
        private string followerAPI;
        private string subscriberAPI;
        private string channelName;
        private string clientId;
        private string accessToken;

        private int totalFollowers;
        private int totalSubscribers;

        //private string followUpdateTime;
        //private string subscriberUpdateTime;

        public bool updateFollowers;
        public bool updateSubscribers;

        private bool running;

        private int updateSleepTime;

        private List<Follower> followerList;
        private List<Follower> followerQueue;
        private List<Subscriber> subscriberList;
        private List<Subscriber> subscriberQueue;

        private int sessionFollowers;
        private int sessionSubscribers;

        private Random rand;

        public TwitchAPIHelper(string channel, string token)
        {
            rand = new Random();

            //followUpdateTime = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            //subscriberUpdateTime = string.Format("{0:HH:mm:ss tt}", DateTime.Now);

            twitchAPI = "https://api.twitch.tv/kraken/";
            followerAPI = "channels/" + channel + "/follows";
            subscriberAPI = "channels/" + channel + "/subscriptions";
            channelName = channel;
            clientId = "qp3ucacbwu3thy6015demf8r8fn43ht";
            accessToken = token;

            this.followerQueue = new List<Follower>();
            this.subscriberQueue = new List<Subscriber>();

            this.sessionFollowers = 0;
            this.sessionSubscribers = 0;
            this.updateSleepTime = 30;  //How many seconds between updates
        }

        public void runAsThread()
        {
            running = true;

            if (updateFollowers)
                syncFollowerList();

            if (updateSubscribers)
                syncSubscriberList();

            while (true)
            {
                if (updateSubscribers)
                    findNewSubscribers();

                if (updateFollowers)
                    findNewFollowers();

                for (int x = 0; x < this.updateSleepTime; x++)
                {
                    Thread.Sleep(1000);

                    if (!running)
                        break;
                }

                if (!running)
                    break;
            }
        }

        public void stopThread()
        {
            running = false;
        }

        public bool newFollowerCheck()
        {
            return followerQueue.Any();
        }

        public bool newSubscriberCheck()
        {
            return subscriberQueue.Any();
        }

        public List<Follower> getFollowerQueue()
        {
            //Returns the follow queue when requested and then empties it
            List<Follower> copy;

            lock(followerQueue)
            {
                copy = new List<Follower>(followerQueue);
                followerQueue.Clear();
            }
            return copy;
        }

        //public string getFollowUpdateTime()
        //{
            //return this.followUpdateTime;
        //}

        //public string getSubscriberUpdateTime()
        //{
            //return this.subscriberUpdateTime;
        //}

        public Subscriber getSubscriber()
        {
            //Returns the subscriber queue when requested and then empties it
            Subscriber sub;

            lock(subscriberQueue)
            {
                sub = subscriberQueue.ElementAt(0);
                subscriberQueue.RemoveAt(0);
            }
            return sub;
        }

        private void queueFollowers(List<Follower> list)
        {
            lock(followerQueue)
                followerQueue.AddRange(list);
        }

        private void queueSubscribers(List<Subscriber> list)
        {
            lock(subscriberQueue)
                subscriberQueue.AddRange(list);
        }
        public List<Follower> getFollowerList()
        {
            return followerList;
        }

        private List<Subscriber> getRecentSubscribers()
        {
            string apiRequest = subscriberAPI + "?direction=DESC&limit=25";
            string subscriberData = pollAPI(apiRequest);

            return parseSubscribers(subscriberData);
        }

        private List<Subscriber> parseSubscribers(string data)
        {
            List<Subscriber> subscribers = new List<Subscriber>();

            JObject parsedData = JObject.Parse(data);

            IList<JToken> results = parsedData["subscriptions"].Children().ToList();

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
            string data = pollAPI(subscriberAPI + "?limit=1");
            JObject parsed_data = JObject.Parse(data);
            totalSubscribers = (int)parsed_data["_total"];
        }

        private List<Subscriber> getAllSubscribers()
        {
            List<Subscriber> subscribers = new List<Subscriber>();

            updateSubscriberTotal();

            int endOffset = totalSubscribers;
            for (int offset = 0; offset <= endOffset; offset += 100)
            {
                string apiRequest = subscriberAPI + "?direction=DESC&limit=100&offset=" + offset.ToString();
                string data = pollAPI(apiRequest);

                subscribers.AddRange(parseSubscribers(data));

                if (!running)
                    break;
            }
            return subscribers;
        }

        public void syncSubscriberList()
        {
            subscriberList = getAllSubscribers();
        }

        private void findNewSubscribers()
        {
            List<Subscriber> subscribers = getRecentSubscribers();
            List<Subscriber> newSubscribers = new List<Subscriber>();
            //subscriberUpdateTime = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            foreach (Subscriber subscriber in subscribers)
            {
                bool found = subscriberList.Any(x => x.name.ToLower() == subscriber.name.ToLower());

                if (!found)
                {
                    sessionSubscribers++;
                    newSubscribers.Add(subscriber);
                }
            }

            subscriberList.AddRange(newSubscribers);
            queueSubscribers(newSubscribers);
        }

        private List<Follower> getRecentFollowers()
        {
            string apiRequest = followerAPI + "?direction=DESC&limit=100&offset=0";
            string followerData = pollAPI(apiRequest);

            return parseFollowers(followerData);
        }

        private List<Follower> parseFollowers(string data)
        {
            List<Follower> followers = new List<Follower>();

            JObject parsedData = JObject.Parse(data);

            IList<JToken> results = parsedData["follows"].Children().ToList();
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
            string data = pollAPI(followerAPI + "?limit=1");
            JObject parsedData = JObject.Parse(data);
            totalFollowers = (int)parsedData["_total"];
        }

        private List<Follower> getAllFollowers()
        {
            List<Follower> followers = new List<Follower>();

            updateFollowerTotal();
            //Block this out to only get the first 1700 until twitch fixes their api.
            int endOffset = 1600;//this.total_followers;

            if (totalFollowers < endOffset)
                endOffset = totalFollowers;

            for (int offset = 0; offset <= endOffset; offset += 100)
            {
                string apiRequest = followerAPI + "?direction=DESC&limit=100&offset=" + offset.ToString();
                string data = pollAPI(apiRequest);

                followers.AddRange(parseFollowers(data));

                if (!running)
                    break;
            }
            return followers;
        }

        public void syncFollowerList()
        {
            followerList = getAllFollowers();
        }

        private void findNewFollowers()
        {
            List<Follower> followers = getRecentFollowers();
            List<Follower> newFollowers = new List<Follower>();

            //followUpdateTime = string.Format("{0:HH:mm:ss tt}", DateTime.Now);
            foreach (Follower follower in followers)
            {
                bool found = followerList.Any(x => x.name.ToLower() == follower.name.ToLower());

                if (!found)
                {
                    sessionFollowers++;
                    newFollowers.Add(follower);
                }
            }

            followerList.AddRange(newFollowers);
            queueFollowers(newFollowers);
        }

        /*private void saveFollowers()
        {
        }

        private void saveSubscribers()
        {
        }*/

        private string pollAPI(string APIRequest)
        {
            bool keepTrying = true;
            string responseFromServer = "";
            
            while (keepTrying)
            {
                try
                {
                    string randomString = "&" + rand.Next(1, 99999999).ToString();

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(twitchAPI + APIRequest + randomString);
                    request.Accept = "application/vnd.twitchtv.v3+json";
                    request.Headers.Add("Authorization", "OAuth " + accessToken);
                    request.Headers.Add("Client-ID", clientId);

                    WebResponse response = request.GetResponse();
                    Stream dataStream = response.GetResponseStream();

                    StreamReader reader = new StreamReader(dataStream);
                    responseFromServer = reader.ReadToEnd();  

                    keepTrying = false;
                }
                catch
                {
                    Console.WriteLine("Webrequest failed, waiting and trying again.");
                    Thread.Sleep(4000);
                }
            }
            return responseFromServer;
        }
        
        public int getSessionFollowerTotal()
        {
            return sessionFollowers;
        }

        public int getSessionSubscriberTotal()
        {
            return sessionSubscribers;
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
