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
    public class FeedItemManager
    {
        public static SyndicationFeed LoadFeed(string url)
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
                MessageBox.Show(e.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Error);
                return null;
            }
        }

        public static void GetFeedItems(SyndicationFeed feed, ObservableCollection<RssFeedItem> rssFeedItems)
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
