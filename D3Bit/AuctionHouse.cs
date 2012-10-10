using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;

namespace D3Bit
{
    public class AuctionHouse
    {
        public Bitmap Original { get; private set; }
        public Bitmap Processed { get; private set; }

		private Bound _previousBoundYs; // with default Ys;
		private string _pwd;


        public AuctionHouse(Bitmap bitmap)
        {
            Original = bitmap;
			Processed = (Bitmap)Original.Clone();

			_previousBoundYs = new Bound(new Point(0, 5), new Point(0, 40));
			_pwd = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

		public Bound GetBlockBoundingWithPoints(Point p1, Point p2)
		{
			Bound bound = new Bound(p1, p2);
			ImageUtil.DrawBlockBounding(Processed, bound, Color.Blue);
			bound = ImageUtil.GetBlockBounding(Original, bound).Expand(4);
			ImageUtil.DrawBlockBounding(Processed, bound);
			return bound;
		}

		public List<Dictionary<string,string>> ParseSearchResults ()
        {
			Point p1;
			Point p2;
			int yHeight = 40; // FIXME: any larger the last search result is ignored, but this might be too small
			List<Dictionary<string,string>> searchResultsList= new List<Dictionary<string,string>>();
			for (int y = 0; y < Original.Height + yHeight; y = y + yHeight)
            {
				Dictionary<string,string> result = new Dictionary<string, string>();
				if (y == 0) {
					p1 = new Point(0, _previousBoundYs.P1.Y);
					p2 = new Point(0, _previousBoundYs.P2.Y);
				} else {
					p1 = new Point(0, _previousBoundYs.P2.Y); // p1 is bottom of previous's p2
					p2 = new Point(0, _previousBoundYs.P2.Y + yHeight); // p2 is previous's p2 + yHeight
				}

				// item name
				Bound resultItemNameBound = GetBlockBoundingWithPoints(new Point(p1.X + 35, p1.Y), new Point(p2.X + 335, p2.Y));

				Bitmap itemNameBlock = Original.Clone(resultItemNameBound.Expand(4).ToRectangle(), Processed.PixelFormat);
				itemNameBlock = ImageUtil.ResizeImage(itemNameBlock, itemNameBlock.Width*6, itemNameBlock.Height*6);
				string itemName = Tesseract.GetTextFromBitmap(ImageUtil.Sharpen(itemNameBlock)).Replace("\r", "").Replace("\n", " ").Replace("GB", "O").Replace("G3", "O").Replace("EB", "O").Replace("G9", "O");
				result.Add("Name", itemName);

                // dps
				Bound resultDpsBound = GetBlockBoundingWithPoints(new Point(p1.X + 380, p1.Y), new Point(p2.X + 420, p2.Y));

				Bitmap dpsBlock = Original.Clone(resultDpsBound.Expand(4).ToRectangle(), Processed.PixelFormat);
				dpsBlock = ImageUtil.ResizeImage(dpsBlock, dpsBlock.Width*6, dpsBlock.Height*6);
				string dps = Tesseract.GetTextFromBitmap(ImageUtil.Sharpen(dpsBlock), String.Format("-psm 7 nobatch {0}", Path.Combine(_pwd, "tesseract", "d3digits")));
				result.Add("DpsArmor", dps);

				// bid
				Bound resultBidBound = GetBlockBoundingWithPoints(new Point(p1.X + 425, p1.Y), new Point(p2.X + 485, p2.Y));

				Bitmap bidBlock = Original.Clone(resultBidBound.Expand(4).ToRectangle(), Processed.PixelFormat);
				bidBlock = ImageUtil.ResizeImage(bidBlock, bidBlock.Width*6, bidBlock.Height*6);
				string bid = Tesseract.GetTextFromBitmap(ImageUtil.Sharpen(bidBlock), String.Format("-psm 7 nobatch {0}", Path.Combine(_pwd, "tesseract", "d3currency")));
				result.Add("Bid", bid);

				// buyout
				Bound resultBuyoutBound = GetBlockBoundingWithPoints(new Point(p1.X + 505, p1.Y), new Point(p2.X + 570, p2.Y));

				Bitmap buyoutBlock = Original.Clone(resultBuyoutBound.Expand(4).ToRectangle(), Processed.PixelFormat);
				buyoutBlock = ImageUtil.ResizeImage(buyoutBlock, buyoutBlock.Width*6, buyoutBlock.Height*6);
				string buyout = Tesseract.GetTextFromBitmap(ImageUtil.Sharpen(buyoutBlock), String.Format("-psm 7 nobatch {0}", Path.Combine(_pwd, "tesseract", "d3currency")));
				result.Add("Buyout", buyout);

                // time left
				Bound resultTimeLeftBound = GetBlockBoundingWithPoints(new Point(p1.X + 620, p1.Y), new Point(p2.X + 675, p2.Y));

				Bitmap timeLeftBlock = Original.Clone(resultTimeLeftBound.Expand(4).ToRectangle(), Processed.PixelFormat);
				timeLeftBlock = ImageUtil.ResizeImage(timeLeftBlock, timeLeftBlock.Width*6, timeLeftBlock.Height*6);
				string timeLeft = Tesseract.GetTextFromBitmap(ImageUtil.Sharpen(timeLeftBlock), String.Format("-psm 7 nobatch {0}", Path.Combine(_pwd, "tesseract", "d3time")));
				result.Add("Time Left", timeLeft);

				// debug
				// itemNameBlock.Save(Path.Combine("tmp", String.Format("item_name_{0}.bmp", p1.Y)));
				// dpsBlock.Save(Path.Combine("tmp", String.Format("dps_{0}.bmp", p1.Y)));
				// bidBlock.Save(Path.Combine("tmp", String.Format("bid_{0}.bmp", p1.Y)));
				// buyoutBlock.Save(Path.Combine("tmp", String.Format("buyout_{0}.bmp", p1.Y)));
				// timeLeftBlock.Save(Path.Combine("tmp", String.Format("time_left_{0}.bmp", p1.Y)));
				// Console.WriteLine(String.Format("Y:{5}, Name: {0}, Dps: {1}, Bid: {2}, Buyout: {3}, Time Left: {4}", itemName, dps, bid, buyout, timeLeft, p1.Y));

				// keep track of the previous Bound, this will be used as an offset for next iteration
				_previousBoundYs = new Bound(new Point(0, resultTimeLeftBound.P1.Y), new Point (0, resultTimeLeftBound.P2.Y));

				// push the result onto the list of search results
				searchResultsList.Add(result);
            }

			return searchResultsList;
        }
    }
}

