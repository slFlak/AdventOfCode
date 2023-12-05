// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using System.Text.RegularExpressions;

var data = File.ReadLines("../../../Day1.txt");
var results = new List<string>();
int sum = 0;

// Part 1 
sum = CalcSum(data, results);

Console.WriteLine($"Ergebnis Teil 1: {sum}");

// Part 2 
sum = 0;

sum = uppingTheAnte(File.ReadAllText("../../../Day1.txt"), true); // CalcSum(data2, results);

// Fremdlösung
Console.WriteLine($"Ergebnis Teil 2: {sum}");

// Eigene Lösung
sum = 0;
results.Clear();
var data2 = new List<string>();

foreach (var line in data)
{
    data2.Add(DestringifySpelledOutNumber(line));
}

sum = CalcSum(data2, results);

int CalcSum(IEnumerable<string> enumerable, List<string> list)
{
    int sum1 = 0;
    foreach (var line in enumerable)
    {
        string firstNumberAsString = string.Empty;
        string lastNumberAsString = string.Empty;
        string finalNumberAsString = string.Empty;
        
        // left to right
        for (int i = 0; i < line.Length; i++ )
        {
            if (int.TryParse(line.Substring(i, 1), out var number))
            {
                firstNumberAsString = line.Substring(i, 1);
                break;
            }
        }

        // right to left
        for (int i = line.Length - 1; i >= 0; i--)
        {
            if (int.TryParse(line.Substring(i, 1), out var number))
            {
                lastNumberAsString = line.Substring(i, 1);
                break;
            }
        }

        finalNumberAsString = string.Concat(firstNumberAsString, lastNumberAsString); // firstNumberAsString + lastNumberAsString;
        list.Add(finalNumberAsString);
    }

    foreach (var result in list)
    {
        if (int.TryParse(result, out var number))
        {
            sum1 += number;
        }
    }
    return sum1;
}

string DestringifySpelledOutNumber(string line)
{
    var result = line;
    result = result.Replace("three", "three3three");
    result = result.Replace("eight", "eight8eight");
    result = result.Replace("two", "two2two");
    result = result.Replace("one", "one1one");
    result = result.Replace("four", "four4four");
    result = result.Replace("five", "five5five");
    result = result.Replace("six", "six6six");
    result = result.Replace("seven", "seven7seven");
    result = result.Replace("nine", "nine9nine");
    
    return result;
}

int uppingTheAnte(string input, bool partTwo) {
    var variableOne = new Dictionary<string, int> {
        { "0"    , 0 },
        { "one"  , 1 },
        { "two"  , 2 },
        { "three", 3 },
        { "four" , 4 },
        { "five" , 5 },
        { "six"  , 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine" , 9 },
        { "1"    , 1 },
        { "2"    , 2 },
        { "3"    , 3 },
        { "4"    , 4 },
        { "5"    , 5 },
        { "6"    , 6 },
        { "7"    , 7 },
        { "8"    , 8 },
        { "9"    , 9 }, 
    };
    return input.
        Trim().
        ReplaceLineEndings().
        Split($"{Environment.NewLine}").
        Select(s => variableOne[Regex.Matches(s, "[0-9]|one|two|three|four|five|six|seven|eight|nine").
            FirstOrDefault(x => partTwo || int.TryParse(x.Value, out var _))?.Value ?? "0"] * 10 + variableOne[Regex.Matches(s, "[0-9]|one|two|three|four|five|six|seven|eight|nine", RegexOptions.RightToLeft).
            FirstOrDefault(x => partTwo || int.TryParse(x.Value, out var _))?.Value ?? "0"]).
        Sum();
}