using System;
using System.Collections.Generic;
using System.Linq;

// Solution to "DRAWM - Draw Mountains"  SPOJ.com classical problem
// https://www.spoj.com/problems/DRAWM/

public static class DRAWM
{
    static char Symbol { get; set; }
    static int Position { get; set; }

    public static void Solve((int length, int[] heights) skyline)
    {
        int mountainMaxHeight = skyline.heights.Max() + 2;
        var mountain = new List<char>[mountainMaxHeight];
        Position = mountain.Length - skyline.heights[0] - 1;

        for (int i = 0; i < skyline.length; i++)
        {
            int heightDifference = skyline.heights[i + 1] - skyline.heights[i];
            char nextSymbol = heightDifference < 0 ? '\\' : heightDifference == 0 ? '_' : '/';
            int nextPosition;
            switch (nextSymbol)
            {
                case '\\':
                    nextPosition = (Symbol == '\\' || Symbol == '_') ? Position + 1 : Position;
                    AddSymbol(mountain, nextPosition, nextSymbol, i);
                    break;

                case '_':
                    nextPosition = Symbol == '/' ? Position - 1 : Position;
                    AddSymbol(mountain, nextPosition, nextSymbol, i);
                    break;

                case '/':
                    nextPosition = Symbol == '/' ? Position - 1 : Position;
                    AddSymbol(mountain, nextPosition, nextSymbol, i);
                    break;
            }
        }
        Draw(mountain);
    }
    public static void AddSymbol(List<char>[] mountain, int nextPosition, char nextSymbol, int i)
    {
        if (mountain[nextPosition] == null)
        {
            mountain[nextPosition] = new List<char>();
        }

        for (int j = mountain[nextPosition].Count; j < i; j++)
        {
            mountain[nextPosition].Add(' ');
        }

        mountain[nextPosition].Add(nextSymbol);
        Symbol = nextSymbol;
        Position = nextPosition;
    }

    public static void Draw(List<char>[] mountain)
    {
        for (int i = 0; i < mountain.Length; i++)
        {
            if (mountain[i] != null)
            {
                for (int j = 0; j < mountain[i].Count; j++)
                {
                    Console.Write(mountain[i][j]);
                }
                Console.WriteLine();
            }
        }
        Console.WriteLine("***");
    }
}
class Program
{
    static void Main()
    {
        var skylines = new List<(int length, int[] heights)>();

        while (true)
        {
            int skylineLength = int.Parse(Console.ReadLine());
            if (skylineLength == -1)
            {
                break;
            }

            int[] skylineHeights = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            skylines.Add((skylineLength, skylineHeights));
        }

        foreach (var skyline in skylines)
        {
            DRAWM.Solve(skyline);
        }
        Console.ReadKey();
    }
}