using IngkaAPIProject.Models;

namespace IngkaAPIProject.Mocks
{
    public static class MockedItems
    {
        public static readonly List<PriceData> MockPrices = new List<PriceData>
            {
                new PriceData { Date = DateTime.Now, Price = 17.7 },
                new PriceData { Date = DateTime.Now.AddDays(-1), Price = 13 },
                new PriceData { Date = DateTime.Now.AddDays(-2), Price = 24.6 },
                new PriceData { Date = DateTime.Now.AddDays(-3), Price = 50.6 },
                new PriceData { Date = DateTime.Now.AddDays(-4), Price = 56.7 },
                new PriceData { Date = DateTime.Now.AddDays(-5), Price = 20.5 },
                new PriceData { Date = DateTime.Now.AddDays(-6), Price = 55.9 },
                new PriceData { Date = DateTime.Now.AddDays(-7), Price = 44.8 },
                new PriceData { Date = DateTime.Now.AddDays(-8), Price = 88.0},
                new PriceData { Date = DateTime.Now.AddDays(-9), Price = 55.3 },
                new PriceData { Date = DateTime.Now.AddDays(-10), Price = 33.2 },
                new PriceData { Date = DateTime.Now.AddDays(-11), Price = 33.7 },
                new PriceData { Date = DateTime.Now.AddDays(-12), Price = 12.8 },
            };
    }
}
