using System.Collections.Generic;
using System.Collections.ObjectModel;
using RssFeedReader.Models;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Interface ISaveUtility 
    /// </summary>
    public interface ISaveUtility
    {
        /// <summary>
        /// Loads the feeds from the saved rss
        /// </summary>
        /// <returns>List&lt;System.String&gt;.</returns>
        List<string> LoadFromFile();

        /// <summary>
        /// Loads the articles from file.
        /// </summary>
        /// <returns>List&lt;SavedArticle&gt;.</returns>
        List<SavedArticle> LoadArticlesFromFile();

        /// <summary>
        /// Saves the feeds to a file
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        void SaveToFile(ObservableCollection<RssFeed> rssFeedList);

        /// <summary>
        /// Saves the articles to file.
        /// </summary>
        /// <param name="savedArticlesList">The saved articles list.</param>
        void SaveArticlesToFile(ObservableCollection<SavedArticle> savedArticlesList);
    }
}
