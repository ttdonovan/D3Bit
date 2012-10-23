
using System;
using System.Collections.Generic;
using System.Linq;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.WebKit;

using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Imaging;
using D3Bit;

namespace D3BitMacGUI
{
	public partial class MainWindowController : MonoMac.AppKit.NSWindowController
	{
        Item item;

		#region Constructors
		
		// Called when created from unmanaged code
		public MainWindowController (IntPtr handle) : base (handle)
		{
			Initialize ();
		}
		
		// Called when created directly from a XIB file
		[Export ("initWithCoder:")]
		public MainWindowController (NSCoder coder) : base (coder)
		{
			Initialize ();
		}
		
		// Call to load from the XIB/NIB file
		public MainWindowController () : base ("MainWindow")
		{
            Initialize ();
		}
		
		// Shared initialization code
		void Initialize ()
		{
		}
		
		#endregion
		
		//strongly typed window accessor
		public new MainWindow Window {
			get {
				return (MainWindow)base.Window;
			}
		}

        public override void  AwakeFromNib() {
            webView.MainFrame.LoadRequest(new NSUrlRequest (new NSUrl ("http://d3bit.com/c")));
        }

        partial void openScreenshot(NSObject sender) {
            var openPanel = new NSOpenPanel();
            openPanel.ReleasedWhenClosed = true;
            openPanel.Prompt = "Select file";

            var result = openPanel.RunModal();
            if (result == 1)
            {
                Bitmap bm = new Bitmap(openPanel.Url.Path);
                var tooltipBmp = Screenshot.GetToolTip(bm);

                if (tooltipBmp != null) {
                    // FIXME: there has to be a better way to do this...    
                    // System.IO.MemoryStream s = new System.IO.MemoryStream();
                    // tooltip.Save(s, ImageFormat.Bmp);
                    // var image = NSImage.FromStream(s);
                    // string locationDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    // tooltipBmp.Save(Path.Combine(locationDir, "tooltip.bmp"))
                    // var image = new NSImage(Path.Combine(locationDir, "tooltip.bmp")); 
                    // tooltipImageCell.Image = image;

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

                    // TODO: look into how KVO works with MonoMac
                    item = new Item {
                        Name = name,
                        Quality = quality,
                        ItemType = itemType,
                        DpsArmor = dpsArmor,
                        Meta = meta,
                        SocketBonus = socketBonus,
                        Affixes = stats
                    };

                    // set the fields string value in the view
                    nameField.StringValue = item.Name;
                    typeField.StringValue = item.ItemType;
                    qualityField.StringValue = item.Quality;
                    dpsArmorField.StringValue = item.DpsArmor;
                    metaField.StringValue = item.Meta;
                    statsField.StringValue = item.Affixes;

                    // displays the processed tooltip image
                    string locationDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    tooltip.Processed.Save(Path.Combine(locationDir, "tooltip.bmp"));
                    var image = new NSImage(Path.Combine(locationDir, "tooltip.bmp"));
                    tooltipImageCell.Image = image;
                }
            }
        }
	
        partial void analyzeClick(NSObject sender) {
            if (item != null) {
                var info = new Dictionary<string, string>();
                info.Add("name", item.Name);
                info.Add("quality", item.Quality);
                info.Add("type", item.ItemType);
                info.Add("meta", item.Meta);
                info.Add("dps", item.DpsArmor);
                info.Add("stats", item.Affixes);
                
                Func<string, string> u = System.Uri.EscapeDataString;
                string url = String.Format ("http://d3bit.com/c/?image={0}&battletag={1}&build={2}&secret={3}&{4}&test=1",
                                            "", // u(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, TooltipPath))
                                            bnetBattleTag.StringValue,
                                            d3upBuild.StringValue,
                                            "", // u(Properties.Settings.Default.Secret.Trim())
                                            String.Join("&", info.Select(d => d.Key + "=" + u(d.Value))));
                
                webView.MainFrame.LoadRequest(new NSUrlRequest (new NSUrl (url)));
            }
        }
    }
}

