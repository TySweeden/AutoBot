﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebsiteAutomation.Services.WebBrowserInstance.Events.EventHandlers
{
    interface INavigatingEventHandlers
    {
        void WebNavigating(object sender, WebBrowserNavigatingEventArgs navEvent);
    }
}
