using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CastleEvent
{
    public static void Room(Dungeon d, Creature p, Event[] Event)
    {
        foreach (Event e in Event)
        {
            int a = e.eventType;
            switch (a)
            {
                case 0:
                    Console.Clear();
                    Console.WriteLine("");
                    Monster.opponentList = new List<Monster> { };
                    Monster.opponentList.Add(d.boss.MonsterCopy());
                    Combat.Start(p, Monster.opponentList, d);
                    break;
                case 1:
                    Event1(d, p, e);
                    break;
                case 2:
                    Event2(d, p, e);
                    break;
                case 3:
                    Event3(d, p, e);
                    break;
                case 4:
                    Event4(d, p, e);
                    break;
                case 5:
                    Event5(d, p, e);
                    break;
            }
        }
    }

    public static void Event1(Dungeon d, Creature p, Event e)
    {
        List<Monster> mon = new List<Monster> { new Monster("Cecil the Butler", pClass.MonsterClassList[4], 8, 65, 5, 0, 80, 5, 5, Drop.BossDrop[2],70,100,100) };
        Console.Clear();
        Console.WriteLine("");
        Combat.Start(p, mon, d);
        Explore.currentShell.encountered = true;
    }

    public static void Event2(Dungeon d, Creature p, Event e)
    {
        List<Monster> mon = new List<Monster> { new Monster("The Cook", pClass.MonsterClassList[4], 8, 65, 5, 0, 80, 5, 5, Drop.BossDrop[3], 70, 100, 100) };
        Console.Clear();
        Console.WriteLine("");
        Combat.Start(p, mon, d);
        Explore.currentShell.encountered = true;
    }

    public static void Event3(Dungeon d, Creature p, Event e)
    {
        Console.Clear();
        Console.WriteLine("You find yourself in a hallway, connecting the servant's quarters to the rest of the castle\nSomewhere in there is Cecil, the head butler.\nPerhaps he will have the key you need to access the owner's private quarters?");
        Explore.currentShell.encountered = true;
        Utilities.Keypress();
        Explore.GameDungeon(d, p);
    }

    public static void Event4(Dungeon d, Creature p, Event e)
    {
        Console.Clear();
        Console.WriteLine("You find yourself in a hallway, connecting the kitchens to the rest of the castle\nThis area is run by The Cook.\nBe careful, those who run afoul of him often end up in his stew");
        Explore.currentShell.encountered = true;
        Utilities.Keypress();
        Explore.GameDungeon(d, p);
    }
    public static void Event5(Dungeon d, Creature p, Event e)
    {

    }
}

