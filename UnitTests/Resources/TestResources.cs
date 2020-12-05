using DataLib.Models;
using ServiceLib.Interfaces;
using ServiceLib.Services;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTests.Resources
{

    public static class TestResources
    {

        #region Fields

        public static string FilePath => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Resources", "products.txt");
        public static IRepository<Product> Repository => new ProductJSONRepository(FilePath);
        public static IEnumerable<object[]> Products =>
            new List<object[]>
            {
                new Product[]
                {
                    new BakeryProduct("Хлеб", 1, 1.55m, 10),
                    new ElectricalProduct("Телефон", 2, 1000m, 20),
                    new BakeryProduct("Смаженка", 100, 2.35m, 20),
                    new ElectricalProduct("Автомобиль", 5, 1000000m, 50)
                },
                new Product[]
                {
                    new BakeryProduct("Батон", 1, 1.55m, 10),
                    new BakeryProduct("Багет", 100, 5.35m, 0)
                }
            };

        #endregion

    }

}
