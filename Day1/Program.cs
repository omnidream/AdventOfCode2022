
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;

string puzzleSearchPath = (@"C:\Users\guskro\Source\Repos\AdventOfCode2022\Day1\puzzleInput.txt");
var puzzleInput = File.ReadAllLines(puzzleSearchPath).ToList();
List<Elf> elvs = new List<Elf>();

Console.WriteLine("Svar del ett: " + PartOne(puzzleInput, elvs));
Console.WriteLine("Svar del två: " + PartTwo(puzzleInput, elvs));


static int PartOne(List<string> input, List<Elf> elfs)
{
	int sum = 0;
	foreach (var line in input)
	{
		if(line == String.Empty)
		{
			Elf myElf = new();
			myElf.TotalCalories = sum;
			elfs.Add(myElf);
			sum = 0;
		}
		else
			sum = sum + Int32.Parse(line);	
	}
	Elf loadedElf = GetTheMostStockedElf(elfs);
    return loadedElf.TotalCalories;
}

static int PartTwo(List<string> input, List<Elf> elfs)
{
	int sum = 0;
    List<Elf> SortedElvs = elfs.OrderByDescending(o => o.TotalCalories).ToList();
	for (int i = 0; i < 3; i++)
	{
		sum = sum + SortedElvs[i].TotalCalories;
	}
    return sum;
}

static Elf GetTheMostStockedElf(List<Elf> elvs)
{
	Elf mostStockedElf = new();

	foreach (var elf in elvs)
	{
		if (elf.TotalCalories > mostStockedElf.TotalCalories)
			mostStockedElf = elf;
	}
	return mostStockedElf;
}
class Elf
{
    public List<int> FoodList { get; set; }
	public int TotalCalories { get; set; }

}