using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

public class MonsterAI
{
    public static void SelectAction(Creature p, List<Monster> monster, Dungeon d)
    {
        for (int i = 0; i < monster.Count; i++)
        {
            monster[i].monChoice = 0;
            int actionSelect = Utilities.rand.Next(1, 101);
            if (monster[i].pClass.type == 1 && monster[i].health <= (monster[i].maxHealth / 2) && monster.Count <3) monster[i].action1 = 0;
            monster[i].monChoice = (monster[i].action1 == 0) ? 1 : (monster[i].action2 == 0) ? 2: (monster[i].action3 == 0) ? 3 : (actionSelect <= monster[i].action1) ? monster[i].monChoice = 0 : (actionSelect > monster[i].action1 && actionSelect <= monster[i].action2) ? monster[i].monChoice = 1 : (actionSelect > monster[i].action2 && actionSelect <= monster[i].action3) ? monster[i].monChoice = 2 : monster[i].monChoice = 3; ;
            DeclareAction(monster[i]);
        }
    }

    private static void DeclareAction(Monster mon)
    {
        mon.declareAction = Status.creatureUpdateName[2];
        for (int i = 0; i < mon.stun.Length; i++)
        {
            if (mon.stun[i] > 0) mon.declareAction = Status.creatureUpdateName[i];
        }                       
        mon.colourChoice = Colour.NAME;
        if (mon.monChoice > 0) mon.colourChoice = Colour.SPECIAL;
        int a = mon.monChoice;
        int b = mon.pClass.type;
        switch (b)
        {
            case 1: //Slime                    
                switch (a)
                {
                    case 1:
                        mon.declareAction = "SPLITTING";
                        break;
                }
                break;
            case 2: //Goblin
                switch (a)
                {
                    case 1:
                        if (Create.p.bleed > 0)
                        {
                            mon.monChoice = 0;
                            DeclareAction(mon);
                        }
                        mon.declareAction = "RAKING";
                        break;
                }
                break;
            case 3://Kobold
                switch (a)
                {
                    case 1:
                        mon.declareAction = "IGNITING";
                        break;
                }
                break;
            case 4: //Orc
                switch (a)
                {
                    case 1:
                        mon.declareAction = "CHARGING";
                        break;
                    case 2:

                        break;
                }
                break;
            case 5: //Spider
                switch (a)
                {
                    case 1:
                        mon.declareAction = "WEBBING";
                        break;
                    case 2:

                        break;
                }
                break;
            case 6: //TBA
                switch (a)
                {
                    case 1:
                        mon.declareAction = "SPECIAL";
                        break;
                    case 2:

                        break;
                }
                break;
        }
    }

    public static void PerformAction(Creature p, List<Monster> monster, Dungeon d)
    {
        foreach (Monster mon in monster.ToList())
        {
            StatusDamage(p, d, mon, monster);
        }
        foreach (Monster mon in monster.ToList())
        {
            if (mon.stun[0] > 0)
            {
                Console.WriteLine($"The {mon.name} is frozen!");
                break;
            }
            if (mon.stun[1] > 0)
            {
                Console.WriteLine($"The {mon.name} is stunned!");
                break;
            }
            switch (mon.monChoice)
            {
                case 0:
                    MonsterAttack.Regular(p, mon, d);
                    break;
                case 1:
                    MonsterAttack.Special(p, d, mon, monster, 1);
                    break;
                case 2:
                    MonsterAttack.Special(p, d, mon, monster, 1);
                    break;
                case 3:
                    MonsterAttack.Special(p, d, mon, monster, 1);
                    break;
            }            
        }
    }

    public static void StatusDamage(Creature p, Dungeon d, Monster mon, List<Monster> monster)
    {
        if (mon.bleed > 0)
        {
            mon.health -= mon.bleedDam;
            Utilities.EmbedColourText(Colour.MONSTER, Colour.BLOOD, Colour.DAMAGE, "The ", $"{mon.name} ", "", "bleeds ", "for ", $"{mon.bleedDam} ", "damage!");
        }
        if (mon.burning > 0)
        {
            mon.health -= mon.burnDam;
            Utilities.EmbedColourText(Colour.MONSTER, Colour.BURNING, Colour.DAMAGE, "The ", $"{mon.name} ", "", "burns ", "for ", $"{mon.burnDam} ", "damage!");
        }
        KillCheck(p, d, mon, monster);
    }

    public static void KillCheck(Creature p, Dungeon d, Monster mon, List<Monster> monster)
    {
        if (mon.health <= 0)
        {
            Utilities.ColourText(Colour.DAMAGE, $"You killed the {mon.name}!\n");
            Combat.GoldReward += mon.gold;
            Combat.XPReward += mon.xp;
            int dropRoll = Utilities.rand.Next(1, 101);
            if (dropRoll <= mon.drop.dropChance) Combat.DropList.Add(mon.drop);
            monster.Remove(mon);
            Thread.Sleep(300);
        }
        WinCheck(d, p, monster);
    }

    public static void WinCheck(Dungeon d, Creature p, List<Monster> monster)
    {
        if (monster.Count == 0)
        {
            p.bleed = 0;
            p.casting = 0;
            p.burning = 0;
            p.shield = 0;
            p.canAct = true;
            Reward.FightReward(d, p);
        }
    }        
}