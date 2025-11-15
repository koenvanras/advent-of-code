using Core.Models;

namespace Core.Abstractions
{
    public interface ISimilarityService
    {
        /// <summary>
        /// Get the amount of times per number where the number in list one exists in list two
        /// </summary>
        /// <param name="listOne"></param>
        /// <param name="listTwo"></param>
        /// <returns>A list of SimilarityResult</returns>
        IEnumerable<SimilarityResult> GetSimilarities(List<int> listOne, List<int> listTwo);
    }
}
