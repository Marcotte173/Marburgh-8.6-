using System;
using System.Threading;
using System.Collections.Generic;

namespace Marburgh
{
    class Program
    {
        public static bool bank;
        public static int bankGold = 0;
        public static bool tutorial;
        public static List<string> adventureButton = new List<string> { "D" };
        public static List<string> adventureList = new List<string> { "ungeon" };
        public static List<string> shopButton = new List<string> { "I" };
        public static List<string> shopList = new List<string> { "tem Shop" };
        public static List<string> serviceButton = new List<string> { "T", "L" };
        public static List<string> serviceList = new List<string> { "avern", "evel Master" };
        public static List<string> otherButton = new List<string> { "Y", "O", "", "?" };
        public static List<string> otherList = new List<string> { "our House", "ther Places", "", "Help" };
    public static Dungeon d = new Dungeon("", 1, "", 0, 0, Room.StarterGenericRoomList, Room.StarterGenericRoomList, Room.StarterGenericRoomList, Boss.BossList[0], false,  1, false, Shell.StarterDungeonShell,0);
        //STARTS GAME
        static void Main(string[] args)
        {
            Welcome();
        }

        //GAME FUNCTIONS    
        public static void Welcome()
        {
            Colour.SetupConsole();
            Console.Clear();
            Utilities.ColourText(Colour.TIME,"/'\\_/`\\             ( )                       ( )    \n");
            Utilities.ColourText(Colour.XP,"|     |   _ _  _ __ | |_    _   _  _ __   __  | |__  \n");
            Utilities.ColourText(Colour.BOSS,"| (_) | /'_` )( '__)| '_`\\ ( ) ( )( '__)/'_ `\\|  _ `\\ \n");
            Utilities.ColourText(Colour.DROP,"| | | |( (_| || |   | |_) )| (_) || |  ( (_) || | | |\n");
            Utilities.ColourText(Colour.RAREDROP,"(_) (_)`\\__,_)(_)   (_,__/'`\\___/'(_)  `\\__  |(_) (_)\n");
            Utilities.ColourText(Colour.NAME,"                                       ( )_) |       \n");
            Utilities.ColourText(Colour.GOLD,"                                        \\___/'       \n");
            Utilities.ColourText(Colour.CLASS,"");
            Utilities.EmbedColourText(Colour.HEALTH,"\n\n","[N]","ew Game       ");
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "n")
            {
                for (int i = 0; i < 7; i++)
                {
                    Shop.armorOptionList1.Add($"{Shop.ArmorList[i].name}    " +Colour.GOLD + $"{Shop.ArmorList[i].price}");
                    Shop.weaponOptionList1.Add($"{Shop.WeaponList[i].name}    " + Colour.GOLD + $"{Shop.WeaponList[i].price}");
                    if (i < 4)
                    {
                        Shop.itemShopTutorialWeaponOptionList.Add($"{Shop.WeaponList[i].name}    " + Colour.GOLD + $"{Shop.WeaponList[i].price}");
                        Shop.itemShopTutorialArmorOptionList.Add($"{Shop.ArmorList[i].name}    " + Colour.GOLD + $"{Shop.ArmorList[i].price}");
                    }
                        
                }
                for (int i = 7; i < 13; i++)
                {
                    Shop.armorOptionList2.Add($"{Shop.ArmorList[i].name}    " + Colour.GOLD + $"{Shop.ArmorList[i].price}");
                    Shop.weaponOptionList2.Add($"{Shop.WeaponList[i].name}    " + Colour.GOLD + $"{Shop.WeaponList[i].price}");
                }
                Dungeon.CreateDungeon(Dungeon.DungeonInfo);
                d = Dungeon.AvailableDungeon[0];
                Create.Character();
            }
            else Welcome();
        }

        public static void Story()
        {
            Console.Clear();
            Utilities.EmbedColourText(Colour.CLASS,"You come from a long line of ","adventurers","\n");
            Thread.Sleep(600);
            Utilities.EmbedColourText(Colour.NAME, Colour.CLASS, Colour.MONSTER, "Your ","mother",", an ","adventurer ","herself was murdered by ","Orcs",", as they ransacked your town\n");
            Thread.Sleep(600);
            Console.WriteLine("Many villagers died, and even more were captured. Until they are free, your town is but a shadow of its old self\n");
            Thread.Sleep(600);
            Utilities.EmbedColourText(Colour.BOSS, "Worse yet, the ","Savage Orc ","that leads them is getting stronger and building an army\n");
            Thread.Sleep(600);
            Utilities.EmbedColourText(Colour.TIME, "In ","five days",", your town will be overrun\n");
            Thread.Sleep(600);
            Console.WriteLine("Are you a bad enough dude to save them?");
            Utilities.Keypress();
        }

        public static void GameTown()
        {
            for (int i = 0; i < Time.Events.Count; i++) {if (Time.Events[i].name == "Bank Construction" && Time.Events[i].trigger && Time.Events[i].active) bank = true;}
            Console.Clear();
            UI.Town(new string[] { "You are in the town of Marburgh", "It is a small town, but is clearly growing", "Who knows what will be here in a month?" }, adventureList, shopList,  serviceList, otherList, adventureButton, shopButton, serviceButton, otherButton);
            string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (choice == "w" && tutorial) Shop.GameShop(Shop.WeaponShop, Create.p);
            else if (choice == "a" && tutorial) Shop.GameShop(Shop.ArmorShop, Create.p);
            else if (choice == "d") Explore.DungeonCheck(d, Create.p);
            else if (choice == "i") Shop.ItemShop(Create.p);
            else if (choice == "?") Help.General();
            else if (choice == "c") Utilities.CharacterSheet(Create.p);
            else if (choice == "l") LevelMaster.VisitLevelMaster(Create.p);
            else if (choice == "t") Tavern.Inn(Create.p);
            else if (choice == "y") House.YourHouse(Create.p);
            else if (choice == "b" && tutorial && bank) Bank.GameBank(Create.p);
            else if (choice == "q") Utilities.Quit();
            else if (choice == "x")
            {
                Create.p.xp += 30;
                Create.p.gold += 500;
                tutorial = true;
                Shop.itemShopOptionButton1.Add(Colour.ENHANCEMENT + "E" + Colour.RESET);
                Shop.itemShopOptionList1.Add("nhancement Machine");
            }
            else if (choice == "o") OtherPlaces.Other(Create.p);
            GameTown();
        }        
    }
}