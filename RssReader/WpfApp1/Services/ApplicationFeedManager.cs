using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class ApplicationFeedManager : IApplicationFeedManager
    {
        private IFeedManager _feedManager;
        private IFeedItemManager _feedItemManager;
        private ISaveUtility _saveUtility;

        public ApplicationFeedManager(IFeedManager feedManager, IFeedItemManager feedItemManager, ISaveUtility saveUtility)
        {
            _feedManager = feedManager;
            _feedItemManager = feedItemManager;
            _saveUtility = saveUtility;
        }

        public void Onload(ObservableCollection<RssFeed> rssFeedList)
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
        }

        public void AddFeed(string url, ObservableCollection<RssFeed> rssFeedList, ObservableCollection<RssFeedItem> rssFeedItemList)
        {
            SyndicationFeed feed = LoadFeedFromUrl(url);

            if (feed != null)
            {
                _feedManager.AddFeed(rssFeedList, new RssFeed() { Feed = feed, RssUrl = url });

                LoadFeedItemToView(rssFeedList, rssFeedItemList);
            }
        }

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
                //MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

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
