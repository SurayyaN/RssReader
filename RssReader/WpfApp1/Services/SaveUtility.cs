using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    /// <summary>
    /// Class SaveUtility.
    /// </summary>
    /// <seealso cref="WpfApp1.Services.ISaveUtility" />
    public class SaveUtility : ISaveUtility
    {
        /// <summary>
        /// Loads the feeds from the saved rss
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> LoadFromFile()
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

        /// <summary>
        /// Saves the feeds to a file
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        public void SaveToFile(ObservableCollection<RssFeed> rssFeedList)
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
