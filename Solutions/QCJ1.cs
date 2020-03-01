using System;
using System.Collections.Generic;
using System.Linq;

// Solution to "QCJ1 - Mountain Walking" SPOJ.com classical problem 
// http://www.spoj.com/problems/QCJ1/

public static class QCJ1
{
    static readonly List<char> steps = new List<char>();
    public static void Solve(List<char>[] mountain)
    {
        int heigth = mountain.Length - 1;
        int walkDistance = mountain[heigth].Count;
        int numberOfSteps = 0;
        char step;

        while (walkDistance > numberOfSteps)
        {
            for (int i = 1; i <= heigth; i++)
            {
                if (mountain[i].Count >= numberOfSteps)
                {
                    if (IsSymbolIsNextStep(mountain[i][numberOfSteps]))
                    {
                        step = mountain[i][numberOfSteps];
                        steps.Add(step);
                        numberOfSteps++;
                        continue;
                    }
                }
            }
        }
        PrintCompleteJourney(walkDistance);
    }

    static bool IsSymbolIsNextStep(char symbol)
    {
        return (symbol == '/' || symbol == '\\' || symbol == '_') ? true : false;
    }

    static void PrintCompleteJourney(int walkDistance)
    {
        Console.WriteLine($"Total Walk Distance = {walkDistance}");

        char previousStep = steps[0];
        char currentStep;
        int numberOfSameSteps = 1;

        for (int i = 1; i < steps.Count; i++)
        {
            currentStep = steps[i];
            if (AreStepsEqual(previousStep, currentStep) && !IsStepLast(i))
            {
                numberOfSameSteps++;
            }
            else
            {
                if (IsStepLast(i))
                {
                    if (AreStepsEqual(previousStep, currentStep))
                    {
                        numberOfSameSteps++;
                    }
                    else
                    {
                        PrintSameSteps(ref previousStep, ref numberOfSameSteps, i);
                    }
                }
                PrintSameSteps(ref previousStep, ref numberOfSameSteps, i);
            }
        }
    }

    static bool AreStepsEqual(char previousStep, char currentStep)
    {
        return previousStep == currentStep ? true : false;
    }

    static bool IsStepLast(int index)
    {
        return index + 1 == steps.Count ? true : false;
    }

    static void PrintSameSteps(ref char previousStep, ref int numberOfSameSteps, int index)
    {
        string direction = "";
        switch (previousStep)
        {
            case '/':
                direction = "Up";
                break;
            case '_':
                direction = "Walk";
                break;
            case '\\':
                direction = "Down";
                break;
        }
        Console.WriteLine($"{direction} {numberOfSameSteps} steps");
        previousStep = steps[index];
        numberOfSameSteps = 1;
    }
}

class Program
{
    static void Main()
    {
        int mountainHeigth = int.Parse(Console.ReadLine()) + 1;
        List<char>[] mountain = new List<char>[mountainHeigth];

        for (int i = 0; i < mountainHeigth; i++)
        {
            mountain[i] = Console.ReadLine().ToList();
        }
        QCJ1.Solve(mountain);
        Console.ReadKey();
    }
}