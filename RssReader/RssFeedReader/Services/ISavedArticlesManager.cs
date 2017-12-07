using RssFeedReader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Interface ISavedArticlesManager
    /// </summary>
    public interface ISavedArticlesManager
    {
        /// <summary>
        /// Adds the article.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        /// <param name="savedFeedItem">The saved feed item.</param>
        void AddArticle(ObservableCollection<SavedArticle> savedArticleList, RssFeedItem savedFeedItem);

        /// <summary>
        /// Removes the saved feed item.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        /// <param name="savedArticle">The saved article.</param>
        void RemoveSavedFeedItem(ObservableCollection<SavedArticle> savedArticleList, SavedArticle savedArticle);
    }
}
