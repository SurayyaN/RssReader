using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Models
{
    [Serializable]
    public class SavedArticle : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _title;

        private Uri _link;

        private bool _isChecked;

        public SavedArticle()
        { }

        public SavedArticle(string title, Uri link, bool isChecked = false)
        {
            _title = title;
            _link = link;
            _isChecked = isChecked;
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public Uri Link
        {
            get { return _link; }
            set { _link = value; }
        }

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
