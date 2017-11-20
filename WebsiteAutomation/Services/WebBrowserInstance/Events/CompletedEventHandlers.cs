using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Navigation;
using WebsiteAutomation.Services.WebBrowserInstance.Events.EventHandlers;
using WebsiteAutomation.Services.WebPageAutomation;

namespace WebsiteAutomation.Services.WebBrowserInstance.Events
{
    public class CompletedEventHandlers : ICompletedEventHandlers, INavigationEventHandlers
    {
        public void LoadCompleted(object sender, WebBrowserDocumentCompletedEventArgs navArgs)
        {
            Debug.WriteLine("[*] LoadCompleted");
            WebBrowser wBrowser = (WebBrowser)sender;

            if(wBrowser == null)
                throw new ArgumentNullException("Error: Browser Instance is null.");

            // run page automation on loaded documents -- must be in thread to avoid web browser whitepage while processing automation.
            Thread AutomationThread = new Thread(new PageAutomation((mshtml.HTMLDocument)wBrowser.Document.DomDocument).RunCommonAutomationRoutine);

            // set the apartment state -- COM contoles run under Single Thread Apartment
            AutomationThread.SetApartmentState(ApartmentState.STA);
            AutomationThread.IsBackground = true;
            AutomationThread.Start();
        }


        public void WebNavigated(object sender, WebBrowserNavigatedEventArgs navEvent)
        {
            Debug.WriteLine("[*] WebNavigated");
        }
    }
}