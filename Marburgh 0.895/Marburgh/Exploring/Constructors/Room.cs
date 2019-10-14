﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Room
{
    //Variables, self explanatory
    public string name;
    public string[] flavor;
    public int modifier;
    public Event[] EventArray;
    public static List<Event> EventDisplay = new List<Event> { };
    public Monster[] bestiary;

    //Constructor
    public Room(string name, string[] flavor, int modifier, Event[] EventArray, Monster[] bestiary)
    {
        this.name = name;
        this.flavor = flavor;
        this.modifier = modifier;
        this.EventArray = EventArray;
        this.bestiary = bestiary;
    }

    public static Room[] StarterGenericRoomList = new Room[]
    {
            new Room("Entrance", new string[]{"You are at the entrance to the dungeon","You are at the entrance to the dungeon" },0,new Event[] {Event.SearchList[0] }, Monster.starterBestiary),
            new Room("Small room", new string[]{"You enter a small, squalid room","You have explored this room" }, 5, new Event[] { Event.SearchList[1] },Monster.starterBestiary),
            new Room("Small library",new string[]{"You enter a small squalid library", "You have explored this room"},5, new Event[]{ Event.SearchList[1], Event.SearchList[3]},Monster.starterBestiary),
            new Room("Small room", new string[]{"You enter a smallish, squalid room","You have explored this room"}, 5, new Event[]{ Event.SearchList[1], Event.SearchList[2]},Monster.starterBestiary),
    };

    public static Room[] StarterRandomRoomList = new Room[]
    {
            new Room("Plundered loot",new string[]{"A room with a treasure chest!","You see an old empty chest" },0,new Event[] { Event.RandomList[2] },null),
            new Room("Shamanistic rune",new string[]{"A room with a small altar","You see a broken altar" },0,new Event[] { Event.RandomList[3] },null),
            new Room("Elite Orc",new string[]{"An elite Orc!","You see an empty room with a dead ogre in it" },0,new Event[] { Event.RandomList[4] },Monster.starterBestiary)
    };

    public static Room[] StarterStaticRoomList = new Room[]
    {
            new Room("Boss Room", new string[]{$"A secret Lair!","A secret Lair!"},0,new Event[] { Event.RandomList[0] },null),
            new Room("Captive townsfolk",new string[]{"A makeshift prison cell","You see an old prison. Thank goodness the people escaped" },0,new Event[] { Event.RandomList[1] },null)
    };

    public static Room[] CastleGenericRoomList = new Room[]
    {
            new Room("Entrance", new string[]{"You are at the entrance to the castle","You are at the entrance to the castle" },0,new Event[] {Event.SearchList[0] },Monster.castleBestiary),
            new Room("Small Study",new string[]{"You enter a medium sized, regular room","You have explored this room"}, 10,new Event[]{ Event.SearchList[1] },Monster.castleBestiary),
            new Room("Medium Study", new string[]{"You enter a medium sized, regular room","You have explored this room"}, 10,new Event[]{ Event.SearchList[1], Event.SearchList[2], Event.SearchList[3]},Monster.castleBestiary),
            new Room("Small Parlor", new string[]{"You enter a medium sized, regular room","You have explored this room"}, 10,new Event[]{ Event.SearchList[1], Event.SearchList[2], Event.SearchList[3]},Monster.castleBestiary),
            new Room("Medium Parlor", new string[]{"You enter a medium sized, regular room","You have explored this room"}, 10,new Event[]{ Event.SearchList[1], Event.SearchList[2], Event.SearchList[3]},Monster.castleBestiary),
            new Room("Supply Room", new string[]{"You enter a medium sized, regular room","You have explored this room"}, 10,new Event[]{ Event.SearchList[1], Event.SearchList[2], Event.SearchList[3]},Monster.castleBestiary),
            new Room("Storage Study", new string[]{"You enter a medium sized, regular room","You have explored this room"}, 10,new Event[]{ Event.SearchList[1], Event.SearchList[2], Event.SearchList[3]},Monster.castleBestiary),
            new Room("Hallway", new string[]{"You enter a hallway","You have explored this hallway"}, 10,new Event[]{ Event.SearchList[1]},Monster.castleBestiary)
    };

    public static Room[] CastleRandomRoomList = new Room[]
    {
            new Room("Pack Master",new string[]{"The Pack Master!","You are in an room filled with broken furnishings.\nThe pack master lay dead, the spiderlings have already started to eat him" },0,new Event[] { Event.RandomList[5] },null),
            new Room("Plundered loot",new string[]{"A room with a treasure chest!","You see an old empty chest" },0,new Event[] { Event.RandomList[6] },null),
            new Room("Shamanistic rune",new string[]{"A room with a small altar"," You see a broken altar" },0,new Event[] { Event.RandomList[7] },null),
            new Room("Elite Orc",new string[]{"An elite Orc!","You see an empty room with a dead ogre in it" },0,new Event[] { Event.RandomList[8] },null),
            new Room("Elite Orc",new string[]{"An elite Orc!","You see an empty room with a dead ogre in it" },0,new Event[] { Event.RandomList[9] },null)
    };

    public static Room[] CastleStaticRoomList = new Room[]
    {
            new Room("Boss Room", new string[]{$"Master McGuffin's Quarters!","A secret Lair!"},0,new Event[] { Event.CastleStaticList[0] },null),
            new Room("Servant Mini Boss",new string[]{"The head Butler's private quarters!","You see Cecil's Quarters.\nThere is nothing of note remaining, save for cecil's corpse" },0,new Event[] { Event.CastleStaticList[1] },null),
            new Room("Kitchen Mini Boss",new string[]{"The kitchen!","You are looking at the kitchen. There was a great battle here.\nYou'd know, you were in it" },0,new Event[] { Event.CastleStaticList[2] },null),
            new Room("To Servants",new string[]{ "The hallway to servant's quarters", "The hallway to servant's quarters" },0,new Event[] { Event.CastleStaticList[3] },null),
            new Room("To Kitchen",new string[]{ "The hallway to the kitchen", "The hallway to the kitchen" },0,new Event[] { Event.CastleStaticList[4] },null),
            new Room("To Bedrooms",new string[]{ "The hallway to the bedrooms", "The hallway to the bedrooms" },0,new Event[] { Event.CastleStaticList[5] },null)
    };

    public static void RegularRoom(Dungeon d, Creature p, Shell currentShell)
    {
        //Check for monsters
        Monster.Summon(currentShell.assignedRoom, d, p);
        //Get a chance to explore
        RoomSearch(currentShell.assignedRoom, d, p);
        //If you chose not to explore it's back to main dungeon screen, this second chance at baddies is risk for searching      
        //You may have been heard
        Console.Clear();
        Console.Write("You hear shuffling in the distance, were you heard?");
        Utilities.DotDotDot();
        Monster.Summon(currentShell.assignedRoom, d, p);
        if (d.monsterSummon > 50) Console.WriteLine("Phew! You got luckey!");
        else Console.WriteLine("No one came to investigate.\nNot surprising, the dungeon seems pretty empty");
        Utilities.Keypress();
        Explore.currentShell.encountered = true;
        Explore.GameDungeon(d, p);

    }

    public static void RoomSearch(Room room, Dungeon d, Creature p)
    {
        Console.Clear();
        //Search or move on. Search can get stuff but risks a fight if you didn't have one yet.
        Console.WriteLine("You appear to be alone... for now");
        Console.WriteLine("You can either [S]earch the room or [M]ove on");
        Console.WriteLine("\nWhat would you like to do?");
        string choice = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (choice == "m")
        {
            Explore.currentShell.encountered = true;
            Explore.GameDungeon(d, p);
        }

        if (choice == "s")
        {
            //Make a list for events, only add if successful
            EventDisplay = new List<Event> { };
            Console.Clear();
            Console.Write("You find");
            Utilities.DotDotDotSL();
            Console.Write(" ");
            for (int i = 0; i < room.EventArray.Length; i++)
            {
                //if successful, add event to list
                int EventSuccessRoll = Utilities.rand.Next(1, 101);
                if (EventSuccessRoll <= room.EventArray[i].success)
                {
                    EventDisplay.Add(room.EventArray[i]);
                }
            }
            //Tell us what we won!
            string a = (EventDisplay.Count == 3) ? $"{EventDisplay[0].flavor},{EventDisplay[1].flavor} and {EventDisplay[2].flavor}" : (EventDisplay.Count == 2) ? $"{EventDisplay[0].flavor} and {EventDisplay[1].flavor}" : (EventDisplay.Count == 1) ? $"{EventDisplay[0].flavor}" : "Nothing!";
            Console.WriteLine(a);
            Console.WriteLine("");
            // Now give it to me!
            Reward.RoomSearch(room, d, p, EventDisplay, d.tier);
            Utilities.Keypress();
        }
        else RoomSearch(room, d, p);
    }

    public static void RandomRoom(Dungeon d, Creature p, Event[] Event)
    {
        foreach (Event e in Event)
        {
            int a = e.eventType;
            switch (a)
            {
                case 1:
                    RandomEvent.Event1(d, p, e);
                    break;
                case 2:
                    RandomEvent.Event2(d, p, e);
                    break;
                case 3:
                    RandomEvent.Event3(d, p, e);
                    break;
                case 4:
                    RandomEvent.Event4(d, p, e);
                    break;
                case 5:
                    RandomEvent.Event5(d, p, e);
                    break;
                case 6:
                    RandomEvent.Event6(d, p, e);
                    break;
                case 7:
                    RandomEvent.Event7(d, p, e);
                    break;
                case 8:
                    RandomEvent.Event8(d, p, e);
                    break;
                case 9:
                    RandomEvent.Event9(d, p, e);
                    break;
                case 10:
                    RandomEvent.Event10(d, p, e);
                    break;
                case 11:
                    RandomEvent.Event11(d, p, e);
                    break;
                case 12:
                    RandomEvent.Event12(d, p, e);
                    break;
            }
        }
    }
}