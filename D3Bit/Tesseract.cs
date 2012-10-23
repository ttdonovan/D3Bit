using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;

namespace D3Bit
{
    public static class Tesseract
    {
        public static string language_code = "eng";

        public static string GetTextFromBitmap(Bitmap bitmap)
        {
            return GetTextFromBitmap(bitmap, @"nobatch " + Path.Combine("tesseract", "d3letters"));
        }

        public static string GetTextFromBitmap(Bitmap bitmap, string extraParams)
        {
            string pwd = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            bitmap.Save(Path.Combine(pwd, "tesseract", "x.png"), ImageFormat.Png);
//          FIXME: find a way a better way to call tesseract
//          $ ln -f /usr/local/bin/tesseract D3BitTest/bin/Debug/tesseract/tesseract_mac
            ProcessStartInfo info = new ProcessStartInfo(Path.Combine(pwd, "tesseract", "tesseract_mac"), string.Format("{0} {1} -l {2} {3}", Path.Combine(pwd, "tesseract", "x.png"), Path.Combine(pwd, "tesseract", "x"), language_code, extraParams));
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();
            TextReader tr = new StreamReader(Path.Combine(pwd, "tesseract", "x.txt"));
            string res = tr.ReadToEnd();
            tr.Close();
            return res.Trim();
        }
    }
}
