
public class Monster : Character
{
    private Map _map;
    private MonsterAction _monsterAction;
    private MonsterPatrol _monsterPatrol;
    private int _alertDistance = 2;

    // private List<(int, int)> _patrolPoints;

    private DateTime _lastMoveTime = DateTime.Now;

    private enum MonsterState
    {
        Patrol,
        Chase,
        Search,
        ReturnToPatrol
    }

    private MonsterState _currentMonsterState = MonsterState.Patrol;

    public Monster(Map map)
    {
        _map = map;


        (int rowAmt, int colAmt) = _map.GetRowColPos();
        _monsterPatrol = new MonsterPatrol(this, rowAmt / 2, colAmt / 2, 4, 7);
        _monsterPatrol.Patrol();

        _monsterAction = new MonsterAction(this, _monsterPatrol);
    }

    // public Monster()
    // {
    //     // for testing
    // }

    public Enum GetCurrentMonsterState()
    {
        return _currentMonsterState;
    }

    public bool IsPatrolling()
    {
        return _currentMonsterState == MonsterState.Patrol;
    }

    public bool IsChasing()
    {
        return _currentMonsterState == MonsterState.Chase;
    }

    public bool IsSearching()
    {
        return _currentMonsterState == MonsterState.Search;
    }

    public bool IsReturningToPatrol()
    {
        return _currentMonsterState == MonsterState.ReturnToPatrol;
    }

    public DateTime GetTimeNow()
    {
        return _lastMoveTime;
    }

    public void SetPatrolState()
    {
        _currentMonsterState = MonsterState.Patrol;
    }

    public void SetChaseState()
    {
        _currentMonsterState = MonsterState.Chase;
    }

    public void SetSearchState()
    {
        _currentMonsterState = MonsterState.Search;
    }

    public void SetReturnToPatrolState()
    {
        _currentMonsterState = MonsterState.ReturnToPatrol;
    }

    public void UpdateBehavior(int targetRow, int targetCol)
    {
        if (_currentMonsterState == MonsterState.Patrol)
        {
            if (IsNearPlayer(targetRow, targetCol, out int rowGap, out int colGap))
            {
                // Console.WriteLine("Chase method called");
                _monsterAction.Chase(targetRow, targetCol);
            }
            else
            {
                _monsterPatrol.Patrol();
            }
        }
        else if (_currentMonsterState == MonsterState.Chase)
{
            // Console.WriteLine("Entering Chase branch");
            _monsterAction.Chase(targetRow, targetCol);
            // Console.WriteLine("Chasing");
}
        else if (_currentMonsterState == MonsterState.Search)
        {
            _monsterAction.Search();
        }
        else if (_currentMonsterState == MonsterState.ReturnToPatrol)
        {
            _monsterAction.ReturnToPatrol();
        }
    }

    public bool IsNearPlayer(int targetRow, int targetCol, out int rowGap, out int colGap) // y, x
    {
        // Get monster position
        (int row, int col) monsterPos = GetPosition();

        // Calculate distance to player
        // target minus monster = direction from monster to player
        // start with where you want to go (the target)
        rowGap = targetRow - monsterPos.row; // y
        colGap = targetCol - monsterPos.col; // x

        // Pythagorean Theorum (straight line distance)
        double distance = Math.Sqrt(Math.Pow(rowGap, 2) + Math.Pow(colGap, 2));

        // Return whether distance is within alert distance
        return distance < _alertDistance;
    }


    public override void Interact()
    {

    }
}
