using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WebsiteAutomation.Services.WebPageAutomation
{
    
    public class FileDialogHandler
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetDlgItem(IntPtr hWnd, int nChildID);

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        // uMsg param
        private const int WM_SETTEXT = 0x000C;
        private const int BM_CLICK = 0x00F5;

        IntPtr hFileDialog = FindWindow("#32770", "Choose File To Upload");

        // does not do anything unless a window is found
        public void SetFilePath()
        {
            IntPtr hWndFilePathTextControl = GetDlgItem(hFileDialog, 1148);
            IntPtr hWndFileOpenButtonControl = GetDlgItem(hFileDialog, 1);
            //HandleRef hrefHwndTarget = new HandleRef(null, hWndFilePathControl);
            SendMessage(hWndFilePathTextControl, WM_SETTEXT, 0, String.Format(@"file:///{0}App_Data\{1}", AppDomain.CurrentDomain.BaseDirectory, "file.docx"));
            SendMessage(hWndFileOpenButtonControl, BM_CLICK, 0, null);
            //SendMessage(hFileDialog, 0x0111, 00000084, 0);
        }
    }
}
