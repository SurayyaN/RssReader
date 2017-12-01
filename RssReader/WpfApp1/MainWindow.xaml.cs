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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private ObservableCollection<NewFeeds> _newFeeds;
        private ObservableCollection<RssFeedItem> _rssFeedItems;

        private List<RssFeedSubscription> _rssFeedSubscriptions;

        public MainWindow()
        {
            InitializeComponent();

            //_newFeeds = new ObservableCollection<NewFeeds>();
            //lvwArticle.ItemsSource = _newFeeds;

            _rssFeedItems = new ObservableCollection<RssFeedItem>();
            lvwArticle.ItemsSource = _rssFeedItems;
        }

        private void btnLoadRss_Click(object sender, RoutedEventArgs e)
        {
            string url = txtRssUrl.Text;

            LoadRss(url);
        }

        private void LoadRss(string url)
        {
            XmlReader xmlReader = XmlReader.Create(url);

            SyndicationFeed feed = SyndicationFeed.Load(xmlReader);

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
