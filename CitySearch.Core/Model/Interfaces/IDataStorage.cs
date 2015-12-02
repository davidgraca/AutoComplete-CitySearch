// <copyright file="IDataStorage.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Interfaces
{
    using System.Collections.Generic;
   
    /// <summary>
    /// Interface for data storages
    /// </summary>
    public interface IDataStorage
    {
        /// <summary>
        /// Finds the specified keys.
        /// </summary>
        /// <param name="keys">The keys.</param>
        /// <returns>List strings</returns>
        List<string> Find(int[] keys);

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>Dictionary id and items</returns>
        Dictionary<int, ISearchableItem> GetData();
    }
}