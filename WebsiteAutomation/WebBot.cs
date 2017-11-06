using System.Threading;
using System.Windows;
using WebsiteAutomation.Services.WebBrowserInstance.ThreadRoutines;

namespace WebsiteAutomation
{
    public class WebBot : IWebBot
    {
        private Application app = new Application();

        private Thread ComponentThread { get; set; }

        private HiddenInstanceRoutine HiddenInstanceRoutine { get; set; }
        private VisibleInstanceRoutine VisibleInstanceRoutine { get; set; }


        public WebBot(string URL)
        {
            #if DEBUG
            System.Diagnostics.Debug.WriteLine("[*] Initializing WebBrowserInstance ");
#endif
            this.HiddenInstanceRoutine = new HiddenInstanceRoutine(URL);
            this.VisibleInstanceRoutine = new VisibleInstanceRoutine(URL);

            this.VisibleInstance(); // default to hidden instance
        }


        public void HiddenInstance()
        {
            this.ComponentThread = new Thread( new ThreadStart(() => this.HiddenInstanceRoutine.Get() ));

            // set the apartment state -- COM contoles run under Single Thread Apartment
            ComponentThread.SetApartmentState(ApartmentState.STA);
            ComponentThread.IsBackground = true;
        }

        public void VisibleInstance()
        {
            this.ComponentThread = new Thread( new ThreadStart( () => this.VisibleInstanceRoutine.Get() ));

            // set the apartment state -- COM contoles run under Single Thread Apartment
            ComponentThread.SetApartmentState(ApartmentState.STA);
            ComponentThread.IsBackground = true;
        }

        public void Start()
        {
            this.ComponentThread.Start();
        }

    }
}


// routine for WebBrowserInstace - Hidden or Visible instance
