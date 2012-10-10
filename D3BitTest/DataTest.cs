using System;
using System.Collections.Generic;
using NUnit.Framework;
using D3Bit;

namespace D3BitTest
{
    [TestFixture()]
    public class DataTest
    {
        [Test()]
        public void ItemQualitiesTestCase()
        {
            List<string> actual = Data.ItemQualities;
            List<string> expected = new List<string>();
            expected.Add("Magic");
            expected.Add("Rare");
            expected.Add("Legendary");
            expected.Add("Set");
            Assert.AreEqual (expected, actual);
        }

        [Test()]
        public void WeaponTypesTestCase()
        {
            List<string> actual = Data.WeaponTypes;
            List<string> expected = new List<string>();
            expected.Add("Axe");
            expected.Add("Ceremonial Knife");
            expected.Add("Hand Crossbow");
            expected.Add("Dagger");
            expected.Add("Fist Weapon");
            expected.Add("Mace");
            expected.Add("Mighty Weapon");
            expected.Add("Spear");
            expected.Add("Sword");
            expected.Add("Wand");
            expected.Add("Two-Handed Axe");
            expected.Add("Bow");
            expected.Add("Daibo");
            expected.Add("Crossbow");
            expected.Add("Two-Handed Mace");
            expected.Add("Two-Handed Mighty Weapon");
            expected.Add("Polearm"); 
            expected.Add("Staff");
            expected.Add("Two-Handed Sword"); 
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void OffHandTypesTestCase()
        {
            List<string> actual = Data.OffHandTypes;
            List<string> expected = new List<string>();
            expected.Add("Mojo");
            expected.Add("Source");
            expected.Add("Quiver");
            Assert.AreEqual (expected, actual);
        }

        [Test()]
        public void FollowerTypesTestCase()
        {
            List<string> actual = Data.FollowerTypes;
            List<string> expected = new List<string>();
            expected.Add("Enchantress Focus");
            expected.Add("Scoundrel Token");
            expected.Add("Templar Relic");
            Assert.AreEqual (expected, actual);
        }

        [Test()]
        public void CommonTypesTestCase()
        {
            List<string> actual = Data.CommonTypes;
            List<string> expected = new List<string>();
            expected.Add("Shield");
            expected.Add("Ring");
            expected.Add("Amulet");
            expected.Add("Shoulders");
            expected.Add("Helm");
            expected.Add("Pants");
            expected.Add("Gloves");
            expected.Add("Chest Armor");
            expected.Add("Bracers");
            expected.Add("Boots");
            expected.Add("Belt");
            expected.Add("Cloak");
            expected.Add("Mighty Belt");
            expected.Add("Spirit Stone");
            expected.Add("Voodoo Mask");
            expected.Add("Wizard Hat");
            Assert.AreEqual (expected, actual);
        }

        [Test()]
        public void ItemTypesTestCase()
        {
            List<string> actual = Data.ItemTypes;
            List<string> expected = new List<string>();
            expected.Add("Axe");
            expected.Add("Ceremonial Knife");
            expected.Add("Hand Crossbow");
            expected.Add("Dagger");
            expected.Add("Fist Weapon");
            expected.Add("Mace");
            expected.Add("Mighty Weapon");
            expected.Add("Spear");
            expected.Add("Sword");
            expected.Add("Wand");
            expected.Add("Two-Handed Axe");
            expected.Add("Bow");
            expected.Add("Daibo");
            expected.Add("Crossbow");
            expected.Add("Two-Handed Mace");
            expected.Add("Two-Handed Mighty Weapon");
            expected.Add("Polearm"); 
            expected.Add("Staff");
            expected.Add("Two-Handed Sword"); 
            expected.Add("Mojo");
            expected.Add("Source");
            expected.Add("Quiver");
            expected.Add("Shield");
            expected.Add("Ring");
            expected.Add("Amulet");
            expected.Add("Shoulders");
            expected.Add("Helm");
            expected.Add("Pants");
            expected.Add("Gloves");
            expected.Add("Chest Armor");
            expected.Add("Bracers");
            expected.Add("Boots");
            expected.Add("Belt");
            expected.Add("Cloak");
            expected.Add("Mighty Belt");
            expected.Add("Spirit Stone");
            expected.Add("Voodoo Mask");
            expected.Add("Wizard Hat");
            Assert.AreEqual(expected, actual);
        }

        [Test()]
        public void affixMatchesTestCase()
        {
            Dictionary<string, string> actual = Data.affixMatches;
            Dictionary<string, string> expected = new Dictionary<string, string>();
            expected.Add("Str", "+{I} Strength");
            expected.Add("Int", "+{I} Intelligence");
            expected.Add("Dex", "+{I} Dexterity");
            expected.Add("Vit", "+{I} Vitality");
            expected.Add("AR", "+{I} Resistance to All Elements");
            expected.Add("ArcR", "+{I} Arcane Resistance");
            expected.Add("ColdR", "+{I} Cold Resistance");
            expected.Add("FireR", "+{I} Fire Resistance");
            expected.Add("PoisonR", "+{I} Poison Resistance");
            expected.Add("LtnR", "+{I} Lightning Resistance");
            expected.Add("PhyR", "+{I} Physical Resistance");
            expected.Add("ArcD", "+{I}-{I} Arcane Damage");
            expected.Add("ColdD", "+{I}-{I} Cold Damage");
            expected.Add("FireD", "+{I}-{I} Fire Damage");
            expected.Add("HolyD", "+{I}-{I} Holy Damage");
            expected.Add("PoisonD", "+{I}-{I} Poison Damage");
            expected.Add("LtnD", "+{I}-{I} Lightning Damage");
            expected.Add("Dmg", "+- Damage");
            expected.Add("Dmg%", "+% Damage");
            expected.Add("MinD", "+{I} Minimum Damage");
            expected.Add("MaxD", "+{I} Maximum Damage");
            expected.Add("AtkSpd", "Increases Attack Speed by {I}%");
            expected.Add("Crit", "Critical Hit Chance Increased by {D}%");
            expected.Add("CritD", "Critical Hit Damage Increased by {I}%");
            expected.Add("LoH", "Each Hit Adds +{I} Life");
            expected.Add("LoK", "+{I} Life after Each Kill");
            expected.Add("LS", "{D}% of Damage Dealt Is Converted to Life");
            expected.Add("LPS", "Gain {D} per Spirit Spent");
            expected.Add("Life%", "+% Life");
            expected.Add("LRegen", "Regenerates {I} Life per Second");
            expected.Add("GlobeHP", "Health Globes grant +{I} Life.");
            expected.Add("MF", "{I}% Better Chance of Finding Magical Items");
            expected.Add("GF", "{I}% Extra Gold from Monsters");
            expected.Add("Exp", "Monster kills grant +{I} experience.");
            expected.Add("Exp%", "Increases Bonus Experience by {I}%");
            expected.Add("MvSpd", "+{I}% Movement Speed");
            expected.Add("Pick", "Increases Gold and Health Pickup by {I} Yards");
            expected.Add("LvlRe", "Level Requirement Reduced by {I}");
            expected.Add("MaxArcP", "+{I} Maximum Arcane Power");
            expected.Add("ArcPCrit", "Critical Hits grant {I} Arcane Power");
            expected.Add("HateRegen", "Increases Hatred Regeneration by {D} per Second");
            expected.Add("MaxMana", "+{I} Maximum Mana");
            expected.Add("ManaRegen", "Increases Mana Regeneration by {D} per Second");
            expected.Add("MaxDisc", "+{I} Maximum Discipline");
            expected.Add("MaxFury", "+{I} Maximum Fury");
            expected.Add("SpiritRegen", "Increases Spirit Regeneration by {D} per Second");
            expected.Add("Chill", "{D}% Chance to Chill on Hit");
            expected.Add("Fear", "{D}% Chance to Fear on Hit");
            expected.Add("Freeze", "{D}% Chance to Freeze on Hit");
            expected.Add("Immobilize", "{D}% Chance to Immobilize on Hit");
            expected.Add("Knockback", "{D}% Chance to Knockback on Hit");
            expected.Add("Slow", "{D}% Chance to Slow on Hit");
            expected.Add("Stun", "{D}% Chance to Stun on Hit");
            expected.Add("ReCC", "Reduces duration of control impairing effects by {I}%");
            expected.Add("RDElite", "Reduces damage from elites by {I}%.");
            expected.Add("RDMelee", "Reduces damage from melee attacks by {I}%.");
            expected.Add("RDRanged", "Reduces damage from ranged attacks by {I}%.");
            expected.Add("IDElite", "Increase Damage Against Elites by {I}%.");
            expected.Add("Armor", "+{I} Armor");
            expected.Add("Block", "+{I}% Chance to Block");
            expected.Add("Ind", "Ignores Durability Loss");
            expected.Add("Thorn", "Melee attackers take {I} damage per hit");
            expected.Add("Bleed", "{D}% chance to inflict Bleed for {I}-{I} damage over 5 seconds.");
            expected.Add("Soc", "Empty Socket");
            expected.Add("B-HoA", "Reduces resource cost of Hammer of the Ancients by {i} Fury.");
            expected.Add("B-OP", "Increases Critical Chance of Overpower by {i}%");
            expected.Add("B-SS", "Increases Critical Chance of Seismic Slam by {i}%");
            expected.Add("B-WW", "Increases Critical Chance of Whirlwind by {i}%");
            expected.Add("D-BS", "Increases Bola Shot Damage by {i}%");
            expected.Add("D-EA", "Increases Elemental Arrow Damage by {i}%");
            expected.Add("D-ES", "Increases Entangling Shot Damage by {i}%");
            expected.Add("D-HA", "Increases Hungering Arrow Damage by {i}%");
            expected.Add("D-MS", "Increases Critical Chance of Multishot by {i}%");
            expected.Add("D-RF", "Increases Critical Chance of Rapid Fire by {i}%");
            expected.Add("M-LTK", "Reduces resource cost of Lashing Tail Kick by {i} Spirit.");
            expected.Add("M-TR", "Increases Critical Chance of Tempest Rush by {i}%");
            expected.Add("M-WoL", "Increases Critical Chance of Wave of Light by {i}%");
            expected.Add("W-FBomb", "Reduces resource cost of Firebomb by {i} Mana.");
            expected.Add("W-Haunt", "Increases Haunt Damage by {i}%");
            expected.Add("W-PoT", "Increases Plague of Toads Damage by {i}%");
            expected.Add("W-PD", "Increases Poison Dart Damage by {i}%");
            expected.Add("W-SB", "Increases Spirit Barrage Damage by {i}%");
            expected.Add("W-WoZ", "Reduces cooldown of Wall of Zombies by {i} seconds.");
            expected.Add("W-ZC", "Reduces resource cost of Zombie Charger by {i} Mana.");
            expected.Add("Z-ET", "Increases Critical Chance of Energy Twister by {i}%");
            expected.Add("Z-MM", "Increases Magic Missile Damage by {i}%");
            expected.Add("Z-AO", "Increases Critical Chance of Arcane Orb by {i}%");
            expected.Add("Z-Blizz", "Increases duration of Blizzard by {i} seconds");
            expected.Add("Z-Meteor", "Reduces resource cost of Meteor by {i} Arcane Power.");
            expected.Add("Z-SP", "Increases Shock Pulse Damage by {i}%");
            expected.Add("Z-SB", "Increases Spectral Blade Damage by {i}%");
            expected.Add("B-Bash", "Increases Bash Damage by {i}%");
            expected.Add("B-Cleave", "Increases Cleave Damage by {i}%");
            expected.Add("B-Frenzy", "Increases Frenzy Damage by {i}%");
            expected.Add("B-Rend", "Reduces resource cost of Rend by {i} Fury.");
            expected.Add("B-Revenge", "Increases Critical Chance of Revenge by {i}%");
            expected.Add("B-WThrow", "Reduces resource cost of Weapon Throw by {i} Fury.");
            expected.Add("D-Chakram", "Reduces resource cost of Chakram by {i} Hatred.");
            expected.Add("D-EFire", "Increases Evasive Fire Damage by {i}%");
            expected.Add("D-Grenades", "Increases Grenades Damage by {i}%");
            expected.Add("D-Impale", "Reduces resource cost of Impale by {i} Hatred.");
            expected.Add("D-STrap", "Increases Spike Trap Damage by {i}%");
            expected.Add("M-CWave", "Increases Crippling Wave Damage by {i}%");
            expected.Add("M-CStrke", "Reduces resource cost of Cyclone Strike by {i} Spirit.");
            expected.Add("M-DReach", "Increases Deadly Reach Damage by {i}%");
            expected.Add("M-EPalm", "Increases Exploding Palm Damage by {i}%");
            expected.Add("M-FoT", "Increases Fists of Thunder Damage by {i}%");
            expected.Add("M-SWind", "Increases Sweeping Wind Damage by {i}%");
            expected.Add("M-WotHF", "Increases Way of the Hundred Fists Damage by {i}%");
            expected.Add("W-ACloud", "Increases Critical Chance of Acid Cloud by {i}%");
            expected.Add("W-FBats", "Reduces resource cost of Fire Bats by {i} Mana.");
            expected.Add("W-LSwarm", "Increases Locust Swarm Damage by {i}%");
            expected.Add("W-ZDogs", "Reduces cooldown of Summon Zombie Dogs by {i} seconds.");
            expected.Add("Z-ATorrent", "Reduces resource cost of Arcane Torrent by {i} Arcane Power.");
            expected.Add("Z-DisInt", "Reduces resource cost of Disintegrate by {i} Arcane Power.");
            expected.Add("Z-Elec", "Increases Electrocute Damage by {i}%");
            expected.Add("Z-EB", "Increases Critical Chance of Explosive Blast by {i}%");
            expected.Add("Z-Hydra", "Reduces resource cost of Hydra by {i} Arcane Power.");
            expected.Add("Z-RoF", "Increases Critical Chance of Ray of Frost by {i}%");
            Assert.AreEqual(expected, actual);
        }
    }
}

