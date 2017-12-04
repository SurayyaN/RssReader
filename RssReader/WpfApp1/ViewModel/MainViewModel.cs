using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using WpfApp1.Command;
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IApplicationFeedManager _applicationFeedManager;
        private ObservableCollection<RssFeed> _rssFeeds;
        private ObservableCollection<RssFeedItem> _rssFeedItems;
        private string _url;

        public MainViewModel(IApplicationFeedManager applicationFeedManager)
        {
            _applicationFeedManager = applicationFeedManager;

            _rssFeeds = new ObservableCollection<RssFeed>();
            _rssFeedItems = new ObservableCollection<RssFeedItem>();

            _applicationFeedManager.Onload(_rssFeeds);
            _applicationFeedManager.LoadFeedItemToView(_rssFeeds, _rssFeedItems);
        }

        public ObservableCollection<RssFeed> RssFeeds
        {
            get { return _rssFeeds; }
        }

        public ObservableCollection<RssFeedItem> RssFeedItems
        {
            get { return _rssFeedItems; }
        }

        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Url"));
            }
        }

        public ICommand AddNewFeedCommand
        {
            get { return new DelegateCommand(AddNewFeed); }
        }

        public ICommand DeleteFeedCommand
        {
            get { return new DelegateCommand(DeleteFeed); }
        }

        public ICommand RefreshFeedCommand
        {
            get { return new DelegateCommand(RefreshFeed); }
        }

        public ICommand CheckAllItemsCommand
        {
            get { return new DelegateCommand(CheckAllItems); }
        }

        public ICommand UncheckAllItemsCommand
        {
            get { return new DelegateCommand(UncheckAllItems); }
        } 

        private void AddNewFeed()
        {
            _applicationFeedManager.AddFeed(Url, _rssFeeds, _rssFeedItems);
        }

        private void DeleteFeed()
        {
            _applicationFeedManager.DeleteFeed(_rssFeeds, _rssFeedItems);
        }

        private void RefreshFeed()
        {
            _applicationFeedManager.LoadFeedItemToView(_rssFeeds, _rssFeedItems);
        }

        private void CheckAllItems()
        {
            foreach (RssFeed subscription in _rssFeeds)
            {
                subscription.IsChecked = true;
            }
        }

        private void UncheckAllItems()
        {
            foreach (RssFeed subscription in _rssFeeds)
            {
                subscription.IsChecked = false;
            }
        }

        private void NavigateToUrl(RequestNavigateEventArgs e)
        {
            Process.Start(e.Uri.AbsoluteUri);
        }
    }
}
