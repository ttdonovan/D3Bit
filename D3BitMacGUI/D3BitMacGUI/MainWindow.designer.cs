// WARNING
//
// This file has been generated automatically by MonoDevelop to store outlets and
// actions made in the Xcode designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoMac.Foundation;

namespace D3BitMacGUI
{
	[Register ("MainWindowController")]
	partial class MainWindowController
	{
		[Outlet]
		MonoMac.AppKit.NSTextField bnetBattleTag { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField d3upBuild { get; set; }

		[Outlet]
		MonoMac.AppKit.NSImageCell tooltipImageCell { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField nameField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField qualityField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField typeField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField dpsArmorField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField metaField { get; set; }

		[Outlet]
		MonoMac.AppKit.NSTextField statsField { get; set; }

		[Outlet]
		MonoMac.WebKit.WebView webView { get; set; }

		[Action ("openScreenshot:")]
		partial void openScreenshot (MonoMac.Foundation.NSObject sender);

		[Action ("analyzeClick:")]
		partial void analyzeClick (MonoMac.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (bnetBattleTag != null) {
				bnetBattleTag.Dispose ();
				bnetBattleTag = null;
			}

			if (d3upBuild != null) {
				d3upBuild.Dispose ();
				d3upBuild = null;
			}

			if (tooltipImageCell != null) {
				tooltipImageCell.Dispose ();
				tooltipImageCell = null;
			}

			if (nameField != null) {
				nameField.Dispose ();
				nameField = null;
			}

			if (qualityField != null) {
				qualityField.Dispose ();
				qualityField = null;
			}

			if (typeField != null) {
				typeField.Dispose ();
				typeField = null;
			}

			if (dpsArmorField != null) {
				dpsArmorField.Dispose ();
				dpsArmorField = null;
			}

			if (metaField != null) {
				metaField.Dispose ();
				metaField = null;
			}

			if (statsField != null) {
				statsField.Dispose ();
				statsField = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}
		}
	}

	[Register ("MainWindow")]
	partial class MainWindow
	{
		
		void ReleaseDesignerOutlets ()
		{
		}
	}
}
