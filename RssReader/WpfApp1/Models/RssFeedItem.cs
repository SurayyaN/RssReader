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
        
        public string Article { get; set; }

        public string Description { get; set; }

        public string PublishedDateTimeOffset { get; set; }
    }
}
