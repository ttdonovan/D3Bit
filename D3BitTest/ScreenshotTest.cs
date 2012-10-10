using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using D3Bit;

namespace D3BitTest
{
    [TestFixture()]
    public class ScreenshotTest
    {
        [Test()]
        [Ignore("Pending D3Bit.Screenshot.RECT")]
        public void RECTTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.Screenshot.GetSnapShot")]
        public void GetSnapShotTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
//      FIXME: ScreenshotTest.GetToolTipGivenToolTipBMPTestCase -- find a better way to test this this method
        public void GetToolTipGivenBmpWithToolTipTestCase()
        {
//          FIXME: is this really the best way to open files in NUnit?
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "02_d3_auction_house_with_tooltip_legendary.bmp");
            Bitmap bm = new Bitmap(file);
            var tooltip = Screenshot.GetToolTip(bm);
//          tooltip.Save(@"tmp/test.bmp");
            Assert.IsInstanceOf<Bitmap>(tooltip);
        }

        [Test()]
        public void GetToolTipGivenBmpWithNoToolTipTestCase()
        {
//          FIXME: is this really the best way to open files in NUnit?
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "01_d3_auction_house.bmp");
            Bitmap bm = new Bitmap(file);
            var tooltip = Screenshot.GetToolTip(bm);
            Assert.IsNull(tooltip);
        }
    }
}

