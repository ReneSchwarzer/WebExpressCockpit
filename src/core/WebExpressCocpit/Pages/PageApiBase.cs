using Cocpit.Model;
using System.Text.Json;
using WebExpress.Pages;

namespace Cocpit.Pages
{
    public class PageApiBase : PageApi
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageApiBase()
            : base()
        {
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public override void Init()
        {
            base.Init();


        }

        /// <summary>
        /// Verarbeitung
        /// </summary>
        public override void Process()
        {
            base.Process();

            //var converter = new TimeSpanConverter();

            var api = new API()
            {
                WebSites = ViewModel.Instance.Settings.WebSites
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            Content = JsonSerializer.Serialize(api, options);
        }
    }
}
