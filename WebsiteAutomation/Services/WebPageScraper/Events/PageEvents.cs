using mshtml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using WebsiteAutomation.Services.WebPageAutomation;

namespace WebsiteAutomation.Services.WebPageScraper.Events
{
    public class PageEvents //: IPageActions
    {
        public void InvokeClick(IHTMLElement HtmlElement)
        {

            HTMLButtonElementEvents_Event htmlButtonEvent = HtmlElement as HTMLButtonElementEvents_Event;
            htmlButtonEvent.onclick += new HTMLButtonElementEvents_onclickEventHandler(OnClick);
            

            HtmlElement.click();
            /*
            BackgroundWorker bw = new BackgroundWorker { WorkerReportsProgress = true };

            bw.DoWork += new DoWorkEventHandler( delegate (object o, DoWorkEventArgs args)
            {
                BackgroundWorker pBw = o as BackgroundWorker;
                System.Diagnostics.Debug.WriteLine("[*] Click Button");
                HtmlElement.click();
            });

            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler( delegate (object o, RunWorkerCompletedEventArgs args)
            {
                System.Diagnostics.Debug.WriteLine("[*] Completed Click");
            });

            bw.RunWorkerAsync();

            //FileDialogHandler DialogHandler = new FileDialogHandler();
            //DialogHandler.SetFilePath();
            */
        }

        // testing .. this event fires before the File Upload Window is available .. cannot automate window if it is not present. fuck my life right now.
        private bool OnClick()
        {
            Thread ClickThread = new Thread(DoSomething);

            ClickThread.SetApartmentState(ApartmentState.STA);
            ClickThread.IsBackground = true;
            ClickThread.Start();


            return true;
        }

        public void DoSomething()
        {
            Thread.Sleep(5000); // wait for File Upload Dialog Window to open.
            System.Diagnostics.Debug.WriteLine("[*] DoSomething");

            FileDialogHandler DialogHandler = new FileDialogHandler();
            DialogHandler.SetFilePath();
        }
    }
}
