using System;
using System.Collections.Generic;
using System.Linq;

// Solution to "GOC11A - Appending String"  SPOJ.com classical problem 
// http://www.spoj.com/problems/GOC11A/

public static class GOC11A
{
    public static void Solve()
    {
        var remainingTestCases = int.Parse(Console.ReadLine());
        var results = new List<(string afterAppend, List<int> queries)>();

        while (remainingTestCases-- > 0)
        {
            string lineForAppend = Console.ReadLine();
            int remainingQueries = int.Parse(Console.ReadLine());
            var queries = new List<int>();

            while (remainingQueries-- > 0)
            {
                queries.Add(int.Parse(Console.ReadLine()));
            }

            var charactersForAppend = lineForAppend.ToCharArray();
            string lineAfterAppend = Append(charactersForAppend);

            results.Add((lineAfterAppend, queries));
        }
        Print(results);
    }

    public static string Append(char[] charactersForAppend)
    {
        string lineUnderConstruction = null;
        for (int i = 0; i < charactersForAppend.Length - 1; i++)
        {
            bool isDigit = char.IsDigit(charactersForAppend[i]);
            if (isDigit)
            {
                if (charactersForAppend[i].Equals(0))
                {
                    lineUnderConstruction = string.Empty;
                }
                else
                {
                    lineUnderConstruction = string.Concat(Enumerable.Repeat(
                            lineUnderConstruction, int.Parse(charactersForAppend[i].ToString())));
                }
            }
            else
            {
                lineUnderConstruction += charactersForAppend[i];
            }
        }
        return lineUnderConstruction;
    }

    public static void Print(List<(string afterAppend, List<int> queries)> results)
    {
        foreach (var result in results)
        {
            for (int i = 0; i < result.queries.Count; i++)
            {
                Console.WriteLine(result.queries[i] <= result.afterAppend.Length ?
                   result.afterAppend.ElementAt(result.queries[i] - 1) : -1);
            }
        }
        Console.ReadKey();
    }
}

class Program
{
    static void Main()
    {
        GOC11A.Solve();
    }
}

