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

        private FeedManager _feedManager;

        public MainWindow()
        {
            InitializeComponent();

            _feedManager = new FeedManager();
            ListboxSubscription.ItemsSource = _feedManager.GetFeeds();

            _rssFeedItems = new ObservableCollection<RssFeedItem>();
            LvwArticle.ItemsSource = _rssFeedItems;
        }

        private void btnAddNewFeed_Click(object sender, RoutedEventArgs e)
        {
            string url = TxtRssUrl.Text;

            SyndicationFeed feed = FeedItemManager.LoadFeed(url);

            if (feed != null)
            {
                _feedManager.AddFeed(new RssFeed() { Feed = feed, RssUrl = url});
                btnRefreshFeed_Click(sender, e);
            }
        }

        private void btnRefreshFeed_Click(object sender, RoutedEventArgs e)
        {
            _rssFeedItems.Clear();

            foreach (RssFeed subscription in _feedManager.GetFeeds())
            {
                FeedItemManager.GetFeedItems(subscription.Feed, _rssFeedItems);
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
                    foreach (RssFeed subscription in _feedManager.GetFeeds())
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
                    foreach (RssFeed subscription in _feedManager.GetFeeds())
                    {
                        subscription.IsChecked = false;
                    }
                }
            }
        }

        private void BtnDeleteFeed_Click(object sender, RoutedEventArgs e)
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

            btnRefreshFeed_Click(sender, e);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
