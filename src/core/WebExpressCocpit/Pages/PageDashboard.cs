using Cocpit.Controls;
using Cocpit.Model;
using WebExpress.UI.Controls;

namespace Cocpit.Pages
{
    public class PageDashboard : PageBase
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageDashboard()
            : base("Überblick")
        {
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public override void Init()
        {
            base.Init();

            var menu = new Controls.ControlMenu(this);
            HamburgerMenu = menu;
        }

        /// <summary>
        /// Verarbeitung
        /// </summary>
        public override void Process()
        {
            base.Process();

            Main.Content.Add(new ControlText(this)
            {
                Text = "Willkommen",
                Format = TypesTextFormat.H1,
                Class = "mb-5"
            });

            var i = 0;
            var grid = new ControlGrid(this) { Fluid = false };

            foreach (var webSite in ViewModel.Instance.Settings.WebSites)
            {
                var card = new ControlWebSite(this)
                {
                    WebSite = webSite
                };

                grid.Add(i++, card);
            }

            Main.Content.Add(grid);

        }

        /// <summary>
        /// In String konvertieren
        /// </summary>
        /// <returns>Das Objekt als String</returns>
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
