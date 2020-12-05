using DataLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ServiceLib.Interfaces;
using ServiceLib.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace UnitTests.Tests
{
    [TestClass]
    public class ServiceLibTest
    {
        private static readonly string _filePath = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Resources", "products.txt");
        private static readonly IRepository<Product> _repository = new ProductJSONRepository(_filePath);

        [TestMethod]
        public void TestMethod1()
        {
            Product product1 = new BakeryProduct("Хлеб", 1, 1.55m, 10);
            Product product2 = new ElectricalProduct("Телефон", 2, 1000m, 20);

            List<Product> products = new List<Product> { product1, product2 };

            _repository.Save(products);

            List<Product> result = _repository.Load().ToList();
            Assert.IsInstanceOfType(result[0], typeof(BakeryProduct));
        }
    }
}
