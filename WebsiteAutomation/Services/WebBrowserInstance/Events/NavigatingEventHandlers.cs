using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebsiteAutomation.Services.WebBrowserInstance.Events.EventHandlers;

namespace WebsiteAutomation.Services.WebBrowserInstance.Events
{
    public class NavigatingEventHandlers : INavigatingEventHandlers
    {
        public void WebNavigating(object sender, WebBrowserNavigatingEventArgs navEvent)
        {
            throw new NotImplementedException();
        }
    }
}
