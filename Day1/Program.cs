
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

string puzzleSearchPath = (@"C:\Users\guskro\Source\Repos\AdventOfCode2022\Day1\puzzleInput.txt");
var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();
List<int> elvs = new List<int>();

Console.WriteLine("Svar del ett: " + PartOne(puzzleInput, elvs));
Console.WriteLine("Svar del två: " + PartTwo(puzzleInput, elvs));


static int PartOne(List<string> input, List<int> elfs)
{
	int sum = 0;
	foreach (var line in input)
	{
		if(line == String.Empty)
		{
			elfs.Add(sum);
			sum = 0;
		}
		else
			sum = sum + Int32.Parse(line);	
	}
	int loadedElf = GetTheMostStockedElf(elfs);
    return loadedElf;
}

static int PartTwo(List<string> input, List<int> elfs)
{
	int sum = 0;
    List<int> SortedElvs = elfs.OrderByDescending(o => o).ToList();
	for (int i = 0; i < 3; i++)
	{
		sum = sum + SortedElvs[i];
	}
    return sum;
}

static int GetTheMostStockedElf(List<int> elvs)
{
	int mostStockedElf = 0;

	foreach (var elf in elvs)
	{
		if (elf > mostStockedElf)
			mostStockedElf = elf;
	}
	return mostStockedElf;
}