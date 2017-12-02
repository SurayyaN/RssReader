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

            _rssFeedItems = new ObservableCollection<RssFeedItem>();
            LvwArticle.ItemsSource = _rssFeedItems;

            ListboxSubscription.ItemsSource = _subscriptionsManager.GetSubscriptions();
        }

        private void btnAddNewRss_Click(object sender, RoutedEventArgs e)
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
                RssReadingUtility.PrintFeed(subscription.Feed, _rssFeedItems);
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
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
    }
}
