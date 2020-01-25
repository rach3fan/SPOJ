using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


// Solution to "SHAKILKEYWORD - Keyword Finder"  SPOJ.com classical problem 
// http://www.spoj.com/problems/SHAKILKEYWORD/

public static class SHAKILKEYWORD
{
    public static List<string> Solve(List<string[]> lines)
    {
        var keywords = new List<string>();
        foreach (var line in lines)
        {
            int hashCount = 0;
            foreach (var word in line)
            {
                if (word.Contains("#"))
                {
                    keywords.Add(word);
                    hashCount++;
                }
            }

            if (hashCount == 0)
            {
                keywords.Add("No keywords.");
            }
        }
        return keywords;
    }
}

class Program
{
    protected static TextReader reader;
    protected static TextWriter writer;

    static readonly char[] splitCharacters = { '|', '$', ' ', '*', '@', '.', '&', '\\', '"', '!', '^', ',', '?' };

    static void Main()
    {
        reader = new StreamReader(Console.OpenStandardInput());
        writer = new StreamWriter(Console.OpenStandardOutput());

        int remainingTestCases = int.Parse(reader.ReadLine());
        var lines = new List<string[]>();

        while (remainingTestCases-- > 0)
        {
            var line = reader.ReadLine().Split(splitCharacters);
            lines.Add(line);
        }

        foreach (var keyword in SHAKILKEYWORD.Solve(lines))
        {
            writer.WriteLine(keyword);
        }
        reader.Close();
        writer.Close();
    }
}
