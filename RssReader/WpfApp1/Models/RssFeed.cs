using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    [Serializable]
    public class RssFeed : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SyndicationFeed _feed;
        private Boolean _isChecked;
        private string _rssUrl;

        public RssFeed()
        { }

        public RssFeed(SyndicationFeed feed, string rssUrl, Boolean isChecked = false)
        {
            _feed = feed;
            _isChecked = isChecked;
            _rssUrl = rssUrl;
        }

        public SyndicationFeed Feed
        {
            get { return _feed; }
            set
            {
                _feed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Feed"));
            }
        }

        public Boolean IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }

        public string RssUrl
        {
            get { return _rssUrl; }
            set { _rssUrl = value; }
        }
    }
}
