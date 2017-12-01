using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class RssFeedItem
    {
        public string Website { get; set; }

        public Uri WebsiteLink { get; set; }
        
        public string Article { get; set; }

        public Uri ArticleLink { get; set; }

        public string Description { get; set; }

        public string PublishedDateTime { get; set; }
    }
}
