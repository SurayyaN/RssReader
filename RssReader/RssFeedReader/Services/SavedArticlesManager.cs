using RssFeedReader.Models;
using RssFeedReader.Properties;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RssFeedReader.Services
{
    /// <summary>
    /// Class SavedArticlesManager.
    /// </summary>
    /// <seealso cref="RssFeedReader.Services.ISavedArticlesManager" />
    [Serializable]
    public class SavedArticlesManager : ISavedArticlesManager
    {
        /// <summary>
        /// The save utility
        /// </summary>
        private ISaveUtility _saveUtility;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedArticlesManager"/> class.
        /// </summary>
        /// <param name="saveUtility">The save utility.</param>
        public SavedArticlesManager(ISaveUtility saveUtility)
        {
            _saveUtility = saveUtility;
        }

        /// <summary>
        /// Adds the article.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        /// <param name="savedFeedItem">The saved feed item.</param>
        public void AddArticle(ObservableCollection<SavedArticle> savedArticleList, RssFeedItem savedFeedItem)
        {
            if (savedArticleList.Count() != 0)
            {
                bool exist = savedArticleList.Any(c => c.Title == savedFeedItem.Item.Title.Text);

                if (exist)
                {
                    MessageBox.Show(Resources.ERROR_SAVING_ARTICLE_MESSAGE, Resources.MESSAGEBOX_ALERT, MessageBoxButton.OK, MessageBoxImage.Information);
                }

                else
                    savedArticleList.Add(new SavedArticle(savedFeedItem.Item.Title.Text, savedFeedItem.Item.Links[0].Uri));
            }

            else
            {
                savedArticleList.Add(new SavedArticle(savedFeedItem.Item.Title.Text, savedFeedItem.Item.Links[0].Uri));
            }

            _saveUtility.SaveArticlesToFile(savedArticleList);
        }

        /// <summary>
        /// Removes the saved feed item.
        /// </summary>
        /// <param name="savedArticleList">The saved article list.</param>
        /// <param name="savedArticle">The saved article.</param>
        public void RemoveSavedFeedItem(ObservableCollection<SavedArticle> savedArticleList, SavedArticle savedArticle)
        {
            savedArticleList.Remove(savedArticle);
        }
    }
}
