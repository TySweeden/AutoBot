using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebsiteAutomation.Services.WebPageAutomation.ExecutionRoutines;

// PageAutomation => ExecutionRoutines

namespace WebsiteAutomation.Services.WebPageAutomation
{
    public class PageAutomation
    {
        private HTMLDocument Document { get; set; }
        private CommonRoutine CommonAutomationRoutine { get; set; }

        //private PageScraper PageScraper { get; set; }

        public PageAutomation(HTMLDocument HtmlDocument)
        {
            this.Document = HtmlDocument;
            this.CommonAutomationRoutine = new CommonRoutine(HtmlDocument);
        }

        public void RunCommonAutomationRoutine()
        {
            //System.Threading.Thread.Sleep(1000);
            this.CommonAutomationRoutine.Execute();
        }

        public void GetIndeedRoutine()
        {

        }

        public void GetMonsterRoutine()
        {

        }
    }
}
