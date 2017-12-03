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
        public static List<string> LoadFromFile()
        {
            string filename = @"c:\RSS Feeds.json";
            List<string> feeds = null; 
            
            if (File.Exists(filename))
            {
                string[] feedString = File.ReadAllLines(filename);
                feeds = new List<string>(feedString);
            }

            return feeds;
        }

        public static void SaveToFile(string url)
        {
                using (StreamWriter streamwriter = File.AppendText(@"c:\RSS Feeds.json"))
                {
                    streamwriter.WriteLine(url);
                }
        }

        public static void SaveToFile(ObservableCollection<RssFeed> rssFeedList)
        {
            using (StreamWriter streamWriter = File.CreateText(@"c:\RSS Feeds.json"))
            {
                foreach (RssFeed feed in rssFeedList)
                {
                    streamWriter.WriteLine(feed.RssUrl);
                }
            }
        }
    }
}
