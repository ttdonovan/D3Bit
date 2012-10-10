using System;
using NUnit.Framework;
using D3Bit;

namespace D3BitTest
{
    [TestFixture()]
    public class ImageUtilTest
    {
        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.ColorWithInRange")]
        public void ColorWithInRangeTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.FindHorizontalLines")]
        public void FindHorizontalLinesTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.GetTextLineBounds")]
        public void GetTextLineBoundsTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.GetGrayValue")]
        public void GetGrayValueTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.GetBlockBounding (without Color function")]
        public void GetBlockBoundingWithoutColorFuncTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.GetBlockBounding (with Color function)")]
        public void GetBlockBoundingWithColorFuncTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.DrawBlockBounding (without Color)")]
        public void DrawBlockBoundingWithoutColorTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.DrawBlockBounding (with Color)")]
        public void DrawBlockBoundingWithColorTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.ImproveForOCR")]
        public void ImproveForOCRTestCase()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.DpsFix")]
        public void DpsFix()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.ResizeImage")]
        public void ResizeImage()
        {
            Assert.AreEqual(true, false);
        }

        [Test()]
        [Ignore("Pending D3Bit.ImageUtil.Sharpen")]
        public void Sharpen()
        {
            Assert.AreEqual(true, false);
        }
    }

    [TestFixture()]
    public class BoundTest
    {
        [Test()]
        [Ignore("Pending D3Bit.Bound")]
        public void TestCase()
        {
            Assert.AreEqual(true, false);
        }
    }

    [TestFixture()]
    public class PointTest
    {
        [Test()]
        public void XTestCase()
        {
            Point p = new Point(100, 10);
            Assert.AreEqual(100, p.X);
        }

        [Test()]
        public void YTestCase()
        {
            Point p = new Point(20, 200);
            Assert.AreEqual(200, p.Y);
        }

        [Test()]
        public void ToStringTestCase()
        {
            Point p = new Point(150, 300);
            Assert.AreEqual("150, 300", p.ToString());
        }
    }

    [TestFixture()]
    public class LineTest
    {
        [Test()]
        public void P1TestCase()
        {
            Point p1 = new Point(100, 100);
            Point p2 = new Point(200, 150);
            Line l = new Line(p1, p2);
            Assert.AreSame(p1, l.P1);
        }

        [Test()]
        public void P2TestCase()
        {
            Point p1 = new Point(300, 200);
            Point p2 = new Point(400, 250);
            Line l = new Line(p1, p2);
            Assert.AreSame(p2, l.P2);
        }

        [Test()]
        public void XLengthPosTestCase()
        {
            Point p1 = new Point(10, 100);
            Point p2 = new Point(35, 100);
            Line l = new Line(p1, p2);
            Assert.AreEqual(25, l.XLength);
        }

        [Test()]
        public void XLengthNegTestCase()
        {
            Point p1 = new Point(75, 100);
            Point p2 = new Point(65, 100);
            Line l = new Line(p1, p2);
            Assert.AreEqual(10, l.XLength);
        }

        [Test()]
        public void ToStringTestCase()
        {
            Point p1 = new Point(222, 222);
            Point p2 = new Point(444, 444);
            Line l = new Line(p1, p2);
            Assert.AreEqual("222, 222 - 444, 444", l.ToString());
        }
    }
}

