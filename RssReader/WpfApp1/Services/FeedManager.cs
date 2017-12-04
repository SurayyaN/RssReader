using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using RssFeedReader.Models;
using RssFeedReader.Properties;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Class FeedManager.
    /// </summary>
    /// <seealso cref="RssFeedReader.Services.IFeedManager" />
    [Serializable]
    public class FeedManager : IFeedManager
    {
        private ISaveUtility _saveUtility;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedManager"/> class.
        /// </summary>
        /// <param name="saveUtility">The save utility.</param>
        public FeedManager(ISaveUtility saveUtility)
        {
            _saveUtility = saveUtility;
        }

        /// <summary>
        /// Adds the feed to the feed list.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeed">The RSS feed.</param>
        public void AddFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed)
        {
            if (rssFeedList.Count() != 0)
            {
                bool exist = rssFeedList.Any(c => c.Feed.Title.Text == rssFeed.Feed.Title.Text);

                if (exist)
                {
                    MessageBox.Show(Resources.ERROR_LOADING_FEED_MESSAGE, Resources.MESSAGEBOX_ALERT, MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                    rssFeedList.Add(rssFeed);
            }

            else
            {
                rssFeedList.Add(rssFeed);
            }

            _saveUtility.SaveToFile(rssFeedList);
        }

        /// <summary>
        /// Removes the feed from the feed list.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeed">The RSS feed.</param>
        public void RemoveFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed)
        {
            rssFeedList.Remove(rssFeed);
        }
    }
}
