﻿using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAutomation.Services.WebPageScraper.Events
{
    interface IPageEvents
    {
        void InvokeClick(IHTMLElement HtmlElement);
    }
}
