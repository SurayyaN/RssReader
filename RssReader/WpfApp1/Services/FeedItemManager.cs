using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public class FeedItemManager : IFeedItemManager
    {
        //public SyndicationFeed GetFeed(string url)
        //{
        //    try
        //    {
        //        XmlReaderSettings settings = new XmlReaderSettings();
        //        settings.DtdProcessing = DtdProcessing.Parse;
        //        XmlReader xmlReader = XmlReader.Create(url, settings);
        //        SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

        //        return feed;
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
        //        return null;
        //    }
        //}

        //public void LoadFeedItemToView(ObservableCollection<RssFeed> rssFeeds,
        //    ObservableCollection<RssFeedItem> rssFeedItems)
        //{
        //    rssFeedItems.Clear();

        //    foreach (RssFeed feed in rssFeeds)
        //    {
        //        AddFeedItem(feed.Feed, rssFeedItems);
        //    }

        //    SortList(rssFeedItems);
        //}

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

        //private void SortList(ObservableCollection<RssFeedItem> feedItems)
        //{
        //    var tempFeedItems = new List<RssFeedItem>(feedItems);
        //    tempFeedItems.Sort((a, b) => { return b.Item.PublishDate.CompareTo(a.Item.PublishDate); });

        //    for (int i = 0; i < tempFeedItems.Count; i++)
        //    {
        //        feedItems.Move(feedItems.IndexOf(tempFeedItems[i]), i);
        //    }
        //}
    }
}
