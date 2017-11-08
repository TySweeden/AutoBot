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
        private static extern IntPtr GetDlgItem(IntPtr hWnd, int nChildID);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int uMsg, int wParam, string lParam);

        // uMsg param
        private int WM_SETTEXT { get; set; }
        private int BM_CLICK { get; set; }

        private IntPtr hFileDialog { get; set; }

        public FileDialogHandler()
        {
            this.WM_SETTEXT = 0x000C;
            this.BM_CLICK = 0x00F5;

            this.hFileDialog = FindWindow("#32770", "Choose File To Upload");
        }

        private void SetFilePath()
        {
            IntPtr hWndFilePathTextControl = GetDlgItem(this.hFileDialog, 1148);
            SendMessage(hWndFilePathTextControl, this.WM_SETTEXT, 0, String.Format(@"file:///{0}App_Data\{1}", AppDomain.CurrentDomain.BaseDirectory, "file.docx"));
        }

        private void SubmitFile()
        {
            IntPtr hWndFileOpenButtonControl = GetDlgItem(this.hFileDialog, 1);
            SendMessage(hWndFileOpenButtonControl, this.BM_CLICK, 0, null);
        }

        public void Execute()
        {
            this.SetFilePath();
            this.SubmitFile();
        }
    }
}
