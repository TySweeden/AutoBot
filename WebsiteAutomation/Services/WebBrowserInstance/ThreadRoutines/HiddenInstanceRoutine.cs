using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebsiteAutomation.Services.WebBrowserInstance.ThreadRoutines
{
    public class HiddenInstanceRoutine
    {
        private string URL = string.Empty;

        public HiddenInstanceRoutine(string URL)
        {
            this.URL = URL;
        }

        public Delegate Get()
        {
            return new ThreadStart(() =>
            {
                // create instance of webbrowser control -- must run/initialized in STA thread.
                WebBrowserInstance browserInstance = new WebBrowserInstance();
                browserInstance.Navigate(URL);

                // start the Dispatcher processing to run control
                System.Windows.Threading.Dispatcher.Run();

                // other routines ..
            });
        }
    }
}
