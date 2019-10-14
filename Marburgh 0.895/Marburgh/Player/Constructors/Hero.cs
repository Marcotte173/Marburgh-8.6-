﻿using System.Collections.Generic;
public class Hero : Creature
{
    public Hero(pClass pClass, Family family, Equipment Weapon, Equipment Armor, string[] attacks)
    : base(pClass)
    {
        this.attacks = attacks;
        List<Drop> Drops = new List<Drop> { };
        this.family = family;
        this.pClass = pClass;
        this.Weapon = Weapon;
        this.Armor = Armor;
        energy = maxEnergy = pClass.startingEnergy;
        health = maxHealth = pClass.startingHealth;
        magic = pClass.startingMagic;
        damage = pClass.startingDamage;
        level = 1;
        gold = 100;
        xp = 0;
        potions = 1;
        invested = 0;
        hasInvestment = false;
        craft = false;
        maxPotions = 2;
        mitigation = 1;
        hit = 75;
        crit = 10;
        defence = 5;
        tempDef = 0;
        tempMit = 0;
        if (pClass.cName == "Warrior")
        {
            mitigation += 1;
            defence += 3;
            lvlDamage =     (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1;
            lvlHealth =     (level == 3 || level == 5 || level == 7 || level == 10) ? 5 : 3;
            lvlEnergy =     (level == 3 || level == 5 || level == 7 || level == 10) ? 1 : 2;
            lvlMitigation = (level == 3 || level == 5 || level == 7 || level == 10) ? 3 : 1; 
            lvlHit =        (level == 3 || level == 5 || level == 7 || level == 10) ? 5 : 5; 
            lvlCrit =       (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1; 
            lvlDefence =    (level == 3 || level == 5 || level == 7 || level == 10) ? 3 : 2; 
        }
        if (pClass.cName == "Rogue")
        {
            hit += 2;
            crit += 2;
            lvlDamage =     (level == 3 || level == 5 || level == 7 || level == 10) ? 3 : 1;
            lvlHealth =     (level == 3 || level == 5 || level == 7 || level == 10) ? 5 : 2;
            lvlEnergy =     (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 2;
            lvlMitigation = (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1;
            lvlHit =        (level == 3 || level == 5 || level == 7 || level == 10) ? 6 : 5;
            lvlCrit =       (level == 3 || level == 5 || level == 7 || level == 10) ? 3 : 1;
            lvlDefence =    (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 2;
        }
        if (pClass.cName == "Mage")
        {
            lvlDamage =      (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1;
            lvlHealth =      (level == 3 || level == 5 || level == 7 || level == 10) ? 4 : 2;
            lvlEnergy =      (level == 3 || level == 5 || level == 7 || level == 10) ? 3 : 2;
            lvlMagic =       (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1;
            lvlMitigation =  (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1;
            lvlHit =         (level == 3 || level == 5 || level == 7 || level == 10) ? 5 : 5;
            lvlCrit =        (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 1;
            lvlDefence =     (level == 3 || level == 5 || level == 7 || level == 10) ? 2 : 2;
            maxPotions ++;
            Player.currentAttackOptions[0] = Create.mageAttacks[0];
        }
    }
}