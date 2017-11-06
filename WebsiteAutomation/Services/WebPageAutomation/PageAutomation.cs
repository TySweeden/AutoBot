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
        private BasicRoutine BasicAutomationRoutine { get; set; }

        //private PageScraper PageScraper { get; set; }

        public PageAutomation(HTMLDocument HtmlDocument)
        {
            this.Document = HtmlDocument;
            this.BasicAutomationRoutine = new BasicRoutine(HtmlDocument);
        }

        public void RunBasicRoutine()
        {
            //System.Threading.Thread.Sleep(1000);
            this.BasicAutomationRoutine.Execute();
        }

        public void GetIndeedRoutine()
        {

        }

        public void GetMonsterRoutine()
        {

        }
    }
}
