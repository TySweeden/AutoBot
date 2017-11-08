using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Navigation;

namespace WebsiteAutomation.Services.WebBrowserInstance.Events.EventHandlers
{
    interface ICompletedEventHandlers
    {
        void LoadCompleted(object sender, WebBrowserDocumentCompletedEventArgs navArgs);
    }
}
