using RssFeedReader.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Services
{
    public interface ISavedFeedItemManager
    {
        void AddFeedItem(ObservableCollection<SavedRssFeedItem> savedFeedItemList, RssFeedItem savedFeedItem);

        void RemoveSavedFeedItem(ObservableCollection<SavedRssFeedItem> savedFeedItemList, SavedRssFeedItem savedFeedItem);
    }
}
