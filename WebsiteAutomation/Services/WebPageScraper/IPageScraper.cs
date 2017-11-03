using mshtml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAutomation.Services.WebPageScraper
{
    interface IPageScraper
    {
        List<IHTMLElement> GetElementsByTagName(string TagName);
        IHTMLElement GetElementByText(string TagName, string InnerText);
        IHTMLElement GetLabelElement(string InnerText); // <label>
        IHTMLElement GetInputElement(IHTMLElement HtmlNodeContainer);
        IHTMLElement GetButtonElement(string TagName, string InnerText); // <a>, <button>, <input>
        IHTMLElement GetFileUploadElement(string TagName);

        IHTMLElement GetParentElement(IHTMLElement HtmlElement);

        void SetLabelElementText(IHTMLElement HtmlLabelElement, string InnerText);
        void SetInputElementValue(IHTMLElement HtmlInputElement, dynamic value);
    }
}
