using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using D3Bit;

namespace D3BitTest
{
    [TestFixture()]
//  FIXME: is this really the best way to open the image files in NUnit?
    public class TooltipTest
    {
        [Test()]
        public void ParseItemNameTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "05_d3_tooltip_rare.bmp");
            Bitmap bm = new Bitmap(file);
            Tooltip tooltip = new Tooltip(bm);
            string actual = tooltip.ParseItemName();
            string expected = "ALLIANCE CARNAGE";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ParseItemTypeTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "05_d3_tooltip_rare.bmp");
            Bitmap bm = new Bitmap(file);
            Tooltip tooltip = new Tooltip(bm);
            string actual = "";
            tooltip.ParseItemType(out actual);
            string expected = "Rare";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ParseMetaTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "05_d3_tooltip_rare.bmp");
            Bitmap bm = new Bitmap(file);
            Tooltip tooltip = new Tooltip(bm);
            string actual = tooltip.ParseMeta();
            string expected = "723-1289,1.32";
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ParseDPSTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "05_d3_tooltip_rare.bmp");
            Bitmap bm = new Bitmap(file);
            Tooltip tooltip = new Tooltip(bm);
            double actual = tooltip.ParseDPS();
            double expected = 1328.0;
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void ParseAffixesTestCase()
        {
            string file = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..", "..", "images", "05_d3_tooltip_rare.bmp");
            Bitmap bm = new Bitmap(file);
            Tooltip tooltip = new Tooltip(bm);
            string actual_socket = "";
            Dictionary<string, string> actual_affixes = tooltip.ParseAffixes(out actual_socket);
            Assert.AreEqual("", actual_socket);
            Dictionary<string, string> expected_affixes = new Dictionary<string, string>();
            expected_affixes.Add("MinD", "299");
            expected_affixes.Add("MaxD", "398");
            expected_affixes.Add("Dmg%", "42");
            expected_affixes.Add("Dex", "54");
            expected_affixes.Add("LoH", "858");
            Assert.AreEqual(expected_affixes, actual_affixes);
        }
    }
}

