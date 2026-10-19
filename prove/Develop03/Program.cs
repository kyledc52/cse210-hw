using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        // Scripture verse = new Scripture("And he shall go forth, suffering pains and afflictions and temptations of every kind; and this that the word might be fulfilled which saith he will take upon him the pains and the sicknesses of his people.", "Alma 7:11");
        string input = "";
        while (input != "1" && input != "2" && input != "3" && input != "4" && input != "5")
        {
            Console.WriteLine("Enter scripture category (1-5):");
            Console.WriteLine("1: Faith");
            Console.WriteLine("2: Repentance");
            Console.WriteLine("3: Baptism");
            Console.WriteLine("4: Holy Ghost");
            Console.WriteLine("5: ETTE");
            Console.Write("Enter Number: ");
            input = Console.ReadLine();
        }

        string category = "";

        if (input == "1")
        {
            category = "Faith";
        }
        else if (input == "2")
        {
            category = "Repentance";
        }
        else if (input == "3")
        {
            category = "Baptism";
        }
        else if (input == "4")
        {
            category = "Holy Ghost";
        }
        else if (input == "5")
        {
            category = "ETTE";
        }

        ScriptureLibrary scriptures = new ScriptureLibrary();
        Scripture myVerse = scriptures.GetRandomScripture(category);

        while (true)
        {
            Console.WriteLine($"{myVerse.GetDisplayReference()} {myVerse.GetDisplayScripture()}");
            Console.Write("Press enter to hide words or type \"quit\" to end session: \n");
            
            string displayInput = Console.ReadLine().ToLower().Trim();

            if (displayInput == "quit")
            {
                break;
            }

            myVerse.HideRandomWords();

            if (myVerse.IsCompletelyHidden())
            {
                break;
            }

            Console.Clear();
        }
    }
}
