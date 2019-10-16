using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class UI
{
    public static void Store(List<int> colourArray, List<string> descriptions, List<string> options1, List<string> options2)
    {
        Console.Clear();
        int colourArrayCheck = 0;
        for (int i = 0; i < descriptions.Count; i++)
        {
            Console.SetCursorPosition(0, (8 - colourArray.Count / 2) + i);
            if (colourArray[i] == 0) Utilities.CenterText(descriptions[colourArrayCheck]);
            else if (colourArray[i] == 1) Utilities.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3]);
            else if (colourArray[i] == 2) Utilities.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6]);
            colourArrayCheck += (colourArray[i] == 0)?1: colourArray[i] == 1?4: colourArray[i] == 2?7:10;
            if (colourArrayCheck >= descriptions.Count) break;
        } 
        Console.SetCursorPosition(0, 16);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        if (options2 != null)
        {
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
                int number = 0;
                for (int i = 1; i < options1.Count; i++)
                {
                    if (options1[i] == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(1, 18 + i);
                        Console.WriteLine($"[{i}]{Colour.ITEM + options1[i] + Colour.RESET}");
                        number++;
                    }                    
                }
                for (int i = 1; i < options2.Count; i++)
                {
                    if (options2[i] == "") Console.WriteLine("");
                    {
                        Console.SetCursorPosition(59, 18 + i);
                        Console.WriteLine($"[{number + i}]{Colour.ITEM + options2[i] + Colour.RESET}");
                    }                    
                }
            }
        }
        else
        {
            {
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|                                                                                                                      |");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Utilities.CenterText("What would you like to do?");
                for (int i = 0; i < options1.Count; i++)
                {
                    if (options1[i] == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(27, 19 + i);
                        Console.WriteLine($"[{i}]{Colour.ITEM + options1[i] + Colour.RESET}");
                    }                    
                }
            }
        }
        Console.SetCursorPosition(1, 17);
        Console.WriteLine(Colour.NAME + $"\t{Create.p.family.FirstName} {Create.p.family.LastName}\t\t" + Colour.RESET + "Level:" + Colour.XP + $"{Create.p.level}\t\t" + Colour.RESET + "Gold:" + Colour.GOLD + $"{Create.p.gold}\t\t" + Colour.RESET + "[C]haracter\t\t" + "[R]eturn");
        Console.SetCursorPosition(35, 26);
        Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, "It is day ", $"{Time.day}", ", the ", $"{Time.weeks[Time.week]}", " week of ", $"{Time.months[Time.month]}", ", ", $"{Time.year}", "\n\n");
    }

    public static void General(List<int> colourArray, List<string> descriptions, List<string> options1, List<string> options2, List<string> optionButton1, List<string> optionButton2)
    {
        Console.Clear();
        int colourArrayCheck = 0;
        for (int i = 0; i < descriptions.Count; i++)
        {
            Console.SetCursorPosition(0, (8 - colourArray.Count / 2) + i);
            if (colourArray[i] == 0) Utilities.CenterText(descriptions[colourArrayCheck]);
            else if (colourArray[i] == 1) Utilities.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3]);
            else if (colourArray[i] == 2) Utilities.CenterColourText(descriptions[colourArrayCheck], descriptions[colourArrayCheck + 1], descriptions[colourArrayCheck + 2], descriptions[colourArrayCheck + 3], descriptions[colourArrayCheck + 4], descriptions[colourArrayCheck + 5], descriptions[colourArrayCheck + 6]);
            colourArrayCheck += (colourArray[i] == 0) ? 1 : colourArray[i] == 1 ? 4 : colourArray[i] == 2 ? 7 : 10;
            if (colourArrayCheck >= descriptions.Count) break;
        }
        Console.SetCursorPosition(0, 16);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("|                                                                                                                      |");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        if (options2 != null)
        {
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
                for (int i = 0; i < options1.Count; i++)
                {
                    if (options1[i] == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(1, 19 + i);
                        Console.WriteLine($"[{optionButton1[i]}]{options1[i]}");
                    }
                }
                for (int i = 0; i < options2.Count; i++)
                {
                    if (options2[i] == "") Console.WriteLine("");
                    {
                        Console.SetCursorPosition(59, 19 + i);
                        Console.WriteLine($"[{optionButton2[i]}]{options2[i]}");

                    }
                }
            }
        }
        else
        {
            {
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("|xxxxxxxxxxxxxxxxxxxxxxxxx|                                                                  |xxxxxxxxxxxxxxxxxxxxxxxxx|");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("|                                                                                                                      |");
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
                Utilities.CenterText("What would you like to do?");
                for (int i = 0; i < options1.Count; i++)
                {
                    if (options1[i] == "") Console.WriteLine("");
                    else
                    {
                        Console.SetCursorPosition(27, 19 + i);
                        Console.WriteLine($"[{optionButton1[i]}]{options1[i]}");
                    }
                }
            }
        }
        Console.SetCursorPosition(1, 17);
        Console.WriteLine(Colour.NAME + $"\t{Create.p.family.FirstName} {Create.p.family.LastName}\t\t" + Colour.RESET + "Level:" + Colour.XP + $"{Create.p.level}\t\t" + Colour.RESET + "Gold:" + Colour.GOLD + $"{Create.p.gold}\t\t" + Colour.RESET + "[C]haracter\t\t" + "[R]eturn");
        Console.SetCursorPosition(35, 26);
        Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, "It is day ", $"{Time.day}", ", the ", $"{Time.weeks[Time.week]}", " week of ", $"{Time.months[Time.month]}", ", ", $"{Time.year}", "\n\n");
    }

    public static void Town(string[] descriptions, List<string> adventure, List<string> shop, List<string> service, List<string> other, List<string> adventureButton, List<string> shopButton, List<string> serviceButton, List<string> otherButton)
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
            for (int i = 0; i < adventure.Count; i++)
            {
                Console.SetCursorPosition(1, 21 + i);
                Console.WriteLine($"[{adventureButton[i]}]{adventure[i]}");
            }
            for (int i = 0; i < shop.Count; i++)
            {
                if (shop[i] == "") Console.WriteLine("");
                else
                {
                    Console.SetCursorPosition(31, 21 + i);
                    Console.WriteLine($"[{shopButton[i]}]{shop[i]}");
                }                
            }
            for (int i = 0; i < service.Count; i++)
            {
                Console.SetCursorPosition(61, 21 + i);
                Console.WriteLine($"[{serviceButton[i]}]{service[i]}");
            }
            for (int i = 0; i < other.Count; i++)
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
    }
}