public class MapHandler
{
    private Dictionary<string, Map> _maps = new Dictionary<string, Map>();

    public MapHandler()
    {
    }

    public void GenerateMap(string mapName, int rowAmt, int colAmt, bool isMainMap = false)
    {
        string lowerMapName = mapName.ToLower();

        // Create Map object
        Map map = new Map(lowerMapName, rowAmt, colAmt, isMainMap);

        _maps[lowerMapName] = map;
    }

    public void DisplayMap(string mapName)
    {
        _maps[mapName.ToLower()].Display();
    }

    public Map GetMap(string mapName)
    {
        return _maps[mapName.ToLower()];
    }
}