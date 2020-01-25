using System;
using System.Collections.Generic;
using System.Linq;

// Solution to "UCBINTG - Archipelago"  SPOJ.com classical problem 
// http://www.spoj.com/problems/UCBINTG/

public static class UCBINTG
{
    public static void Solve(int height, int width)
    {
        var map = PrepareMap(height, width);
        var futureMap = (char[,])map.Clone();
        var dryLandHeights = new List<int>();
        var dryLandWidths = new List<int>();

        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                if (char.IsLetter(map[i, j]))
                {
                    int sidesSurroundedBySea = 0;
                    if (IsSurroundedBySea(map[i - 1, j])) sidesSurroundedBySea++;
                    if (IsSurroundedBySea(map[i, j + 1])) sidesSurroundedBySea++;
                    if (IsSurroundedBySea(map[i + 1, j])) sidesSurroundedBySea++;
                    if (IsSurroundedBySea(map[i, j - 1])) sidesSurroundedBySea++;

                    bool willBeFlooded = sidesSurroundedBySea > 2;
                    if (willBeFlooded)
                    {
                        futureMap.SetValue('.', i, j);
                    }

                    bool willRemainDry = sidesSurroundedBySea > 0 && sidesSurroundedBySea <= 2;
                    if (willRemainDry)
                    {
                        dryLandHeights.Add(i);
                        dryLandWidths.Add(j);
                    }
                }
            }
        }
        DrawFutureMap(futureMap, dryLandHeights, dryLandWidths);
    }

    static char[,] PrepareMap(int height, int width)
    {
        char[,] border = AddBorder(height + 2, width + 2);
        return FillBorder(border, height);
    }

    static char[,] AddBorder(int borderHeight, int borderWidth)
    {
        char[,] border = new char[borderHeight, borderWidth];

        for (int i = 0; i < borderHeight; i++)
        {
            for (int j = 0; j < borderWidth; j++)
            {
                border.SetValue('.', i, j);
            }
        }
        return border;
    }

    static char[,] FillBorder(char[,] border, int height)
    {
        for (int i = 1; i < height + 1; i++)
        {
            char[] mapLine = Console.ReadLine().ToCharArray();

            int j = 1;
            foreach (var ch in mapLine)
            {
                border.SetValue(ch, i, j);
                j++;
            }
        }
        return border;
    }

    static bool IsSurroundedBySea(char ch)
    {
        return char.IsLetter(ch) ? false : true;
    }

    static void DrawFutureMap(char[,] futureMap, List<int> dryLandHeights, List<int> dryLandWidths)
    {
        int maxHeightOfLand = dryLandHeights.Max();
        int minHeightOfLand = dryLandHeights.Min();
        int maxWidthOfLand = dryLandWidths.Max();
        int minWidthOfLand = dryLandWidths.Min();

        for (int i = minHeightOfLand; i < maxHeightOfLand + 1; i++)
        {
            for (int j = minWidthOfLand; j < maxWidthOfLand + 1; j++)
            {
                Console.Write(futureMap[i, j]);
            }
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        string[] input = Console.ReadLine().Split();

        int height = int.Parse(input[0]);
        int width = int.Parse(input[1]);

        UCBINTG.Solve(height, width);

        Console.ReadKey();
    }
}

