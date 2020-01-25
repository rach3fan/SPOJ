using System;
using System.Collections.Generic;
using System.Linq;

public static class GMSTRE
{
    // Solution to "GMSTRE - Game Store"  SPOJ.com classical problem 
    // http://www.spoj.com/problems/GMSTRE/

    public static void Solve(List<(int health, int enemies, int ammo, int levelIndex)> levels)
    {
        int easiestLevel, hardestLevel;

        if (levels.Count == 1)
        {
            easiestLevel = hardestLevel = 1;
        }
        else
        {
            easiestLevel = FindLevel(levels, true);
            hardestLevel = FindLevel(levels, false);
        }
        Print(easiestLevel, hardestLevel);
    }

    static int FindLevel(List<(int health, int enemies, int ammo, int originalIndex)> levels, bool isEasiest)
    {
        if (isEasiest) { levels.Sort((x, y) => y.health.CompareTo(x.health)); }
        else { levels.Sort((x, y) => x.health.CompareTo(y.health)); }

        int soughtLevel;
        int newIndex = 0;

        int dataToCompare = levels[newIndex].health;
        bool isHealthPointsEqual = dataToCompare == levels[newIndex + 1].health;

        if (isHealthPointsEqual)
        {
            var candidateLevels = new List<(int health, int enemies, int ammo, int index)>
            {
                levels[newIndex]
            };

            while (newIndex + 1 < levels.Count)
            {
                if (isHealthPointsEqual)
                {
                    candidateLevels.Add(levels[newIndex + 1]);
                }
                else
                {
                    break;
                }
                newIndex++;
            }

            if (isEasiest) { candidateLevels.Sort((x, y) => x.enemies.CompareTo(y.enemies)); }
            else { candidateLevels.Sort((x, y) => y.enemies.CompareTo(x.enemies)); }

            bool isEnemiesCountEqual = candidateLevels[0].enemies == candidateLevels[1].enemies;
            if (isEnemiesCountEqual)
            {
                dataToCompare = candidateLevels[0].enemies;

                Reset:
                foreach (var level in candidateLevels)
                {
                    if (dataToCompare != level.enemies)
                    {
                        candidateLevels.Remove(level);
                        goto Reset;
                    }
                }

                if (isEasiest) { candidateLevels.Sort((x, y) => y.ammo.CompareTo(x.ammo)); }
                else { candidateLevels.Sort((x, y) => x.ammo.CompareTo(y.ammo)); }

                soughtLevel = candidateLevels[0].index;
            }
            else
            {
                soughtLevel = candidateLevels[0].index;
            }
        }
        else
        {
            soughtLevel = levels[0].originalIndex;
        }
        return soughtLevel;
    }

    static void Print(int theEasiestLevel, int theHardestLevel)
    {
        Console.WriteLine(
            theHardestLevel == theEasiestLevel ? $"Easiest and Hardest is level {theEasiestLevel}" :
            $"Easiest is level {theEasiestLevel + 1}\nHardest is level { theHardestLevel + 1 }"
            );

        Console.ReadKey();
    }
}

class Program
{
    static void Main()
    {
        var levels = new List<(int health, int enemies, int ammo, int originalIndex)>();

        var index = 0;
        int remainingLevels = int.Parse(Console.ReadLine());

        while (remainingLevels-- > 0)
        {
            string[] input = Console.ReadLine().Split();

            (int health, int enemies, int ammo, int originalIndex) levelData = (
                int.Parse(input[0]),
                int.Parse(input[1]),
                int.Parse(input[2]),
                index);

            levels.Add(levelData);
            index++;
        }
        GMSTRE.Solve(levels);
    }
}
