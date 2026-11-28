public abstract class Character()
{
    private int _row;
    private int _col;

    public (int, int) GetPosition()
    {
        return (_row, _col);
    }

    public void SetPosition(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public abstract void Interact();
}