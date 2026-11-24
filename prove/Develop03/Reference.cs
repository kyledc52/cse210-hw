using System.Security.Cryptography;

public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;
    private bool _isOneVerse;
    

    // 1 verse
    public Reference(string book, int chapter, int startVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _isOneVerse = true;
    }

    // more than 1 verse
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
        _isOneVerse = false;
    }

    public string GetReference()
    {
        if (_isOneVerse)
        {
            return _book + " " + _chapter + ":" + _startVerse;
        }
        else
        {
            return _book + " " + _chapter + ":" + _startVerse + "-" + _endVerse;
        }
        
    }
}