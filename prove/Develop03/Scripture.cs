using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Xml.Serialization;

public class Scripture
{
    private List<Word> _scripture = new List<Word>();
    private Reference _scriptureReference;
    private Random random = new Random();

    public Scripture(string scripture, string reference)
    {   
        // Create Word object
        string[] words = scripture.Split(' ');
        foreach (string word in words)
        {
            Word w = new Word(word);
            _scripture.Add(w);
        }


        // Create Reference object
        string[] referenceParts = reference.Split(" "); // Array of reference
        string book = "";
        for (int i = 0; i < referenceParts.Length - 1; i++) // everything except last part
        {
            book += referenceParts[i] + " ";
        }
        book = book.Trim(); // Alma, 1 John
        
        // Left is chapter, right are verses
        string[] chapterAndVerses = referenceParts[referenceParts.Length - 1].Split(":"); // '3' '7'

        // split verses if more than 1 verse
        string[] verses = chapterAndVerses[chapterAndVerses.Length - 1].Split("-");  // '7'

        if (verses.Length == 1)
        {
            // 1 verse
            _scriptureReference = new Reference(book, int.Parse(chapterAndVerses[0]), int.Parse(chapterAndVerses[1]));   
        }
        else
        {
            // 2 verses
            _scriptureReference = new Reference(book, int.Parse(chapterAndVerses[0]), int.Parse(verses[0]), int.Parse(verses[1]));
        }
    }

    public void HideRandomWords()
    {
        int numOfWordsToHide = 5;

        int hidden = 0;
        int len = _scripture.Count();
        while (hidden < numOfWordsToHide)
        {
            int randIndex = random.Next(len);
            Word currentWord = _scripture[randIndex]; // Select random word
            if (!currentWord.IsHidden())
            {
                // Word isn't hidden
                currentWord.HideWord();
                hidden++;
            }
            if (IsCompletelyHidden())
            {
                break;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _scripture)
        {
            if (!word.IsHidden())
            {
                // Words aren't all hidden
                return false;
            }
        }
        // All words are hidden
        return true;
    }

    public string GetDisplayReference()
    {
        return _scriptureReference.GetReference();
    }

    // Return scripture plus hidden words.
    public string GetDisplayScripture()
    {
        string textToDisplay = "";
        int len = _scripture.Count();
        
        for (int i = 0; i < len; i++)
        {
            Word currentWord = _scripture[i];
            if (!currentWord.IsHidden())
            {
                textToDisplay += currentWord.GetDisplayText() + " ";
            }
            else
            {
                // word is hidden
                textToDisplay += "     ";
            }
        }

        return textToDisplay;
    }

    // public string GetRandomScripture()
    // {

    // }
}