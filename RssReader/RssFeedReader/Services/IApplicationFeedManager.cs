using System.Collections.ObjectModel;
using RssFeedReader.Models;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Interface IApplicationFeedManager
    /// </summary>
    public interface IApplicationFeedManager
    {
        /// <summary>
        /// loads the feeds from the saved rss list and saved feed items on startup
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        //void Onload(ObservableCollection<RssFeed> rssFeedList, ObservableCollection<RssFeedItem> savedFeedItemsList);

        void Onload(ObservableCollection<RssFeed> rssFeedList, ObservableCollection<SavedRssFeedItem> savedFeedItemsList);

        /// <summary>
        /// Adds the feed from the feed list into the feed item list.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeedItemList">The RSS feed item list.</param>
        void AddFeed(string url, ObservableCollection<RssFeed> rssFeedList, ObservableCollection<RssFeedItem> rssFeedItemList);

        /// <summary>
        /// Deletes the feed selected by user.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeedItemList">The RSS feed item list.</param>
        void DeleteFeed(ObservableCollection<RssFeed> rssFeedList, ObservableCollection<RssFeedItem> rssFeedItemList);

        /// <summary>
        /// Loads and sorts the feed items to view.
        /// </summary>
        /// <param name="rssFeeds">The RSS feeds.</param>
        /// <param name="rssFeedItems">The RSS feed items.</param>
        void LoadFeedItemToView(ObservableCollection<RssFeed> rssFeeds,
                ObservableCollection<RssFeedItem> rssFeedItems);

        /// <summary>
        /// Saves the feed items.
        /// </summary>
        /// <param name="feedItemsToSave">The feed items to save.</param>
        //void SaveFeedItems(ObservableCollection<RssFeedItem> feedItemsToSave);

        void SaveFeedItems(ObservableCollection<SavedRssFeedItem> savedFeedItemsList, RssFeedItem feedItem);

        void DeleteFeedItems(ObservableCollection<SavedRssFeedItem> savedFeedItemList);

    }
}
