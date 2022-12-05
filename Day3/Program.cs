
using System.ComponentModel;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;

string puzzleSearchPath = (@"C:\Users\gusta\source\repos\AdventOfCode2022\Day3\puzzleInput.txt");
var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();

Console.WriteLine("Svar del ett: " + PartOne(puzzleInput));
Console.WriteLine("Svar del två: " + PartTwo(puzzleInput));


static int PartOne(List<string> input)
{
    var totalValue = 0;
    int count = 0;
    foreach (var rucksack in input)
    {
        totalValue = totalValue + GetRucksackValue(rucksack);
        count++;
    }
    Console.WriteLine(count);
    return totalValue;
}

static int PartTwo(List<string> input)
{
    int totalValue = 0;
    List<string> setOfElvs = new();
    for (int i = 0; i < input.Count; i++)
    {
        setOfElvs.Add(input[i]);
        setOfElvs.Add(input[i+1]);
        setOfElvs.Add(input[i+2]);
        totalValue = totalValue + GetValueOfCommonBadge(setOfElvs);
        setOfElvs.Clear();
        i = i + 2;
    }
    return totalValue;
}

static int GetValueOfCommonBadge(List<string> setOfElvs)
{
    int count = 0;
    for (int i = 0; i < setOfElvs.Count; i++)
    {
        foreach (char myChar in setOfElvs[0])
        {
            if (setOfElvs[1].IndexOf(myChar) > -1)
                if (setOfElvs[2].IndexOf(myChar) > -1)
                    return GetValueOfItem(myChar.ToString());
        }
    }
    return 0;
}

static int GetRucksackValue(string rucksack)
{
    int compVolume = rucksack.Length / 2;
    string compOne = rucksack.Substring(0, compVolume);
    string compTwo = rucksack.Substring((compVolume), compVolume);
    string diffItem = FindFailedItem(compOne, compTwo);
    int diffValue = GetValueOfItem(diffItem);
    return diffValue;
}

static string FindFailedItem(string compOne, string compTwo)
{
    var myChar = compOne.Intersect(compTwo);
    return myChar.First().ToString();
}

static int GetValueOfItem(string diffItem)
{
    string aToz = "*abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    int value = aToz.IndexOf(diffItem);
    return value;
}