try
{
	List<int> ListTest = File.ReadLines("./input.txt")
							.Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[0]))
							.OrderBy(number => number)
							.ToList();
	List<int> ListOne = new();
	List<int> ListTwo = new();

	int result = 0;

	//Create lists based on txt file
	foreach (var line in File.ReadLines("./input.txt"))
	{
		// Split numbers in line
        var split = line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries);

		// Add split numbers to list
		ListOne.Add(int.Parse(split[0]));
		ListTwo.Add(int.Parse(split[1]));
	}

	Console.WriteLine(ListOne.SequenceEqual(ListTest));

	// Sort the lists
	ListOne.Sort();
	ListTwo.Sort();

    Console.WriteLine(ListOne.SequenceEqual(ListTest));

    for (int i = 0; i < ListOne.Count; i++)
	{
        Console.WriteLine($"{i}: {ListOne[i]} -> {ListTwo[i]} = {Math.Abs(ListOne[i] - ListTwo[i])}");
        result += Math.Abs(ListOne[i] - ListTwo[i]);
    }

    Console.WriteLine(result.ToString());

    Console.ReadLine();
}
catch (Exception ex)
{
	Console.WriteLine("Exception: " + ex.Message);
	throw ex;
}