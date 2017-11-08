using mshtml;
using System.Threading;
using WebsiteAutomation.Services.WebPageScraper;
using WebsiteAutomation.Services.WebPageScraper.Events;

// ExecutionRoutine => PageScraper

namespace WebsiteAutomation.Services.WebPageAutomation.ExecutionRoutines
{
    public class BasicRoutine
    {
        private PageScraper PageScraper { get; set; }
        private PageEvents PageActions { get; set; }

        public BasicRoutine(HTMLDocument HtmlDocument)
        {
            this.PageScraper = new PageScraper(HtmlDocument);
            this.PageActions = new PageEvents();
        }

        public void Execute()
        {
            this.SetFirstName();
            // middle name
            this.SetLastName();
            this.SetEmail();
            this.SetPhoneNumber();
            this.SetCoverLetter();
            this.SetResumeFile();
        }


        private void SetFirstName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("First"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "first name here");
        }


        private void SetFullMiddleName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Middle"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "middle name here");
        }


        private void SetInitialMiddleName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Middle"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "middle initial here");
        }


        private void SetLastName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Last"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "last name here");
        }


        private void SetEmail()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Email"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "emailhere@gmail.com");
        }


        private void SetPhoneNumber()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Phone"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "4055555555");
        }


        private void SetCoverLetter()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Cover"));
            this.PageScraper.SetElementInnerText(this.PageScraper.GetTextAreaElement(ParentElement), "Text blob here");
        }


        private void SetCoverLetterFile()
        {
            throw new System.NotImplementedException();
        }


        private void SetResumeFile()
        {
            this.PageActions.InvokeFileUpload(this.PageScraper.GetFileUploadElement("Input"));
        }
    }
}
