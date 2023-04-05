// See https://aka.ms/new-console-template for more information

var elfes = new List<int>();

var input = File.ReadLines(@"../../../Day1_Input.txt").ToList();

var elfSum = 0;

for (int i = 0; i < input.Count(); i++)
{
    if (input[i] == "")
    {
        elfes.Add(elfSum);
        elfSum = 0;
    }
    else
    {
        elfSum += int.Parse(input[i]);    
    }
}

int top1 = 0;
int top2 = 0;
int top3 = 0;

foreach (var elfe in elfes)
{
    if (elfe > top1)
    {
        top3 = top2;
        top2 = top1;
        top1 = elfe;
    }
    else if (elfe > top2)
    {
        top3 = top2;
        top2 = elfe;
    }
    else if (elfe > top3)
    {
        top3 = elfe;
    }
}

Console.WriteLine($"Top 1 Elf: {top1}");
Console.WriteLine($"Top 3 Elf Sum: {top1 + top2 + top3}");


