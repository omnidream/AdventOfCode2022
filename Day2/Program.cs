
using System.Security.Cryptography.X509Certificates;

string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2022\Day2\puzzleInput.txt");
var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();

Console.WriteLine("Svar del ett: " + PartOne(puzzleInput));
Console.WriteLine("Svar del två: " + PartTwo(puzzleInput));


static int PartOne(List<string> input)
{
    var totalPoints = 0;
    foreach (var line in input)
    {
        totalPoints = totalPoints + CalculateRound(line);
    }
    return totalPoints;
}

static int PartTwo(List<string> input)
{
    var totalPoints = 0;
    var newInput = "";
    foreach (var line in input)
    {
        newInput = CalculateOutcome(line);
        totalPoints = totalPoints + CalculateRound(newInput);
    }
    return totalPoints;
}

static int CalculateRound(string input)
{
    switch (input)
    {
        case "A X":
            return 3+1;
        case "A Y":
            return 6+2;
        case "A Z":
            return 0+3;
        case "B X":
            return 0+1;
        case "B Y":
            return 3+2;
        case "B Z":
            return 6+3;
        case "C X":
            return 6+1;
        case "C Y":
            return 0+2;
        case "C Z":
            return 3+3;
    }
    return 0;
}

static string CalculateOutcome(string line)
{
    if (line[2] == 'X') //Loose
    {
        if (line[0] == 'A')
            return "A Z";

        if (line[0] == 'B')
            return "B X";

        if (line[0] == 'C')
            return "C Y";
    }

    if (line[2] == 'Y') //Draw
    {
        if (line[0] == 'A')
            return "A X";

        if (line[0] == 'B')
            return "B Y";

        if (line[0] == 'C')
            return "C Z";
    }

    if (line[2] == 'Z') //Win
    {
        if (line[0] == 'A')
            return "A Y";

        if (line[0] == 'B')
            return "B Z";

        if (line[0] == 'C')
            return "C X";
    }
    return "ERROR";
}
