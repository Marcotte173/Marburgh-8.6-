using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class CombatUI
{
    public static void ActionSelect(Creature p, List<Monster> monster)
    {
        DrawOpponent(p, monster);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine($"\t\t{Colour.HEALTH}{ p.health}{Colour.RESET}/{Colour.HEALTH}{ p.maxHealth}\t\t\t\t\t{Colour.ENERGY}{p.energy}{Colour.RESET}/{Colour.ENERGY}{p.maxEnergy}\t\t\t\t{Colour.ABILITY}{ p.magic}{Colour.RESET}");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Utilities.ActionText("[1]Attack", "[2]Defend", Player.currentAttackOptions[0]);
        Utilities.ActionText(Player.currentAttackOptions[1], Player.currentAttackOptions[2], Player.currentAttackOptions[3]);
        Utilities.ActionText("[H]eal", "[C]haracter", "\n");
        string a = "", b = "", c = "", d = "";
        if (p.shield > 0) a = "SHIELDED\t";
        if (p.bleed > 0) b = "BLEEDING\t";
        if (p.burning > 0) c = "BURNING\t";
        if (p.defending == true) d = "DEFENDING";
        Console.Write(Colour.SHIELD + a + Colour.BLOOD + b + Colour.BURNING + c + Colour.MITIGATION + d + Colour.RESET);
    }

    public static void Stunned(Creature p, List<Monster> monster)
    {
        DrawOpponent(p, monster);
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n");
        Console.WriteLine($"\t\t{Colour.HEALTH}{ p.health}{Colour.RESET}/{Colour.HEALTH}{ p.maxHealth}\t\t\t\t\t{Colour.ENERGY}{p.energy}{Colour.RESET}/{Colour.ENERGY}{p.maxEnergy}\t\t\t\t{Colour.ABILITY}{ p.magic}{Colour.RESET}");
        Console.WriteLine("-----------------------------------------------1q-------------------------------------------------------------------------");
        Console.WriteLine("");
        Utilities.CenterText("YOU ARE STUNNED");
        Utilities.CenterText("Press any key to continue");
        Console.ReadKey(true);
        Console.SetCursorPosition(0, 9);
    }

    public static void DrawOpponent(Creature p, List<Monster> monster)
    {
        foreach (Monster mon in monster)
        {
            for (int i = 0; i < mon.statusText.Length; i++)
            {
                mon.statusText[i] = "";
            }
            if (mon.bleed > 0) mon.statusText[0] = "BLEEDING";
            if (mon.burning > 0) mon.statusText[1] = "BURNING";
            if (mon.shield > 0) mon.statusText[2] = "SHIELDED";
            if (mon.confused > 0) mon.statusText[3] = "CONFUSED";
        }
        Console.Clear();
        Console.WriteLine($"Combat round {Combat.round}");
        if (monster.Count == 1)
        {
            Utilities.CombatText(Colour.MONSTER, monster[0].name);
            Utilities.CombatText(Colour.HEALTH, monster[0].health.ToString());
            Utilities.CombatText(monster[0].colourChoice, monster[0].declareAction);
            Utilities.CombatText(Colour.BLOOD, monster[0].statusText[0]);
            Utilities.CombatText(Colour.BURNING, monster[0].statusText[1]);
            Utilities.CombatText(Colour.SHIELD, monster[0].statusText[2]);
            Utilities.CombatText(Colour.STUNNED, monster[0].statusText[3]);
        }
        else if (monster.Count == 2)
        {
            Utilities.CombatText(Colour.MONSTER, Colour.MONSTER, monster[0].name, monster[1].name);
            Utilities.CombatText(Colour.HEALTH, Colour.HEALTH, monster[0].health.ToString(), monster[1].health.ToString());
            Utilities.CombatText(monster[0].colourChoice, monster[1].colourChoice, monster[0].declareAction, monster[1].declareAction);
            Utilities.CombatText(Colour.BLOOD, Colour.BLOOD, monster[0].statusText[0], monster[1].statusText[0]);
            Utilities.CombatText(Colour.BURNING, Colour.BURNING, monster[0].statusText[1], monster[1].statusText[1]);
            Utilities.CombatText(Colour.SHIELD, Colour.SHIELD, monster[0].statusText[2], monster[1].statusText[2]);
            Utilities.CombatText(Colour.STUNNED, Colour.STUNNED, monster[0].statusText[3], monster[1].statusText[3]);
        }
        else if (monster.Count == 3)
        {
            Console.Write(Colour.MONSTER);
            Utilities.CombatText(Colour.MONSTER, Colour.MONSTER, Colour.MONSTER, monster[0].name, monster[1].name, monster[2].name);
            Utilities.CombatText(Colour.HEALTH, Colour.HEALTH, Colour.HEALTH, monster[0].health.ToString(), monster[1].health.ToString(), monster[2].health.ToString());
            Utilities.CombatText(monster[0].colourChoice, monster[1].colourChoice, monster[2].colourChoice, monster[0].declareAction, monster[1].declareAction, monster[2].declareAction);
            Utilities.CombatText(Colour.BLOOD, Colour.BLOOD, Colour.BLOOD, monster[0].statusText[0], monster[1].statusText[0], monster[2].statusText[0]);
            Utilities.CombatText(Colour.BURNING, Colour.BURNING, Colour.BURNING, monster[0].statusText[1], monster[1].statusText[1], monster[2].statusText[1]);
            Utilities.CombatText(Colour.SHIELD, Colour.SHIELD, Colour.SHIELD, monster[0].statusText[2], monster[1].statusText[2], monster[2].statusText[2]);
            Utilities.CombatText(Colour.STUNNED, Colour.STUNNED, Colour.STUNNED, monster[0].statusText[3], monster[1].statusText[3], monster[2].statusText[3]);
        }
    }
}