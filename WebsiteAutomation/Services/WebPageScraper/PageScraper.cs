using mshtml;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;


namespace WebsiteAutomation.Services.WebPageScraper
{
    public class PageScraper : IPageScraper
    {
        private HTMLDocument Document { get; set; }

        public PageScraper(HTMLDocument HtmlDocument)
        {
            this.Document = HtmlDocument;
        }


        public IHTMLElement GetElementByText(string TagName, string InnerText)
        {
            IList<IHTMLElement> Elements = this.GetElementsByTagName(TagName);
            IHTMLElement FoundElement = Elements.Where(x => x.innerText.ToLower().Contains(InnerText.ToLower())).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetLabelElement(string InnerText)
        {
            IList<IHTMLElement> Elements = this.GetElementsByTagName("Label");

            Elements.Remove(Elements.Where(x => x.innerText == null).FirstOrDefault());//.RemoveAll(x => x.innerText == null);

            IHTMLElement FoundElement = Elements.Where(x => x.innerText.ToLower().Contains(InnerText.ToLower())).FirstOrDefault();
            Elements.Clear();

            return FoundElement;
        }


        public IHTMLElement GetInputElement(IHTMLElement HtmlNodeContainer)
        {
            IList<IHTMLElement> Elements = this.GetNodeChildren(HtmlNodeContainer);
            
            Elements.Remove(Elements.Where(x => x.tagName == null).FirstOrDefault());//.RemoveAll(x => x.tagName == null);

            IHTMLElement FoundElement = Elements.Where(x => x.tagName.ToLower().Contains("input")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetRadioElement(IHTMLElement HtmlNodeContainer)
        {
            IList<IHTMLElement> Elements = this.GetNodeChildren(HtmlNodeContainer);

            Elements.Remove(Elements.Where(x => x.tagName == null).FirstOrDefault());

            IHTMLElement FoundElement = Elements.Where(x => x.tagName.ToLower().Contains("input") && x.getAttribute("type").ToLower().Equals("radio")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetDropdownElement(IHTMLElement HtmlNodeContainer)
        {
            IList<IHTMLElement> Elements = this.GetNodeChildren(HtmlNodeContainer);

            Elements.Remove(Elements.Where(x => x.tagName == null).FirstOrDefault());

            IHTMLElement FoundElement = Elements.Where(x => x.tagName.ToLower().Contains("select")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetTextAreaElement(IHTMLElement HtmlNodeContainer)
        {
            IList<IHTMLElement> Elements = this.GetNodeChildren(HtmlNodeContainer);

            IHTMLElement FoundElement = Elements.Where(x => x.tagName.ToLower().Contains("textarea")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetButtonElement(string TagName, string InnerText)
        {
            IList<IHTMLElement> Elements = this.GetElementsByTagName(TagName);
            
            IHTMLElement FoundElement = Elements.Where(x => x.innerText.ToLower().Contains(InnerText.ToLower())).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetFileUploadElement(string TagName)
        {
            IList<IHTMLElement> Elements = this.GetElementsByTagName(TagName);

            IHTMLElement FoundElement = Elements.Where(x => x.getAttribute("type").ToLower().Equals("file")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetParentElement(IHTMLElement HtmlElement)
        {
            return HtmlElement.parentElement;
        }


        public IList<IHTMLElement> GetNodeChildren(IHTMLElement HtmlNodeContainer)
        {
            IHTMLElementCollection Children = HtmlNodeContainer.children;

            return Children.Cast<IHTMLElement>().ToList();
        }


        public IList<IHTMLElement> GetElementsByTagName(string TagName)
        {
            return this.Document.getElementsByTagName(TagName).Cast<IHTMLElement>().ToList();
        }


        // set element properties
        public void SetElementInnerText(IHTMLElement HtmlElement, dynamic value)
        {
            HtmlElement.innerText = value;
        }

        public void SetValueAttribute(IHTMLElement HtmlElement, dynamic value)
        {
            HtmlElement.setAttribute("value", value);
        }

        public void SetInputElementValue(IHTMLElement HtmlInputElement, dynamic value)
        {
            this.SetElementInnerText(HtmlInputElement, value);
            this.SetValueAttribute(HtmlInputElement, value);
        }

        public void SetRadioValue(IHTMLElement HtmlInputElement)
        {
            HtmlInputElement.setAttribute("checked", "true");
        }

        public void SetDropdownValue(IHTMLElement HtmlSelectElement, dynamic value)
        {
            IList<IHTMLElement> Options = this.GetNodeChildren(HtmlSelectElement);
            Options.Remove(Options.Where(x => x.innerText == null).FirstOrDefault());

            IHTMLElement Option = Options.Where(x => x.innerHTML.ToLower().Contains(value.ToString().ToLower())).FirstOrDefault();

            Option.setAttribute("selected", "true");
        }

    }
}
