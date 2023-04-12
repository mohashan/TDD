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

        [Test]
        public void ShouldReturnArticlesAddedToCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                item = item1
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            var item2 = new AddToCartItem()
            {
                ArticleId = 32,
                Quantity = 2
            };

            request = new AddToCartRequest()
            {
                item = item2
            };

            response = manager.AddToCart(request);
            response = manager.AddToCart(request);


            Assert.IsNotNull(response);
            Assert.Contains(item1, response.Items);
            Assert.Contains(item2, response.Items);
        }

        [Test]
        public void ShouldReturnCombinedQuantityWhenSameArticleAddedToCart()
        {
            var item1 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 5
            };

            var request = new AddToCartRequest()
            {
                item = item1
            };

            var manager = new ShoppingCartManager();

            AddToCartResponse response = manager.AddToCart(request);

            var item2 = new AddToCartItem()
            {
                ArticleId = 42,
                Quantity = 2
            };

            request = new AddToCartRequest()
            {
                item = item2
            };

            response = manager.AddToCart(request);


            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Items);
            Assert.That(response.Items.Length == 1);
            Assert.That(response.Items.FirstOrDefault(c=>c.ArticleId == 42).Quantity == 7);
        }
    }
}
