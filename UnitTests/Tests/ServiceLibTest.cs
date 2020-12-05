using DataLib.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceLib.Interfaces;
using System.Collections.Generic;
using System.Linq;
using UnitTests.Resources;

namespace UnitTests.Tests
{

    [TestClass]
    public class ServiceLibTest
    {

        #region Resources

        private static IRepository<Product> _repository => TestResources.Repository;
        private static IEnumerable<object[]> _products => TestResources.Products;

        #endregion

        #region Tests

        [Description("Saves products and loades them for correct Save/Load methods")]
        [DynamicData(nameof(_products))]
        [DataTestMethod]
        public void SavingProductsAndLoadingThemFor_CorrectSaveingLoading(params Product[] products)
        {
            _repository.Save(products);

            List<Product> result = _repository.Load().ToList();

            Assert.AreEqual(result.Count, products.Length);
            for (int i=0; i<result.Count; ++i)
            {
                Assert.AreEqual(result[i], products[i]);
            }
        }

        #endregion

    }

}
