using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Monster: Creature
{
    //Variables, self explanatory
    public string name;
    public string summonName;
    public Drop drop;
    public bool isBoss = false;
    public static List<Monster> opponentList = new List<Monster> { };
    public int action1;
    public int action2;
    public int action3;
    public int monChoice;
    public string colourChoice;

    //Constructor
    public Monster(string name, pClass pClass, int xp, int gold, int addHP, int addDam, int hit, int defence, int crit, Drop drop, int action1, int action2 , int action3)
    : base(pClass)
    {
        declareAction = Status.creatureUpdateName[2];
        maxHealth = health = pClass.startingHealth + addHP;
        damage = pClass.startingDamage + addDam;
        energy = pClass.startingEnergy;
        magic = pClass.startingMagic;
        this.addDam = addDam;
        this.addHP = addHP;
        this.drop = drop;
        this.name = name;
        this.pClass = pClass;
        this.xp = xp;
        this.gold = gold;
        this.drop = drop;
        this.hit = hit;
        this.defence = defence;
        this.crit = crit;
        this.action1 = action1;
        this.action2 = action2;
        this.action3 = action3;
        monChoice = 0;
        colourChoice = Colour.NAME;
    }

    public static Monster[] starterBestiary = new Monster[]
    {
            new Monster("Slime",  pClass.MonsterClassList[0], 5, 10, 0, 0, 75,5,5, Drop.drop[1],100,100,100),
            new Monster("Goblin",  pClass.MonsterClassList[1], 5, 20, 0, 0, 75,5,5, Drop.drop[2],70,100,100),
            new Monster("Kobold",  pClass.MonsterClassList[2], 5, 20, 0, 0, 80,0,5, Drop.drop[3],70,100,100),
    };

    public static Monster[] castleBestiary = new Monster[]
    {
        new Monster("Goblin",  pClass.MonsterClassList[1], 5, 20, 0, 0, 75,5,5, Drop.drop[2],70,100,100),
        new Monster("Orc",  pClass.MonsterClassList[3], 12, 85, 0, 0,  75,10,6, Drop.drop[4],70,100,100),
        new Monster("Spider",  pClass.MonsterClassList[4], 12, 85, 0, 0,  75,10,6, Drop.drop[5],70,100,100),
    };

    public static void Summon(Room room, Dungeon d, Creature p)
    {
        opponentList = new List<Monster> { };
        //Did monsters get summoned?
        int x = Utilities.rand.Next(1, 101);
        //If yes,
        int monsterChance = room.modifier + d.monsterSummon;
        if (x <= monsterChance || p.force)//Make monsters, fight them        
        {
            //Make monsters, fight them
            Console.Write("You have been discovered by");
            Utilities.DotDotDot();
            Console.WriteLine();
            //How many monsters?
            //If level one, 1 or 2. Otherwise, up to three
            int levelConsideration = (p.level == 1) ? 3 : 4;
            int numroll = Utilities.rand.Next(1, levelConsideration);
            for (int i = 0; i < numroll; i++)
            {
                //Which specific monsters?
                int monsterSelect = Utilities.rand.Next(0, room.bestiary.Length);
                opponentList.Add(room.bestiary[monsterSelect].MonsterCopy());
            }
            for (int i = 0; i < opponentList.Count; i++)
            {
                if (opponentList[i].name.FirstOrDefault() == 'A' || opponentList[i].name.FirstOrDefault() == 'E' || opponentList[i].name.FirstOrDefault() == 'I' ||
                opponentList[i].name.FirstOrDefault() == 'O' || opponentList[i].name.FirstOrDefault() == 'U') Utilities.EmbedColourText(Colour.MONSTER, "An ", $"{opponentList[i].name}", "");
                else Utilities.EmbedColourText(Colour.MONSTER, "A ", $"{opponentList[i].name}", "");
            }
            Utilities.Keypress();
            p.force = false;
            Combat.Start(p, opponentList, d);
        }
    }

    //Creates a copy of the monster, rather than the static version
    public Monster MonsterCopy()
    {
        return (Monster)MemberwiseClone();
    }
}