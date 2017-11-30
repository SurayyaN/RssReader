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


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<NewFeeds> _newFeeds;

        public MainWindow()
        {
            InitializeComponent();

            _newFeeds = new ObservableCollection<NewFeeds>();
            lvwArticle.ItemsSource = _newFeeds;
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

            foreach (SyndicationItem items in feed.Items.Take(5))
            {
                //ListViewItem listItem = new ListViewItem();
                //listItem.DataContext = items.Title.Text;
                //this.lvwArticle.Items.Add(listItem);

                _newFeeds.Add(new NewFeeds() { Article = items.Title.Text});
            }
        }
    }

    public class NewFeeds
    {
        public string Article { get; set; }
    }
}
