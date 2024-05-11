using GroceryApi.CartShop;

namespace GroceryApi.Tests.CartShop
{
    public class CartShopServiceTests {
        [Fact]
        public void TestCalculateCartShopPriceWithoutProducts()
        {
            // Given
            var input = new CartShopRequest {
                Items = new() {}
            };
            var expected = "No Products";
            // When
            var cartShopService = new CarShopService();
            var actual = cartShopService.CalculateCartShopPrice(input);
            // Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateCartShopPriceWithProducts()
        {
            // Given
            var input = new CartShopRequest
            {
                Items = new() { "3 Tomato","1 Chicken", "2 Bread" }
            };
            var expected = "total price 9.36, tax 1.33";
            // When
            var cartShopService = new CarShopService();
            var actual = cartShopService.CalculateCartShopPrice(input);
            // Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateCartShopPriceWithProducts2()
        {
            // Given
            var input = new CartShopRequest
            {
                Items = new() { "2 Jam", "5 Lettuce", "3 Chicken" }
            };
            var expected = "total price 20.55, tax 3.36";
            // When
            var cartShopService = new CarShopService();
            var actual = cartShopService.CalculateCartShopPrice(input);
            // Then
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TestCalculateCartShopPriceWithProducts3()
        {
            // Given
            var input = new CartShopRequest
            {
                Items = new() { "1 Lettuce", "1 Chicken" }
            };
            var expected = "total price 3.55, tax 0.58";
            // When
            var cartShopService = new CarShopService();
            var actual = cartShopService.CalculateCartShopPrice(input);
            // Then
            Assert.Equal(expected, actual);
        }
    }
}
