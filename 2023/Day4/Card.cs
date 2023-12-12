namespace Day4;

public class Card
{
    public int Id { get; set; }
    public List<int> WinningNumbers { get; set; }
    public List<int> Numbers { get; set; }

    public Card()
    {
        WinningNumbers = new List<int>();
        Numbers = new List<int>();
    }
    public int Points { get; set; }
    public int Count { get; set; }
}