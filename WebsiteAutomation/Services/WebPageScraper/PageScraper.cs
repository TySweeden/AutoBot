using mshtml;
using System.Collections.Generic;
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
            IEnumerable<IHTMLElement> Elements = this.GetElementsByTagName(TagName);
            IHTMLElement FoundElement = Elements.Where(x => x.innerText.ToLower().Contains(InnerText.ToLower())).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetLabelElement(string InnerText)
        {
            List<IHTMLElement> Elements = this.GetElementsByTagName("Label");
            Elements.RemoveAll(x => x.innerText == null);

            System.Diagnostics.Debug.WriteLine("Lables: "+Elements.Count()+ "  InnerText: "+ InnerText);

            IHTMLElement FoundElement = Elements.Where(x => x.innerText.ToLower().Contains(InnerText.ToLower())).FirstOrDefault();
            Elements.Clear();

            return FoundElement;
        }


        public IHTMLElement GetInputElement(IHTMLElement HtmlNodeContainer)
        {
            IHTMLElementCollection Children = HtmlNodeContainer.children;
            
            List<IHTMLElement> Elements = Children.Cast<IHTMLElement>().ToList();
            Elements.RemoveAll(x => x.tagName == null);

            IHTMLElement FoundElement = Elements.Where(x => x.tagName.ToLower().Contains("input")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetButtonElement(string TagName, string InnerText)
        {
            List<IHTMLElement> Elements = this.GetElementsByTagName(TagName);

            IHTMLElement FoundElement = Elements.Where(x => x.innerText.ToLower().Contains(InnerText.ToLower())).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetFileUploadElement(string TagName)
        {
            List<IHTMLElement> Elements = this.GetElementsByTagName(TagName);

            IHTMLElement FoundElement = Elements.Where(x => x.getAttribute("type").ToLower().Equals("file")).FirstOrDefault();

            return FoundElement;
        }


        public IHTMLElement GetParentElement(IHTMLElement HtmlElement)
        {
            return HtmlElement.parentElement;
        }


        public List<IHTMLElement> GetElementsByTagName(string TagName)
        {
            return this.Document.getElementsByTagName(TagName).Cast<IHTMLElement>().ToList();
        }


        public void SetLabelElementText(IHTMLElement HtmlLabelElement, string InnerText)
        {
            HtmlLabelElement.innerText = InnerText;
        }


        public void SetInputElementValue(IHTMLElement HtmlInputElement, dynamic value)
        {
            HtmlInputElement.innerText = value;
            HtmlInputElement.setAttribute("value", value);
        }
    }
}
