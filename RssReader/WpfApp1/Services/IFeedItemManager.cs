using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    interface IFeedItemManager
    {
        SyndicationFeed LoadFeed(string url);

        void GetFeedItemsFromFeedList(ObservableCollection<RssFeed> rssFeeds,
            ObservableCollection<RssFeedItem> rssFeedItems);

        void GetFeedItems(SyndicationFeed feed, ObservableCollection<RssFeedItem> rssFeedItems);
    }
}
