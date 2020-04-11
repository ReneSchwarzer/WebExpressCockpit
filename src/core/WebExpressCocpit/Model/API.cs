using System;
using System.Collections.Generic;
using System.Text;

namespace Cocpit.Model
{
    public class API
    {
        /// <summary>
        /// Liefert oder setzt die Webseiten
        /// </summary>
        public List<WebSiteItem> WebSites { get; set; } = new List<WebSiteItem>();
    }
}
