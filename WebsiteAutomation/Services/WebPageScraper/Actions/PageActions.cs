using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteAutomation.Services.WebPageAutomation;

namespace WebsiteAutomation.Services.WebPageScraper.Actions
{
    public class PageActions : IPageActions
    {
        public void InvokeClick(IHTMLElement HtmlElement)
        {
            HTMLButtonElementEvents_Event htmlButtonEvent = HtmlElement as HTMLButtonElementEvents_Event;

            htmlButtonEvent.onclick += new HTMLButtonElementEvents_onclickEventHandler(OnClick);

            HtmlElement.click();

            /*Task.Factory.StartNew(() => {
                HtmlElement.click();
            }).ContinueWith(_ => {
                FileDialogHandler DialogHandler = new FileDialogHandler();
                DialogHandler.SetFilePath();
            });*/
        }

        // testing .. this event fires before the File Upload Window is available .. cannot automate window if it is not present. fuck my life right now.
        private bool OnClick()
        {
            return true;
        }
    }
}
