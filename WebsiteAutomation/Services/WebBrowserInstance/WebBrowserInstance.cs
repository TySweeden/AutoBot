using mshtml;
using System;
using System.Windows;
using System.Windows.Forms;
using WebsiteAutomation.Services.WebBrowserInstance.Events;

namespace WebsiteAutomation.Services.WebBrowserInstance
{
    public class WebBrowserInstance 
    {
        private WebBrowser wBrowser { get; set; }
        private CompletedEventHandlers CompletedEventHandlers { get; set; }

        public WebBrowserInstance()
        {
            this.CompletedEventHandlers = new CompletedEventHandlers();

            this.InitializeWebBroweserInstance();
        }

        private void InitializeWebBroweserInstance()
        {
            this.wBrowser = new WebBrowser()
            {
                Visible = true,
                AllowNavigation = true,
                ScriptErrorsSuppressed = true,
                Dock = DockStyle.Fill
            };

            this.wBrowser.Navigated += new WebBrowserNavigatedEventHandler(this.CompletedEventHandlers.WebNavigated);
            this.wBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.CompletedEventHandlers.LoadCompleted);
        }


        public Form CreateWindow()
        {
            Form Window = new Form()
            {
                Width = 1200,
                Height = 800
            };

            Panel PanelContainer = new Panel()
            {
                Visible = true,
                Dock = DockStyle.Fill
            };

            PanelContainer.Controls.Add(this.wBrowser);
            Window.Controls.Add(PanelContainer);

            Window.Show();

            return Window;
        }


        public void Navigate(string URL)
        {
            #if DEBUG
            System.Diagnostics.Debug.WriteLine("[*] Navigating to '"+URL+"'");
            #endif

            wBrowser.Navigate(new Uri(URL));
        }


        public HTMLDocument GetDocument()
        {
            return (HTMLDocument)this.wBrowser.Document.DomDocument;
        }
    }
}