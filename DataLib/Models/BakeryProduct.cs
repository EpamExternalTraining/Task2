using DataLib.Exceptions;
using System;

namespace DataLib.Models
{

    /// <summary>
    /// Class which represents Bakery product
    /// </summary>
    public class BakeryProduct : Product
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public BakeryProduct() : base() { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the bakery product</param>
        /// <param name="amount">Amount of the bakery product</param>
        /// <param name="price">Price of the bakery product</param>
        /// <param name="markup">Markup of the bakery product</param>
        public BakeryProduct(string name, uint amount, decimal price, decimal markup) : base(name, amount, price, markup) { }

        #endregion

        #region Methods

        /// <summary>
        /// Overloaded operator+ for two bakery products
        /// </summary>
        /// <param name="bp1">First bakery product</param>
        /// <param name="bp2">Second bakery product</param>
        /// <returns>Resulting bakery product</returns>
        public static BakeryProduct operator +(BakeryProduct bp1, BakeryProduct bp2)
        {
            if (bp1.Name != bp2.Name) throw new DifferentNameException($"{bp1} hasn`t equal name to {bp2}.");
            return new BakeryProduct(bp1.Name,
                                     bp1.Amount + bp2.Amount,
                                    (bp1.Price + bp2.Price) / 2,
                                    (bp1.Markup + bp2.Markup) / 2);
        }

        /// <summary>
        /// Overloaded operator- for bakery product and integer
        /// </summary>
        /// <param name="bp">Bakery product</param>
        /// <param name="value">Value which decrease amount</param>
        /// <returns>Resultring bakery product</returns>
        public static BakeryProduct operator -(BakeryProduct bp, int value)
        {
            return new BakeryProduct(bp.Name,
                                     (uint)((int)bp.Amount - value),
                                     bp.Price,
                                     bp.Markup);
        }

        /// <summary>
        /// Overloaded implicit operator for castring bakery product to electrical produtct
        /// </summary>
        /// <param name="bp">Bakery product</param>
        public static implicit operator ElectricalProduct(BakeryProduct bp) => new ElectricalProduct(bp.Name, bp.Amount, bp.Price, bp.Markup);

        /// <summary>
        /// Overloaded implicit operator for casting bakery product to integer
        /// </summary>
        /// <param name="bp">Bakery product</param>
        public static implicit operator int(BakeryProduct bp) => (int)Math.Ceiling(bp.GetSummaryCost() * 100);

        /// <summary>
        /// Overloaded implicit operator for castring bakery product to decimal
        /// </summary>
        /// <param name="bp">Bakery product</param>
        public static implicit operator decimal(BakeryProduct bp) => bp.GetSummaryCost();

        #endregion

    }

}
