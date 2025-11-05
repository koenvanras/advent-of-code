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
	int distance = 0;
    int similarity = 0;

    // Note: Looping list one count because there should always be 2 points to calculate distance
    for (int i = 0; i < ListOne.Count; i++)
	{
        // Calculate
        var distanceCount = Math.Abs(ListOne[i] - ListTwo[i]);
        var similarityCount = ListOne[i] * ListTwo.Count(number => number == ListOne[i]);

        // Print calculation information to console
        Console.WriteLine($"{i}: {ListOne[i]} -> {ListTwo[i]} = Distance: {distanceCount}, Similarity: {similarityCount}");

        // Add calculations to results
        distance += distanceCount;
        similarity += similarityCount;
    }

    // Print results to console
    Console.WriteLine($"Total distance: {distance}, Similarity score: {similarity}");

    Console.ReadLine();
}
catch (Exception ex)
{
	Console.WriteLine("Exception: " + ex.Message);
	throw;
}