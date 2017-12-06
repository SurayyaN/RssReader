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
        private ObservableCollection<SavedArticle> _savedArticles;
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
            _savedArticles = new ObservableCollection<SavedArticle>();

            _applicationFeedManager.Onload(_rssFeeds, _savedArticles);
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

        public ObservableCollection<SavedArticle> SavedArticles
        {
            get { return _savedArticles; }
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
        public ICommand SaveArticlesCommand
        {
            get { return new DelegateCommand(SaveArticle); }
        }

        /// <summary>
        /// Gets the delete saved feed item command.
        /// </summary>
        /// <value>The delete saved feed item command.</value>
        public ICommand DeleteSavedArticlesCommand
        {
            get { return new DelegateCommand(DeleteSavedArticle); }
        }

        /// <summary>
        /// Gets the check all articles command.
        /// </summary>
        /// <value>The check all articles command.</value>
        public ICommand CheckAllArticlesCommand
        {
            get { return new DelegateCommand(CheckAllArticles); }
        }

        /// <summary>
        /// Gets the uncheck all articles command.
        /// </summary>
        /// <value>The uncheck all articles command.</value>
        public ICommand UncheckAllArticlesCommand
        {
            get { return new DelegateCommand(UncheckAllArticles); }
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

        /// <summary>
        /// Checks all articles.
        /// </summary>
        private void CheckAllArticles()
        {
            foreach (SavedArticle articles in _savedArticles)
            {
                articles.IsChecked = true;
            }
        }

        /// <summary>
        /// Unchecks all articles.
        /// </summary>
        private void UncheckAllArticles()
        {
            foreach (SavedArticle article in _savedArticles)
            {
                article.IsChecked = false;
            }
        }

        /// <summary>
        /// Saves the article.
        /// </summary>
        private void SaveArticle()
        {
            _applicationFeedManager.SaveArticles(_savedArticles, _selectedFeedItem);
        }

        /// <summary>
        /// Deletes the saved article.
        /// </summary>
        private void DeleteSavedArticle()
        {
            _applicationFeedManager.DeleteArticles(_savedArticles);
        }
    }
}
