using DataLib.Models;
using Newtonsoft.Json;
using ServiceLib.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ServiceLib.Services
{

    /// <summary>
    /// Class which represents JSON repository for products
    /// </summary>
    public class ProductJSONRepository : IRepository<Product>
    {

        #region Fields

        private string _fileName;

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">File name where JSON repository located</param>
        public ProductJSONRepository(string fileName)
        {
            this._fileName = fileName;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads products
        /// </summary>
        /// <returns>IEnumerable of products</returns>
        public IEnumerable<Product> Load()
        {
            List<Product> result = new List<Product>();

            using (StreamReader reader = new StreamReader(_fileName))
            {
                IEnumerable<dynamic> res = JsonConvert.DeserializeObject<IEnumerable<dynamic>>(reader.ReadToEnd());
                foreach (dynamic product in res)
                {
                    string type = product.ProductType;
                    string name = product.Name;
                    uint amount = Convert.ToUInt32(product.Amount);
                    decimal price = Convert.ToDecimal(product.Price);
                    decimal markup = Convert.ToDecimal(product.Markup);

                    if (type == "BakeryProduct")
                    {
                        result.Add(new BakeryProduct(name, amount, price, markup));
                    }
                    if (type == "ElectricalProduct")
                    {
                        result.Add(new ElectricalProduct(name, amount, price, markup));
                    }

                }
            }

            return result;
        }

        /// <summary>
        /// Saves products
        /// </summary>
        /// <param name="products">IEnumerable of products</param>
        public void Save(IEnumerable<Product> products)
        {
            using (StreamWriter writer = new StreamWriter(_fileName))
            {
                writer.Write(JsonConvert.SerializeObject(
                                products
                                    .ToList()
                                    .ConvertAll(item => new
                                    {
                                        ProductType = item.GetType().Name,
                                        item.Name,
                                        item.Amount,
                                        item.Price,
                                        item.Markup
                                    }), Formatting.Indented));

            }
        }

        #endregion

    }

}
