using WebExpress.Pages;
using WebExpress.UI.Controls;

namespace Cocpit.Controls
{
    public class ControlSettingForm : ControlPanelFormular
    {

        /// <summary>
        /// Konstruktor
        /// </summary>
        public ControlSettingForm(IPage page)
            : base(page, "settings")
        {
            Init();
        }

        /// <summary>
        /// Initialisierung
        /// </summary>
        public void Init()
        {
            Name = "settings";
            EnableCancelButton = false;
            Class = "m-3";
        }
    }
}
