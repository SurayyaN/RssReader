using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1.MainViewModel
{
    public class FeedViewModel
    {
        private FeedManager _feedManager;

        private ObservableCollection<RssFeed> _rssFeedList;
        private ObservableCollection<RssFeedItem> _rssFeedItems;
        private string _url;

        public FeedViewModel()
        {
            _rssFeedList = _feedManager.GetFeeds();
        }

        //public ICommand AddNewFeed()
        //{
        //    SyndicationFeed feed = FeedItemManager.LoadFeed(_rssFeedList.);

        //    if (feed != null)
        //    {
        //        _feedManager.AddFeed(new RssFeed() { Feed = feed, RssUrl = url });

        //        FeedItemManager.GetFeedItemsFromFeedList(_feedManager.GetFeeds(), _rssFeedItems);
        //    }
        //}

        private void DeleteFeed()
        {
            List<RssFeed> feedToBeDeleted = new List<RssFeed>();

            foreach (RssFeed item in _feedManager.GetFeeds().Where(c => c.IsChecked))
            {
                feedToBeDeleted.Add(item);
            }

            foreach (RssFeed feed in feedToBeDeleted)
            {
                _feedManager.RemoveFeed(feed);
            }

            SaveUtility.SaveToFile(_feedManager.GetFeeds());

            FeedItemManager.GetFeedItemsFromFeedList(_feedManager.GetFeeds(), _rssFeedItems);
        }
    }
}
