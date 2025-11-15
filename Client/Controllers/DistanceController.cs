using Core.Abstractions;

namespace Client.Controllers
{
    public class DistanceController
    {
        private readonly IDistanceService _distanceService;

        public DistanceController(IDistanceService distanceService)
        {
            _distanceService = distanceService;
        }

        public int CalculateTotalDistance()
        {
            // Declare and initialize the lists to calculate distance
            List<int> listOne = File.ReadLines("./2024_1.txt")
                                .Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[0]))
                                .OrderBy(number => number)
                                .ToList();
            List<int> listTwo = File.ReadLines("./2024_1.txt")
                                .Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[1]))
                                .OrderBy(number => number)
                                .ToList();

            // Get the total distance of the two lists
            var result = GetTotalDistance(listOne, listTwo);

            Console.WriteLine($"Total distance: {result}");

            return result;
        }

        /// <summary>
        /// Get the total distance of all distances between points in 2 lists
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="listTwo"></param>
        /// <returns>The total distance</returns>
        private int GetTotalDistance(List<int> listOne, List<int> listTwo)
        {
            var result = 0;
            var distances = _distanceService.CalculateDistances(listOne, listTwo);

            foreach (var distance in distances)
            {
                result += distance;
            }

            return result;
        }
    }
}
