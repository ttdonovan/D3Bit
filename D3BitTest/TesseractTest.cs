using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using D3Bit;

namespace D3BitTest
{
    [TestFixture()]
    public class TesseractTest
    {
        [Test()]
        public void GetTextFromBitmapWithoutExtraParamsTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "06_d3_tooltip_item_name.bmp");
            Bitmap bm = new Bitmap(file);
            Assert.AreEqual("ALLIANCE CARNAGE", Tesseract.GetTextFromBitmap(bm));
        }

        [Test()]
        public void GetTextFromBitmapWithExtraParamsTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "06_d3_tooltip_item_name.bmp");
            Bitmap bm = new Bitmap(file);
            Assert.AreEqual("ALLIANCE CARNAGE", Tesseract.GetTextFromBitmap(bm, @"nobatch " + Path.Combine("tesseract", "d3letters")));
        }
    }
}

