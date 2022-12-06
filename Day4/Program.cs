
string puzzleSearchPath = (@"C:\Users\guskro\Source\Repos\AdventOfCode2022\Day4\puzzleInput.txt");
var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();

Console.WriteLine("Svar del ett: " + PartOne(puzzleInput));
Console.WriteLine("Svar del två: " + PartTwo(puzzleInput));


static int PartOne(List<string> input)
{
    var contains = 0;
    foreach (var line in input)
    {
        var area = line.Split(',');

        if (IsInRange(area[0], area[1]))
            contains++;
        if (IsInRange(area[1], area[0]))
            contains++;
    }
    return contains;
}

static bool IsInRange(string areaOne, string areaTwo)
{
    var result = false;
    var areaOneSplit = areaOne.Split("-");
    var areaTwoSplit = areaTwo.Split("-");

    if (Int32.Parse(areaOneSplit[0]) > Int32.Parse(areaTwoSplit[0]) && Int32.Parse(areaOneSplit[1]) < Int32.Parse(areaTwoSplit[1]))
        result = true;
    return result;
}

static int PartTwo(List<string> input)
{
    return 0;
}