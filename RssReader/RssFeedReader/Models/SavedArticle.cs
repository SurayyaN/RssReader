using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Models
{
    /// <summary>
    /// Class SavedArticle.
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    [Serializable]
    public class SavedArticle : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The title
        /// </summary>
        private string _title;

        /// <summary>
        /// The link
        /// </summary>
        private Uri _link;

        /// <summary>
        /// The is checked
        /// </summary>
        private bool _isChecked;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedArticle"/> class.
        /// </summary>
        public SavedArticle()
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="SavedArticle"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="link">The link.</param>
        /// <param name="isChecked">if set to <c>true</c> [is checked].</param>
        public SavedArticle(string title, Uri link, bool isChecked = false)
        {
            _title = title;
            _link = link;
            _isChecked = isChecked;
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        /// <summary>
        /// Gets or sets the link.
        /// </summary>
        /// <value>The link.</value>
        public Uri Link
        {
            get { return _link; }
            set { _link = value; }
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
    }
}
