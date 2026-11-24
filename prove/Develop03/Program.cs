using System;
using Microsoft.VisualBasic;

class Program
{

    // I went above and beyond by creating another different class that is at the top of the hierarchy, the ScriptureLibrary class. It uses a
    // txt file to grab a random scripture according to a category the user enters. It will then display that scripture. I also pushed myself
    // and used dictionaries. (I used to know Java really well and took an AP test and scored well on it, so this is a refresher basically lol).
    static void Main(string[] args)
    {
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
        // Scripture verse = new Scripture("scripture hello hello", "1 nephi 12:1212");

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
