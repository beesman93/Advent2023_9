List<string> lines = new();
using (StreamReader reader = new(args[0]))
    while (!reader.EndOfStream)
        lines.Add(reader.ReadLine()??"");

solve(false);
solve(true);

void solve(bool part2)
{
    int runTotal = 0;
    foreach (string line in lines)
    {
        int curr = 0;
        var hh = line.Split(' ');

        List<List<int>> history = new(){new()};
        foreach (var h in hh)
            history.First().Add(int.Parse(h));

        if (part2) history[0].Reverse();

        bool zeroes = false;
        for(int depth = 0;!zeroes;depth++)
        {
            history.Add(new());
            zeroes = true;
            for (int i = 1; i < history[depth].Count; i++)
            {
                int diff = history[depth][i] - history[depth][i - 1];
                if (diff!=0) zeroes = false;
                history[depth+1].Add(diff);
            }
        }

        for (int i = history.Count - 2; i >= 0; i--)
        {
            int lastDiff = history[i].Last() + history[i + 1].Last();
            history[i].Add(lastDiff);
            if (i == 0) curr += lastDiff;
        }
        runTotal += curr;
    }
    Console.WriteLine(runTotal);
}