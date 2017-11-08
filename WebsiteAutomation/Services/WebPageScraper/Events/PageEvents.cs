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
            HtmlElement.click();
        }


        public void InvokeFileUpload(IHTMLElement HtmlElement)
        {
            HTMLButtonElementEvents_Event htmlButtonEvent = HtmlElement as HTMLButtonElementEvents_Event;
            htmlButtonEvent.onclick += new HTMLButtonElementEvents_onclickEventHandler(() => 
            {
                // have to create thread to run Dialog automation
                Thread FileUploadThread = new Thread(() => 
                {
                    Thread.Sleep(500); // wait just in case File Dialog is not open.
                    System.Diagnostics.Debug.WriteLine("[*] AutoFillFileUploadDialog");

                    // Automate file upload dialog box
                    FileDialogHandler AutomateFileUpload = new FileDialogHandler();
                    AutomateFileUpload.Execute();
                });

                FileUploadThread.SetApartmentState(ApartmentState.STA);
                FileUploadThread.IsBackground = true;
                FileUploadThread.Start();

                return true;
            });

            HtmlElement.click();
        }
    }
}
