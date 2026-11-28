// Holds gate function

public class Gate : MapObject
{
    private int _gateStart;
    private int _gateEnd;

    public Gate()
    {
    }

    // public bool isGate(int row, int col)
    // {
    //     return (row == 0) && (col >= _gateStart) && (col < _gateStart);
    // }

    // public bool IsNextTo(int userCurrentRow, int userCurrentCol)
    // {
    //     if ((userCurrentRow == 0 || userCurrentRow == 1) && userCurrentCol >= _gateStart && userCurrentCol < _gateEnd)
    //     {
    //         return true;
    //     }
    //     return false;
    // }
}