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
        IList<IHTMLElement> GetElementsByTagName(string TagName);
        IHTMLElement GetElementByText(string TagName, string InnerText);
        IHTMLElement GetLabelElement(string InnerText); // <label>
        IHTMLElement GetInputElement(IHTMLElement HtmlNodeContainer);
        IHTMLElement GetRadioElement(IHTMLElement HtmlNodeContainer);
        IHTMLElement GetDropdownElement(IHTMLElement HtmlNodeContainer);
        IHTMLElement GetTextAreaElement(IHTMLElement HtmlNodeContainer);
        IHTMLElement GetButtonElement(string TagName, string InnerText); // <a>, <button>, <input>
        IHTMLElement GetFileUploadElement(string TagName);

        IHTMLElement GetParentElement(IHTMLElement HtmlElement);
        IList<IHTMLElement> GetNodeChildren(IHTMLElement HtmlNodeContainer);

        void SetElementInnerText(IHTMLElement HtmlElement, dynamic value);
        void SetValueAttribute(IHTMLElement HtmlElement, dynamic value);
        void SetInputElementValue(IHTMLElement HtmlInputElement, dynamic value);
        void SetRadioValue(IHTMLElement HtmlInputElement);
        void SetDropdownValue(IHTMLElement HtmlInputElement, dynamic value);
    }
}
