﻿using System.Collections.Generic;
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

        ///// <summary>
        ///// Loads the feed items from file.
        ///// </summary>
        ///// <returns>List&lt;RssFeedItem&gt;.</returns>
        //public List<RssFeedItem> LoadFeedItemsFromFile()
        //{
        //    List<RssFeedItem> savedFeedItemsList = null;
        //    string filename = Settings.Default.SaveFeedItemFileName;

        //    if (File.Exists(filename))
        //    {
        //        string json = File.ReadAllText(Settings.Default.SaveFeedItemFileName);

        //        if (json != null)
        //        {
        //            savedFeedItemsList = JsonConvert.DeserializeObject<List<RssFeedItem>>(json);
        //        }
        //    }

        //    return savedFeedItemsList;
        //}

        //public List<SavedRssFeedItem> LoadFeedItemsFromFile()
        //{
        //    List<SavedRssFeedItem> savedFeedItemsList = null;
        //    string filename = Settings.Default.SaveFeedItemFileName;

        //    if (File.Exists(filename))
        //    {
        //        string json = File.ReadAllText(Settings.Default.SaveFeedItemFileName);

        //        if (json != null)
        //        {
        //            savedFeedItemsList = JsonConvert.DeserializeObject<List<SavedRssFeedItem>>(json);
        //        }
        //    }

        //    return savedFeedItemsList;
        //}

        public List<SavedArticle> LoadArticlesFromFile()
        {
            List<SavedArticle> savedArticlesList = null;
            string filename = Settings.Default.SaveFeedItemFileName;

            if (File.Exists(filename))
            {
                string json = File.ReadAllText(Settings.Default.SaveFeedItemFileName);

                if (json != null)
                {
                    savedArticlesList = JsonConvert.DeserializeObject<List<SavedArticle>>(json);
                }
            }

            return savedArticlesList;
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

        ///// <summary>
        ///// Saves the feed item to file.
        ///// </summary>
        ///// <param name="rssFeedItem">The RSS feed item.</param>
        //public void SaveFeedItemToFile(RssFeedItem rssFeedItem)
        //{
        //    File.WriteAllText(Settings.Default
        //        .SaveFeedItemFileName, JsonConvert.SerializeObject(rssFeedItem, Formatting.Indented));
        //}

        //public void SaveFeedItemToFile(SavedRssFeedItem rssFeedItem)
        //{
        //    File.WriteAllText(Settings.Default
        //        .SaveFeedItemFileName, JsonConvert.SerializeObject(rssFeedItem, Formatting.Indented));
        //}

        //public void SaveFeedItemListToFile(ObservableCollection<SavedRssFeedItem> savedFeedItemList)
        //{
        //    string json = JsonConvert.SerializeObject(savedFeedItemList, Formatting.Indented);

        //    if (json != null)
        //    {
        //        File.WriteAllText(Settings.Default.SaveFeedItemFileName, json);
        //    }
        //}

        public void SaveArticlesToFile(ObservableCollection<SavedArticle> savedArticlesList)
        {
            string json = JsonConvert.SerializeObject(savedArticlesList, Formatting.Indented);

            if (json != null)
            {
                File.WriteAllText(Settings.Default.SaveFeedItemFileName, json);
            }
        }
    }
}
