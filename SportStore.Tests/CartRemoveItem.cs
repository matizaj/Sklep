using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportStore.Models;
using Xunit;

namespace SportStore.Tests
{
    public class CartRemoveItem
    {
        [Fact]
        public void CanRemoveItem()
        {
            //arrange
            var p1 = new Product() { Name = "P1", ProductID = 1 };
            var p2 = new Product() { Name = "P2", ProductID = 2 };
            var p3 = new Product() { Name = "P3", ProductID = 3 };
            var cart = new Cart();
            cart.AddItem(p1, 10);
            cart.AddItem(p2, 1);
            cart.AddItem(p3, 1);

            //act
            cart.RemoveLine(p1);

            //assert
            Assert.Equal(2,cart.Items.Count());
        }
    }
}
