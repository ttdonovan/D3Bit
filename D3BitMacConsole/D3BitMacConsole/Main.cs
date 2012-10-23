using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

using MonoMac.Foundation;
using MonoMac.ObjCRuntime;

using D3Bit;

namespace D3BitMacConsole
{
    class MainClass
    {
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

                        var itemObjs = new NSObject[] {
                            new NSString(name),
                            new NSString(quality),
                            new NSString(itemType),
                            new NSString(dpsArmor),
                            new NSString(meta),
                            new NSString(socketBonus),
                            new NSString(stats)
                        };
//
                        var itemKeys = new NSObject[] {
                            new NSString("Name"),
                            new NSString("Quality"),
                            new NSString("ItemType"),
                            new NSString("DpsArmor"),
                            new NSString("Meta"),
                            new NSString("SocketBonus"),
                            new NSString("Affixes")
                        };
//
//                        var itemDict = NSDictionary.FromObjectsAndKeys(itemObjs, itemKeys);
//
//                        NSError error = null;
//                        NSData jsonData = NSJsonSerialization.Serialize(itemDict, new NSJsonWritingOptions(), out error);
//
//                        NSString jsonString = NSString.FromData(jsonData, NSStringEncoding.UTF8);

                        // FIXME: very hackish but issues getting NSDictionary and NSJsonSerialization working...
                        var jsonString = "";
                        jsonString = jsonString + "{ ";
                        for (int i = 0; i < 7; i++) {
                            jsonString = jsonString + String.Format("\"{0}\": \"{1}\", ",
                                                       itemKeys.ElementAt(i), itemObjs.ElementAt(i));
                        }
                        jsonString = jsonString + " \"CreatedAt\": \"\" }";
                        Console.WriteLine(jsonString);
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

