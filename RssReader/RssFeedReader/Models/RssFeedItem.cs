﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;

namespace RssFeedReader.Models
{
    /// <summary>
    /// Class RssFeedItem.
    /// </summary>
    [Serializable]
    public class RssFeedItem
    {
        /// <summary>
        /// Gets or sets the channel of the feed
        /// </summary>
        /// <value>The website.</value>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        public SyndicationItem Item { get; set; }
    }
}
