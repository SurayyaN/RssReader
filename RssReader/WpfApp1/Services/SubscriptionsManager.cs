using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Models;

namespace WpfApp1.Services
{
    [Serializable]
    public class SubscriptionsManager
    {
        private List<RssFeedSubscription> _rssFeedSubscriptionsList;

        public SubscriptionsManager()
        {
            _rssFeedSubscriptionsList = new List<RssFeedSubscription>();
        }

        public void AddSubscription(RssFeedSubscription rssFeed)
        {
            _rssFeedSubscriptionsList.Add(rssFeed);
        }

        public void RemoveSubscription(RssFeedSubscription rssFeed)
        {
            _rssFeedSubscriptionsList.Remove(rssFeed);
        }
    }
}
