namespace Day4;

public class Part1
{
    public int CalcPoints(List<Card> cards)
    {
        
        cards.ForEach(c =>
        {
            c.WinningNumbers.ForEach(w =>
            {
                c.Numbers.ForEach(n =>
                {
                    if (w == n) c.Count++;
                });
            });
            
            for (int i = 1; i <= c.Count; i++)
            {
                if (c.Points == 0)
                {
                    c.Points+= 1;
                }
                else
                {
                    c.Points *= 2;
                }
            }
        });

        return cards.Sum(c => c.Points);

    }
}