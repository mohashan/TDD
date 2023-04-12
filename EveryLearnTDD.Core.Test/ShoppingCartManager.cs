namespace EveryLearnTDD.Core
{
    internal class ShoppingCartManager
    {
        private List<AddToCartItem> _shoppingCart;
        public ShoppingCartManager()
        {
            _shoppingCart = new List<AddToCartItem>();
        }

        internal AddToCartResponse AddToCart(AddToCartRequest request)
        {
            var ExistItem = _shoppingCart.FirstOrDefault(x => x.ArticleId == request.item.ArticleId);
            if (ExistItem == null)
            {
                _shoppingCart.Add(request.item);
            }
            else
            {
                ExistItem.Quantity += request.item.Quantity;
            }
            return new AddToCartResponse
            {
                Items = _shoppingCart.ToArray()
            };
        }
    }
}