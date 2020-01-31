using System;
using System.IO;
using System.Text.RegularExpressions;

// Solution to "SIGNPOST - Signpost reading" SPOJ.com classical problem 
// http://www.spoj.com/problems/SIGNPOST/

public static class SIGNPOST
{
    public static string Solve(string leftDirection, string rightDirection)
    {
        return leftDirection == "dragon" ?
            $"Right, to the {rightDirection}!" :
            $"Left, to the {leftDirection}!";
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

        string beginOfPattern = "Left to ";
        var pattern = new Regex(
            @"^(Left to (?<left>[a-zA-Z]+?)\. Right to (?<right>[a-zA-Z]+?)\.$)",
            RegexOptions.Compiled);

        string[] lines = reader
            .ReadToEnd()
            .Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            if (line.StartsWith(beginOfPattern))
            {
                var match = pattern.Match(line);
                if (match.Success)
                {
                    string leftDirection = match.Groups["left"].Value;
                    string rightDirection = match.Groups["right"].Value;
                    
                    bool isSignpostValid =
                        (leftDirection == "dragon" || rightDirection == "dragon")
                        && leftDirection != rightDirection;
                    
                    if (isSignpostValid)
                    {
                        writer.WriteLine(SIGNPOST.Solve(leftDirection, rightDirection));
                    }
                }
            }
        }
        reader.Close();
        writer.Close();
        Console.ReadKey();
    }
}