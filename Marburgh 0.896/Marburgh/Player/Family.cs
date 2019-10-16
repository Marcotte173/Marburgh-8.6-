using System;
using System.Collections.Generic;

public class Family
{
    public static string FamilyLastName;
    public string sibling1, sibling2;
    public string FirstName, LastName;
    public static List<string> FamilyFirstNames = new List<string> { };
    public static List<string> DeadSiblings = new List<string> { };
    public static List<string> killingMonster = new List<string> { };
    public static int[,] timeOfDeath = new int[3,4] 
    {
        {0, 0, 0, 0 },
        {0, 0, 0, 0 },
        {0, 0, 0, 0 }
    };

    public static List<string> potentialNames = new List<string>
    {
            "Angela","Amy", "Anna","Alison","Adam","Alex","Anthony","Alistair","Alfred","Alexa","Ainsley",
            "Beth", "Bonnie", "Bailey","Beuford", "Barbara","Bernard", "Bill", "Bryce", "Belle","Barrie", 
            "Carol", "Candice", "Cindy","Cole", "Charles","Chris","Chance", "Caleb","Caddie","Caitlyn", "Connor", "Carl",
            "Donna", "Deborah","Doug",  "Don", "Dwight", "Dexter", "Daphne", 
            "Elaine", "Emily","Edward", "Eric",
            "Farrah","Fred","Frank", "Fran", 
            "Gina", "George", "Gerald", 
            "Heather",  "Harold","Hank",
            "Isabelle", "Ian", 
            "Jolene",  "Jake", "James", "Jackson", "Jesse", "John", "Jack", "Janet",
            "Katherine", "Karl", "Keon", "Kevan",
            "Laura","Lewis","Larry", 
            "Mary",  "Matt","Martin","Melvin","Maebel", "Maddox","Meagen","Magda","Marvin","Mitch","Micah","Mia","Mark","Micheal",
            "Olivea",
            "Piper"
        };
    

    public static void FamilyCreate()
    {
        Console.Clear();
        Console.WriteLine("What is your family name?\n" + Colour.NAME);
        FamilyLastName = Console.ReadLine();
        Console.Write(Colour.RESET);
        Utilities.EmbedColourText(Colour.NAME, "\nIs ", FamilyLastName, " correct?\n\n\n[Y]es   [N]o");
        string confirm = Console.ReadKey(true).KeyChar.ToString().ToLower();
        if (confirm != "y") FamilyCreate();
        else
        {
            while (FamilyFirstNames.Count < 3)
            {
                //Roll, add name to fmaily list, take of potential list to avoid repeats
                int roll = Utilities.rand.Next(0, potentialNames.Count - 1);
                FamilyFirstNames.Add(potentialNames[roll]);
                potentialNames.Remove(potentialNames[roll]);
            }
        }
        Create.f = new Family(Family.FamilyLastName, Family.FamilyFirstNames[0], Family.FamilyFirstNames[1], Family.FamilyFirstNames[2]);
    }

    public static void FamilyAssignment()
    {
        Console.Clear();
        Utilities.EmbedColourText(Colour.NAME, Colour.NAME, "Your name is", $" {Create.p.family.FirstName} {Create.p.family.LastName}", ".\n\nYour Mother, ", $"Helen {Create.p.family.LastName} ", "was an adventurer. She was recently killed by an Orc.\nYou never knew your father.\n");
        if (FamilyFirstNames.Count == 3) Utilities.EmbedColourText(Colour.NAME, Colour.NAME, "You are the eldest child.\nYour siblings,", $" {Create.p.family.sibling1}", " and", $" {Create.p.family.sibling2}", " look up to you now to take care of them.");
        else if (FamilyFirstNames.Count == 2) Utilities.EmbedColourText(Colour.NAME, "You are the eldest surviving child.\nYour sibling,", $" {Create.p.family.sibling2}", " looks up to you now to put food on the table the only way you know how - Adventuring.");
        else Utilities.EmbedColourText(Colour.NAME, "You are the only survivng", $" {Create.p.family.LastName}", ".\nIt is all up to you now.");
        Utilities.Keypress();
    }
    
    public Family(string lastName, string firstBorn, string secondBorn, string thirdBorn)
    {
        LastName = lastName;
        FirstName = firstBorn;
        sibling1 = secondBorn;
        sibling2 = thirdBorn;
    }
}