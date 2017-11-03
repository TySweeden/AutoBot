using mshtml;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using WebsiteAutomation.Services.WebBrowserInstance.Events;

namespace WebsiteAutomation.Services.WebBrowserInstance
{
    public class WebBrowserInstance 
    {
        private WebBrowser wBrowser { get; set; }
        private CompletedEventHandlers CompletedEventHandlers { get; set; }

        private bool _isVisible = false;
        public bool isVisible { get { return _isVisible; } }

        public WebBrowserInstance()
        {
            CompletedEventHandlers = new CompletedEventHandlers();

            this.InitializeWebBroweserInstance();
        }

        private void InitializeWebBroweserInstance()
        {
            this.wBrowser = new WebBrowser();

            this.wBrowser.Visibility = Visibility.Visible;
            this.wBrowser.Navigated += new NavigatedEventHandler(CompletedEventHandlers.WebNavigated);
            this.wBrowser.LoadCompleted += new LoadCompletedEventHandler(CompletedEventHandlers.LoadCompleted);

            this.wBrowser.BeginInit(); // start initialization of WebBrowser Component
        }


        public Window CreateWindow()
        {
            this._isVisible = true;
            Window Window = new Window();
            DockPanel DockPanelContainer = new DockPanel();
            
            DockPanelContainer.Children.Add(this.wBrowser);

            //Window.Visibility = Visibility.Hidden; 
            Window.Content = DockPanelContainer;
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
            HTMLDocument HtmlDocument = null;

            if(this.wBrowser.IsLoaded)
            {
                HtmlDocument = (HTMLDocument)this.wBrowser.Document;
            }

            return HtmlDocument;
        }


        public bool isPageLoaded()
        {
            return (bool)this.wBrowser.IsLoaded;
        }
    }
}