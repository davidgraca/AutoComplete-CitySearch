// <copyright file="ISearchableItem.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Interfaces
{
    using Enum;

    /// <summary>
    /// Interface of Storage results
    /// </summary>
    public interface ISearchableItem
    {
        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        int Id { get; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; }

        /// <summary>
        /// Gets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        LanguageEnum Language { get; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        CategoryEnum Category { get; }
    }
}