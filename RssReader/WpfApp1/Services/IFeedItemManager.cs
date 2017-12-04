using System.Collections.ObjectModel;
using System.ServiceModel.Syndication;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    /// <summary>
    /// Interface IFeedItemManager
    /// </summary>
    public interface IFeedItemManager
    {
        /// <summary>
        /// Adds the feed items from the feed list.
        /// </summary>
        /// <param name="feed">The feed.</param>
        /// <param name="rssFeedItems">The RSS feed items.</param>
        void AddFeedItem(SyndicationFeed feed, ObservableCollection<RssFeedItem> rssFeedItems);
    }
}
