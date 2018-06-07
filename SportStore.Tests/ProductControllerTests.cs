using Microsoft.AspNetCore.Mvc;
using Moq;
using SportStore.Controllers;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SportStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Index()
        {
            //arrange
            Mock<IRepository> mock = new Mock<IRepository>();
            mock.Setup(x => x.Products).Returns(new Product[] {
                new Product{ProductID=1, Name="P1"},
                new Product{ProductID=2, Name="P2"},
                new Product{ProductID=3, Name="P3"}
            }.AsQueryable());

            var products = new Product[] {
                new Product{ProductID=1, Name="P1"},
                new Product{ProductID=2, Name="P2"},
                new Product{ProductID=3, Name="P3"}
            };
            ProductController controller = new ProductController(mock.Object);
            

            //act
            IEnumerable<Product> result = controller.Index(null).ViewData.Model as IEnumerable<Product>;

            //assert
            Assert.Equal(3, result.Count());
        }
    }
}
