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
    public interface IFeedItemManager
    {
        //SyndicationFeed GetFeed(string url);

        //void LoadFeedItemToView(ObservableCollection<RssFeed> rssFeeds,
        //    ObservableCollection<RssFeedItem> rssFeedItems);

        void AddFeedItem(SyndicationFeed feed, ObservableCollection<RssFeedItem> rssFeedItems);
    }
}
