using System.Data.SqlTypes;

namespace Day2;

public class Bag
{
    public int ID { get; set; }
    public List<GameSet> GameSets { get; set; }
    public GameSet MinimumSet { get; set; }
    public bool IsValid { get; set; } = true;

    public static Bag ParseGame(string game)
    {
        Bag bag = new Bag();
        bag.GameSets = new List<GameSet>();
        bag.MinimumSet = new GameSet();
        
        // Beispiel 
        // Game 5: 7 blue, 4 red, 6 green; 2 red, 3 green, 6 blue; 11 blue, 1 red, 5 green
        
        // 1. Splitte nach Doppelpunkt
        var gameSplit = game.Split(":");
        bag.ID = int.Parse(gameSplit[0].Replace("Game ", "").Trim());

        // 2. Splitte nach Semikolon
        
        var gameSets = gameSplit[1].Split(";");

        foreach (var gameSet in gameSets)
        {
            // 3. Splitte nach Komma
            var cubes = gameSet.Split(",");
            
            // 4. Cubes auswerten und addieren

            foreach (var cube in cubes)
            {
                var set = new GameSet();
                var cubeData = cube.Trim().Split(" ");

                if (cubeData[1] == "red")
                { 
                    set.Red += int.Parse(cubeData[0]);
                }
                if (cubeData[1] == "blue")
                {
                    set.Blue += int.Parse(cubeData[0]);
                }
                if (cubeData[1] == "green")
                {
                    set.Green += int.Parse(cubeData[0]);
                }
                bag.GameSets.Add(set);
            }
        }
        
        return bag;
    }

    public bool CheckIfGameIsValid(Bag game, GameSet configSet)
    {
        foreach (var set in game.GameSets)
        {
            if(set.Red > configSet.Red || set.Blue > configSet.Blue || set.Green > configSet.Green)
            {
                IsValid = false;
            }
        }
        return IsValid;
    }

    public void CalcMinimumSet()
    {
        foreach (var set in GameSets)
        {
            if(set.Red > MinimumSet.Red) MinimumSet.Red = set.Red;
            if(set.Blue > MinimumSet.Blue) MinimumSet.Blue = set.Blue;
            if(set.Green > MinimumSet.Green) MinimumSet.Green = set.Green;
        }
    }
}