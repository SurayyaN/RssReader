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
    public class SubscriptionsManager
    {
        private ObservableCollection<RssFeedSubscription> _rssFeedSubscriptionsList;

        public SubscriptionsManager()
        {
            _rssFeedSubscriptionsList = new ObservableCollection<RssFeedSubscription>();

            if (SaveUtility.LoadFromFile() != null)
            {
                foreach (string uri in SaveUtility.LoadFromFile())
                {
                    SyndicationFeed feed = RssReadingUtility.LoadFeed(uri);

                    if (feed != null)
                    {
                        AddSubscription(new RssFeedSubscription() { Feed = feed, IsSelected = false });
                    }
                }
            }
        }

        public ObservableCollection<RssFeedSubscription> GetSubscriptions()
        {
            return _rssFeedSubscriptionsList;
        }

        public void AddSubscription(RssFeedSubscription rssFeed)
        {
            if (_rssFeedSubscriptionsList.Count() != 0)
            {
                bool exist = _rssFeedSubscriptionsList.Any(c => c.Feed.Title.Text == rssFeed.Feed.Title.Text);

                if (exist)
                {
                    MessageBox.Show("Subscription already exists", "Alert", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                }

                _rssFeedSubscriptionsList.Add(rssFeed);
            }

            else
            {
                _rssFeedSubscriptionsList.Add(rssFeed);
            }

            SaveUtility.SaveToFile(_rssFeedSubscriptionsList);
        }

        public void RemoveSubscription(RssFeedSubscription rssFeed)
        {
            _rssFeedSubscriptionsList.Remove(rssFeed);
        }
    }
}
