using Cocpit.Model;
using Cocpit.Pages;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using WebExpress.Pages;
using WebExpress.Workers;

namespace Cocpit
{
    public class CocpitPlugin : WebExpress.Plugins.Plugin
    {
        /// <summary>
        /// Konstruktor
        /// </summary>
        public CocpitPlugin()
        : base("Cocpit", "/Asserts/img/Cocpit.svg")
        {
        }

        /// <summary>
        /// Initialisierung des Prozesszustandes. Hier können z.B. verwaltete Ressourcen geladen werden. 
        /// </summary>
        /// <param name="configFileName">Der Dateiname der Konfiguration oder null</param>
        public override void Init(string configFileName = null)
        {
            base.Init(configFileName);

            ViewModel.Instance.Context = Context;
            ViewModel.Instance.Init();
            Context.Log.Info(MethodBase.GetCurrentMethod(), "Cocpit Plugin initialisierung");

            Register(new WorkerFile(new Path(Context, "", "Assets/.*"), Context.AssetBaseFolder));

            var root = new VariationPath(Context, "home", new PathItem("Home"));
            var help = new VariationPath(root, "help", new PathItem("Hilfe", "help"));
            var log = new VariationPath(root, "log", new PathItem("Logging", "log"));
            var debug = new VariationPath(root, "debug", new PathItem("Debug", "debug"));
            var settings = new VariationPath(root, "settings", new PathItem("Einstellungen", "settings"));
            var api = new VariationPath(root, "api", new PathItem("API", "api"));

            root.GetUrls("Home").ForEach(x => Register(new WorkerPage<PageDashboard>(x) { }));
            help.GetUrls("Hilfe").ForEach(x => Register(new WorkerPage<PageHelp>(x) { }));
            log.GetUrls("Logging").ForEach(x => Register(new WorkerPage<PageLog>(x) { }));
            debug.GetUrls("Debug").ForEach(x => Register(new WorkerPage<PageDebug>(x) { }));
            settings.GetUrls("Einstellungen").ForEach(x => Register(new WorkerPage<PageSettings>(x) { }));
            api.GetUrls("API").ForEach(x => Register(new WorkerPage<PageApiBase>(x) { }));

            Task.Run(() => { Run(); });
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, nachdem das Fenster aktiv ist.
        /// </summary>
        private void Run()
        {
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            // Loop
            while (true)
            {
                try
                {
                    Update();
                }
                finally
                {
                    Thread.Sleep(60000);
                }
            }
        }

        /// <summary>
        /// Diese Methode wird aufgerufen, nachdem das Fenster aktiv ist.
        /// </summary>
        private void Update()
        {
            ViewModel.Instance.Update();
        }
    }
}
