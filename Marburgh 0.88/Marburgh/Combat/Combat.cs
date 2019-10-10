using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Combat
{
    public static int round;       
    public static int Attacks = 2;
    public static int GoldReward;
    public static int XPReward;    
    public static List<Drop> DropList = new List<Drop> { };
    //Is this a boss fight?
    public static bool bossFight;

    public static void Start(Creature p, List<Monster> monster, Dungeon d)
    {
        round = 0;
        //reset rewards
        GoldReward = XPReward = 0;
        bossFight = false;
        DropList = new List<Drop> { };
        //If you desecrated runes, cut health in half then set back to false
        foreach (Monster mon in monster)
        {
            mon.bleed = 0;
            mon.burning = 0;
            for (int i = 0; i < 2; i++)
            {
                mon.stun[i] = 0;
            }
            ////mon.health += mon.addHP;
            ////mon.damage += mon.addDam;
            mon.health = RandomEvent.desecrated ? mon.health /= 2 : mon.health;
        }
        RandomEvent.desecrated = false;
        //Check if it's a boss fight
        for (int i = 0; i < Boss.BossList.Count(); i++)
        {
            if (monster[0].name == Boss.BossList[i].name) bossFight = true;
        }        
        FullRound(p, monster, d);
    }

    public static void FullRound(Creature p, List<Monster> monster, Dungeon d)
    {
        round++;
        Player.target = 0;
        Update(p);
        foreach (Monster mon in monster) { Update(mon); }
        MonsterAI.SelectAction(p, monster, d);
        if (p.canAct)
        {
            Player.ActionSelect(p, monster, d);
            Console.WriteLine();
        }
        else CombatUI.Stunned(p, monster);
        MonsterAI.PerformAction(p, monster, d);
        Utilities.Keypress();
        FullRound(p, monster, d);
    }

    public static void Update(Creature p)
    {
        p.tempDef = 0;
        p.tempMit = 0;
        p.canAct = true;
        for (int i = 0; i < p.stun.Length; i++)
        {
            if (p.stun[i] > 0) p.canAct = false;
            p.stun[i]--;
        }
        if (p.bleed > 0) p.bleed--;
        if (p.casting > 0) p.casting--;
        if (p.burning > 0) p.burning--;
        if (p.shield > 0) p.shield--;        
    } 

    public static void Update(Monster mon)
    {
        for (int i = 0; i < mon.stun.Length; i++)
        {
            if (mon.stun[i] > 0) mon.stun[i]--;
        }
        if (mon.bleed > 0) mon.bleed--;
        if (mon.casting > 0) mon.casting--;
        if (mon.burning > 0) mon.burning--;
        if (mon.shield > 0) mon.shield--;
        if (mon.confused > 0) mon.confused--;
    }
}