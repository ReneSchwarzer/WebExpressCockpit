using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using WebExpress.Plugins;

namespace Cocpit.Model
{
    public class ViewModel
    {
        /// <summary>
        /// Instanz des einzigen Modells
        /// </summary>
        private static ViewModel _this = null;

        /// <summary>
        /// Lifert die einzige Instanz der Modell-Klasse
        /// </summary>
        public static ViewModel Instance
        {
            get
            {
                if (_this == null)
                {
                    _this = new ViewModel();
                }

                return _this;
            }
        }

        /// <summary>
        /// Liefert die aktuelle Zeit
        /// </summary>
        public string Now => DateTime.Now.ToString("dd.MM.yyyy<br>HH:mm:ss");

        /// <summary>
        /// Liefert oder setzt den Verweis auf den Kontext des Plugins
        /// </summary>
        public IPluginContext Context { get; set; }

        /// <summary>
        /// Liefert oder setzt den Staustext
        /// </summary>
        [XmlIgnore]
        public List<LogItem> Logging { get; set; } = new List<LogItem>();

        /// <summary>
        /// Liefert oder setzt die Settings
        /// </summary>
        public Settings Settings { get; private set; } = new Settings();

        /// <summary>
        /// Liefert die Programmversion
        /// </summary>
        [XmlIgnore]
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        /// <summary>
        /// Liefert oder setzt den Status
        /// </summary>
        public Dictionary<WebSiteItem, string> Status { get; private set; } = new Dictionary<WebSiteItem, string>(); 

        /// <summary>
        /// Konstruktor
        /// </summary>
        private ViewModel()
        {
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public void Init()
        {
            try
            {

            }
            catch
            {

            }

            ResetSettings();
        }

        /// <summary>
        /// Updatefunktion
        /// </summary>
        public virtual void Update()
        {
            var client = new HttpClient();
            try
            {
                //foreach (var webSite in Settings.WebSites)
                //{
                //    if (!string.IsNullOrWhiteSpace(webSite.Status))
                //    {
                //        var url = webSite.Url + "/status";
                //        var responseBody = client.GetStringAsync(url).Result;


                //        if (!Status.ContainsKey(webSite))
                //        {
                //            Status.Add(webSite, null);
                //        }

                //        Status[webSite] = responseBody;
                //    }
                //}
            }
            catch (HttpRequestException ex)
            {
                Log(new LogItem(LogItem.LogLevel.Exception, ex.ToString()));
            }
        }

        /// <summary>
        /// Loggt ein Event
        /// </summary>
        /// <param name="logItem">Der Logeintrag</param>
        public void Log(LogItem logItem)
        {
            Logging.Add(logItem);

            switch (logItem.Level)
            {
                case LogItem.LogLevel.Info:
                    Context.Log.Info(logItem.Instance, logItem.Massage);
                    break;
                case LogItem.LogLevel.Debug:
                    Context.Log.Debug(logItem.Instance, logItem.Massage);
                    break;
                case LogItem.LogLevel.Warning:
                    Context.Log.Warning(logItem.Instance, logItem.Massage);
                    break;
                case LogItem.LogLevel.Error:
                    Context.Log.Error(logItem.Instance, logItem.Massage);
                    break;
                case LogItem.LogLevel.Exception:
                    Context.Log.Exception(logItem.Instance, logItem.Massage);
                    break;
            }
        }

        /// <summary>
        /// Wird aufgerufen, wenn das Speichern der Einstellungen erfolgen soll
        /// </summary>
        public void SaveSettings()
        {
            Log(new LogItem(LogItem.LogLevel.Info, "Einstellungen werden gespeichert"));

            // Konfiguration speichern
            var serializer = new XmlSerializer(typeof(Settings));

            using (var memoryStream = new System.IO.MemoryStream())
            {
                serializer.Serialize(memoryStream, Settings);

                var utf = new UTF8Encoding();

                File.WriteAllText
                (
                    Path.Combine(Context.ConfigBaseFolder, "cocpit.settings.xml"),
                    utf.GetString(memoryStream.ToArray())
                );
            }
        }

        /// <summary>
        /// Wird aufgerufen, wenn die Einstellungen zurückgesetzt werden sollen
        /// </summary>
        public void ResetSettings()
        {
            Log(new LogItem(LogItem.LogLevel.Info, "Einstellungen werden geladen"));

            // Konfiguration laden
            var serializer = new XmlSerializer(typeof(Settings));

            try
            {
                using (var reader = File.OpenText(Path.Combine(Context.ConfigBaseFolder, "cocpit.settings.xml")))
                {
                    Settings = serializer.Deserialize(reader) as Settings;
                }
            }
            catch (Exception ex)
            {
                Log(new LogItem(LogItem.LogLevel.Warning, "Datei mit den Einstellungen wurde nicht gefunden!"));
            }


        }
    }
}