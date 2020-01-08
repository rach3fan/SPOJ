using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Solution to "UCBINTF - Music Academy"  SPOJ.com classical problem 
// http://www.spoj.com/problems/UCBINTF/

public static class UCBINTF
{
    public static string Solve(List<string> melody)
    {
        int mood = 0;
        List<char> mainTones = GetMainTones(melody);

        foreach (var tone in mainTones)
        {
            mood = (tone == 'C' || tone == 'F' || tone == 'G') ? ++mood : --mood;
        }

        string scale;
        if (mood > 0)
        {
            scale = "C-dur";
        }
        else if (mood < 0)
        {
            scale = "A-mol";
        }
        else
        {
            string lastMeasure = melody.Last();
            scale = GetLastToneScale(lastMeasure);
        }
        return scale;
    }

    static List<char> GetMainTones(List<string> melody)
    {
        var mainTones = new List<char>();

        foreach (var measure in melody)
        {
            if (measure.ElementAt(0) != 'B')
            {
                mainTones.Add(measure.ElementAt(0));
            }
        }
        return mainTones;
    }

    static string GetLastToneScale(string lastMeasure)
    {
        return (lastMeasure.Last() == 'C') ? "C-dur" : "A-mol";
    }
}

class Program
{
    protected static TextReader reader;
    protected static TextWriter writer;

    static void Main()
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        List<string> melody = reader.ReadLine().Split('|').ToList();
        writer.WriteLine(UCBINTF.Solve(melody));

        reader.Close();
        writer.Close();
        Console.ReadKey();
    }
}

