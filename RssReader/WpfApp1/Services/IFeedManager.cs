using System.Collections.ObjectModel;
using RssFeedReader.Models;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Interface IFeedManager
    /// </summary>
    public interface IFeedManager
    {
        /// <summary>
        /// Adds the feed to the feed list.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeed">The RSS feed.</param>
        void AddFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed);

        /// <summary>
        /// Removes the feed from the feed list.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeed">The RSS feed.</param>
        void RemoveFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed);
    }
}
