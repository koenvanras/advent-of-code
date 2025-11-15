using Core.Abstractions;
using Core.Models;

namespace Core.Services
{
    public class SimilarityService : ISimilarityService
    {
        /// <inheritdoc/>
        public IEnumerable<SimilarityResult> GetSimilarities(List<int> listOne, List<int> listTwo)
        {
            var result = new List<SimilarityResult>();

            // Looping list one to check how many times the number exists in list two
            for (int i = 0; i < listOne.Count; i++)
            {
                result.Add(new(listOne[i], listTwo.Count(n => n == listOne[i])));
            }

            return result;
        }
    }
}
