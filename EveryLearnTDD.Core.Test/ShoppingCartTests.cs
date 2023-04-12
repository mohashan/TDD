using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveryLearnTDD.Core
{
    public class ShoppingCartTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [Test]
        public void ShouldReturnArticleAddedToCart()
        {
            var item = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                item = item
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            Assert.IsNotNull(response);
            Assert.Contains(item, response.Items);
        }
    }
}
