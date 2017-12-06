using System.Collections.Generic;
using System.Collections.ObjectModel;
using RssFeedReader.Models;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Interface ISaveUtility 
    /// </summary>
    public interface ISaveUtility
    {
        /// <summary>
        /// Loads the feeds from the saved rss
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        List<string> LoadFromFile();

        ///// <summary>
        ///// Loads the feed items from file.
        ///// </summary>
        ///// <returns>List&lt;RssFeedItem&gt;.</returns>
        //List<RssFeedItem> LoadFeedItemsFromFile();

        List<SavedRssFeedItem> LoadFeedItemsFromFile();

        /// <summary>
        /// Saves the feeds to a file
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        void SaveToFile(ObservableCollection<RssFeed> rssFeedList);

        ///// <summary>
        ///// Saves the feed item to file.
        ///// </summary>
        ///// <param name="rssFeedItem">The RSS feed item.</param>
        //void SaveFeedItemToFile(RssFeedItem rssFeedItem);

        //void SaveFeedItemToFile(SavedRssFeedItem rssFeedItem);

        void SaveFeedItemListToFile(ObservableCollection<SavedRssFeedItem> savedFeedItemList);
    }
}
