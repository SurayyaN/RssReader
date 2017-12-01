using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    [Serializable]
    public class RssFeedSubscription
    {
        public SyndicationFeed Feed { get; set; }
        
        public Boolean IsSelected { get; set; }
    }
}
