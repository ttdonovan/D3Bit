using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using D3Bit;

namespace D3BitTest
{
    [TestFixture()]
    //  FIXME: had to copy en_US.aff and en_US.dic and tesseract from D3Bit/Build to D3Bit/bin/Debug
    //  FIXME: is this really the best way to open the image files in NUnit?
    public class AuctionHouseTest
    {
        [Test()]
        public void ParseSearchResultsTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "07_d3_auction_house_search_results.bmp");
            Bitmap bm = new Bitmap(file);
            AuctionHouse ah = new AuctionHouse(bm);
            ah.Resized.Save(@"tmp/ah_resized.bmp");
            string actual = ah.ParseSearchResults();
            string expected = "array of results";
            Assert.AreEqual(expected, actual);
        }
    }
}

