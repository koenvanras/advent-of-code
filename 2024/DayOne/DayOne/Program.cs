try
{
	List<int> ListOne = File.ReadLines("./input.txt")
							.Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[0]))
							.OrderBy(number => number)
							.ToList();
	List<int> ListTwo = File.ReadLines("./input.txt")
                            .Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[1]))
                            .OrderBy(number => number)
                            .ToList(); ;

	int result = 0;

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