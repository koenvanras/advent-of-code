using Core.Models;
using Core.Services;

namespace Core.Tests.Services
{
    public class SimilarityServiceTests
    {
        private SimilarityService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new SimilarityService();
        }

        [Test]
        public void GetSimilarities_ReturnsCorrectValues()
        {
            // Arrange
            var listOne = new List<int> { 3, 4, 2, 1, 3, 3 };
            var listTwo = new List<int> { 4, 3, 5, 3, 9, 3 };

            // Act
            var result = _sut.GetSimilarities(listOne, listTwo).ToList();

            // Assert
            var expected = new List<SimilarityResult>
            {
                new(3, 3),
                new(4, 1),
                new(2, 0),
                new(1, 0),
                new(3, 3),
                new(3, 3)
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetSimilarities_HandlesDuplicatesCorrectly()
        {
            // Arrange
            var listOne = new List<int> { 1, 1, 1, 1 };
            var listTwo = new List<int> { 1, 1, 1 };

            // Act
            var result = _sut.GetSimilarities(listOne, listTwo).ToList();

            // Assert
            var expected = new List<SimilarityResult>
            {
                new(1, 3),
                new(1, 3),
                new(1, 3),
                new(1, 3)
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetSimilarities_ListTwoIsEmpty_ReturnsZeroCounts()
        {
            // Arrange
            var listOne = new List<int> { 3, 4, 2, 1, 3, 3 };
            var listTwo = new List<int>();

            // Act
            var result = _sut.GetSimilarities(listOne, listTwo).ToList();

            // Assert
            var expected = new List<SimilarityResult>
            {
                new(3, 0),
                new(4, 0),
                new(2, 0),
                new(1, 0),
                new(3, 0),
                new(3, 0)
            };

            Assert.That(result, Is.EqualTo(expected));
        }
    }
}
