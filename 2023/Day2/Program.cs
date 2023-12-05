
using Day2;

int resultSum = 0;
var data = File.ReadAllLines("../../../Day2_Input.txt");

var configSet = new GameSet() {Red = 12, Blue = 14, Green = 13};

var games = new List<Bag>();
var allGames = new List<Bag>();

// Part 1
foreach (var game in data)
{
    var bag = Bag.ParseGame(game);
    allGames.Add(bag);
    if (bag.CheckIfGameIsValid(bag, configSet))
    {
        games.Add(bag);
    }
}

resultSum = games.Sum(x => x.ID);

Console.WriteLine($"Ergebnis Part 1: {resultSum}");

// Part 2

foreach (var game in allGames)
{
    game.CalcMinimumSet();
}

resultSum = 0;
resultSum = allGames.Sum(x => x.MinimumSet.Red * x.MinimumSet.Blue * x.MinimumSet.Green);

Console.WriteLine($"Ergebnis Part 2: {resultSum}");
