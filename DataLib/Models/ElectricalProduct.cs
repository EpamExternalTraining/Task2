using DataLib.Exceptions;
using System;

namespace DataLib.Models
{

    /// <summary>
    /// Class which represents electrical product
    /// </summary>
    public class ElectricalProduct : Product
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the electrical product</param>
        /// <param name="amount">Amount of the electrical product</param>
        /// <param name="price">Price of the electrical product</param>
        /// <param name="markup">Markup of the electrical product</param>
        public ElectricalProduct(string name, uint amount, decimal price, decimal markup) : base(name, amount, price, markup) { }

        #endregion

        #region Methods

        /// <summary>
        /// Overloaded operator+ for two electrical products
        /// </summary>
        /// <param name="ep1">First electrical product</param>
        /// <param name="ep2">Second electrical product</param>
        /// <returns>Resulting electrical product</returns>
        public static ElectricalProduct operator +(ElectricalProduct ep1, ElectricalProduct ep2)
        {
            if (ep1.Name != ep2.Name) throw new DifferentNameException($"{ep1} hasn`t equal name to {ep2}.");
            return new ElectricalProduct(ep1.Name,
                                         ep1.Amount + ep2.Amount,
                                        (ep1.Price + ep2.Price) / 2,
                                        (ep1.Markup + ep2.Markup) / 2);
        }

        /// <summary>
        /// Overloaded operator- for electrical product and integer
        /// </summary>
        /// <param name="ep">Electrical product</param>
        /// <param name="value">Value which decrease amount</param>
        /// <returns>Resultring electrical product</returns>
        public static ElectricalProduct operator-(ElectricalProduct ep, int value)
        {
            return new ElectricalProduct(ep.Name,
                                         (uint)((int)ep.Amount - value),
                                         ep.Price,
                                         ep.Markup);
        }

        /// <summary>
        /// Overloaded implicit operator for casting electrical product to bakery product
        /// </summary>
        /// <param name="ep">Electrical product</param>
        public static implicit operator BakeryProduct(ElectricalProduct ep) => new BakeryProduct(ep.Name, ep.Amount, ep.Price, ep.Markup);

        /// <summary>
        /// Overloaded implicit operator for casting electrical product to integer
        /// </summary>
        /// <param name="ep">Electrical product</param>
        public static implicit operator int(ElectricalProduct ep) => (int)Math.Ceiling(ep.GetSummaryCost() * 100);

        /// <summary>
        /// Overloaded implicit operator for castring electrical product to decimal
        /// </summary>
        /// <param name="ep">Electrical product</param>
        public static implicit operator decimal(ElectricalProduct ep) => ep.GetSummaryCost();

        #endregion

    }

}
