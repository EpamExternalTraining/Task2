using System.Collections.Generic;

namespace ServiceLib.Interfaces
{

    /// <summary>
    /// Pattern repository
    /// </summary>
    /// <typeparam name="T">Class that will be stored in this repository</typeparam>
    public interface IRepository<T>
    {

        #region Methods

        /// <summary>
        /// Saves IEnumerable of objects
        /// </summary>
        /// <param name="value">IEnumerable to save</param>
        void Save(IEnumerable<T> value);

        /// <summary>
        /// Loads IEnumerable of objects
        /// </summary>
        /// <returns>Loaded IEnumerable of objects</returns>
        IEnumerable<T> Load();

        #endregion

    }

}
