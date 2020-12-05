using DataLib.Exceptions;
using DataLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using UnitTests.Resources;

namespace UnitTests.Tests
{
    [TestClass]
    public class DataLibTest
    {

        #region Resources

        private static IEnumerable<object[]> _products => TestResources.Products;

        private static IEnumerable<object[]> _productsSum => new List<object[]>
        {
            new object[]
                {
                    101u,
                    2m,
                    15m,
                    new BakeryProduct("Хлеб", 1, 1.55m, 10),
                    new BakeryProduct("Хлеб", 100, 2.45m, 20)
                },
        };

        private static IEnumerable<object[]> _productsIncorrectSum => new List<object[]>
        {
            new Product[]
                {
                    new BakeryProduct("Хлеб", 1, 1.55m, 10),
                    new BakeryProduct("Смаженка", 100, 2.35m, 20)
                },
        };

        #endregion

        #region Tests

        [Description("Decreases amount and check if correct decrease")]
        [DataTestMethod]
        [DynamicData(nameof(_products))]
        public void DecreaseAmount_CorrectDecrease(params Product[] products)
        {
            foreach (Product product in products)
            {
                if (product is BakeryProduct bp)
                {
                    Assert.AreEqual((bp - 5).Amount, bp.Amount - 5);
                }
                if (product is ElectricalProduct el)
                {
                    Assert.AreEqual((el - 5).Amount, el.Amount - 5);
                }
            }
        }

        [Description("Sum two equal products")]
        [DataTestMethod]
        [DynamicData(nameof(_productsSum))]
        public void SumEqualProducts_CorrectSum(uint amount, decimal price, decimal markup,params Product[] products)
        {
            BakeryProduct bp1 = products[0] as BakeryProduct;
            BakeryProduct bp2 = products[1] as BakeryProduct;
            BakeryProduct sum = bp1 + bp2;

            Assert.AreEqual(amount, sum.Amount);
            Assert.AreEqual(price, sum.Price);
            Assert.AreEqual(markup, sum.Markup);
        }

        [Description("Sum two equal products and catch DifferentNameException")]
        [DataTestMethod]
        [DynamicData(nameof(_productsIncorrectSum))]
        public void SumEqualProducts_DifferentNameException(params Product[] products)
        {
            BakeryProduct bp1 = products[0] as BakeryProduct;
            BakeryProduct bp2 = products[1] as BakeryProduct;
            Assert.ThrowsException<DifferentNameException>(()=>bp1 + bp2);
        }

        [Description("Checks if correct Cost calculating")]
        [DataTestMethod]
        [DynamicData(nameof(_productsIncorrectSum))]
        public void CalculateCosts_CorrectCalculating(params Product[] products)
        {
            foreach(Product product in products)
            {
                Assert.AreEqual(product.Price * (1 + 100 / product.Markup), product.GetUnitCost());
                Assert.AreEqual(product.Price * product.Amount * (1 + 100 / product.Markup), product.GetSummaryCost());
            }
        }

        [Description("Cast to decimal and int and check for correct casting")]
        [DataTestMethod]
        [DynamicData(nameof(_productsIncorrectSum))]
        public void CastToDecimalAndInt_CorrectCasting(params Product[] products)
        {
            foreach(Product item in products)
            {
                int res1 = item;
                decimal res2 = item;
                Assert.AreEqual(res1, Math.Ceiling(item.GetSummaryCost() * 100));
                Assert.AreEqual(res2, item.GetSummaryCost());
            }
        }

        [Description("Cast to other product type and check for correct casting")]
        [DataTestMethod]
        [DynamicData(nameof(_productsIncorrectSum))]
        public void CastToOtherProductType_CorrectCasting(params Product[] products)
        {
            foreach (Product item in products)
            {
                if (item is BakeryProduct bp)
                {
                    ElectricalProduct electricalProduct = bp;
                    Assert.AreEqual(new ElectricalProduct(bp.Name, bp.Amount, bp.Price, bp.Markup), electricalProduct);
                }
                if (item is ElectricalProduct el)
                {
                    BakeryProduct bakeryProduct = el;
                    Assert.AreEqual(new BakeryProduct(el.Name, el.Amount, el.Price, el.Markup), bakeryProduct);
                }

            }
        }

        #endregion

    }
}
