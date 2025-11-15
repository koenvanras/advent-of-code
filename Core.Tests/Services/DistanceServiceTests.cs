using Core.Services;

namespace Core.Tests.Services
{
    public class DistanceServiceTests
    {
        private DistanceService _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new DistanceService();
        }

        [Test]
        public void CalculateDistances_ReturnsCorrectValues()
        {
            // Arrange
            var listOne = new List<int> { 3, 4, 2, 1, 3, 3 };
            var listTwo = new List<int> { 4, 3, 5, 3, 9, 3 };

            // Act
            var result = _sut.CalculateDistances(listOne, listTwo).ToList();

            // Assert
            var expected = new List<int> { 2, 1, 0, 1, 2, 5};

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void CalculateDistances_ThrowsException_WhenListLengthsDiffer()
        {
            // Arrange
            var listOne = new List<int> { 3, 4, 2, 1, 3, 3 };
            var listTwo = new List<int> { 4, 3, 5, 3 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _sut.CalculateDistances(listOne, listTwo);
            });
        }

        [Test]
        public void CalculateDistances_ThrowsException_WhenListLengthsDiffer2()
        {
            // Arrange
            var listOne = new List<int> { 3, 4, 2, 1 };
            var listTwo = new List<int> { 4, 3, 5, 3, 9, 3 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() =>
            {
                _sut.CalculateDistances(listOne, listTwo);
            });
        }
    }
}
