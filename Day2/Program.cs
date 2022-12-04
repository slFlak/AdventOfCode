// See https://aka.ms/new-console-template for more information

int score = 0;
var options = new string[,] {{"A", "X"}, {"B", "Y"}, {"C", "Z"}};

var rounds = File.ReadLines(@"C:\Users\MSeib\RiderProjects\AdventOfCode\Day2\Day2_Input.txt");
var winCondition = new int[] { -1, 2 };

foreach (var round in rounds)
{
    var enemy = round[0];
    var me = round[2];

    int enemyIndex = 0;
    int myIndex = 0;
    
    for (int i = 0; i < options.GetLength(0); i++)
    {
        if (options[i, 0] == enemy.ToString())
        {
            enemyIndex = i + 1;
        }
        if (options[i, 1] == me.ToString())
        {
            myIndex = i + 1;
        }
    }

    // 1 = Stone, 2 = Paper, 3 = Scissors
    // 1 - 2 = -1 -> I win
    // 2 - 3 = -1 -> I win
    // 1 - 3 = -2 -> Enemy wins
    // 3 - 1 = 2 -> I win
    // 2 - 1 = 1 -> Enemy wins
    // 3 - 2 = 1 -> Enemy wins
    // 3 - 3 = 0 -> draw
    // 2 - 2 = 0 -> draw
    // 1 - 1 = 0 -> draw

    var result = enemyIndex - myIndex;
    
    if (winCondition.Contains(result))
    {
        score = score + 6;
    }
    else if (result == 0)
    {
        score = score + 3;
    }

    score = score + myIndex;
}

Console.WriteLine($"Part 1 Score: {score}");

// Part 2 

//X = Loose, Y = Draw, Z = Win

foreach (var round in rounds)
{
    var enemy = round[0];
    var outcome = round[2];
    
    int enemyIndex = 0;
    int myIndex = 0;

    string me = string.Empty;
    
    for (int i = 0; i < options.GetLength(0); i++)
    {
        if (options[i, 0] == enemy.ToString())
        {
            enemyIndex = i + 1;
        }
    }
    
    // 1 = Stone, 2 = Paper, 3 = Scissors
    // 1 - 2 = -1 -> I win
    // 2 - 3 = -1 -> I win
    // 1 - 3 = -2 -> Enemy wins
    // 3 - 1 = 2 -> I win
    // 2 - 1 = 1 -> Enemy wins
    // 3 - 2 = 1 -> Enemy wins
    // 3 - 3 = 0 -> draw
    // 2 - 2 = 0 -> draw
    // 1 - 1 = 0 -> draw

    var result = enemyIndex - myIndex;
    
    if (winCondition.Contains(result))
    {
        score = score + 6;
    }
    else if (result == 0)
    {
        score = score + 3;
    }

    score = score + myIndex;
}

Console.WriteLine($"Part 1 Score: {score}");