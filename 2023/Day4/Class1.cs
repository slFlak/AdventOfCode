
using Day4;

var data = File.ReadAllLines("../../../Day4_Input.txt").ToList();
var cards = new List<Card>();

data.ForEach(c =>
{
    var card = new Card();
    var test = c.Split(':')[0].Replace("Card ", "");
    card.Id = int.Parse(test);
    c.Trim().Split(':')[1].Split(" | ")[0].Split(' ').ToList().ForEach(n =>
    {
        if (n != "")
        {
            card.WinningNumbers.Add(int.Parse(n));
        }
    });
    c.Split(':')[1].Split(" | ")[1].Split(' ').ToList().ForEach(n =>
    {
        if (n != "")
        {
            card.Numbers.Add(int.Parse(n));
        }
    });
    cards.Add(card);
});

var part1 = new Part1();
var result = part1.CalcPoints(cards);

Console.WriteLine($"Part 1: {result}");

var part2 = new Part2(cards);
var result2 = part2.CountInstances(cards);

Console.WriteLine($"Part 2: {result2}");