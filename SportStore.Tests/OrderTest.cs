using Microsoft.AspNetCore.Mvc;
using Moq;
using SportStore.Controllers;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace SportStore.Tests
{
    public class OrderTest
    {
        [Fact]
        public void CanSubmitOrder()
        {
            // Arrange 
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            Product p = new Product() { Name = "p1", ProductID = 0 };
            cart.AddItem(p, 1);            
            OrderController controller = new OrderController(mock.Object, cart);

            // Act 
            RedirectToActionResult result =
            controller.Index(new Order()) as RedirectToActionResult;

            // Assert 
            mock.Verify(m => m.SaveOrder(It.IsAny<Order>()), Times.Once);
            Assert.Equal("Thanks", result.ActionName);
        }
    }
}
