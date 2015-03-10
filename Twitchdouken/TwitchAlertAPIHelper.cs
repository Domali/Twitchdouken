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
    class TwitchAlertAPIHelper
    {
        private string ta_api;
        private string ta_access_token;
        private List<Donation> donation_list;
        private List<Donation> new_donation_queue;
        private bool run_thread = false;
        private bool update_donations;
        private int update_sleep_time;

        public TwitchAlertAPIHelper(string ta_access_token)
        {
            this.ta_api = "http://www.twitchalerts.com/api/donations?access_token=";
            this.ta_access_token = ta_access_token;
            this.new_donation_queue = new List<Donation>();
            this.update_sleep_time = 30 * 1000;
            this.syncDonationList();
        }


        private string PollAPI()
        {
            
            bool keepTrying = true;
            string responseFromServer = "";
            while (keepTrying)
            {
                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.ta_api + this.ta_access_token);
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

        public void runAsThread()
        {
            this.run_thread = true;
            this.update_donations = true;
            this.syncDonationList();
            while (this.run_thread)
            {
                if(this.update_donations)
                {
                    this.findNewDonations();
                }
                System.Threading.Thread.Sleep(this.update_sleep_time);
            }
            return;
        }

        public bool newDonationCheck()
        {
            return this.new_donation_queue.Any();
        }

        public Donation getDonation()
        {
            Donation donation;
            lock(this.new_donation_queue)
            {
                
                donation = this.new_donation_queue.ElementAt(0);
                this.new_donation_queue.RemoveAt(0);
            }
            return donation;
        }
        
        private void  queueDonation(Donation donation)
        {
            lock(this.new_donation_queue)
            {
                this.new_donation_queue.Add(donation); 
            }
        }
        private void syncDonationList()
        {
            this.donation_list = this.getDonations();
            return;
        }

        private List<Donation> getDonations()
        {
            List<Donation> donation_list = new List<Donation>();
            string data = this.PollAPI();
            JObject parsed_data = JObject.Parse(data);
            IList<JToken> results = parsed_data["donations"].Children().ToList();
            foreach (JToken result in results)
            {
                Donation donation = new Donation();
                donation.name = (string)result["donator"]["name"];
                donation.comment = (string)result["message"];
                donation.amount = (string)result["amount"];
                donation.id = (string)result["id"];
                donation_list.Add(donation);
            }
            return donation_list;
        }

        private void findNewDonations()
        {

            List<Donation> new_donation_list = this.getDonations();
            foreach (Donation donation in new_donation_list)
            {
                bool found = this.donation_list.Any(x => x.id == donation.id);
                if (!found)
                {
                    this.donation_list.Add(donation);
                    this.queueDonation(donation);
                }
            }
            return;
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
