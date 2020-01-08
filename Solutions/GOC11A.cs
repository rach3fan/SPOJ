using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Solution to "GOC11A - Appending String"  SPOJ.com classical problem 
// http://www.spoj.com/problems/GOC11A/

public static class GOC11A
{
    public static void Solve()
    {
        var remainingTestCases = int.Parse(Console.ReadLine());
        var results = new List<Tuple<string, List<int>>>();

        while (remainingTestCases-- > 0)
        {
            string forAppend = Console.ReadLine();
            int remainingQueries = int.Parse(Console.ReadLine());
            var queries = new List<int>();

            while (remainingQueries-- > 0)
            {
                queries.Add(int.Parse(Console.ReadLine()));
            }

            var charactersForAppend = forAppend.ToCharArray();
            string afterAppend = Append(charactersForAppend);

            results.Add(new Tuple<string, List<int>>(afterAppend, queries));
        }
        Print(results);
    }

    public static string Append(char[] charactersForAppend)
    {
        string underConstruction = null;
        for (int i = 0; i < charactersForAppend.Length - 1; i++)
        {
            bool isDigit = char.IsDigit(charactersForAppend[i]);
            if (isDigit == false)
            {
                underConstruction += (charactersForAppend[i]);
            }
            else
            {
                if (charactersForAppend[i].Equals(0))
                {
                    underConstruction = string.Empty;
                }
                else
                {
                    underConstruction = string.Concat(Enumerable.Repeat(
                            underConstruction, int.Parse(charactersForAppend[i].ToString())));
                }
            }
        }
        return underConstruction;
    }

    public static void Print(List<Tuple<string, List<int>>> results)
    {
        foreach (var result in results)
        {
            for (int i = 0; i < result.Item2.Count; i++)
            {
                if (result.Item2[i] <= result.Item1.Length)
                {
                    Console.WriteLine(result.Item1.ElementAt(result.Item2[i] - 1));
                }
                else
                {
                    Console.WriteLine("-1");
                }
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

