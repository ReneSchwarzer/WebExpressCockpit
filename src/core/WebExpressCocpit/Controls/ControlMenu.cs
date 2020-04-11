using WebExpress.Pages;
using WebExpress.UI.Controls;

namespace Cocpit.Controls
{
    public class ControlMenu : WebExpress.UI.Controls.ControlHamburgerMenu
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="page">Die zugehörige Seite</param>
        public ControlMenu(IPage page)
            : base(page, null)
        {
            Icon = Icon.Bars;
            Text = "";
            Layout = TypesLayoutButton.Primary;

            Items.Add(new ControlLink(Page) { Text = "Home", Icon = Icon.Home, Url = Page.GetPath(0) });

            Items.Add(new ControlDropdownMenuDivider(Page) { });
            Items.Add(new ControlLink(Page) { Text = "Logging", Icon = Icon.Book, Url = Page.GetPath(0, "log") });
            Items.Add(new ControlLink(Page) { Text = "Einstellungen", Icon = Icon.Cog, Url = Page.GetPath(0, "settings") });
            Items.Add(new ControlDropdownMenuDivider(Page) { });
            Items.Add(new ControlLink(Page) { Text = "Hilfe", Icon = Icon.InfoCircle, Url = Page.GetPath(0, "help") });

        }
    }
}
