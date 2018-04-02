using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using copyWoWtoVM;
using static copyWoWtoVM.Logg;
using static copyWoWtoVM.myProxy;
using static copyWoWtoVM.ReadWrite_ProxyXML;

namespace copyWoWtoVM
{
    partial class Form1
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);


        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        static extern bool CreateSymbolicLink(
        string lpSymlinkFileName, string lpTargetFileName, SymbolicLink dwFlags);

        enum SymbolicLink
        {
            File = 0,
            Directory = 1
        }

        [DllImport("Kernel32.dll", CharSet = CharSet.Unicode)]
        static extern bool CreateHardLink(string lpFileName, string lpExistingFileName, IntPtr lpSecurityAttributes);

        private const uint WM_COMMAND = 0x0111;
        private const int BN_CLICKED = 0x00f5;
        private const int BN_QUIT = 0x0012;
        private const int IDOK = 1;
        private const uint WM_CLOSE = 0x0010;
        private const int WM_LBUTTONDOWN = 0x0201;
        private const int WM_LBUTTONUP = 0x0202;

        static private void Click_OK_Proxifier()
        {
            Log("");

            if (FindWindow("#32770", "Proxifier") == IntPtr.Zero)
            {
                Log("wait for window...");
                Thread.Sleep(500);
            }

            bool flag = false;

            while (!flag)
            {
                IntPtr hWnd = FindWindow("#32770", "Proxifier"); //  #32770 - класс окна как сказал инспектор
                if (hWnd != IntPtr.Zero)
                {
                    SendMessage(hWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                    IntPtr hwndChild = FindWindowEx((IntPtr)hWnd, IntPtr.Zero, "Button", "&Да");
                    SendMessage(hwndChild, WM_LBUTTONDOWN, IntPtr.Zero, IntPtr.Zero);
                    SendMessage(hwndChild, WM_LBUTTONUP, IntPtr.Zero, IntPtr.Zero);
                    Log("clicked OK!");
                    flag = true;
                }
                Thread.Sleep(500);
            }
        }

    }
}