using System;

using MonoMac.Foundation;

namespace D3BitMacGUI
{
    public class Item : NSObject
    {
        [Export("Name")]
        public string Name { get; set; }
        
        [Export("Quality")]
        public string Quality { get; set; }
        
        [Export("itemType")]
        public string ItemType { get; set; }
        
        [Export("DpsArmor")]
        public string DpsArmor { get; set; }
        
        [Export("Meta")]
        public string Meta { get; set; }
        
        [Export("SocketBonus")]
        public string SocketBonus { get; set; }
        
        [Export("Affixes")]
        public string Affixes { get; set; }

        public Item ()
        {
            Name = "";
            Quality = "";
            ItemType = "";
            DpsArmor = "";
            Meta = "";
            SocketBonus = "";
            Affixes = "";
        }
    }
}

