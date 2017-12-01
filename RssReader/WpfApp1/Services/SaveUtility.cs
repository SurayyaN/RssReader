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
            using (StreamWriter streamWriter = File.CreateText(@"c:\RSS Reader.json"))
            {
                foreach (RssFeedSubscription subscription in rssFeedSubscriptionList)
                {
                    streamWriter.WriteLine(subscription.Feed.Links[0].Uri);
                }
            }
        }

        public static List<string> LoadFromFile()
        {
            string filename = @"c:\RSS Reader.json";
            List<string> feeds = null; 
            
            if (File.Exists(filename))
            {
                string[] feedString = File.ReadAllLines(filename);
                feeds = new List<string>(feedString);
            }

            return feeds;
        }
    }
}
