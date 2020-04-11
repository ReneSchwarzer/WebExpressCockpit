using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cocpit.Model
{
    [XmlRoot(ElementName = "settings", IsNullable = false)]
    public class Settings
    {
        /// <summary>
        /// Liefert oder setzt den Debug-Modus
        /// </summary>
        [XmlAttribute("debug", DataType = "boolean")]
        public bool DebugMode { get; set; }

        /// <summary>
        /// Liefert oder setzt die Webseiten
        /// </summary>
        [XmlElement("website")]
        public List<WebSiteItem> WebSites { get; set; } = new List<WebSiteItem>();

        /// <summary>
        /// Kostruktor
        /// </summary>
        public Settings()
        {

        }
    }
}
