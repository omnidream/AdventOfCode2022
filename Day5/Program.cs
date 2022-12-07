
using System.Numerics;
using System.Text.RegularExpressions;

internal class Program
{
    

    private static void Main(string[] args)
    {
        string puzzleSearchPath = @"C:\Users\gusta\source\repos\AdventOfCode2022\Day5\puzzleInput.txt";
        var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();
        
        Console.WriteLine("Svar del ett: " + PartOne(puzzleInput));
        Console.WriteLine("Svar del två: " + PartTwo(puzzleInput));

        Dictionary<int, List<char>> InitiateCrateStacks()
        {
            Dictionary<int, List<char>> stacks = new();
            List<char> one = new() { 'N', 'V', 'C', 'S' };
            List<char> two = new() { 'S', 'N', 'H', 'J', 'M', 'Z' };
            List<char> three = new() { 'D', 'N', 'J', 'G', 'T', 'C', 'M' };
            List<char> four = new() { 'M', 'R', 'W', 'J', 'F', 'D', 'T' };
            List<char> five = new() { 'H', 'F', 'P' };
            List<char> six = new() { 'J', 'H', 'Z', 'T', 'C' };
            List<char> seven = new() { 'Z', 'L', 'S', 'F', 'Q', 'R', 'P', 'D' };
            List<char> eight = new() { 'W', 'P', 'F', 'D', 'H', 'L', 'S', 'C' };
            List<char> nine = new() { 'Z', 'G', 'N', 'F', 'P', 'M', 'S', 'D' }; //56 crates
            stacks.Add(1, one);
            stacks.Add(2, two);
            stacks.Add(3, three);
            stacks.Add(4, four);
            stacks.Add(5, five);
            stacks.Add(6, six);
            stacks.Add(7, seven);
            stacks.Add(8, eight);
            stacks.Add(9, nine);
            return stacks;
        }

        string PartOne(List<string> input)
        {
            var stacks = InitiateCrateStacks();
            foreach (var moveString in input)
            {
                var move = moveString.Split(' ');
                MakeMoveCrane9000(move, stacks);
            }
            return ExtractTopCrates(stacks);
        }

        void MakeMoveCrane9000(string[] move, Dictionary<int, List<char>> stacks)
        {
            int crates = Int32.Parse(move[1]);
            int fromStack = Int32.Parse(move[3]);
            int toStack = Int32.Parse(move[5]);

            for (int i = 0; i < crates ; i++)
            {
                stacks[toStack].Insert(0, stacks[fromStack][0]);
                stacks[fromStack].RemoveAt(0);
            }
        }

        string ExtractTopCrates(Dictionary<int, List<char>> stacks)
        {
            var answer = "";

            for (int i = 0; i < stacks.Count; i++)
            {
                answer = answer + stacks[i+1][0];
            }
            return answer;
        }

        string PartTwo(List<string> input)
        {
            var stacks = InitiateCrateStacks();
            foreach (var moveString in input)
            {
                var move = moveString.Split(' ');
                MakeMoveCrane9001(move, stacks);
            }
            return ExtractTopCrates(stacks);
        }

        void MakeMoveCrane9001(string[] move, Dictionary<int, List<char>> stacks)
        {
            List<char> crane9001 = new();
            int crates = Int32.Parse(move[1]);
            int fromStack = Int32.Parse(move[3]);
            int toStack = Int32.Parse(move[5]);

            crane9001 = stacks[fromStack].GetRange(0, crates);
            stacks[toStack].InsertRange(0, crane9001);
            stacks[fromStack].RemoveRange(0, crates);
            crane9001.Clear();
        }
    }
}