try
{
	List<List<int>> reports = File.ReadLines("./input.txt")
							    .Select(line => line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
							                    .ToList())
                                .ToList();

    int safe = 0;

    foreach (var report in reports)
    {
        if (AreValidSteps(report))
            safe++;
    }

    Console.WriteLine(safe);

    Console.ReadLine();
}
catch (Exception ex)
{
	Console.WriteLine("Exception: " + ex.Message);
	throw;
}

bool AreValidSteps(List<int> report)
{
    bool ascending = true;
    bool descending = true;

    for (int i = 1; i < report.Count; i++)
    {
        int diff = report[i] - report[i - 1];
        int absDiff = Math.Abs(diff);

        // Step size must be between 1 and 3
        if (absDiff < 1 || absDiff > 3)
            return false;

        // Track order direction
        if (diff > 0)
            descending = false;
        else if (diff < 0)
            ascending = false;
    }

    // Must be fully ascending or descending
    return ascending || descending;
}