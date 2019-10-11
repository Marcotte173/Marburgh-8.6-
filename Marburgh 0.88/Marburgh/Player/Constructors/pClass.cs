public class pClass
{    
    public string cName;
    public int startingEnergy;    
    public int startingHealth;    
    public int startingMagic;    
    public int startingDamage;
    public int type;

    public pClass(string name, int startingHealth, int startingDamage, int startingEnergy, int startingMagic, int type )
    {
        this.startingEnergy = startingEnergy;        
        this.startingHealth = startingHealth;        
        this.startingMagic = startingMagic;        
        this.startingDamage = startingDamage;
        cName = name;
        this.type = type;
    }
    public static pClass[] MonsterClassList = new pClass[]
    {
            new pClass("Slime"   ,  8,  5, 0, 0, 1),
            new pClass("Goblin"  ,  8,  4, 0, 0, 2),
            new pClass("Kobald"  ,  9,  5, 0, 0, 3),
            new pClass("Orc"     , 14,  7, 0, 0, 4),
            new pClass("Spider"  , 12,  7, 0, 0, 5),
            new pClass("Minotaur", 15,  8, 0, 0, 6),
            new pClass("Ogre"    , 20, 10, 0, 0, 7),
            new pClass("Ettin"   , 25, 12, 0, 0, 8)
    };
}