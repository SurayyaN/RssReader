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
using RssFeedReader.Command;
using RssFeedReader.Models;
using RssFeedReader.Services;

namespace RssFeedReader
{
    /// <summary>
    /// Class MainViewModel.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private IApplicationFeedManager _applicationFeedManager;
        private ObservableCollection<RssFeed> _rssFeeds;
        private ObservableCollection<RssFeedItem> _rssFeedItems;
        //private ObservableCollection<RssFeedItem> _savedFeedItems;
        private ObservableCollection<SavedRssFeedItem> _savedFeedItems;
        private RssFeedItem _selectedFeedItem;
        private string _url;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="applicationFeedManager">The application feed manager.</param>
        public MainViewModel(IApplicationFeedManager applicationFeedManager)
        {
            _applicationFeedManager = applicationFeedManager;

            _rssFeeds = new ObservableCollection<RssFeed>();
            _rssFeedItems = new ObservableCollection<RssFeedItem>();
            //_savedFeedItems = new ObservableCollection<RssFeedItem>();
            _savedFeedItems = new ObservableCollection<SavedRssFeedItem>();

            //_applicationFeedManager.Onload(_rssFeeds, _savedFeedItems);
            _applicationFeedManager.Onload(_rssFeeds, _savedFeedItems);
            _applicationFeedManager.LoadFeedItemToView(_rssFeeds, _rssFeedItems);
        }

        /// <summary>
        /// Gets the RSS feeds.
        /// </summary>
        /// <value>The RSS feeds.</value>
        public ObservableCollection<RssFeed> RssFeeds
        {
            get { return _rssFeeds; }
        }

        /// <summary>
        /// Gets the RSS feed items.
        /// </summary>
        /// <value>The RSS feed items.</value>
        public ObservableCollection<RssFeedItem> RssFeedItems
        {
            get { return _rssFeedItems; }
        }

        /// <summary>
        /// Gets the saved feed items.
        /// </summary>
        /// <value>The saved feed items.</value>
        public ObservableCollection<SavedRssFeedItem> SavedFeedItems
        {
            get { return _savedFeedItems; }
        }

        /// <summary>
        /// Gets or sets the selected feed item.
        /// </summary>
        /// <value>The selected feed item.</value>
        public RssFeedItem SelectedFeedItem
        {
            get { return _selectedFeedItem; }
            set
            {
                _selectedFeedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedFeedItem"));
            }
        }

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url
        {
            get { return _url; }
            set
            {
                _url = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Url"));
            }
        }

        /// <summary>
        /// Gets the add new feed command.
        /// </summary>
        /// <value>The add new feed command.</value>
        public ICommand AddNewFeedCommand
        {
            get { return new DelegateCommand(AddNewFeed); }
        }

        /// <summary>
        /// Gets the delete feed command.
        /// </summary>
        /// <value>The delete feed command.</value>
        public ICommand DeleteFeedCommand
        {
            get { return new DelegateCommand(DeleteFeed); }
        }

        /// <summary>
        /// Gets the refresh feed command.
        /// </summary>
        /// <value>The refresh feed command.</value>
        public ICommand RefreshFeedCommand
        {
            get { return new DelegateCommand(RefreshFeed); }
        }

        /// <summary>
        /// Gets the check all items command.
        /// </summary>
        /// <value>The check all items command.</value>
        public ICommand CheckAllFeedsCommand
        {
            get { return new DelegateCommand(CheckAllFeeds); }
        }

        /// <summary>
        /// Gets the uncheck all items command.
        /// </summary>
        /// <value>The uncheck all items command.</value>
        public ICommand UncheckAllFeedsCommand
        {
            get { return new DelegateCommand(UncheckAllFeeds); }
        }

        /// <summary>
        /// Gets the save feed iems command.
        /// </summary>
        /// <value>The save feed iems command.</value>
        public ICommand SaveFeedItemsCommand
        {
            get { return new DelegateCommand(SaveFeedItem); }
        }

        public ICommand DeleteSavedFeedItemCommand
        {
            get { return new DelegateCommand(DeleteSavedFeedItems); }
        }

        public ICommand CheckAllFeedItemsCommand
        {
            get { return new DelegateCommand(CheckAllFeedItems); }
        }

        public ICommand UncheckAllFeedItemsCommand
        {
            get { return new DelegateCommand(UncheckAllFeedItems); }
        }

        /// <summary>
        /// Adds the new feed.
        /// </summary>
        private void AddNewFeed()
        {
            _applicationFeedManager.AddFeed(Url, _rssFeeds, _rssFeedItems);
        }

        /// <summary>
        /// Deletes the feed.
        /// </summary>
        private void DeleteFeed()
        {
            _applicationFeedManager.DeleteFeed(_rssFeeds, _rssFeedItems);
        }

        /// <summary>
        /// Refreshes the feed.
        /// </summary>
        private void RefreshFeed()
        {
            _applicationFeedManager.LoadFeedItemToView(_rssFeeds, _rssFeedItems);
        }

        /// <summary>
        /// Checks all feeds in feed list.
        /// </summary>
        private void CheckAllFeeds()
        {
            foreach (RssFeed subscription in _rssFeeds)
            {
                subscription.IsChecked = true;
            }
        }

        /// <summary>
        /// Unchecks all feeds in feed list.
        /// </summary>
        private void UncheckAllFeeds()
        {
            foreach (RssFeed subscription in _rssFeeds)
            {
                subscription.IsChecked = false;
            }
        }

        private void CheckAllFeedItems()
        {
            foreach (SavedRssFeedItem feedItems in _savedFeedItems)
            {
                feedItems.IsChecked = true;
            }
        }

        private void UncheckAllFeedItems()
        {
            foreach (SavedRssFeedItem feedItems in _savedFeedItems)
            {
                feedItems.IsChecked = false;
            }
        }

        ///// <summary>
        ///// Saves the feed item.
        ///// </summary>
        //private void SaveFeedItem()
        //{
        //    _savedFeedItems.Add(_selectedFeedItem);

        //    _applicationFeedManager.SaveFeedItems(_savedFeedItems);
        //}

        private void SaveFeedItem()
        {
            _applicationFeedManager.SaveFeedItems(_savedFeedItems, _selectedFeedItem);
        }

        private void DeleteSavedFeedItems()
        {
            _applicationFeedManager.DeleteFeedItems(_savedFeedItems);
        }
    }
}
