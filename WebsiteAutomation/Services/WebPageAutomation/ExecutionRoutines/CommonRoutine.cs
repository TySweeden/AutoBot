﻿using mshtml;
using System.Threading;
using WebsiteAutomation.Services.WebPageScraper;
using WebsiteAutomation.Services.WebPageScraper.Events;

// ExecutionRoutine => PageScraper

namespace WebsiteAutomation.Services.WebPageAutomation.ExecutionRoutines
{
    public class CommonRoutine: ICommonAutomations
    {
        private PageScraper PageScraper { get; set; }
        private PageEvents PageActions { get; set; }

        public CommonRoutine(HTMLDocument HtmlDocument)
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
            this.SetGender();
            this.SetEthnicity();
            this.SetVeteranStatus();
            this.SetDisabilityStatus();

            this.SetCoverLetter();
            this.SetResumeFile();
        }


        public void SetFirstName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("First"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "first name here");
        }


        public void SetFullMiddleName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Middle"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "middle name here");
        }


        public void SetInitialMiddleName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Middle"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "middle initial here");
        }


        public void SetLastName()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Last"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "last name here");
        }


        public void SetEmail()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Email"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "emailhere@gmail.com");
        }


        public void SetPhoneNumber()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Phone"));
            this.PageScraper.SetInputElementValue(this.PageScraper.GetInputElement(ParentElement), "4055555555");
        }

        public void SetGender()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Male"));
            this.PageScraper.SetRadioValue(this.PageScraper.GetRadioElement(ParentElement));
        }

        public void SetEthnicity()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Ethnicity"));
            this.PageScraper.SetDropdownValue(this.PageScraper.GetDropdownElement(ParentElement), "White");
        }

        public void SetVeteranStatus()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("I AM NOT A PROTECTED VETERAN"));
            this.PageScraper.SetRadioValue(this.PageScraper.GetRadioElement(ParentElement));
        }

        public void SetDisabilityStatus()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("NO, I DON''T HAVE A DISABILITY"));
            this.PageScraper.SetRadioValue(this.PageScraper.GetRadioElement(ParentElement));
        }

        public void SetCoverLetter()
        {
            IHTMLElement ParentElement = this.PageScraper.GetParentElement(this.PageScraper.GetLabelElement("Cover"));
            this.PageScraper.SetElementInnerText(this.PageScraper.GetTextAreaElement(ParentElement), "Text blob here");
        }


        public void SetCoverLetterFile()
        {
            throw new System.NotImplementedException();
        }


        public void SetResumeFile()
        {
            this.PageActions.InvokeFileUpload(this.PageScraper.GetFileUploadElement("Input"));
        }
    }
}
