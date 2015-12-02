// <copyright file="IResult.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Interfaces
{
    /// <summary>
    /// Interface of tree results
    /// </summary>
    public interface IResult
    {
        /// <summary>
        /// Gets the valid options.
        /// </summary>
        /// <value>
        /// The valid options.
        /// </value>
        string[] ValidOptions { get; }

        /// <summary>
        /// Gets the next characters.
        /// </summary>
        /// <value>
        /// The next characters.
        /// </value>
        char[] NextCharacters { get; }
    }
}