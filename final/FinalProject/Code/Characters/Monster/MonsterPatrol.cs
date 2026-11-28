public class MonsterPatrol
{
    public Monster _monster;
    private int _centerRow;
    private int _centerCol;
    private int _radiusRow;
    private int _radiusCol;
    private double _angle = 0;
    private double _step = 0.25;
    private List<(int, int)> _patrolPoints = new List<(int, int)>();

    public MonsterPatrol(Monster monster, int centerRow, int centerCol, int radiusRow, int radiusCol)
    {
        _monster = monster;
        _centerRow = centerRow;
        _centerCol = centerCol;
        _radiusRow = radiusRow;
        _radiusCol = radiusCol;

        CalculatePatrolPoints();
    }

    public List<(int, int)> GetPatrolPoints()
    {
        return _patrolPoints;
    }
    
    public void Patrol()
    {
        // Triangles tell us where a point is on a circle

        _angle += _step;

        // Cosine is X value -> links with columns
        // Cosine gives us the X value (col value)
        int col = _centerCol + (int)Math.Round(_radiusCol * Math.Cos(_angle)); // x

        // Sin is Y value -> links with rows
        // Sin gives us the Y value (row value)
        int row = _centerRow + (int)Math.Round(_radiusRow * Math.Sin(_angle)); // y

        _monster.SetPosition(row, col);
    }
    
    public void CalculatePatrolPoints()
    {
        // One full rotation is equivalent to 2 Pi radians (360 degrees)
        for (double angle = 0; angle <= Math.PI * 2; angle += _step)
        {
            int col = _centerCol + (int)Math.Round(_radiusCol * Math.Cos(angle));
            int row = _centerRow + (int)Math.Round(_radiusRow * Math.Sin(angle));

            // Skip the duplicate values
            if (!_patrolPoints.Contains((row,col)))
            {
                _patrolPoints.Add((row, col));
            }
        }
    }

    public (int, (int, int)) GetClosestPoint()
    {
        // Loop through and compare all row and col values to monster value and pick closest one
        (int monsterRow, int monsterCol) = _monster.GetPosition();
        (int row, int col) closestPoint = (0, 0);
        double closestDistance = double.MaxValue;

        for (int i = 0; i < _patrolPoints.Count; i++)
        {
            (int patrolRow, int patrolCol) = _patrolPoints[i];

            double distanceToPatrolPoint = CalculateDistance((monsterRow, monsterCol), (patrolRow, patrolCol));

            // Compare patrol point distance to closest distance
            if (distanceToPatrolPoint < closestDistance)
            {
                closestPoint = _patrolPoints[i];
                closestDistance = distanceToPatrolPoint;
            }
        }

        return ((int)closestDistance, closestPoint);
    }
    
    public double CalculateDistance((int row1, int col1) pos1, (int row2, int col2) pos2)
    {
        // Distance formula
        double distance = Math.Sqrt(
            Math.Pow(pos2.col2 - pos1.col1, 2) +
            Math.Pow(pos2.row2 - pos1.row1, 2));

        return distance;
    }
}