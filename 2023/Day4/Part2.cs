/// Provides access to system debugging services like EventLog, PerformanceCounter, Process, Stopwatch etc. This namespace is primarily used for logging and performance monitoring.
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace Day4;

public class Part2
{
    private List<Card> _cards;
    private int _instanzes;
    
    public Part2(List<Card> cards)
    {
        _cards = cards;
    }
    public int CountInstances(List<Card> cards)
    {
        cards.ForEach(c => { Count(c); });
        return _instanzes;
    }

    private void Count(Card card)
    {
        _instanzes++;
        for (int i = 1; i <= card.Count; i++)
        {
            if (card.Id + i <= _cards.Count) Count(_cards[card.Id + i - 1]);
        }
    }
}