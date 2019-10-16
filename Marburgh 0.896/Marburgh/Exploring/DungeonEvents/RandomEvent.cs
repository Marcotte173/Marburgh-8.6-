﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


public class RandomEvent
{
    public static string RescueName = "";
    public static bool desecrated;
    public static void Event1(Dungeon d, Creature p, Event e)
    {
        Console.Clear();
        Console.WriteLine("You see several townsfolk huddling for warmth, obviously scared.\nOne comes up to you to speak\n\n" + Colour.SPEAK + "'Thank god you're here! We'd given up all hope!" +
                "\nUntie us and we will reward you handomely when we get back!'\n\n" + Colour.RESET + "You untie them and point the way out.\n" +
                "Be sure to meet them in the tavern afterwards to claim your reward.\n\nThat is.... if you live");
        Event.TFRescued = true;
        RescueName = Family.FamilyFirstNames[0];
        Explore.currentShell.encountered = true;
        Utilities.Keypress();
        Explore.GameDungeon(d, p);
    }

    public static void Event2(Dungeon d, Creature p, Event e)
    {
        Console.Clear();
        bool key = false;
        for (int i = 0; i < p.Drops.Count; i++)
        {
            if (p.Drops[i].name == "Chest Key" && p.Drops[i].amount > 0) key = true;
        }
        Console.WriteLine("A large chest of goods with a sturdy lock sits here. " +
                "\n\nThe goblins haven't managed to bypass the lock yet, but an old goblin dagger sticks out of the top of the chest" +
                "\nwhere they attempted to create a new opening.\n");
        Utilities.EmbedColourText(Colour.DAMAGE,"You could ", "bash"," the lock, but risk destroying the contents");
        Utilities.EmbedColourText(Colour.ABILITY,"You could"," pick"," the lock, but in the time it takes, more monsters may find you");
        Utilities.EmbedColourText(Colour.NAME,"If only you had a"," key","!\n\n");
        Utilities.EmbedColourText(Colour.DAMAGE, Colour.ABILITY, Colour.NAME, "","[B]","ash the lock        ","[P]","ick the lock             ","[K]","ey            [R]eturn");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "b")
        {
            Console.Clear();
            Utilities.ColourText(Colour.DAMAGE, "BLAM!");
            Utilities.DotDotDot();
            Console.WriteLine("\n\n\n\n\n\n\n");
            int bashRoll = Utilities.rand.Next(1, 101);
            if (bashRoll <= e.success + e.effect)
            {
                Console.WriteLine("Success!\n\n");
                Thread.Sleep(300);
                Reward.TreasureLootTable(d.tier,p);
                Utilities.Keypress();
            }
            else
            {
                Console.WriteLine("Failure!");
                Thread.Sleep(300);
                Console.WriteLine("It looks like the valuables inside were fragile indeed. Oh well, maybe next time");
                Utilities.Keypress();
            }
        }
        else if (choice == "p")
        {
            Console.Clear();
            Utilities.ColourText(Colour.ABILITY, "CHICK CHICK!");
            Utilities.DotDotDot();
            Console.WriteLine("\n\n\n\n\n\n\n");
            int pickRoll = Utilities.rand.Next(1, 101);
            if (pickRoll <= e.success)
            {
                Console.WriteLine("Success!\n\n");
                Thread.Sleep(300);
                Reward.TreasureLootTable(d.tier,p);
                Utilities.Keypress();
            }
            else if (pickRoll > e.success && pickRoll <= e.success + e.effect)
            {
                Console.WriteLine("You got in!\n\n");
                Thread.Sleep(300);
                Reward.TreasureLootTable(d.tier,p);
                Utilities.Keypress();
                Console.WriteLine("\nThat took a while though, it looks like someone found you!");
                p.force = true;
                Utilities.Keypress();
                Console.Clear();
                Monster.Summon(Room.StarterRandomRoomList[2], d, p);
            }
            else
            {
                Console.WriteLine("Failure!");
                Thread.Sleep(300);
                Console.WriteLine("Not only could you not get in, you took so long that someone found you!");
                p.force = true;
                Utilities.Keypress();
                Console.Clear();
                Monster.Summon(Room.StarterRandomRoomList[2], d, p);
            }
        }
        else if (choice == "k" && key == true)
        {
            Console.Clear();
            Utilities.ColourText(Colour.NAME, "CLICK!");
            Utilities.DotDotDot();
            Console.WriteLine("\n\n\n\n\n\n\n");
            Console.WriteLine("Success!\n\n");
            Thread.Sleep(300);
            Console.WriteLine("Inside you find a bunch of treasure, to be described later!");
            Utilities.Keypress();
        }
        else if (choice == "k" && key == false)
        {
            Utilities.EmbedColourText(Colour.NAME, "\n\nYou don't have a ", "key", "!");
            Utilities.Keypress();
            Event1(d, p, e);
        }
        else if (choice == "r")
        {
            Explore.currentShell.encountered = true;
            Explore.GameDungeon(d, p);
        }
        else if (choice == "x")
        {
            p.Drops.Add(new Drop("Chest Key", 1, 100, 1));
            Event1(d, p, e);
        }
        else Event1(d, p, e);
        Explore.currentShell.encountered = true;
        Explore.GameDungeon(d, p);
    }    

    public static void Event3(Dungeon d, Creature p, Event e)
    {
        Console.Clear();
        Console.WriteLine("You approach the altar and find a rune, placed with great care and reverance. " +
                "\n\nYou recognize it as belonging to one of the Orc gods, who they belive bring them strength and victory." +
                "\nThey would be angry indeed if anything were to happen to it.\n");
        Utilities.EmbedColourText(Colour.ENERGY, "You could ", "study ", "the runes, trying to learn the secrets of the Orc gods");
        Utilities.EmbedColourText(Colour.DAMAGE, "You could ", "desecrate ", "the runes, angering the orcs but possibly interrupting their power source");
        Utilities.EmbedColourText(Colour.MITIGATION, "You could ", "walk away, ", "moving on to the next room\n\n");
        Utilities.EmbedColourText(Colour.ENERGY, Colour.DAMAGE, Colour.MITIGATION, "", "[S]", "tudy        ", "[D]", "esecrate             ", "[W]", "alk away\n\n");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "s")
        {
            Console.Clear();
            Utilities.ColourText(Colour.ENERGY, "Studying");
            Utilities.DotDotDot();
            Console.WriteLine("\n\n\n\n\n\n\n");
            int roll = Utilities.rand.Next(1, 101);
            if (roll <= 75)
            {
                if (p.health < p.maxHealth)
                {
                    Utilities.ColourText(Colour.ENERGY, "Success! ");
                    Utilities.EmbedColourText(Colour.HEALTH, "Your ", "health ", "returns to maximum!");
                    p.health = p.maxHealth;
                }
                else Console.WriteLine("Sadly, you glean very little from the runes");
            }
            else
            {
                Utilities.ColourText(Colour.DAMAGE, "This was not for you to know! It's too much for your mind or body!");
                p.health = 1;
                Utilities.EmbedColourText(Colour.HEALTH, Colour.DAMAGE, "Your ", "health ", "is reduced to ", "1", "!");
            }
            Utilities.Keypress();
            Explore.currentShell.encountered = true;
            Explore.GameDungeon(d, p);
        }
        if (choice == "d")
        {
            Console.Clear();
            Utilities.ColourText(Colour.DAMAGE, "Desecrating");
            Utilities.DotDotDot();
            Console.WriteLine("\n\n\n\n\n\n\n");
            int roll = Utilities.rand.Next(1, 101);
            if (roll <= 25)
            {
                Utilities.ColourText(Colour.HEALTH, "Success! ");
                desecrated = true;
                Utilities.EmbedColourText(Colour.HEALTH, "You hear screams from further in the dungeon!\nNext fight, every monster starts with", " HALF ", "health!");
            }
            else
            {
                Utilities.ColourText(Colour.DAMAGE, "You have made the gods angry!");
                Utilities.EmbedColourText(Colour.HEALTH, Colour.DAMAGE, "Your ", "health ", "is reduced to ", "1", "!");
            }
            Utilities.Keypress();
            Explore.currentShell.encountered = true;
            Explore.GameDungeon(d, p);
        }
        if (choice == "w")
        {
            Explore.currentShell.encountered = true;
            Explore.GameDungeon(d, p);
        }
        else Event3(d, p, e);
    }

    public static void Event4(Dungeon d, Creature p, Event e)
    {
        List<Monster> mon = new List<Monster> { new Monster("Elite Orc", pClass.MonsterClassList[3], 8, 65, 5, 0, 80,5,5, Drop.BossDrop[0], 70, 100, 100) };
        Console.Clear();
        Console.WriteLine("One of the savage orc's personal guards have found you!/nYou have no choice but to fight him");
        Combat.Start(p, mon, d);
        Explore.currentShell.encountered = true;
    }

    public static void Event5(Dungeon d, Creature p, Event e)
    {
        List<Monster> mon = new List<Monster> { new Monster("Pack Master", pClass.MonsterClassList[4], 8, 65, 5, 0, 80, 5, 5, Drop.BossDrop[0], 70, 100, 100) };
        Console.Clear();
        Console.WriteLine("");
        Combat.Start(p, mon, d);
        Explore.currentShell.encountered = true;
    }
    public static void Event6(Dungeon d, Creature p, Event e)
    {
        
    }
    public static void Event7(Dungeon d, Creature p, Event e)
    {
        
    }
    public static void Event8(Dungeon d, Creature p, Event e)
    {
        
    }
    public static void Event9(Dungeon d, Creature p, Event e)
    {

    }
    public static void Event10(Dungeon d, Creature p, Event e)
    {

    }
    public static void Event11(Dungeon d, Creature p, Event e)
    {

    }
    public static void Event12(Dungeon d, Creature p, Event e)
    {

    }
}