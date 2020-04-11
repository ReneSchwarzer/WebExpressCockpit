using Cocpit.Controls;

namespace Cocpit.Pages
{
    public sealed class PageSettings : PageBase
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public PageSettings()
            : base("Einstellungen")
        {
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public override void Init()
        {
            base.Init();

            var menu = new ControlMenu(this);
            ToolBar.Add(menu);

            Main.Content.Add(new ControlSettingForm(this)
            {

            });
        }

        /// <summary>
        /// Verarbeitung
        /// </summary>
        public override void Process()
        {
            base.Process();
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
