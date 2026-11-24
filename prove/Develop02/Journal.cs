using System.IO;

public class Journal
{
    // use () at end to call the constructor of List object to make a new object.
    public List<Entry> _entries = new List<Entry>();
    public List<string> _prompts = new List<string>
        {
            "What is something difficult I overcame recently, and what did I learn from it?",
            "What is one thing I am grateful for today, and why?",
            "What is something I want to improve about myself, and what is one step I can take?",
            "When did I feel happiest or most at peace today?",
            "What is something someone did for me recently that made a difference in my life?" 
        };

    public void AddEntry(string userResponse, string prompt)
    {
        // create entry
        Entry ent = new Entry();
        ent._prompt = prompt;
        ent._response = userResponse;

        // add user's response to existing _entries list
        _entries.Add(ent);
    }

    public void Display()
    {
        // display each entry info
        foreach (Entry ent in _entries)
        {
            ent.Display();
            // new line
            Console.WriteLine();
        }
    }

    public string GeneratePrompt()
    {
        // Get random number for 
        Random random = new Random();
        int randomIndex = random.Next(_prompts.Count);
        string randomPrompt = _prompts[randomIndex];
        
        return randomPrompt;
    }

    public void SaveToFile(string fileName)
    {
        // create saved file using stream writer
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry ent in _entries)
            {
                outputFile.WriteLine($"{ent._date}|{ent._prompt}|{ent._response}");
            }
            Console.WriteLine($"Saved to: {Path.GetFullPath(fileName)}");
        }
    }

    public void LoadToFile(String savedFileName)
    {
        // Load
        string[] lines = System.IO.File.ReadAllLines(savedFileName);

        // clear current journal
        _entries.Clear();
        
        foreach (string line in lines)
        {
            // load into new objects
            Entry ent = new Entry();
            string[] parts = line.Split("|");

            ent._date = parts[0];
            ent._prompt = parts[1];
            ent._response = parts[2];

            // add to journal
            _entries.Add(ent);
        }
    }
}