using GroceryApi.Stocks;

namespace GroceryApi.Tests.Stocks;

public class StockRepositoryTests {
    [Theory]
    [InlineData("Lettuce", 0.44)]
    [InlineData("Tomato", 0.72)]
    [InlineData("Chicken", 3.10)]
    [InlineData("Bread", 2.05)]
    [InlineData("Jam", 4.50)]
    public void TestCalculateItemPrice(string name, decimal expected)
    {
        // When
        var repository = new StockRepository();
        var item = repository.FindOrFail(name);
        // Then
        Assert.Equal(expected, repository.CalculateItemPrice(item));
    }
}
