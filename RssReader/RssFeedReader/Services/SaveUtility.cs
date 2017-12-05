using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using RssFeedReader.Models;
using RssFeedReader.Properties;
using Newtonsoft.Json;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Class SaveUtility.
    /// </summary>
    /// <seealso cref="RssFeedReader.Services.ISaveUtility" />
    public class SaveUtility : ISaveUtility
    {
        /// <summary>
        /// Loads the feeds from the saved rss
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        public List<string> LoadFromFile()
        {
            string filename = Settings.Default.SaveFileName;
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
            using (StreamWriter streamWriter = File.CreateText(Settings.Default.SaveFileName))
            {
                foreach (RssFeed feed in rssFeedList)
                {
                    streamWriter.WriteLine(feed.RssUrl);
                }
            }
        }

        public void SaveFeedItemToFile(RssFeedItem rssFeedItem)
        {
            File.WriteAllText(Settings.Default
                .SaveFeedItemFileName, JsonConvert.SerializeObject(rssFeedItem, Formatting.Indented));
        }
    }
}
