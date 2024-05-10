namespace GroceryApi.Stocks
{

    public class StockRepository {
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
            decimal total = 0;
            var revenueTax = model.CostValue * ((decimal)model.Revenue / 100);
            total = model.CostValue + revenueTax;
            var tax = total * ((decimal)model.Tax / 100);
            total += tax;
            return Math.Round(total , 2, MidpointRounding.AwayFromZero);
        }

        public Dictionary<string, decimal> CalculateDetailedItemPrice(StockProductModel model) {
            decimal total = 0;
            var revenueTax = model.CostValue * ((decimal)model.Revenue / 100);
            total = model.CostValue + revenueTax;
            var tax = total * ((decimal)model.Tax / 100);
            total += tax;
            return new Dictionary<string, decimal> {
                {"price", Math.Round(total, 2, MidpointRounding.AwayFromZero) },
                {"taxes", Math.Round(tax, 2, MidpointRounding.AwayFromZero) }
            };
        }


    }
}
