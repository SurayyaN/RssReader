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

        private FeedItemManager _feedItemManager;
        private FeedManager _feedManager;

        public MainWindow()
        {
            InitializeComponent();

            _feedManager = new FeedManager();
            ListboxFeeds.ItemsSource = _feedManager.GetFeeds();

            _rssFeedItems = new ObservableCollection<RssFeedItem>();
            LvwFeedItems.ItemsSource = _rssFeedItems;

            FeedItemManager.GetFeedItemsFromFeedList(_feedManager.GetFeeds(), _rssFeedItems);

        }

        private void btnAddNewFeed_Click(object sender, RoutedEventArgs e)
        {
            string url = TxtRssUrl.Text;

            SyndicationFeed feed = FeedItemManager.LoadFeed(url);

            if (feed != null)
            {
                _feedManager.AddFeed(new RssFeed() { Feed = feed, RssUrl = url});

                FeedItemManager.GetFeedItemsFromFeedList(_feedManager.GetFeeds(), _rssFeedItems);
            }
        }

        private void btnRefreshFeed_Click(object sender, RoutedEventArgs e)
        {
            FeedItemManager.GetFeedItemsFromFeedList(_feedManager.GetFeeds(), _rssFeedItems);
        }

        private void CbAllItems_Checked(object sender, RoutedEventArgs e)
        {
            foreach (RssFeed subscription in _feedManager.GetFeeds())
            {
                subscription.IsChecked = true;
            }
        }

        private void CbAllItems_UnChecked(object sender, RoutedEventArgs e)
        {
            foreach (RssFeed subscription in _feedManager.GetFeeds())
            {
                subscription.IsChecked = false;
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

            FeedItemManager.GetFeedItemsFromFeedList(_feedManager.GetFeeds(), _rssFeedItems);
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
