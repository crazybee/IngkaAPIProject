using DataSource.Models;

namespace DataSource.Mocks
{
    public static class MockedItems
    {
        public static readonly List<PriceData> MockPrices = new List<PriceData>
            {
                new PriceData { Date = DateTime.Now, Price = 17.7 },
                new PriceData { Date = DateTime.Now.AddDays(-100), Price = 13 },
                new PriceData { Date = DateTime.Now.AddDays(-200), Price = 24.6 },
                new PriceData { Date = DateTime.Now.AddDays(-300), Price = 50.6 },
                new PriceData { Date = DateTime.Now.AddDays(-4), Price = 56.7 },
                new PriceData { Date = DateTime.Now.AddDays(-365), Price = 20.5 },
                new PriceData { Date = DateTime.Now.AddDays(-60), Price = 55.9 },
                new PriceData { Date = DateTime.Now.AddDays(-67), Price = 44.8 },
                new PriceData { Date = DateTime.Now.AddDays(-90), Price = 88.0},
                new PriceData { Date = DateTime.Now.AddDays(-500), Price = 55.3 },
                new PriceData { Date = DateTime.Now.AddDays(-10), Price = 33.2 },
                new PriceData { Date = DateTime.Now.AddDays(-400), Price = 33.7 },
                new PriceData { Date = DateTime.Now.AddDays(-30), Price = 12.8 },
            };
    }
}
