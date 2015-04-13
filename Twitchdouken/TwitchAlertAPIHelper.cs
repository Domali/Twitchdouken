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
    class TwitchAlertAPIHelper
    {
        private string taAPI;
        private string taAccessToken;

        private List<Donation> donationList;
        private List<Donation> donationQueue;

        private bool    running = false;
        private int     updateSleepTime;
        private float   donationTotal;

        public TwitchAlertAPIHelper(string token)
        {
            taAPI = "http://www.twitchalerts.com/api/donations?access_token=";
            taAccessToken = token;

            donationQueue = new List<Donation>();
            updateSleepTime = 20;    //How many seconds between updates
            donationList = new List<Donation>();
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
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(taAPI + taAccessToken);
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

                if (!this.running)
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

            IList<JToken> results = parsedData["donations"].Children().ToList();

            foreach (JToken result in results)
            {
                Donation d = new Donation();

                d.name = (string)result["donator"]["name"];
                d.comment = (string)result["message"];
                d.amount = (string)result["amount"];
                d.id = (string)result["id"];

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
    struct Donation
    {
        public string name;
        public string comment;
        public string amount;
        public string id;
    }
}
