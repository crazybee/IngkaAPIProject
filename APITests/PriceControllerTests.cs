using IngkaAPIProject.Controllers;
using IngkaAPIProject.Models;
using IngkaAPIProject.Mocks;
using Microsoft.AspNetCore.Mvc;
namespace APITests
{

    public class PriceControllerTests
    {
        [Fact]
        public void GetAllPrices_ReturnsAllPrices()
        {
            // Arrange
            var controller = new PriceController();

            // Act
            var result = controller.GetAllPrices() as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var prices = result.Value as List<PriceData>;
            Assert.NotNull(prices);
            Assert.Equal(MockedItems.MockPrices.Count, prices.Count);
        }

        [Fact]
        public void GetPricesByDateRange_ReturnsFilteredPrices()
        {
            // Arrange
            var controller = new PriceController();
            var startDate = new DateTime(2025, 1, 14);
            var endDate = new DateTime(2025, 1, 20);
            var expectedCount = 6;
            // Act
            var result = controller.GetPricesByDateRange(startDate, endDate) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var filteredPrices = result.Value as List<PriceData>;
            Assert.NotNull(filteredPrices);
            Assert.Equal(expectedCount, filteredPrices.Count);

            Assert.All(filteredPrices, p => Assert.InRange(p.Date, startDate, endDate));
        }

        [Fact]
        public void GetPricesByDateRange_ReturnsEmptyList_IfNoMatch()
        {
            // Arrange
            var controller = new PriceController();
            var startDate = new DateTime(2024, 1, 1);
            var endDate = new DateTime(2024, 1, 10);

            // Act
            var result = controller.GetPricesByDateRange(startDate, endDate) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);

            var filteredPrices = result.Value as List<PriceData>;
            Assert.NotNull(filteredPrices);
            Assert.Empty(filteredPrices);
        }

    }
}