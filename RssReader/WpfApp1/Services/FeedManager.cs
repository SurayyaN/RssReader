using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Newtonsoft.Json.Schema;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    [Serializable]
    public class FeedManager : IFeedManager
    {
        //private ObservableCollection<RssFeed> _rssFeedList;

        private ISaveUtility _saveUtility;

        public FeedManager(ISaveUtility saveUtility)
        {
            _saveUtility = saveUtility;
            //_rssFeedList = new ObservableCollection<RssFeed>();

            ////if (SaveUtility.LoadFromFile() != null)
            ////{
            ////    foreach (string uri in SaveUtility.LoadFromFile())
            ////    {
            ////        SyndicationFeed feed = FeedItemManager.LoadFeed(uri);

            ////        if (feed != null)
            ////        {
            ////            AddFeed(new RssFeed() { Feed = feed, RssUrl = uri});
            ////        }
            ////    }
            ////}

            //LoadFromFile(_rssFeedList);
        }

        //public void LoadFromFile(ObservableCollection<RssFeed> rssFeedList)
        //{
        //    if (SaveUtility.LoadFromFile() != null)
        //    {
        //        foreach (string uri in SaveUtility.LoadFromFile())
        //        {
        //            SyndicationFeed feed = FeedItemManager.LoadFeed(uri);

        //            if (feed != null)
        //            {
        //                AddFeed(rssFeedList, new RssFeed() { Feed = feed, RssUrl = uri });
        //            }
        //        }
        //    }
        //}

        //public ObservableCollection<RssFeed> GetFeeds()
        //{
        //    return _rssFeedList;
        //}

        //public void AddFeed(RssFeed rssFeed)
        //{
        //    if (_rssFeedList.Count() != 0)
        //    {
        //        bool exist = _rssFeedList.Any(c => c.Feed.Title.Text == rssFeed.Feed.Title.Text);

        //        if (exist)
        //        {
        //            MessageBox.Show("Subscription already exists", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }

        //        _rssFeedList.Add(rssFeed);
        //    }

        //    else
        //    {
        //        _rssFeedList.Add(rssFeed);
        //    }

        //    SaveUtility.SaveToFile(_rssFeedList);
        //}

        public void AddFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed)
        {
            if (rssFeedList.Count() != 0)
            {
                bool exist = rssFeedList.Any(c => c.Feed.Title.Text == rssFeed.Feed.Title.Text);

                if (exist)
                {
                    MessageBox.Show("Subscription already exists", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                rssFeedList.Add(rssFeed);
            }

            else
            {
                rssFeedList.Add(rssFeed);
            }

            //SaveUtility.SaveToFile(rssFeedList);
            _saveUtility.SaveToFile(rssFeedList);
        }

        //public void RemoveFeed(RssFeed rssFeed)
        //{
        //    _rssFeedList.Remove(rssFeed);
        //}

        public void RemoveFeed(ObservableCollection<RssFeed> rssFeedList, RssFeed rssFeed)
        {
            rssFeedList.Remove(rssFeed);
        }
    }
}
