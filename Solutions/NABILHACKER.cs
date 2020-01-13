using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Solution to "NABILHACKER - Hack the Password"  SPOJ.com classical problem 
// https://www.spoj.com/problems/NABILHACKER/

public static class NABILHACKER
{
    public static char[] Solve(char[] input)
    {
        Stack<char> solutionStack = new Stack<char>();
        Stack<char> temporaryStack = new Stack<char>();

        int inputLength = input.Length;
        int index = 0;
        while (index < inputLength)
        {
            char current = input[index];
            switch (current)
            {
                case '<':
                    if (IsStackNotEmpty(solutionStack) && IsInputNotFinished(index,inputLength))
                    {
                        temporaryStack.Push(solutionStack.Pop());
                    }
                    break;

                case '>':
                    if (IsStackNotEmpty(temporaryStack))
                    {
                        solutionStack.Push(temporaryStack.Pop());
                    }
                    break;

                case '-':
                    if (IsStackNotEmpty(solutionStack))
                    {
                        solutionStack.Pop();
                    }
                    break;

                default:
                    solutionStack.Push(current);
                    break;
            }
            index++;
        }

        if (IsStackNotEmpty(temporaryStack))
        {
            foreach (var ch in temporaryStack)
            {
                solutionStack.Push(ch);
            }
        }
        return solutionStack.Reverse().ToArray();
    }

    static bool IsStackNotEmpty(Stack<char> stack)
    {
        return (stack.Count != 0) ? true : false;
    }

    static bool IsInputNotFinished(int index, int inputLength)
    {
        return (index != inputLength - 1) ? true : false;
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

        int remainingTestCases = int.Parse(reader.ReadLine());

        while (remainingTestCases-- > 0)
        {
            char[] input = reader.ReadLine().ToArray();
            char[] output = NABILHACKER.Solve(input);

            foreach (var ch in output)
            {
                writer.Write(ch);
            }
            writer.WriteLine();
        }
        reader.Close();
        writer.Close();
        Console.ReadKey();
    }
}

