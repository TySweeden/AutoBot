using mshtml;
using System.Threading;
using WebsiteAutomation.Services.WebPageScraper;
using WebsiteAutomation.Services.WebPageScraper.Actions;

// ExecutionRoutine => PageScraper

namespace WebsiteAutomation.Services.WebPageAutomation.ExecutionRoutines
{
    public class BasicRoutine
    {
        private PageScraper PageScraper { get; set; }
        private PageActions PageActions { get; set; }

        public BasicRoutine(HTMLDocument HtmlDocument)
        {
            this.PageScraper = new PageScraper(HtmlDocument);
            this.PageActions = new PageActions();
        }

        public async void Execute()
        {
            IHTMLElement ParentElement = null;

            ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("First"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "first name here");

            ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Last"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "last name here");

            ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Email"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "emailhere@gmail.com");

            ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Resume"));
            this.PageActions.InvokeClick(this.PageScraper.GetFileUploadElement("Input"));


            // Automate File Upload Window
            FileDialogHandler DialogHandler = new FileDialogHandler();
            DialogHandler.SetFilePath();
            

        }
    }
}
