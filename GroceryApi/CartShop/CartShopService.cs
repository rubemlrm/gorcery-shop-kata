using System.Globalization;
using GroceryApi.Stocks;

namespace GroceryApi.CartShop {

    public class CartShopService(StockRepository stockRepository)
    {

        private readonly StockRepository _stockRepository = stockRepository;

        public string CalculateCartShopPrice(CartShopRequest request)
        {
            var cartShopPrice = new Dictionary<string, decimal> {
                {"price", 0},
                {"taxes", 0},
            };
            if (request.Items.Count == 0)
            {
                return "No Products";
            }

            var mappedItems = CartShopMapper.MapForCalculations(request.Items);
            var getStockItems = new StockService().GetStockProducts();

            mappedItems.ForEach(mappedItem => {
                var item = _stockRepository.FindOrFail(mappedItem.Name);
                var priceInfo = _stockRepository.CalculateDetailedItemPrice(item);
                cartShopPrice["price"] += mappedItem.Quantity * priceInfo["price"];
                cartShopPrice["taxes"] += mappedItem.Quantity * Math.Round(priceInfo["taxes"], 2);
            });
            return $"total price {cartShopPrice["price"].ToString(CultureInfo.InvariantCulture)}, tax {cartShopPrice["taxes"].ToString(CultureInfo.InvariantCulture)}";

        }

    }

}
