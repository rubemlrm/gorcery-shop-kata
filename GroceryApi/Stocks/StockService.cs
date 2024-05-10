namespace GroceryApi.Stocks
{
    public class StockService
    {

        private readonly StockRepository _stockRepository;
        public StockService() {
            _stockRepository = new StockRepository();
        }

        public List<StockProductModel> GetStockProducts() {
            return _stockRepository.All();
        }


        public StockProductPrice GetProductPrice(string name) {
            var products = GetStockProducts();
            var productInformation = products.FirstOrDefault(x => x.Name == name);
            if (productInformation != null) {
                var itemPrice = _stockRepository.CalculateItemPrice(productInformation);
                return new StockProductPrice {
                    Price = itemPrice,
                    Name = productInformation.Name
                };
            }
            throw new ProductNotFoundExceptionException();
        }
    }
}
