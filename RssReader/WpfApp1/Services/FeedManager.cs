﻿using System;
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
    public class FeedManager
    {
        private ObservableCollection<RssFeed> _rssFeedList;

        public FeedManager()
        {
            _rssFeedList = new ObservableCollection<RssFeed>();

            if (SaveUtility.LoadFromFile() != null)
            {
                foreach (string uri in SaveUtility.LoadFromFile())
                {
                    SyndicationFeed feed = FeedItemManager.LoadFeed(uri);

                    if (feed != null)
                    {
                        AddFeed(new RssFeed() { Feed = feed, RssUrl = uri});
                    }
                }
            }
        }

        public ObservableCollection<RssFeed> GetFeeds()
        {
            return _rssFeedList;
        }

        public void AddFeed(RssFeed rssFeed)
        {
            if (_rssFeedList.Count() != 0)
            {
                bool exist = _rssFeedList.Any(c => c.Feed.Title.Text == rssFeed.Feed.Title.Text);

                if (exist)
                {
                    MessageBox.Show("Subscription already exists", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                _rssFeedList.Add(rssFeed);
            }

            else
            {
                _rssFeedList.Add(rssFeed);
            }
        }

        public void RemoveFeed(RssFeed rssFeed)
        {
            _rssFeedList.Remove(rssFeed);
        }
    }
}