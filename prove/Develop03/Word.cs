public class Word
{
    private string _text;
    private bool _isHidden = false;
    public Word(string word)
    {
        _text = word;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public string GetDisplayText()
    {
        return _text;
    }
}
