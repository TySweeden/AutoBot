using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebsiteAutomation;

namespace WebsiteAutomationConsole
{
    public class Program
    {
        //[STAThread]
        static void Main(string[] args)
        {
#if DEBUG 
            System.Diagnostics.Debug.WriteLine("[*] Initializing WebBot ");
#endif
            string HtmlFilePath = String.Format(@"file:///{0}App_Data\{1}", AppDomain.CurrentDomain.BaseDirectory, "IndeedApplicationForm1.html");

            WebBot bot = new WebBot(HtmlFilePath);

            bot.HiddenInstance();
            //Thread.Sleep(3000); // ensures page loads contents before starting thread routines
            bot.Start();

            Console.ReadLine();
        }
    }
}
