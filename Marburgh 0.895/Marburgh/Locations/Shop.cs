using System;
using System.Collections.Generic;

public class Shop
{
    public string name;
    public string shopkeepName;
    public string shopkeepRace;
    public string shopkeepGreeting;
    public static List<string> itemShopOptionButton1 = new List<string> {Colour.HEALTH + "P" + Colour.RESET, "" };
    public static List<string> itemShopOptionList1 = new List<string> {"otions", "" };
    public static List<string> itemShopOptionButton2 = new List<string> {Colour.ITEM  + "B" + Colour.RESET,Colour.ITEM + "S" + Colour.RESET };
    public static List<string> itemShopOptionList2 = new List<string> {"uy","ell" };
    public Equipment[] ItemList;
    public static Equipment[] WeaponList = new Equipment[] 
    {
        new Equipment("None", 0, 0,0,0,0,0,0,0,"","",true),              new Equipment("Dagger", 1, 50,0,0,0,0,0,0,"","",true),            new Equipment("Battered Sword", 3, 150,0,0,0,0,0,0,"","",true),  new Equipment("Short Sword", 5, 300,0,0,0,0,0,0,"","",true),
        new Equipment("Arming Sword", 8, 800,0,0,0,0,0,0,"","",true),    new Equipment("Roman Sword", 10, 1000,0,0,0,0,0,0,"","",true),    new Equipment("Long Sword", 12, 1200,0,0,0,0,0,0,"","",true),    new Equipment("Steel Sword", 14, 1600,0,0,0,0,0,0,"","",true),
        new Equipment("Broad Sword", 16, 2000,0,0,0,0,0,0,"","",true),   new Equipment("Great Sword", 20, 2500,0,0,0,0,0,0,"","",true),    new Equipment("Blue Sword", 22, 3000,0,0,0,0,0,0,"","",true),    new Equipment("Black Sword", 25, 3500,0,0,0,0,0,0,"","",true),
        new Equipment("Red Sword", 30, 4500,0,0,0,0,0,0,"","",true),     new Equipment("Purple Sword", 35, 5500,0,0,0,0,0,0,"","",true),   new Equipment("White Sword", 40, 6500,0,0,0,0,0,0,"","",true),   new Equipment("Crystal Sword", 50, 7500,0,0,0,0,0,0,"","",true)
    };
    public static Equipment[] ArmorList = new Equipment[] 
    {
        new Equipment("None", 0, 0,0,0,0,0,0,0,"","",false),              new Equipment("Cloth Armor", 1, 50,0,0,0,0,0,0,"","",false),      new Equipment("Battered Armor", 3, 150,0,0,0,0,0,0,"","",false), new Equipment("Soldier's Armor", 5, 300,0,0,0,0,0,0,"","",false),
        new Equipment("Leather Armor", 8, 1000,0,0,0,0,0,0,"","",false),  new Equipment("Roman Armor", 10, 3000,0,0,0,0,0,0,"","",false),   new Equipment("Chain mail", 12, 1500,0,0,0,0,0,0,"","",false),   new Equipment("Heavy mail", 14, 3000,0,0,0,0,0,0,"","",false),
        new Equipment("Coat of plates", 16, 2000,0,0,0,0,0,0,"","",false),new Equipment("Plate mail", 20, 2500,0,0,0,0,0,0,"","",false),    new Equipment("Blue mail", 22, 3000,0,0,0,0,0,0,"","",false),    new Equipment("Black mail", 25, 3500,0,0,0,0,0,0,"","",false),
        new Equipment("Red mail", 32, 4500,0,0,0,0,0,0,"","",false),      new Equipment("Purple Mail", 40, 5500,0,0,0,0,0,0,"","",false),   new Equipment("White Armor", 56, 6500,0,0,0,0,0,0,"","",false),  new Equipment("Crystal Armor", 70, 7500,0,0,0,0,0,0,"","",false)
    };

    public static Equipment[] TutorialEquipList = new Equipment[]
    {
        new Equipment("None", 0, 0,0,0,0,0,0,0,"","",true),new Equipment("Dagger", 1, 50,0,0,0,0,0,0,"","",true), new Equipment("Cloth Armor", 1, 50,0,0,0,0,0,0,"","",false), new Equipment("Battered Sword", 3, 150,0,0,0,0,0,0,"","",true), new Equipment("Battered Armor", 3, 150,0,0,0,0,0,0,"","",false)
    };

