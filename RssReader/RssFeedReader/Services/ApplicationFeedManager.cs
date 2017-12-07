using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Windows;
using System.Xml;
using RssFeedReader.Models;
using RssFeedReader.Properties;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Class ApplicationFeedManager.
    /// </summary>
    /// <seealso cref="RssFeedReader.Services.IApplicationFeedManager" />
    public class ApplicationFeedManager : IApplicationFeedManager
    {
        private IFeedManager _feedManager;
        private IFeedItemManager _feedItemManager;
        private ISavedArticlesManager _savedFeedItemManager;
        private ISaveUtility _saveUtility;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationFeedManager"/> class.
        /// </summary>
        /// <param name="feedManager">The feed manager.</param>
        /// <param name="feedItemManager">The feed item manager.</param>
        /// <param name="saveUtility">The save utility.</param>
        public ApplicationFeedManager(IFeedManager feedManager, IFeedItemManager feedItemManager, ISavedArticlesManager savedFeedItemManager, ISaveUtility saveUtility)
        {
            _feedManager = feedManager;
            _feedItemManager = feedItemManager;
            _savedFeedItemManager = savedFeedItemManager;
            _saveUtility = saveUtility;
        }

        /// <summary>
        /// Onloads the specified RSS feed list.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="savedArticlesList">The saved articles list.</param>
        public void Onload(ObservableCollection<RssFeed> rssFeedList, ObservableCollection<SavedArticle> savedArticlesList)
        {
            if (_saveUtility.LoadFromFile() != null)
            {
                foreach (string uri in _saveUtility.LoadFromFile())
                {
                    SyndicationFeed feed = LoadFeedFromUrl(uri);

                    if (feed != null)
                    {
                        _feedManager.AddFeed(rssFeedList, new RssFeed() { Feed = feed, RssUrl = uri });
                    }
                }
            }

            if (_saveUtility.LoadArticlesFromFile() != null)
            {
                foreach (SavedArticle article in _saveUtility.LoadArticlesFromFile())
                {
                    savedArticlesList.Add(article);
                }
            }
        }

        /// <summary>
        /// Adds the feed from the feed list into the feed item list.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeedItemList">The RSS feed item list.</param>
        public void AddFeed(string url, ObservableCollection<RssFeed> rssFeedList, ObservableCollection<RssFeedItem> rssFeedItemList)
        {
            SyndicationFeed feed = LoadFeedFromUrl(url);

            if (feed != null)
            {
                _feedManager.AddFeed(rssFeedList, new RssFeed() { Feed = feed, RssUrl = url });

                LoadFeedItemToView(rssFeedList, rssFeedItemList);
            }
        }

        /// <summary>
        /// Deletes the feed selected by user.
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        /// <param name="rssFeedItemList">The RSS feed item list.</param>
        public void DeleteFeed (ObservableCollection<RssFeed> rssFeedList, ObservableCollection<RssFeedItem> rssFeedItemList)
        {
            List<RssFeed> feedToBeDeleted = new List<RssFeed>();

            foreach (RssFeed item in rssFeedList.Where(c => c.IsChecked))
            {
                feedToBeDeleted.Add(item);
            }

            foreach (RssFeed feed in feedToBeDeleted)
            {
                _feedManager.RemoveFeed(rssFeedList, feed);
            }

            _saveUtility.SaveToFile(rssFeedList);

            LoadFeedItemToView(rssFeedList, rssFeedItemList);
        }

        /// <summary>
        /// Loads and sorts the feed items to view.
        /// </summary>
        /// <param name="rssFeeds">The RSS feeds.</param>
        /// <param name="rssFeedItems">The RSS feed items.</param>
        public void LoadFeedItemToView(ObservableCollection<RssFeed> rssFeeds,
                ObservableCollection<RssFeedItem> rssFeedItems)
        {
            rssFeedItems.Clear();

            foreach (RssFeed feed in rssFeeds)
            {
                _feedItemManager.AddFeedItem(feed.Feed, rssFeedItems);
            }

            SortList(rssFeedItems);
        }

        /// <summary>
        /// Saves the articles.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        /// <param name="feedItem">The feed item.</param>
        public void SaveArticles(ObservableCollection<SavedArticle> savedArticleList, RssFeedItem feedItem)
        {
            _savedFeedItemManager.AddArticle(savedArticleList, feedItem);
        }

        /// <summary>
        /// Deletes the articles.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        public void DeleteArticles(ObservableCollection<SavedArticle> savedArticleList)
        {
            List<SavedArticle> articlesToBeDeleted = new List<SavedArticle>();

            foreach (SavedArticle article in savedArticleList.Where(c => c.IsChecked))
            {
                articlesToBeDeleted.Add(article);
            }

            foreach (SavedArticle item in articlesToBeDeleted)
            {
                _savedFeedItemManager.RemoveSavedFeedItem(savedArticleList, item);
            }

            _saveUtility.SaveArticlesToFile(savedArticleList);
        }

        /// <summary>
        /// Loads the feed from URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>SyndicationFeed.</returns>
        private SyndicationFeed LoadFeedFromUrl(string url)
        {
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.DtdProcessing = DtdProcessing.Parse;
                XmlReader xmlReader = XmlReader.Create(url, settings);
                SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

                return feed;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, Resources.MESSAGEBOX_EXCEPTION, MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        /// <summary>
        /// Sorts the feed items according to publsh date.
        /// </summary>
        /// <param name="feedItems">The feed items.</param>
        private void SortList(ObservableCollection<RssFeedItem> feedItems)
        {
            var tempFeedItems = new List<RssFeedItem>(feedItems);
            tempFeedItems.Sort((a, b) => { return b.Item.PublishDate.CompareTo(a.Item.PublishDate); });

            for (int i = 0; i < tempFeedItems.Count; i++)
            {
                feedItems.Move(feedItems.IndexOf(tempFeedItems[i]), i);
            }
        }
    }
}
