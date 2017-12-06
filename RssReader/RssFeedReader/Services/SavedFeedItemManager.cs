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
    [Serializable]
    public class SavedFeedItemManager : ISavedFeedItemManager
    {
        private ISaveUtility _saveUtility;

        public SavedFeedItemManager(ISaveUtility saveUtility)
        {
            _saveUtility = saveUtility;
        }

        //public void AddFeedItem(ObservableCollection<SavedRssFeedItem> savedFeedItemList, RssFeedItem savedFeedItem)
        //{
        //    if (savedFeedItemList.Count() != 0)
        //    {
        //        bool exist = savedFeedItemList.Any(c => c.FeedItem.Title.Text == savedFeedItem.Item.Title.Text);

        //        if (exist)
        //        {
        //            MessageBox.Show(Resources.ERROR_LOADING_FEED_MESSAGE, Resources.MESSAGEBOX_ALERT, MessageBoxButton.OK, MessageBoxImage.Information);
        //        }

        //        else
        //            savedFeedItemList.Add(new SavedRssFeedItem(savedFeedItem.Item));
        //    }

        //    else
        //    {
        //        savedFeedItemList.Add(new SavedRssFeedItem(savedFeedItem.Item));
        //    }

        //    _saveUtility.SaveFeedItemListToFile(savedFeedItemList);
        //}

        public void AddArticle(ObservableCollection<SavedArticle> savedArticleList, RssFeedItem savedFeedItem)
        {
            if (savedArticleList.Count() != 0)
            {
                bool exist = savedArticleList.Any(c => c.Title == savedFeedItem.Item.Title.Text);

                if (exist)
                {
                    MessageBox.Show(Resources.ERROR_LOADING_FEED_MESSAGE, Resources.MESSAGEBOX_ALERT, MessageBoxButton.OK, MessageBoxImage.Information);
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

        //public void RemoveSavedFeedItem(ObservableCollection<SavedRssFeedItem> savedFeedItemList, SavedRssFeedItem savedFeedItem)
        //{
        //    savedFeedItemList.Remove(savedFeedItem);
        //}

        public void RemoveSavedFeedItem(ObservableCollection<SavedArticle> savedArticleList, SavedArticle savedArticle)
        {
            savedArticleList.Remove(savedArticle);
        }
    }
}
