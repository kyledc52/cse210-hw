public class ScriptureLibrary
{
    private string[] lines = File.ReadAllLines("scriptures.txt");
    private Dictionary<string, List<Scripture>> _verses = new Dictionary<string, List<Scripture>>();
    Random random = new Random();

    public ScriptureLibrary()
    {
        int fileLength = lines.Length;

        // Add the 5 categories to the dictionary as the keys.
        _verses.Add("Faith", new List<Scripture>());
        _verses.Add("Repentance", new List<Scripture>());
        _verses.Add("Baptism", new List<Scripture>());
        _verses.Add("Holy Ghost", new List<Scripture>());
        _verses.Add("ETTE", new List<Scripture>());

        // Iterate through txt file and put them in the dictionary under their category.
        foreach (string line in lines)
        {
            string[] parts = line.Split("|");
            Scripture currentScripure = new Scripture(parts[2],parts[0]);
            
            if (parts[1] == "Faith")
            {
                _verses["Faith"].Add(currentScripure);
            }
            else if (parts[1] == "Repentance")
            {
                _verses["Repentance"].Add(currentScripure);
            }
            else if (parts[1] == "Baptism")
            {
                _verses["Baptism"].Add(currentScripure);
            }
            else if (parts[1] == "Holy Ghost")
            {
                _verses["Holy Ghost"].Add(currentScripure);
            }
            else if (parts[1] == "ETTE")
            {
                _verses["ETTE"].Add(currentScripure);
            }
        }
    }
    
    // Returns a random scripture from the txt file according to what the user enters.
    public Scripture GetRandomScripture(string inputCategory)
    {
        if (inputCategory == "Faith")
        {
            List<Scripture> faithVerses = _verses["Faith"];
            int randIndex = random.Next(faithVerses.Count);
            Scripture randScripture = faithVerses[randIndex];
            return randScripture;
        }
        else if (inputCategory == "Repentance")
        {
            List<Scripture> repentanceVerses = _verses["Repentance"];
            int randIndex = random.Next(repentanceVerses.Count);
            Scripture randScripture = repentanceVerses[randIndex];
            return randScripture;
        }
        else if (inputCategory == "Holy Ghost")
        {
            List<Scripture> holyGhostVerses = _verses["Holy Ghost"];
            int randIndex = random.Next(holyGhostVerses.Count);
            Scripture randScripture = holyGhostVerses[randIndex];
            return randScripture;
        }
        else if (inputCategory == "Baptism")
        {
            List<Scripture> baptismVerses = _verses["Baptism"];
            int randIndex = random.Next(baptismVerses.Count);
            Scripture randScripture = baptismVerses[randIndex];
            return randScripture;
        }
        else if (inputCategory == "ETTE")
        {
            List<Scripture> etteVerses = _verses["ETTE"];
            int randIndex = random.Next(etteVerses.Count);
            Scripture randScripture = etteVerses[randIndex];
            return randScripture;
        }
        else
        {
            // Not a valid category
            return null;
        }
    }
}