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
    class StreamtipAPIHelper
    {
        private string API;
        private string AccessToken;
        private string ClientID;

        private List<Donation> donationList;
        private List<Donation> donationQueue;

        private bool    running = false;
        private int     updateSleepTime;
        private float   donationTotal;

        public StreamtipAPIHelper(string token, string id)
        {
            API = "https://streamtip.com/api/tips?client_id=" + id + "&access_token=" + token;
            AccessToken = token;
            ClientID = id;

            donationList = new List<Donation>();
            donationQueue = new List<Donation>();

            updateSleepTime = 30;    //How many seconds between updates
            donationTotal = 0;
        }


        private string pollAPI()
        {
            bool keepTrying = true;
            string responseFromServer = "";

            while (keepTrying)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(API);
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

        public void runAsThread()
        {
            running = true;
            syncDonationList();

            while (true)
            {
                findNewDonations();

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

        public float getDonationTotal()
        {
            return donationTotal;
        }

        public bool newDonationCheck()
        {
            return donationQueue.Any();
        }

        public Donation getDonation()
        {
            Donation donation;

            lock(donationQueue)
            {
                donation = donationQueue.ElementAt(0);
                donationQueue.RemoveAt(0);
            }
            return donation;
        }
        
        private void queueDonation(Donation donation)
        {
            lock(donationQueue)
            {
                donationQueue.Add(donation); 
            }
        }
        private void syncDonationList()
        {
            donationList = getDonations();
        }

        private List<Donation> getDonations()
        {
            List<Donation> donations = new List<Donation>();

            string data = pollAPI();
            JObject parsedData = JObject.Parse(data);

            IList<JToken> results = parsedData["tips"].Children().ToList();

            foreach (JToken result in results)
            {
                Donation d = new Donation();

                d.name = (string)result["username"];
                d.comment = (string)result["note"];
                d.amount = (string)result["amount"];
                d.id = (string)result["_id"];
                donations.Add(d);
            }
            return donations;
        }

        private void findNewDonations()
        {
            List<Donation> donations = getDonations();

            foreach (Donation donation in donations)
            {
                bool found = donationList.Any(x => x.id == donation.id);

                if (!found)
                {
                    donationTotal += float.Parse(donation.amount);
                    donationList.Add(donation);
                    queueDonation(donation);
                }
            }
        }
    }
}
