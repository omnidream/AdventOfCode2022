
using System.Numerics;
using System.Text.RegularExpressions;

internal class Program
{
    

    private static void Main(string[] args)
    {
        string puzzleSearchPath = @"C:\Users\gusta\source\repos\AdventOfCode2022\Day5\puzzleInput.txt";
        var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();

        //    [D]
        //[N] [C]
        //[Z] [M] [P]
        // 1   2   3

        //Initiate stacked creates
        List<char> one = new() { 'N', 'Z' };
        List<char> two = new() { 'D', 'C', 'M' };
        List<char> three = new() { 'P' };

        Console.WriteLine("Svar del ett: " + PartOne(puzzleInput));
        Console.WriteLine("Svar del två: " + PartTwo(puzzleInput));

        int PartOne(List<string> input)
        {
            foreach (var moveString in input)
            {
                int move = int.Parse(new string(moveString.Where(char.IsDigit).ToString()));
            }
            one.Insert(0, 'D');
            one.RemoveAt(0);
            return 0;
        }

        int PartTwo(List<string> input)
        {
            return 0;
        }
    }
}