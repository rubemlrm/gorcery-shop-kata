namespace GroceryApi.Stocks
{

    public class StockRepository {

        public StockRepository() { }

        public List<StockProductModel> All()
        {
            return [
                new StockProductModel { Name = "Lettuce", CostValue = 0.32m, Revenue = 15,  Tax = 20 },
                new StockProductModel { Name = "Tomato", CostValue = 0.52m, Revenue = 15, Tax = 20},
                new StockProductModel { Name = "Chicken", CostValue = 2.15m, Revenue = 20, Tax = 20},
                new StockProductModel { Name = "Bread", CostValue = 1.55m, Revenue = 15, Tax = 15},
                new StockProductModel { Name = "Jam", CostValue = 3.26m, Revenue = 20, Tax = 15},
            ];
        }

        public StockProductModel FindOrFail(string name) {
            var item = All().Where(x => x.Name == name).FirstOrDefault() ?? throw new Exception("Item doesn't exist");
            return item;
        }

        public decimal CalculateItemPrice(StockProductModel model) {

            // apply taxes
            var taxedPrice = model.CostValue * ((decimal)model.Tax / 100);
            var total = model.CostValue + taxedPrice;
            // apply revenue
            var revenueTaxPrice = total * ((decimal)model.Revenue / 100);
            total += revenueTaxPrice;
            return RoundUpToPence(total);
        }

        public Dictionary<string, decimal> CalculateDetailedItemPrice(StockProductModel model) {
            // apply taxes
            var taxedPrice = model.CostValue * ((decimal)model.Tax / 100);
            decimal total = model.CostValue + taxedPrice;
            // apply revenue
            var revenueTaxPrice = total * ((decimal)model.Revenue / 100);
            total += revenueTaxPrice;


            return new Dictionary<string, decimal> {
                {"price", RoundUpToPence(total) },
                {"taxes", revenueTaxPrice }
            };
        }

        public decimal RoundUpToPence(decimal amount) {
            decimal scaledValue = amount * 100; // Scale to pence
            decimal roundedValue = Math.Ceiling(scaledValue); // Round up to the nearest whole number
            return roundedValue / 100; // Scale back to pounds
        }
    }
}
