using System.Diagnostics;
using System.Text.RegularExpressions;

List<string> lines = new();
using (StreamReader reader = new(args[0]))
{
    while (!reader.EndOfStream)
    {
        lines.Add(reader.ReadLine());
    }
}

part1();
part2();

void part1()
{
    int runTotal = 0;


    foreach (string line in lines.Skip(0))
    {
        int curr = 0;

        var hh = line.Split(' ');

        List<List<int>> history = new();
        history.Add(new List<int>());
        foreach(var h in hh)
            history[0].Add(int.Parse(h));

        int depth = 0;

        bool zeroes = false;
        while (!zeroes)
        {
            history.Add(new List<int>());
            zeroes = true;
            for (int i = 1; i < history[depth].Count(); i++)
            {
                int diff = history[depth][i] - history[depth][i - 1];
                if (diff!=0)
                {
                    zeroes = false;
                }
                history[depth+1].Add(diff);
            }
            depth++;
        }

        history.Last().Add(0);
        for (int i = history.Count - 2; i >= 0; i--)
        {
            int lastDiff = history[i].Last() + history[i + 1].Last();
            history[i].Add(lastDiff);
            if(i==0)
                curr += lastDiff;
        }
        runTotal += curr;
    }

    Console.WriteLine(runTotal);
}

void part2()
{
    int runTotal = 0;


    foreach (string line in lines.Skip(0))
    {
        int curr = 0;

        var hh = line.Split(' ');

        List<List<int>> history = new();
        history.Add(new List<int>());
        foreach (var h in hh)
            history[0].Add(int.Parse(h));

        int depth = 0;

        bool zeroes = false;
        while (!zeroes)
        {
            history.Add(new List<int>());
            zeroes = true;
            for (int i = 1; i < history[depth].Count(); i++)
            {
                int diff = history[depth][i] - history[depth][i - 1];
                if (diff != 0)
                {
                    zeroes = false;
                }
                history[depth + 1].Add(diff);
            }
            depth++;
        }

        history.First().Add(0);
        for (int i = history.Count - 2; i >= 0; i--)
        {
            int lastDiff = history[i].First() - history[i + 1].First();
            history[i].Insert(0,lastDiff);
            if (i == 0)
                curr += lastDiff;
        }
        runTotal += curr;
    }

    Console.WriteLine(runTotal);
}