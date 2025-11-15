namespace Core.Abstractions
{
    public interface IDistanceService
    {
        /// <summary>
        /// Calculate the distances between 2 points in 2 lists
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="listTwo"></param>
        /// <returns>A list of distances for each point in the lists</returns>
        /// <exception cref="ArgumentException"></exception>
        IEnumerable<int> CalculateDistances(List<int> listOne, List<int> listTwo);
    }
}
