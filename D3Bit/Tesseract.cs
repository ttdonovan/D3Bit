using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Reflection;
// using NHunspell;

namespace D3Bit
{
    public static class Tesseract
    {
//      FIXME: Mono OS X System.EntryPointNotFoundException -- can this be conditinally included depending on the platform?
//      private static Hunspell hunspell = new Hunspell("en_US.aff", "en_US.dic");

        public static string GetTextFromBitmap(Bitmap bitmap)
        {
			string _pwd = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			return GetTextFromBitmap(bitmap, @"nobatch " + Path.Combine(_pwd, "tesseract", "d3letters"));
        }

        public static string GetTextFromBitmap(Bitmap bitmap, string extraParams)
        {
            //StopWatch sw = new StopWatch();
            string _pwd = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			bitmap.Save(Path.Combine(_pwd, "tesseract", "x.png"), ImageFormat.Png);
            //sw.Lap("File Save");
//          FIXME: find a way to switch between tesseract.exe and tesseract depending on platform
//          $ brew install tesseract
//          $ which tesseract
//          /usr/local/bin/tesseract
//          $ cd D3BitTest/bin/Debug/tesseract
//          $ ln /usr/local/bin/tesseract tesseract_mac
//          ProcessStartInfo info = new ProcessStartInfo(Path.Combine("tesseract", "tesseract.exe"), Path.Combine("tesseract", "x.png") + " " + Path.Combine("tesseract", "x") + extraParams);
			ProcessStartInfo info = new ProcessStartInfo(Path.Combine(_pwd, "tesseract", "tesseract_mac"), Path.Combine(_pwd, "tesseract", "x.png") + " " + Path.Combine(_pwd, "tesseract", "x") + " " + extraParams);
            info.WindowStyle = ProcessWindowStyle.Hidden;
            Process p = Process.Start(info);
            p.WaitForExit();
//          //sw.Lap("Tesseract");

			TextReader tr = new StreamReader(Path.Combine(_pwd, "tesseract", "x.txt"));
            string res = tr.ReadToEnd();
            tr.Close();
            //File.Delete(@"tesseract\x.png");
            //File.Delete(@"tesseract\x.txt");
            return res.Trim();
        }

        public static string CorrectSpelling(string text)
        {
//            FIXME: no Hunspell Mono OS X System.EntryPointNotFoundException, see Tesseract.cs line 16
//            string[] words = text.Split(new[] { ' ' });
//            string res = "";
//            foreach (var word in words)
//            {
//                var suggestions = hunspell.Suggest(word);
//                if (suggestions.Count > 0 && !hunspell.Spell(word))
//                    res += suggestions[0] + " ";
//                else
//                    res += word + " ";
//            }
//            return res.Trim();
            return text.Trim ();
        }

    }
}
