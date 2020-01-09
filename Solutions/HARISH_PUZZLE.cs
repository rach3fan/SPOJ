using System;
using System.Collections.Generic;
using System.IO;

// Solution to "HARISH_PUZZLE - Harish and his rooks puzzle"  SPOJ.com classical problem 
// https://www.spoj.com/problems/HARISH_PUZZLE/

public static class HARISH_PUZZLE
{
    public const int gameBoardLength = 8;

    public static bool Solve(char[][] gameBoard)
    {
        var rooksPositions = new List<int>();
        bool isGameSolved = false;

        for (int i = 0; i < gameBoardLength; i++)
        {
            int rooksCountInRow = 0;
            for (int j = 0; j < gameBoardLength; j++)
            {
                if (IsRookInTheCell(gameBoard, i, j))
                {
                    if (IsRookAlreadyInRow(rooksPositions, ref rooksCountInRow, j))
                    {
                        isGameSolved = false;
                        goto End;
                    }
                    else if (IsAnyRookMissing(rooksCountInRow, j))
                    {
                        isGameSolved = false;
                        goto End;
                    }
                }
            }
        }
        if (IsGameSolved(rooksPositions))
        {
            isGameSolved = true;
        }
        End:
        return isGameSolved;
    }

    static bool IsRookInTheCell(char[][] gameBoard, int i, int j)
    {
        return char.IsLetter(gameBoard[i][j]) ? true : false;
    }

    static bool IsRookAlreadyInRow(List<int> rooksPositions, ref int rooksCountInRow, int position)
    {
        if (!rooksPositions.Contains(position) && rooksCountInRow == 0)
        {
            rooksPositions.Add(position);
            rooksCountInRow++;
            return false;
        }
        return true;
    }

    static bool IsAnyRookMissing(int rooksCountInRow, int index)
    {
        return (index == gameBoardLength - 1 && rooksCountInRow == 0) ? true : false;
    }

    static bool IsGameSolved(List<int> rooksPositions)
    {
        return rooksPositions.Count == gameBoardLength ? true : false;
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

        var gameBoards = new List<char[][]>();

        int remainingTestCases = int.Parse(reader.ReadLine());
        while (remainingTestCases-- > 0)
        {
            var gameBoard = new char[HARISH_PUZZLE.gameBoardLength][];

            for (int i = 0; i < HARISH_PUZZLE.gameBoardLength; i++)
            {
                Reset:
                string input = reader.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    goto Reset;
                }
                gameBoard[i] = input.ToCharArray();
            }
            gameBoards.Add(gameBoard);
        }
        foreach (var gameBoard in gameBoards)
        {
            writer.WriteLine(HARISH_PUZZLE.Solve(gameBoard) ? "YES" : "NO");
        }
        reader.Close();
        writer.Close();
        Console.ReadKey();
    }
}