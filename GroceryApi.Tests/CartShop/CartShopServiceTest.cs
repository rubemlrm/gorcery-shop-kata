using GroceryApi.CartShop;

namespace GroceryApi.Tests.CartShop
{

    public class CartShopServiceTests {

        public static IEnumerable<object[]> Data =>
        [
            [
                    new CartShopRequest {Items = new() { "3 Tomato","1 Chicken", "2 Bread" }},
                    "total price 9.36, tax 1.33"
                ],
            [
                   new CartShopRequest {Items = new() { "2 Jam", "5 Lettuce", "3 Chicken" }},
                   "total price 20.55, tax 3.36"
                ],
            [
                    new CartShopRequest {Items = new() { "1 Lettuce", "1 Chicken" }},
                    "total price 3.55, tax 0.58"
                ],
            [
                    new CartShopRequest {Items = new() {}},
                    "No Products"
                ],
        ];

        [Theory]
        [MemberData(nameof(Data))]
        public void TestCalculateCartShopPriceWithProducts(CartShopRequest input, string result)
        {
            // When
            var cartShopService = new CarShopService();
            var actual = cartShopService.CalculateCartShopPrice(input);
            // Then
            Assert.Equal(result, actual);
        }
    }
}
