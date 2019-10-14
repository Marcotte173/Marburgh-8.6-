using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class OtherPlaces
{
    public static void Other(Creature p)
    {
        Console.Clear();
        Utilities.ColourText(Colour.SPEAK, "Welcome to the still expanding portion of this game.\nAs Marburgh grows, both inside and out, this is where you will find new places to visit and thing to do.\n");
        Utilities.ColourText(Colour.SPEAK, "For now tho, you can visit your family graveyard\n\n");
        Console.WriteLine("[G]raveyard\n[R]eturn to town\n\nWhat you you like to do?");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "r") Marburgh.Program.GameTown();
        if (choice == "g") Graveyard(p);
        Other(p);
    }

    public static void Graveyard(Creature p)
    {
        Console.Clear();
        if (Family.DeadSiblings.Count == 0) Console.WriteLine("As you arrive at the family plot you see one grave, your mother's. \nIt is still fresh, the memories still vivid.");
        else if (Family.DeadSiblings.Count == 1) Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, $"As you arrive at the family plot you see two graves.\nThe newer one belongs to {Family.DeadSiblings[0]}, killed by {Family.killingMonster[0]} on day ", $"{Family.timeOfDeath[0,0]}", ", the ", $"{Family.timeOfDeath[0, 1]}", " week of ", $"{Family.timeOfDeath[0, 2]}", ", ", $"{Family.timeOfDeath[0, 3]}", ". \nNext to it is your Mother's grave.");
        else
        {
            Console.WriteLine("You arrive at the graveyard to visit the only family you've ever known.");
            Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, $"{Family.DeadSiblings[0]}, killed by {Family.killingMonster[0]} on day ", $"{Family.timeOfDeath[0, 0]}", ", the ", $"{Family.timeOfDeath[0, 1]}", " week of ", $"{Family.timeOfDeath[0, 2]}", ", ", $"{Family.timeOfDeath[0, 3]}", "." );
            Utilities.EmbedColourText(Colour.TIME, Colour.TIME, Colour.TIME, Colour.TIME, $"{Family.DeadSiblings[1]}, killed by {Family.killingMonster[1]} on day ", $"{Family.timeOfDeath[1, 0]}", ", the ", $"{Family.timeOfDeath[1, 1]}", " week of ", $"{Family.timeOfDeath[1, 2]}", ", ", $"{Family.timeOfDeath[1, 3]}", ".");
            Console.WriteLine("Your siblings lay next to your Mother.\nAt least they can be together.");
        }
        Utilities.Keypress();
    }
}
