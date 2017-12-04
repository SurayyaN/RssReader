using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;
using RssFeedReader.Models;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Class FeedItemManager.
    /// </summary>
    /// <seealso cref="RssFeedReader.Services.IFeedItemManager" />
    public class FeedItemManager : IFeedItemManager
    {

        /// <summary>
        /// Adds the feed items from the feed.
        /// </summary>
        /// <param name="feed">The feed.</param>
        /// <param name="rssFeedItems">The RSS feed items.</param>
        public void AddFeedItem(SyndicationFeed feed, ObservableCollection<RssFeedItem> rssFeedItems)
        {
            foreach (SyndicationItem items in feed.Items)
            {
                rssFeedItems.Add(new RssFeedItem()
                {
                    Website = feed.Title.Text,
                    Item = items
                });
            }
        }
    }
}
