using Core.Abstractions;

namespace Core.Services
{
    public class DistanceService : IDistanceService
    {
        /// <inheritdoc/>
        public IEnumerable<int> CalculateDistances(List<int> listOne, List<int> listTwo)
        {
            // Check if lists have the same length, else fail
            if (listOne.Count != listTwo.Count)
                throw new ArgumentException("Lists are not the same length.");

            // Order the lists for proper calculation
            var orderedListOne = listOne.OrderBy(number => number).ToList();
            var orderedListTwo = listTwo.OrderBy(number => number).ToList();

            var result = new List<int>();

            // Note: Looping list one count because there should always be 2 points to calculate distance
            for (int i = 0; i < listOne.Count; i++)
            {
                var distanceCount = Math.Abs(orderedListOne[i] - orderedListTwo[i]);
                result.Add(distanceCount);
            }

            return result;
        }
    }
}
