using System;

public class Event
{
    //Variables, self explanatory
    public string name;
    public int eventType;
    public int effect;
    public int success;
    public static Random rand = new Random();
    public static bool TFRescued = false;
    public string flavor;

    //Constructor
    public Event(string name,int eventType, int effect, int success)
    {
        this.name = name;
        this.eventType = eventType;
        this.effect = effect;
        this.success = success;
        flavor = (name == "Gold")?"Some" + Colour.GOLD + " gold" + Colour.RESET: (name == "Potion")? "A " + Colour.HEALTH + "potion" + Colour.RESET: (name == "XP")? "An old " + Colour.XP + "book" + Colour.RESET:null;
    }

    public static Event[] SearchList = new Event[]
    {
            new Event("First room",  0,   0,   0),
            new Event("Gold",        1,  60,  50),
            new Event("Potion",      2,   1,  40),
            new Event("XP",          3,  10,  30)
    };

    public static Event[] RandomList = new Event[]
    {
            new Event("Boss Room",         0,       1,      1),
            new Event("Captive townsfolk", 1,      20,     40),
            new Event("Plundered Loot",    2,      20,     40),            
            new Event("Shamanistic rune",  3,      20,     40),
            new Event("Elite Orc",         4,      20,     40),
            new Event("Pack Master",       5,      20,     40),
            new Event("Plundered Loot",    6,      20,     40),
            new Event("Shamanistic rune",  7,      20,     40),
            new Event("Captive townsfolk", 8,      20,     40),
            new Event("Plundered Loot",    9,      20,     40),
            new Event("Shamanistic rune",  10,     20,     40),
            new Event("Captive townsfolk", 11,     20,     40),
            new Event("Plundered Loot",    12,     20,     40)

    };

    public static Event[] CastleStaticList = new Event[]
    {
            new Event("Boss Room",          0,      1,     1),
            new Event("Captive townsfolk",  1,     20,    40),
            new Event("Plundered Loot",     2,     20,    40),
            new Event("Shamanistic rune",   3,     20,    40),
            new Event("Elite Orc",          4,     20,    40),
            new Event("Elite Orc",          5,     20,    40)
    };
}