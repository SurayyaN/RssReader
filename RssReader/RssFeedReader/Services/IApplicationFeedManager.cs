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
        /// Onloads the specified RSS feed list.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="savedArticlesList">The saved articles list.</param>
        void Onload(ObservableCollection<RssFeed> rssFeedList, ObservableCollection<SavedArticle> savedArticlesList);

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
        /// Saves the articles.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        /// <param name="feedItem">The feed item.</param>
        void SaveArticles(ObservableCollection<SavedArticle> savedArticleList, RssFeedItem feedItem);

        /// <summary>
        /// Deletes the articles.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        void DeleteArticles(ObservableCollection<SavedArticle> savedArticleList);
    }
}
