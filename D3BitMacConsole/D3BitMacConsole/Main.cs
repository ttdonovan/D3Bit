using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Reflection;
//using System.Web.Script.Serialization;
using D3Bit;

namespace D3BitMacConsole
{
	class MainClass
	{

		public class Item
		{
			public string Name { get; set; }
			public string Quality { get; set; }
			public string ItemType { get; set; }
			public string DpsArmor { get; set; }
			public string Meta { get; set; }
			public string SocketBonus { get; set; }
			public string Affixes { get; set; }
		}

		public static void Main (string[] args)
		{
			// FIXME: find a better way to parse the command line arguments
			if (args.Length == 2) {
				string scanner = args[0];
				string path = args[1];
				
				// set the path to the bitmap
				string  pathToBmp = "";
				if (path.StartsWith("/")) {
					pathToBmp = path;
				} else {
					pathToBmp = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), path);
				}
				
				// check for the type of scan to perform
				if (scanner == "--tooltip") {
					var tooltipBmp = Screenshot.GetToolTip(new Bitmap(pathToBmp));
					if (tooltipBmp != null) {
						// parse D3 information from Bitmap using D3Bit.Tooltip
						Tooltip tooltip = new Tooltip(tooltipBmp);

						string name = tooltip.ParseItemName();                      // parse item name
						string quality = "";
						string itemType = tooltip.ParseItemType(out quality);       // parse item type (and quality);
						string dpsArmor = String.Format("{0}", tooltip.ParseDPS()); // parse dps armor
						string meta = tooltip.ParseMeta();                          // parse meta
						string socketBonus = "";
						var affixes = tooltip.ParseAffixes(out socketBonus);        // parse affixes
						string stats = String.Join(", ", affixes.Select(kv => (kv.Value + " " + kv.Key).Trim()));

						Item item = new Item {
							Name = name,
							Quality = quality,
							ItemType = itemType,
							DpsArmor = dpsArmor,
							Meta = meta,
							SocketBonus = socketBonus,
							Affixes = stats
						};

//						List<Item> list = new List<Item>() {
//							item
//						};
//
//						var jss = new JavaScriptSerializer();
//						var json = jss.Serialize(list);
//						Console.WriteLine(json);
						var output = String.Format("Name:{0}|Quality:{1}|ItemType:{2}|DpsArmor:{3}|Meta:{4}|SocketBonus:{5}|Affixes:{6}",
						                           item.Name, item.Quality, item.ItemType, item.DpsArmor, item.Meta, item.SocketBonus, item.Affixes);
						Console.WriteLine(output);
					}
				}

				if (scanner == "--auction") {
					var auctionBmp = Screenshot.GetAuctionHouseSearchResults(new Bitmap(pathToBmp));
					if (auctionBmp != null) {
						AuctionHouse auction = new AuctionHouse(auctionBmp);
						List<Dictionary<string,string>> resultsList = auction.ParseSearchResults();
						auction.Processed.Save(@"tmp/a.bmp");

						foreach (Dictionary<string,string> result in resultsList) {
							Console.WriteLine("------");
							foreach (KeyValuePair<string, string> item in result) {
								Console.WriteLine("{0} = {1}", item.Key, item.Value);
							}
						}
					}
				}
			}
		}
	}
}