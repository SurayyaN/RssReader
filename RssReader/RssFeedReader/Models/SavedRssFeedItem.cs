using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Models
{
    [Serializable]
    public class SavedRssFeedItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private SyndicationItem _feedItem;

        private bool _isChecked;

        public SavedRssFeedItem()
        { }

        public SavedRssFeedItem(SyndicationItem feedItem, bool isChecked = false)
        {
            _feedItem = feedItem;
            _isChecked = isChecked;
        }

        public SyndicationItem FeedItem
        {
            get { return _feedItem; }
            set
            {
                _feedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SavedFeedItem"));
            }
        }

        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}
