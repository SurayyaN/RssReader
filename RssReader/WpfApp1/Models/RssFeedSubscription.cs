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
    public class RssFeedSubscription : INotifyPropertyChanged
    {
        //public SyndicationFeed Feed { get; set; }

        //public Boolean IsSelected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private SyndicationFeed _feed;
        private Boolean _IsChecked;

        public RssFeedSubscription()
        { }

        public RssFeedSubscription(SyndicationFeed feed, Boolean isChecked = false)
        {
            _feed = feed;
            _IsChecked = isChecked;
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
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}
