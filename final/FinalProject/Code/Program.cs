using System;

class Program
{
    static void Main(string[] args)
    {
        MapHandler maps = new MapHandler();

        maps.GenerateMap("Main", 15, 15, true);
        maps.GenerateMap("Side", 6, 6);

        Map mainMap = maps.GetMap("Main");
        Map sideMap = maps.GetMap("Side");

        Console.CursorVisible = false;
        Console.Clear();
        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                Console.WriteLine(key);
            }
            Console.SetCursorPosition(0, 0);

            // shows map
            mainMap.Display();

            // handles AI logic
            mainMap.MoveMonster();
            

            Thread.Sleep(16);
            // Console.Clear();
        }
        
    }
}