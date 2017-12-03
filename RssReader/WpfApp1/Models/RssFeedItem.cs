using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    public class RssFeedItem
    {
        public string Website { get; set; }

        public SyndicationItem Item { get; set; }
    }
}
