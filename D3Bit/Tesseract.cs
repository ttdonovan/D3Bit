using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

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
            bitmap.Save(Path.Combine("tesseract", "x.png"), ImageFormat.Png);
//          FIXME: find a way a better way to call tesseract
//          $ ln -f /usr/local/bin/tesseract D3BitTest/bin/Debug/tesseract/tesseract_mac
            ProcessStartInfo info = new ProcessStartInfo(Path.Combine("tesseract", "tesseract_mac"), string.Format("{0} {1} -l {2} {3}", Path.Combine("tesseract", "x.png"), Path.Combine("tesseract", "x"), language_code, extraParams));
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();
            TextReader tr = new StreamReader(Path.Combine("tesseract", "x.txt"));
            string res = tr.ReadToEnd();
            tr.Close();
            return res.Trim();
        }
    }
}
