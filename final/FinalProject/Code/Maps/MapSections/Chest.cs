public class Chest
{
    private bool _opened = false;

    public Chest()
    {
    }

    public void Open()
    {
        if (_opened)
        {
            return;
        }
        _opened = true;
    }
}