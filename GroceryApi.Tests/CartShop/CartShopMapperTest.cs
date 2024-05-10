namespace GroceryApi.Tests.CartShop;

using GroceryApi.CartShop;

public class CartShopMapperTest
{
    [Fact]
    public void TestMapForCalculationsWithSuccess()
    {
        var input = new List<string> { "1 testing", "2 testing3" };

        var expected = new List<CartShopItemModel> {
            new() { Quantity = 1, Name = "testing"},
            new() { Quantity = 2, Name = "testing3"}
        };

        var result = CartShopMapper.MapForCalculations(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void TestMapForCalculationsWithException()
    {
        var input = new List<string> { "1 testing", "a testing3" };
        Assert.Throws<Exception>(() => CartShopMapper.MapForCalculations(input));
    }
}
