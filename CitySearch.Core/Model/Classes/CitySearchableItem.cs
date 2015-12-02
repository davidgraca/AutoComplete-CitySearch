// <copyright file="CitySearchableItem.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Classes
{
    using System;
    using Enum;
    using Interfaces;

    /// <summary>
    /// DAL object that contains raw data
    /// </summary>
    public class CitySearchableItem : ISearchableItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CitySearchableItem" /> class.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="name">The name.</param>
        /// <param name="lang">The language.</param>
        /// <exception cref="System.ArgumentNullException">Can't have negative ids.</exception>
        public CitySearchableItem(int id, string name, LanguageEnum lang)
        {
            if (id < 0)
            {
                throw new ArgumentNullException("Can't have negative ids.");
            }

            this.Id = id;
            this.Name = name;
            this.Language = lang;
            this.Category = CategoryEnum.City;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public LanguageEnum Language { get; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public CategoryEnum Category { get; }
    }
}
