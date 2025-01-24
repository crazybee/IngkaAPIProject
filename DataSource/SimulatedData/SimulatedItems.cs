

using DataSource.Mocks;
using DataSource.Models;

namespace DataSource.SimulatedData
{
    public static class SimulatedItems
    {
        public static  List<PriceData> MockPrices 
        {
            get 
            {
                var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? string.Empty;

                if (environment != "Release" || string.IsNullOrEmpty(environment))
                {
                    // Use mocked data in Development (unit tests will use this)
                    return MockedItems.MockPrices;
                }
                else
                {
                    // Use real data in production or other environments
                    return GenerateMockPrices(600, 10.6, 1354.7);
                }
            }


            private set
            {
                MockPrices = value;

            }
        
        
        }


        public static List<PriceData> GenerateMockPrices(int numberOfDays, double minPrice, double maxPrice)
        {
            var random = new Random();
            var mockPrices = new List<PriceData>();

            for (int i = 0; i < numberOfDays; i++)
            {
                // Generate a date decrementing by 'i' days
                var date = DateTime.Now.AddDays(-i);

                // Generate a random price between the minPrice and maxPrice
                var price = random.NextDouble() * (maxPrice - minPrice) + minPrice;

                // Add the generated data to the list
                mockPrices.Add(new PriceData { Date = date, Price = Math.Round(price, 2) });
            }

            return mockPrices;
        }
    }
}
