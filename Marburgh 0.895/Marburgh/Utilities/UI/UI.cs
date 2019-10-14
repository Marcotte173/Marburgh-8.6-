using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI
{
    public static void General(string[] descriptions, string[] options1, string[] options2, string[] optionButton1, string[] optionButton2)
    {
        Console.Clear();
        for (int i = 0; i < descriptions.Length; i++)
        {
            Console.SetCursorPosition(60 - (descriptions[i].Length/2), 5+i);
            Console.WriteLine(descriptions[i]);
        }
        Console.SetCursorPosition(0, 16);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");        
        {
            Console.WriteLine("|                                                         |                                                            |");
            Console.WriteLine("|                                                         |                                                            |");
            Console.WriteLine("|                                                         |                                                            |");
            Console.WriteLine("|                                                         |                                                            |");
            Console.WriteLine("|                                                         |                                                            |");
            Console.WriteLine("|                                                         |                                                            |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                      |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Utilities.CenterText("What would you like to do?");            
            for (int i = 0; i < options1.Length; i++)
            {
                Console.SetCursorPosition(1, 19 + i);
                Console.WriteLine($"[{optionButton1[i]}]{options1[i]}");
            }
            for (int i = 0; i < options2.Length; i++)
            {
                Console.SetCursorPosition(59, 19 + i);
                Console.WriteLine($"[{optionButton2[i]}]{options2[i]}");
            }
        }        
        Console.SetCursorPosition(1, 17);
        Console.WriteLine(Colour.NAME + $"\t{Create.p.family.FirstName} {Create.p.family.LastName}\t\t" + Colour.RESET + "Level:" + Colour.XP + $"{Create.p.level}\t\t" + Colour.RESET + "Gold:" + Colour.GOLD + $"{Create.p.gold}\t\t" + Colour.RESET + "[C]haracter\t\t" + "[R]eturn");
        Console.SetCursorPosition(35, 26);
        Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, "It is day ", $"{Time.day}", ", the ", $"{Time.weeks[Time.week]}", " week of ", $"{Time.months[Time.month]}", ", ", $"{Time.year}", "\n\n");
        Console.ReadKey(true);
    }

    public static void Town(string[] descriptions, string[] adventure, string[] shop, string[] service, string[] other, string[] adventureButton, string[] shopButton, string[] serviceButton, string[] otherButton)
    {
        Console.Clear();
        for (int i = 0; i < descriptions.Length; i++)
        {
            Console.SetCursorPosition(60 - (descriptions[i].Length / 2), (8 - descriptions.Length/2) + i);
            Console.WriteLine(descriptions[i]);
        }
        Console.SetCursorPosition(0, 16);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        {
            Console.WriteLine("|                             |                             |                             |                            |");
            Console.WriteLine("|_____________________________|_____________________________|_____________________________|____________________________|");
            Console.WriteLine("|                             |                             |                             |                            |");
            Console.WriteLine("|                             |                             |                             |                            |");
            Console.WriteLine("|                             |                             |                             |                            |");
            Console.WriteLine("|                             |                             |                             |                            |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("|                                                                                                                      |");
            Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
            Utilities.CenterText("What would you like to do?");
            for (int i = 0; i < adventure.Length; i++)
            {
                Console.SetCursorPosition(1, 21 + i);
                Console.WriteLine($"[{adventureButton[i]}]{adventure[i]}");
            }
            for (int i = 0; i < shop.Length; i++)
            {
                Console.SetCursorPosition(31, 21 + i);
                Console.WriteLine($"[{shopButton[i]}]{shop[i]}");
            }
            for (int i = 0; i < service.Length; i++)
            {
                Console.SetCursorPosition(61, 21 + i);
                Console.WriteLine($"[{serviceButton[i]}]{service[i]}");
            }
            for (int i = 0; i < other.Length; i++)
            {
                if (other[i] == "") Console.WriteLine("");
                else
                {
                    Console.SetCursorPosition(91, 21 + i);
                    Console.WriteLine($"[{otherButton[i]}]{other[i]}");
                }                
            }
        }
        Console.SetCursorPosition(9, 19);
        Utilities.ColourText(Colour.MONSTER,"Adventure");
        Console.SetCursorPosition(40, 19);
        Utilities.ColourText(Colour.ITEM, "Shops");
        Console.SetCursorPosition(70, 19);
        Utilities.ColourText(Colour.TIME, "Services");
        Console.SetCursorPosition(100, 19);
        Utilities.ColourText(Colour.XP, "Other");
        Console.SetCursorPosition(1, 17);
        Console.WriteLine(Colour.NAME + $"\t{Create.p.family.FirstName} {Create.p.family.LastName}\t\t" + Colour.RESET + "Level:" + Colour.XP + $"{Create.p.level}\t\t" + Colour.RESET + "Gold:" + Colour.GOLD + $"{Create.p.gold}\t\t" + Colour.RESET + "[C]haracter\t\t" + "[R]eturn");
        Console.SetCursorPosition(35, 26);
        Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, "It is day ", $"{Time.day}", ", the ", $"{Time.weeks[Time.week]}", " week of ", $"{Time.months[Time.month]}", ", ", $"{Time.year}", "\n\n");
        Console.ReadKey(true);
    }
}






        //else
        //{
        //    Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
        //    Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
        //    Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
        //    Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
        //    Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
        //    Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
        //    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        //    Console.WriteLine("|                                                                                                                      |");
        //    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        //    Utilities.CenterText("What would you like to do?");
        //    for (int i = 0; i<options1.Length; i++)
        //    {
        //        Console.SetCursorPosition(27, 19 + i);
        //        Console.WriteLine($"[{i + 1}] {options1[i]}");
        //    }
        //}