    public static Shop WeaponShop = new Shop("Billford's weapon emporium.", "Billford", "troll", "Greetings, What can I do for you", WeaponList);
    public static Shop ArmorShop = new Shop("Alya's armor shop.", "Alya", "elf", "Hey there! Looking to buy some armor?", ArmorList);
    public static Shop Tutorial = new Shop(null, "Elya", null, null, TutorialEquipList);

    public Shop(string name,string shopkeepName, string shopkeepRace, string shopkeepGreeting, Equipment[] ItemList)
    {
        this.name = name;
        this.shopkeepName = shopkeepName;
        this.shopkeepRace = shopkeepRace;
        this.shopkeepGreeting = shopkeepGreeting;
        this.ItemList = ItemList;
    }

    public static void GameShop(Shop shop,Creature p)
    {
        Console.Clear();
        Console.WriteLine($"You walk into {shop.name}");
        Utilities.EmbedColourText(Colour.NAME, Colour.CLASS, $"", $"{shop.shopkeepName} ", "the ", $"{shop.shopkeepRace}", " comes over to greet you");
        Utilities.ColourText(Colour.SPEAK, $"'{shop.shopkeepGreeting}'\n\n");
        Console.WriteLine("[B]uy        [S]ell");
        Console.WriteLine($"[C]haracter  [R]eturn\n\n");
        Utilities.EmbedColourText(Colour.GOLD, "You have ", $"{p.gold}", " gold\n\n");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "b") ShopBuy(shop, p);
        else if (choice == "s") ShopSell(shop, p);        
        else if (choice == "c") Utilities.CharacterSheet(p);
        else if (choice == "r") Marburgh.Program.GameTown();
        GameShop(shop, p);
    }

    private static void ShopSell(Shop shop, Creature p)
    {
        {
            if (p.Weapon.name == "None" && p.Armor.name == "None") Console.WriteLine("You have nothing to Sell!");
            else
            {
                Console.Clear();
                Console.WriteLine($"\n\nWhat would you like to Sell?\n\n");
                List<Equipment> EquipmentList = new List<Equipment> { };
                if (p.Weapon.name != "None") EquipmentList.Add(p.Weapon);
                if (p.Armor.name != "None") EquipmentList.Add(p.Armor);
                for (int i = 0; i < EquipmentList.Count; i++)
                {
                    Utilities.ColourText(Colour.RESET, "");
                    Console.WriteLine(String.Format("{0,-4} {1,-6} {2,-15} {3,-20}{4,-23}{5,-24}", $"[{ i + 1}]", Colour.ITEM, $" {EquipmentList[i].name}", Colour.GOLD, $"{EquipmentList[i].price / 2}", Colour.RESET));
                }
                Console.WriteLine("\n[0] Return\n");
                Utilities.EmbedColourText(Colour.GOLD, "You have ", $"{p.gold}", " gold\n\n");
                int sellChoice;
                do
                {

                } while (!int.TryParse(Console.ReadKey(true).KeyChar.ToString().ToLower(), out sellChoice));
                if (sellChoice > 0 && sellChoice <= shop.ItemList.Length)
                {
                    Console.WriteLine($"\n\nWould you Like to sell your " + Colour.ITEM + $"{EquipmentList[sellChoice - 1].name}" + Colour.RESET + "? I'll give you " + Colour.GOLD + $"{EquipmentList[sellChoice - 1].price / 2} " + Colour.RESET + "for it\n\n[Y]es      [N]o\n\n");
                    string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
                    if (confirm == "y")
                    {
                        Console.Clear();
                        Console.WriteLine($"\n\n'Great!' " + Colour.NAME + $"{shop.shopkeepName} " + Colour.RESET +  "takes your " + Colour.ITEM +$"{EquipmentList[sellChoice - 1].name} " + Colour.RESET + "and gives you " + Colour.GOLD + $"{EquipmentList[sellChoice - 1].price / 2} " + Colour.RESET + "gold");
                        p.gold += EquipmentList[sellChoice - 1].price / 2;
                        if (p.Weapon == EquipmentList[sellChoice - 1]) Utilities.Equip(WeaponList[0]);
                        if (p.Armor == EquipmentList[sellChoice - 1]) Utilities.Equip(ArmorList[0]);
                    }
                }
            }
            Utilities.Keypress();
        }
    }

    private static void ShopBuy(Shop shop, Creature p)
    {
        {
            Console.Clear();
            Console.WriteLine("Great! What would you like to buy?\n");
            for (int i = 1; i < shop.ItemList.Length; i++)
            {
                Utilities.ColourText(Colour.RESET, "");
                Console.WriteLine(String.Format("{0,-4} {1,-6} {2,-15} {3,-20}{4,-23}{5,-24}", $"[{ i}]", Colour.ITEM, $" {shop.ItemList[i].name}", Colour.GOLD, $"{ shop.ItemList[i].price}", Colour.RESET));
            }
            Console.WriteLine("\n[0] Return\n");
            Utilities.EmbedColourText(Colour.GOLD, "You have ", $"{p.gold}", " gold\n\n");
            int buyChoice;
            do
            {

            } while (!int.TryParse(Console.ReadLine(), out buyChoice));
            if (buyChoice > 0 && buyChoice < shop.ItemList.Length)
            {
                if (p.gold < shop.ItemList[buyChoice].price) Console.WriteLine("\n\n'Sorry, you don't Have enough Gold'");
                else
                {
                    Console.WriteLine($"\n\nWould you like to buy the " + Colour.ITEM + $"{shop.ItemList[buyChoice].name}" + Colour.RESET + "?\n\n[Y]es      [N]o\n\n");
                    string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
                    if (confirm == "y")
                    {
                        if (p.Weapon.name != "None" && shop.ItemList[buyChoice].isWeapon) ShopBuySell(p.Weapon, shop.ItemList[buyChoice], p, shop);
                        else if (p.Armor.name != "None" && shop.ItemList[buyChoice].isWeapon == false) ShopBuySell(p.Armor, shop.ItemList[buyChoice], p, shop);
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Smiling, " + Colour.NAME + $"{shop.shopkeepName} " + Colour.RESET + "takes your money and gives you your " + Colour.ITEM + $"{shop.ItemList[buyChoice].name}" + Colour.RESET);
                            p.gold -= shop.ItemList[buyChoice].price;
                            Utilities.Equip(shop.ItemList[buyChoice]);
                        }
                    }
                }
            }
            Utilities.Keypress();
        }
    }

    public static void ShopBuySell(Equipment oldItem, Equipment newItem, Creature p, Shop shop)
    {
        Console.WriteLine($"I see you have a " + Colour.ITEM + $"{oldItem.name}" + Colour.RESET + ". Would you like to sell it?\n\n[Y]es      [N]o\n");
        string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (confirm == "y")
        {
            Console.Clear();
            Utilities.EmbedColourText(Colour.NAME,Colour.ITEM, Colour.GOLD,"",$"{ shop.shopkeepName} ","takes your ",$"{oldItem.name} ", "and gives you ",$"{oldItem.price / 2} ", "gold");
            p.gold += oldItem.price / 2;
            Utilities.EmbedColourText(Colour.NAME, Colour.ITEM, "Smiling, ", $"{shop.shopkeepName} ","takes your money and gives you your ",$"{newItem.name }","");
            p.gold -= newItem.price;
            Utilities.Equip(newItem); 
        }
    }

    public static void ItemShop(Creature p)
    {
        Console.Clear();
        if (Marburgh.Program.tutorial == false)
        {
            UI.General(new List<int> { 0, 2, 0, 1, 1, 1, 1}, new List<string>
            {
                "You enter a cluttered shop. There are bubbling potions everywhere.",
                Colour.NAME, Colour.CLASS, "", "Elya ", "the ", "elf ", "looks at you and smiles",
                "",
                Colour.SPEAK, "","'Well, hello there. Are you here to buy something?", "",
                Colour.SPEAK, "","There's not much in town, i'm afraid.","",
                Colour.SPEAK,"","We normally have a weapon shop and an armor shop but the owners have been kidnapped!","",
                Colour.SPEAK,"", "I pray they come home soon. Until then, I have a few pieces of equipment'",""
            }, 
            itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
        }
        else
        {
            UI.General(new List<int> { 0, 2, 1 }, new List<string>
            {
                "You enter a cluttered shop. There are bubbling potions everywhere.",
                Colour.NAME, Colour.CLASS, "", "Elya ", "the ", "elf ", "looks at you and smiles",
                Colour.SPEAK, "","'Well, hello there! Are you here to buy something? Check back frequently, I'm always getting new items!",""
            }, 
            itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
        }
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();        
        if (choice == "b" && Marburgh.Program.tutorial == false) ShopBuy(Tutorial, p);
        if (choice == "s" && Marburgh.Program.tutorial == false) ShopSell(Tutorial, p);
        if (choice == "r") Marburgh.Program.GameTown();
        if (choice == "c") Utilities.CharacterSheet(p);
        if (choice == "e" && Marburgh.Program.tutorial)
        {
            Console.Clear();

            UI.General(new List<int> { 0, 2, 1, 0, 0, 0 }, new List<string>
            {
                "A very rare thing indeed",
                Colour.ENHANCEMENT,Colour.ENHANCEMENT, "An", " enhancement machine", " can allow you to ","enhance ", "your gear",
                Colour.GOLD, "All yours for the reasonable price of ", "300 ", "gold",
                "Would you like to buy it?",
                "",
                "[Y]es     [N]o"
            }, 
            itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);

            string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
            if (confirm == "y")
            {
                if (p.gold >= 300)
                {
                    UI.General(new List<int> { 1, 2, 0, 0}, new List<string>
                    {
                        Colour.SPEAK,"","'Wonderful!'","",
                        Colour.ENHANCEMENT,Colour.ENHANCEMENT, "","Elya ", "takes your money and gives you the ", "crafting machine.", "",
                        "",
                        "Press any key to continue"
                    },
                    itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
                    Console.ReadKey(true);

                    p.gold -= 300;
                    p.craft = true;                    
                    ItemShop(p);
                }
            }

            UI.General(new List<int> { 1, 0, 0 }, new List<string>
            {
                Colour.SPEAK,"","'Come back when you're serious!'","",
                "",
                "Press any key to continue"
            },
            itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
            Console.ReadKey(true);
        }
        if (choice == "p")
        {
            int amount = p.maxPotions;
            int buymax = (amount - p.potions == 1 && p.gold / 100 >= 1) || (amount - p.potions == 2 && p.gold / 100 >= 1 && p.gold / 100 < 2) ? 1 : (amount - p.potions == 2 && p.gold / 100 >= 2) ? 2 : 0;
            int buyChoice;
            do
            {
                Console.Clear();
                UI.General(new List<int> { 0, 2, 0, 0 }, new List<string>
            {
                "How many would you like to buy?",
                Colour.GOLD, Colour.HEALTH, "They are ","100 ", "gold apiece and you have space for ", $"{buymax} ", "more potions",
                "",
                "[0] Return\n"
            },
            itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
            Console.SetCursorPosition(58, 14);

            } while (!int.TryParse(Console.ReadLine(), out buyChoice));

            if (buyChoice == 0) ItemShop(p);
            else if (buyChoice > buymax)
            {
                UI.General(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Colour.SPEAK,"","'You have too many potions!'","",
                    "",
                    "Press any key to continue"
                },
                itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
                Console.ReadKey(true);
            }
            else if (p.gold < buyChoice * 100)
            {
                UI.General(new List<int> { 1, 0, 0 }, new List<string>
                {
                    Colour.SPEAK,"","'I'm sorry, it doesn't look like you can afford that'","",
                    "",
                    "Press any key to continue"
                },
                itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
                Console.ReadKey(true);
            }
            else
            {
                UI.General(new List<int> { 1, 0, 2, 0, 0 }, new List<string>
                {
                    Colour.SPEAK,"","'A pleasure doing business with you!'","",
                    "",
                    Colour.GOLD,Colour.HEALTH,"You give the elf ", $"{buyChoice * 100}", " gold and receive ", $"{buyChoice}", " potions",
                    "",
                    "Press any key to continue"
                },
                itemShopOptionList1, itemShopOptionList2, itemShopOptionButton1, itemShopOptionButton2);
                Console.ReadKey(true);
                p.gold -= buyChoice * 100;
                p.potions += buyChoice;
            }
        }        
        ItemShop(p);
    }
}