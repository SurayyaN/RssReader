using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The Models namespace.
/// </summary>
namespace WpfApp1.Models
{
    /// <summary>
    /// Class RssFeed. this model contains the feed and the rss url
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    [Serializable]
    public class RssFeed : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The feed
        /// </summary>
        private SyndicationFeed _feed;

        /// <summary>
        /// The is checked. bounded together with checkboxes in the view
        /// </summary>
        private Boolean _isChecked;

        /// <summary>
        /// The RSS URL
        /// </summary>
        private string _rssUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="RssFeed"/> class.
        /// </summary>
        public RssFeed()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RssFeed"/> class.
        /// </summary>
        /// <param name="feed">The feed.</param>
        /// <param name="rssUrl">The RSS URL.</param>
        /// <param name="isChecked">The is checked.</param>
        public RssFeed(SyndicationFeed feed, string rssUrl, Boolean isChecked = false)
        {
            _feed = feed;
            _isChecked = isChecked;
            _rssUrl = rssUrl;
        }

        /// <summary>
        /// Gets or sets the feed.
        /// </summary>
        /// <value>The feed.</value>
        public SyndicationFeed Feed
        {
            get { return _feed; }
            set
            {
                _feed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Feed"));
            }
        }

        /// <summary>
        /// Gets or sets the is checked.
        /// </summary>
        /// <value>The is checked.</value>
        public Boolean IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }

        /// <summary>
        /// Gets or sets the RSS URL.
        /// </summary>
        /// <value>The RSS URL.</value>
        public string RssUrl
        {
            get { return _rssUrl; }
            set { _rssUrl = value; }
        }
    }
}
