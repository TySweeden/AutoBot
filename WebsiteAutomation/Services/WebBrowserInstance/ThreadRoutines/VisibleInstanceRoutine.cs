using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebsiteAutomation.Services.WebPageAutomation;

namespace WebsiteAutomation.Services.WebBrowserInstance.ThreadRoutines
{
    public class VisibleInstanceRoutine
    {
        private string URL = string.Empty;

        public VisibleInstanceRoutine(string URL)
        {
            this.URL = URL;
        }

        public void Get()
        {
            // create instance of webbrowser control -- must run/initialized in STA thread.
            WebBrowserInstance browserInstance = new WebBrowserInstance();
            browserInstance.CreateWindow();
            browserInstance.Navigate(URL);

            // start the Dispatcher processing to run control
            System.Windows.Threading.Dispatcher.Run();
        }
    }
}
