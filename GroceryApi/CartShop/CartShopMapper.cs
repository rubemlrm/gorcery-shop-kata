namespace GroceryApi.CartShop {
    public class CartShopMapper {
        public static List<CartShopItemModel> MapForCalculations(List<string> items) {
            var cartShopItem = new List<CartShopItemModel>();
            items.ForEach(item => {
                var tempItem = item.Split(" ");

                if (!Int32.TryParse(tempItem[0], out int quantity))
                {
                    throw new Exception("Can't parse quantity value");
                }

                cartShopItem.Add(new CartShopItemModel{
                        Name = tempItem[1],
                        Quantity = quantity
                    });
            });
            return cartShopItem;
        }
    }
}
