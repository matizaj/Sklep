using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportStore.Models;
using Xunit;

namespace SportStore.Tests
{
    public class CartAddItemTest
    {
        [Fact]
        public void CanAddNewItem()
        {
            //arrange
            var p1 = new Product() {Name = "P1", ProductID = 1};
            var p2 = new Product() {Name = "P2", ProductID = 2};
            var p3 = new Product() {Name = "P3", ProductID = 3};
            var cart = new Cart();

            //act
            cart.AddItem(p1,1);
            cart.AddItem(p2,1);
            cart.AddItem(p3,1);
            var resutl = cart.Items.ToArray();

            //assert
            Assert.Equal(3, cart.Items.Count());
            Assert.Equal(p2, resutl[1].Product);

        }

        [Fact]
        public void CanAddItem()
        {
            //arrange
            var p1 = new Product() { Name = "P1", ProductID = 1 };
            var p2 = new Product() { Name = "P2", ProductID = 2 };
            var p3 = new Product() { Name = "P3", ProductID = 3 };
            var cart = new Cart();

            //act
            cart.AddItem(p1, 1);
            cart.AddItem(p1, 1);
            cart.AddItem(p2, 1);
            cart.AddItem(p3, 1);
            cart.AddItem(p3, 1);
            var resutl = cart.Items.ToArray();

            //assert
            Assert.Equal(3, cart.Items.Count());
            Assert.Equal(2, resutl[0].Quantity);

        }
    }
}
