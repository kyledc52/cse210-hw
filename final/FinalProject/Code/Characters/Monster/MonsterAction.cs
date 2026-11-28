public class MonsterAction
{
    private Monster _monster;
    private MonsterPatrol _monsterPatrol;
    private int _returnTargetRow;
    private int _returnTargetCol;

    private int _lastSeenPosRow;
    private int _lastSeenPosCol;

    public MonsterAction(Monster monster, MonsterPatrol mPatrol)
    {
        _monster = monster;
        _monsterPatrol = mPatrol;
    }

    public void Chase(int targetRow, int targetCol)
    {
        // Get monster position
        (int row, int col) monsterPos = _monster.GetPosition();
        // Console.WriteLine($"Monster: ({monsterPos.row}, {monsterPos.col})");
        // Console.WriteLine($"Player: ({targetRow}, {targetCol})");

        if (_monster.IsNearPlayer(targetRow, targetCol, out int rowGap, out int colGap))
        {
            // Console.WriteLine("Still within alert distance!");
            _monster.SetPatrolState();
            
            // What path should the monster take (row or col)
            if (Math.Abs(rowGap) >= Math.Abs(colGap))
            {
                // row gap is smaller so take smallest path
                monsterPos.row += Math.Sign(rowGap);
            }
            else
            {
                monsterPos.col += Math.Sign(colGap);
            }

            _lastSeenPosRow = monsterPos.row;
            _lastSeenPosCol = monsterPos.col;
            // Console.WriteLine($"Row gap: {rowGap}, Column gap: {colGap}");
            // Console.WriteLine($"Calculated position: ({monsterPos.row}, {monsterPos.col})");
            _monster.SetPosition(monsterPos.row, monsterPos.col);
        }
        else
        {
            // Console.WriteLine("Player outside alert distance!");
            _monster.SetSearchState();
            Search();
        }
    }

    public void Search()
    {
        (int distance, (int row, int col) closestPoint) = _monsterPatrol.GetClosestPoint();

        _returnTargetRow = closestPoint.row;
        _returnTargetCol = closestPoint.col;

        _monster.SetReturnToPatrolState();
    }

    public void ReturnToPatrol()
    {
        (int monsterPosRow, int monsterPosCol) = _monster.GetPosition();
        (int distance, (int row, int col) targetPoint) = _monsterPatrol.GetClosestPoint();

        int distanceToTravelCol = targetPoint.col - monsterPosCol;
        int distanceToTravelRow = targetPoint.row - monsterPosRow;

        if (Math.Abs(distanceToTravelCol) >= Math.Abs(distanceToTravelRow))
        {
            monsterPosCol += Math.Sign(distanceToTravelCol);
        }
        else
        {
            monsterPosRow += Math.Sign(distanceToTravelRow);
        }

        _monster.SetPosition(monsterPosRow, monsterPosCol);

        if (monsterPosRow == _returnTargetRow && monsterPosCol == _returnTargetCol)
        {
            _monster.SetPatrolState();
        }
    }

}