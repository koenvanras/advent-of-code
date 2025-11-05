try
{
	List<int> ListOne = File.ReadLines("./input.txt")
							.Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[0]))
							.OrderBy(number => number)
							.ToList();
	List<int> ListTwo = File.ReadLines("./input.txt")
                            .Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[1]))
                            .OrderBy(number => number)
                            .ToList();
	int result = 0;

    // Note: Looping list one count because there should always be 2 points to calculate distance
    for (int i = 0; i < ListOne.Count; i++)
	{
        // Print calculation information to console
        Console.WriteLine($"{i}: {ListOne[i]} -> {ListTwo[i]} = {Math.Abs(ListOne[i] - ListTwo[i])}");

        // Add calculation between points too the result
        result += Math.Abs(ListOne[i] - ListTwo[i]);
    }

    // Print result to console
    Console.WriteLine(result.ToString());

    Console.ReadLine();
}
catch (Exception ex)
{
	Console.WriteLine("Exception: " + ex.Message);
	throw;
}