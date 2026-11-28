public class Map
{
    List<List<char>> _map = new List<List<char>>();
    private string _mapName;
    private int _rowAmt = 0;
    private int _colAmt = 0;
    private bool _isMainMap;
    private Gate gate = new Gate();
    private Generator _generator = new Generator();
    private Monster _monster;
    private char _charUnderMonster;

    private int _playerRow = 2;
    private int _playerCol = 2;

    public Map(string mapName, int rowAmt, int colAmt, bool isMainMap = false)
    {
        _mapName = mapName;
        _rowAmt = rowAmt;
        _colAmt = colAmt;
        _isMainMap = isMainMap;

        _monster = new Monster(this);

        GenerateMap();

        if (_isMainMap)
        {
            GenerateObjects();

            // Row is y and column is x
            // _monster = new Monster(_rowAmt / 2, _colAmt / 2, 4, 7);
            PlaceMonster();
        }
    }

    public (int, int) GetRowColPos()
    {
        return (_rowAmt, _colAmt);
    }

    private void PlaceMonster()
    {
        // monster patrol method sets the position initially
        (int row, int col) = _monster.GetPosition();
        _charUnderMonster = _map[row][col];
        _map[row][col] = 'M';
    }

    public void MoveMonster()
    {
        (int oldRow, int oldCol) = _monster.GetPosition();
        _map[oldRow][oldCol] = _charUnderMonster;

        _monster.UpdateBehavior(_playerRow, _playerCol);

        PlaceMonster();
    }

    public void GenerateObjects()
    {
        GenerateGate();
        GenerateGenerator();
    }

    private void GenerateGenerator()
    {
        // Generator will only be in main map
        if (!_isMainMap)
        {
            return;
        }

        int row = 13, col = 12, height = 2, width = 3;

        FillArea(row, col, height, width, '[', ']');

        _generator.SetIndex(row, col);
        _generator.SetSize(height, width);
    }

    private void GenerateGate()
    {
        int len = _map[0].Count;
        
        int leftMiddle = (len - 1) / 2;
        int rightMiddle = len / 2;

        int gateStart = leftMiddle - 1;
        int gateEnd = rightMiddle + 2;

        int width = gateEnd - gateStart;

        FillArea(0, gateStart, 1, width, '|', '|', '=');
        
        gate.SetIndex(0, gateEnd);
        gate.SetSize(1, width);
    }

    private void GenerateMap()
    {
        for (int row = 0; row < _rowAmt; row++)
        {
            List<char> curRow = new List<char>();
            for (int col = 0; col < _colAmt; col++)
            {
                curRow.Add('-');
            }
            _map.Add(curRow);
        }
    }

    public void Display()
    {
        foreach (List<char> row in _map)
        {
            foreach (char c in row)
            {
                Console.Write($"  {c}  ");
            }
            Console.WriteLine();
        }
    }

    public void ChangeChar(int row, int col, char c)
    {
        _map[row][col] = c;
    }

    public void FillArea(int row, int col, int height, int width, char startChar, char endChar, char middleChar = '~')
    {
        for (int r = row; r < row + height; r++)
        {
            for (int cl = col; cl < col + width; cl++)
            {
                if (cl == col)
                {
                    _map[r][cl] = startChar;
                }
                else if (cl == col + width - 1)
                {
                    _map[r][cl] = endChar;
                }
                else
                {
                    _map[r][cl] = middleChar;
                }
            }
        }
    }
}