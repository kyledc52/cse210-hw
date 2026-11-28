public abstract class MapObject
{
    private int _row;
    private int _col;
    private int _height;
    private int _width;

    public (int, int, int, int) GetBounds() 
    {
        return (_row, _col, _height, _width);
    }

    public (int, int) GetPositon()
    {
        return (_row, _col);
    }

    public void SetSize(int height, int width)
    {
        _height = height;
        _width = width;
    }

    public void SetIndex(int row, int col)
    {
        _row = row;
        _col = col;
    }

    public bool isObject(int row, int col)
    {
        // checks 4 end and start for both row and column
        // adding height and width is always 1 more than need so we use less than.
        return row >= _row && row < _row + _height && col >= _col && col < _col + _width;
    }

    public bool IsNextTo(int userCurrentRow, int userCurrentCol)
    {
        // Same as isObject, but grow it by 1 tile on every side
        // First 2 conditions check row start and row end, and the last 2 check col start and col end.
        return userCurrentRow >= _row - 1 && userCurrentRow <= _row + _height && userCurrentCol >= _col - 1 && userCurrentCol <= _col + _width;
    }
}