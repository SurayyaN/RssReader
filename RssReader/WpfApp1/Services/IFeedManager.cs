using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    public interface IFeedManager
    {
        //ObservableCollection<RssFeed> GetFeeds();

        //void AddFeed(RssFeed rssFeed);

        //void RemoveFeed(RssFeed rssFeed);

        void AddFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed);

        void RemoveFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed);
    }
}
