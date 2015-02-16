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

        public TwitchAlertAPIHelper(string ta_access_token)
        {
            this.ta_api = "http://www.twitchalerts.com/api/donations?access_token=";
            this.ta_access_token = ta_access_token;
            this.syncDonationList();
        }


        private string PollAPI()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.ta_api + this.ta_access_token);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            string responseFromServer = reader.ReadToEnd();
            return responseFromServer;
        }

        private void syncDonationList()
        {
            this.donation_list = this.getDonations();
            return;
        }

        public void printDonations()
        {
            foreach (Donation donation in this.donation_list)
            {
                Console.WriteLine(donation.name);
                Console.WriteLine(donation.comment);
                Console.WriteLine(donation.amount);
                Console.WriteLine(donation.id);
                Console.WriteLine();
            }
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
    }

    struct Donation
    {
        public string name;
        public string comment;
        public string amount;
        public string id;
    }
}
