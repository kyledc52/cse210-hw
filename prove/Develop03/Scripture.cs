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
        string[] words = scripture.Split(' ');
        foreach (string word in words)
        {
            Word w = new Word(word);
            _scripture.Add(w);
        }

        string[] referenceParts = reference.Split(" ");
        string book = "";
        for (int i = 0; i < referenceParts.Length - 1; i++)
        {
            book += referenceParts[i] + " ";
        }
        book = book.Trim();
        
        // Left is chapter, right are verses
        string[] chapterAndIndex = referenceParts[referenceParts.Length - 1].Split(":");

        // split verses
        string[] verses = chapterAndIndex[chapterAndIndex.Length - 1].Split("-");

        // actually create Reference object instead of just declaring it
        if (verses.Length == 1)
        {
            _scriptureReference = new Reference(book, int.Parse(chapterAndIndex[0]), int.Parse(chapterAndIndex[1]));   
        }
        else
        {
            _scriptureReference = new Reference(book, int.Parse(chapterAndIndex[0]), int.Parse(verses[0]), int.Parse(verses[1]));
        }
    }

    public void HideRandomWords()
    {
        int hidden = 0;
        int len = _scripture.Count();

        while (hidden < 7)
        {
            int randIndex = random.Next(len);
            Word currentWord = _scripture[randIndex];
            if (!currentWord.IsHidden())
            {
                // word isn't hidden
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
                return false;
            }
        }
        // all words are hidden
        return true;
    }

    public string GetDisplayReference()
    {
        return _scriptureReference.GetReference();
    }

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