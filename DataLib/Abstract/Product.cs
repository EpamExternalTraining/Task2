using System;

namespace DataLib.Models
{

    /// <summary>
    /// Abstract class which represents Product
    /// </summary>
    public abstract class Product
    {

        #region Fields

        /// <summary>
        /// Amount of the product
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Name of the product
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Price of the product
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Markup of the product
        /// </summary>
        public decimal Markup { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of the product</param>
        /// <param name="amount">Amount of ther product</param>
        /// <param name="price">Price of the product</param>
        /// <param name="markup">Markup of the product</param>
        protected Product(string name, uint amount, decimal price, decimal markup)
        {
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Markup = markup;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Calculates unit cost
        /// </summary>
        /// <returns>Unit cost</returns>
        public decimal GetUnitCost()
        {
            return Price * (1 + (100 / Markup));
        }

        /// <summary>
        /// Calculates summary cost
        /// </summary>
        /// <returns>Summary cost</returns>
        public decimal GetSummaryCost()
        {
            return GetUnitCost() * Amount;
        }

        /// <summary>
        /// Determines whether the specified Product is equal to the current Product.
        /// </summary>
        /// <param name="obj">The Product to compare with the current Product.</param>
        /// <returns>true if the specified Product is equal to the current Product; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            Product other = (Product)obj;
            bool Answer = obj != null;

            Answer &= this.Name.Equals(other.Name);
            Answer &= this.Amount.Equals(other.Amount);
            Answer &= this.Price.Equals(other.Price);
            Answer &= this.Markup.Equals(other.Markup);

            return Answer;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current Product.</returns>
        public override int GetHashCode()
        {
            int hashCode = -3379;

            hashCode = hashCode * 9973 + Name.GetHashCode();
            hashCode = hashCode * 9973 + Amount.GetHashCode();
            hashCode = hashCode * 9973 + Price.GetHashCode();
            hashCode = hashCode * 9973 + Markup.GetHashCode();

            return hashCode;
        }

        /// <summary>
        /// Returns a string that represents the current Product.
        /// </summary>
        /// <returns>A string that represents the current Product.</returns>
        public override string ToString()
        {
            return $"{Name}; {Amount}; {Price}; {Markup}%;";
        }

        /// <summary>
        /// Overloaded implicit operator for casting product to integer
        /// </summary>
        /// <param name="p">Product</param>
        public static implicit operator int(Product p) => (int)Math.Ceiling(p.GetSummaryCost() * 100);

        /// <summary>
        /// Overloaded implicit operator for castring product to decimal
        /// </summary>
        /// <param name="p">Product</param>
        public static implicit operator decimal(Product p) => p.GetSummaryCost();

        #endregion

    }

}
