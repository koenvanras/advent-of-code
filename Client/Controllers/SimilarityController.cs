using Core.Abstractions;
using Core.Services;

namespace Client.Controllers
{
    public class SimilarityController
    {
        private readonly ISimilarityService _similarityService;

        public SimilarityController(ISimilarityService similarityService)
        {
            _similarityService = similarityService;
        }

        public int CalculateSimilarityScore()
        {
            // Declare and initialize the lists to calculate distance
            List<int> listOne = File.ReadLines("./2024_1.txt")
                                .Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[0]))
                                .ToList();
            List<int> listTwo = File.ReadLines("./2024_1.txt")
                                .Select(line => int.Parse(line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries)[1]))
                                .ToList();

            // Get the total distance of the two lists
            var result = GetSimilarityScore(listOne, listTwo);

            Console.WriteLine($"Similarity score: {result}");

            return result;
        }

        /// <summary>
        /// Get the similarity score of all numbers in two lists
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="listTwo"></param>
        /// <returns>The similarity score</returns>
        private int GetSimilarityScore(List<int> listOne, List<int> listTwo)
        {
            var result = 0;
            var similarities = _similarityService.GetSimilarities(listOne, listTwo);

            foreach (var similarity in similarities)
            {
                result += similarity.Number * similarity.SimilarityCount;
            }

            return result;
        }
    }
}
