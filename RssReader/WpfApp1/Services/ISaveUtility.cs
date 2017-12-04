using System.Collections.Generic;
using System.Collections.ObjectModel;
using WpfApp1.Models;

namespace WpfApp1.Services
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
        /// Saves the feeds to a file
        /// </summary>
        /// <param name="rssFeedList">The RSS feed list.</param>
        void SaveToFile(ObservableCollection<RssFeed> rssFeedList);
    }
}
