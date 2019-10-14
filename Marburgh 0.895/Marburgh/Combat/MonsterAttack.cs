using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MonsterAttack
{
    public static void DamagePlayer(string text, string text2, Creature p, Dungeon d, Monster mon, int damage)
    {
        if (text != "") Console.WriteLine(text);
        Console.WriteLine(text2);
        p.health -= damage;
        p.health = (p.health <= 0) ? 0 : p.health;
        Player.PlayerDeathCheck(p, mon, null);
    }
    public static void Regular(Creature p, Monster mon, Dungeon d)
    {
        int hitRoll = Utilities.rand.Next(1, 101);
        if (hitRoll <= (mon.hit - p.defence - p.tempDef))
        {
            int critRoll = Utilities.rand.Next(1, 101);
            int damage = (critRoll <= mon.crit) ? (mon.damage - p.Armor.effect - p.mitigation) * 2 : mon.damage - p.Armor.effect - (p.mitigation + p.tempMit);
            string a = (critRoll <= mon.crit) ? Colour.CRIT + "crits" : Colour.RESET + "hits";
            damage = (damage < 0) ? 0 : damage;
            DamagePlayer("", $"The " + Colour.MONSTER + $"{mon.name} " + $"{a} " + Colour.RESET + "you for " + Colour.DAMAGE + $"{damage} " + Colour.RESET + "damage!", p, d, mon, damage);
        }
        else Console.WriteLine($"The {mon.name} misses you!");
    }

    public static void Special(Creature p, Dungeon d, Monster mon, List<Monster> monster, int button)
    {
        {
            int hitRoll = Utilities.rand.Next(1, 101);
            if (hitRoll <= (mon.hit - p.defence - p.tempDef))
            {
                int a = button;
                int b = mon.pClass.type;
                switch (b)
                {
                    case 1: //Slime                    
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("The slime splits. There is a new slime!");
                                monster.Add(Monster.starterBestiary[0].MonsterCopy());
                                monster[monster.Count - 1].maxHealth = monster[monster.Count - 1].health = mon.health;
                                monster.Add(Monster.starterBestiary[0].MonsterCopy());
                                monster[monster.Count - 1].maxHealth = monster[monster.Count - 1].health = mon.health;
                                monster.Remove(mon);
                                break;
                            case 2:

                                break;
                        }
                        break;
                    case 2: //Goblin
                        switch (a)
                        {
                            case 1:
                                Utilities.EmbedColourText(Colour.MONSTER, Colour.BLOOD, "The ", "Goblin ", "", "rakes", " you with its claws");
                                Utilities.ColourText(Colour.BLOOD, "You are bleeding\n");
                                p.bleed = 2;
                                p.bleedDam = 2;
                                break;
                            case 2:

                                break;
                        }
                        break;
                    case 3://Kobold
                        switch (a)
                        {
                            case 1:
                                if (p.burning > 0)
                                {
                                    Utilities.EmbedColourText(Colour.MONSTER, Colour.BURNING, "The ", "Kobold ", "throws a candle at you, further ", "burning ", "your already charred skin!");
                                    Utilities.ColourText(Colour.BURNING, "Your burning length and damage increases by 1!\n");
                                    p.burning++;
                                    p.burnDam++;
                                }
                                else
                                {
                                    Utilities.EmbedColourText(Colour.MONSTER, Colour.BURNING, "The ", "Kobold ", "throws a candle at you, ", "igniting ", "you!");
                                    Utilities.ColourText(Colour.BURNING, "You are burning\n");
                                    p.burning = 3;
                                    p.burnDam = 1;
                                }
                                break;
                            case 2:

                                break;
                        }
                        break;
                    case 4: //Orc
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("The monster hits you with a special attack");
                                break;
                            case 2:

                                break;
                        }
                        break;
                    case 5: //Spider
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("The monster hits you with a special attack");
                                break;
                            case 2:

                                break;
                        }
                        break;
                    case 6: //TBA
                        switch (a)
                        {
                            case 1:
                                Console.WriteLine("The monster hits you with a special attack");
                                break;
                            case 2:

                                break;
                        }
                        break;
                }
            }
            else Console.WriteLine($"The {mon.name} misses you!");          
        }
    }
}