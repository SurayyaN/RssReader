using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.ServiceModel.Syndication;
using WpfApp1.Models;
using System.Diagnostics;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<RssFeedItem> _rssFeedItems;

        private SubscriptionsManager _subscriptionsManager;

        public MainWindow()
        {
            InitializeComponent();

            _subscriptionsManager = new SubscriptionsManager();
            ListboxSubscription.ItemsSource = _subscriptionsManager.GetSubscriptions();

            _rssFeedItems = new ObservableCollection<RssFeedItem>();
            LvwArticle.ItemsSource = _rssFeedItems;
        }

        private void btnAddNewFeed_Click(object sender, RoutedEventArgs e)
        {
            string url = TxtRssUrl.Text;

            SyndicationFeed feed = RssReadingUtility.LoadFeed(url);

            if (feed != null)
            {
                _subscriptionsManager.AddSubscription(new RssFeedSubscription() { Feed = feed});
                btnRefreshFeed_Click(sender, e);
            }
        }

        private void btnRefreshFeed_Click(object sender, RoutedEventArgs e)
        {
            _rssFeedItems.Clear();

            foreach (RssFeedSubscription subscription in _subscriptionsManager.GetSubscriptions())
            {
                RssReadingUtility.GetFeedItems(subscription.Feed, _rssFeedItems);
            }

            var tempFeedItems = new List<RssFeedItem>(_rssFeedItems);

            tempFeedItems.Sort( (a, b) => { return b.PublishedDateTime.CompareTo(a.PublishedDateTime); });

            for (int i = 0; i < tempFeedItems.Count; i++)
            {
                _rssFeedItems.Move(_rssFeedItems.IndexOf(tempFeedItems[i]), i);
            }
        }

        private void CbAllItems_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            if (checkbox.Name == "CbAllItems")
            {
                if (checkbox.IsChecked == true)
                {
                    foreach (RssFeedSubscription subscription in _subscriptionsManager.GetSubscriptions())
                    {
                        subscription.IsChecked = true;
                    }
                }
            }
        }

        private void CbAllItems_UnChecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkbox = sender as CheckBox;

            if (checkbox.Name == "CbAllItems")
            {
                if (checkbox.IsChecked == false)
                {
                    foreach (RssFeedSubscription subscription in _subscriptionsManager.GetSubscriptions())
                    {
                        subscription.IsChecked = false;
                    }
                }
            }
        }

        private void BtnDeleteFeed_Click(object sender, RoutedEventArgs e)
        {
            List<RssFeedSubscription> feedToBeDeleted = new List<RssFeedSubscription>();

            foreach (RssFeedSubscription item in _subscriptionsManager.GetSubscriptions().Where(c => c.IsChecked))
            {
                feedToBeDeleted.Add(item);
            }

            foreach (RssFeedSubscription feed in feedToBeDeleted)
            {
                _subscriptionsManager.RemoveSubscription(feed);
            }

            btnRefreshFeed_Click(sender, e);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
