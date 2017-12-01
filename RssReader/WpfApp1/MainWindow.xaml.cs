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
            lvwArticle.ItemsSource = _rssFeedItems;

            listboxSubscription.ItemsSource = _subscriptionsManager.GetSubscriptions();
        }

        private void btnAddNewRss_Click(object sender, RoutedEventArgs e)
        {
            string url = txtRssUrl.Text;

            XmlReader xmlReader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);
            _subscriptionsManager.AddSubscription(new RssFeedSubscription() { Feed = feed, IsSelected = false });

            btnRefreshFeed_Click(sender, e);
        }

        private void btnRefreshFeed_Click(object sender, RoutedEventArgs e)
        {
            _rssFeedItems.Clear();

            foreach (RssFeedSubscription subscription in _subscriptionsManager.GetSubscriptions())
            {
                LoadRss(subscription.Feed);
            }
        }

        private void LoadRss(SyndicationFeed feed)
        {
            foreach (SyndicationItem items in feed.Items)
            {
                _rssFeedItems.Add(new RssFeedItem()
                {
                    Website = feed.Title.Text,
                    //WebsiteLink = feed.Links.FirstOrDefault(c => c.RelationshipType == "Alternate").Uri,
                    WebsiteLink = feed.Links[0].Uri,
                    Article = items.Title.Text,
                    ArticleLink = items.Links[0].Uri,
                    //Description = items.Summary.Text,
                    PublishedDateTime = items.PublishDate.Date.ToShortDateString()
                });
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
