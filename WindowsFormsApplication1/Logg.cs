using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace copyWoWtoVM
{
    class Logg
    {
        delegate void Del(string text);

        static DateTime lastTime = DateTime.Now;
        static public RichTextBox richTB = new RichTextBox();
        static public void Log(string a, string b = null, string c = null)
        {
            //richTB1.
            richTB.Invoke(new Del((s) => richTB.Text += s), $"\r\n {DateTime.Now.ToString("H:mm")}  >> " + a);
            // richTB.Text += $"\r\n {DateTime.Now.ToString("H:mm")}  >> " + a;
            if (b != null)
            {
                richTB.Invoke(new Del((s) => richTB.Text += s), "\t" + b);
            }
            if (c != null)
            {
                richTB.Invoke(new Del((s) => richTB.Text += s), "\t" + c);
            }
            //richTB.Text += "\r\n";
        }

        static public void logEmptyRow()
        {
            //richTB1.
            richTB.Invoke(new Del((s) => richTB.Text += s), $"\r\n           >> ");
        }

        static public void logERROR()
        {
            richTB.Invoke(new Del((s) => richTB.Text += s), "\r\n  > -- ОШИБКА --\r\n");
            // richTB.Text += ("\r\n  > -- ОШИБКА --\r\n");
        }

        static public void logSUCCESSFUL()
        {
            richTB.Invoke(new Del((s) => richTB.Text += s), "\r\n  > успешно \r\n");
            // richTB.Text += ("\r\n  > успешно \r\n");
        }

        static public void logCLEAR()
        {
            richTB.Invoke(new Del((s) => richTB.Text = s), "");
            //richTB.Clear();
            lastTime = DateTime.Now;
        }

        static public void logSAVEtoFile()
        {

            if (System.IO.Directory.Exists(@"Logs"))
                Log("exists");
            else System.IO.Directory.CreateDirectory(@"Logs");

            string ta = lastTime.ToString("MM-dd HH.mm");
            string tb;
            if (DateTime.Now.Day == lastTime.Day)
                tb = DateTime.Now.ToString("HH.mm");
            else tb = DateTime.Now.ToString("MM-dd HH.mm");

            System.IO.File.WriteAllText($@"Logs\Log {ta + "~~" + tb}.txt", richTB.Text);

        }

        static public void scrollDown()
        {
            // set the current caret position to the end
            richTB.SelectionStart = richTB.Text.Length;
            // scroll it automatically
            richTB.ScrollToCaret();
        }

    }
}
