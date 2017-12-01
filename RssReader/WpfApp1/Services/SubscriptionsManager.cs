using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public ObservableCollection<RssFeedSubscription> GetSubscriptions()
        {
            return _rssFeedSubscriptionsList;
        }

        public void AddSubscription(RssFeedSubscription rssFeed)
        {
            bool exist = _rssFeedSubscriptionsList.Any(c => c.Feed.Title.Text == rssFeed.Feed.Title.Text);
            if (!exist)
            {
                _rssFeedSubscriptionsList.Add(rssFeed);
            }
        }

        public void RemoveSubscription(RssFeedSubscription rssFeed)
        {
            _rssFeedSubscriptionsList.Remove(rssFeed);
        }
    }
}
