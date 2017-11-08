using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsiteAutomation.Services.WebBrowserInstance.Events.EventHandlers
{
    interface INavigationEventHandlers
    {
        void WebNavigated(object sender, WebBrowserNavigatedEventArgs navEvent);
    }
}
