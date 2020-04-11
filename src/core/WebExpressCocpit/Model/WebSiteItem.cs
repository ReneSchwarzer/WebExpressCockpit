using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cocpit.Model
{
    public class WebSiteItem
    {
        /// <summary>
        /// Liefert oder setzt den Namen des Webdienstes
        /// </summary>
        [XmlElement("name")]
        public string Name { get; set; }

        /// <summary>
        /// Liefert oder setzt die Url des Webdienstes
        /// </summary>
        [XmlElement("url")]
        public string Url { get; set; }

        /// <summary>
        /// Liefert oder setzt die Url des Logos des Webdienstes
        /// </summary>
        [XmlElement("icon")]
        public string IconUrl { get; set; }

        /// <summary>
        /// Liefert oder setzt die Url des der Statusseite
        /// </summary>
        [XmlElement("status")]
        public string Status { get; set; }
    }
}
