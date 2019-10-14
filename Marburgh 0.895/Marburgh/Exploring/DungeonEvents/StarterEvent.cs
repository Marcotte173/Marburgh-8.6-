using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class StarterEvent
{
    public static void Room(Dungeon d, Creature p, Event[] Event)
    {
        foreach (Event e in Event)
        {
            int a = e.eventType;
            switch (a)
            {
                case 0:
                    Monster.opponentList = new List<Monster> { };
                    Monster.opponentList.Add(d.boss.MonsterCopy());
                    Combat.Start(p, Monster.opponentList, d);
                    break;
                case 1:
                    RandomEvent.Event1(d, p, e);
                    break;                
            }
        }
    }
}