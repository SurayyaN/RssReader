using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;
using Newtonsoft.Json;

namespace WpfApp1.Services
{
    public static class SaveUtility
    {
        public static void SaveToFile(ObservableCollection<RssFeedSubscription> rssFeedSubscriptionList)
        {
            //using (StreamWriter streamWriter = File.CreateText(@"c:\RSS Reader.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(streamWriter, rssFeedSubscriptionList);
            //}

            using (StreamWriter streamWriter = File.CreateText(@"c:\RSS Reader.json"))
            {
                foreach (RssFeedSubscription subscription in rssFeedSubscriptionList)
                {
                    streamWriter.WriteLine(subscription.Feed.Links[0].Uri);
                }
            }

            //    string jsonString = JsonConvert.SerializeObject(rssFeedSubscriptionList, Formatting.Indented);
            //File.WriteAllText(@"c:\RSS Reader.json", jsonString);
        }

        public static List<string> LoadFromFile()
        {
            string filename = @"c:\RSS Reader.json";
            List<string> feed = null; 
            
            if (File.Exists(filename))
            {
                string[] feedString = File.ReadAllLines(filename);
                feed = new List<string>(feedString);
            }

            return feed;
        }

        //public static ObservableCollection<RssFeedSubscription> LoadFromFile()
        //{
        //    ObservableCollection<RssFeedSubscription> subscriptionsList = null;

        //    //if (File.Exists(@"c:\RSS Reader.json"))
        //    //{
        //    //    subscriptionsList = JsonConvert.DeserializeObject<ObservableCollection<RssFeedSubscription>>(File.ReadAllText(@"c:\RSS Reader.json"));
        //    //}

        //    //using (StreamReader streamReader = File.OpenText(@"c:\RSS Reader.json"))
        //    //{
        //    //    JsonSerializer serializer = new JsonSerializer();
        //    //    subscriptionsList = (ObservableCollection<RssFeedSubscription>) serializer.Deserialize(streamReader,
        //    //            typeof(ObservableCollection<RssFeedSubscription>));
        //    //}

        //    return subscriptionsList;
        //}
    }
}
