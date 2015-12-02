// <copyright file="AutoCompleteResult.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Classes
{
    using System.Text;
    using Interfaces;

    /// <summary>
    /// Output result class for tree search.
    /// </summary>
    public class AutoCompleteResult : IResult
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteResult"/> class.
        /// </summary>
        /// <param name="validOptions">The valid options.</param>
        /// <param name="nextCharacters">The next characters.</param>
        public AutoCompleteResult(string[] validOptions, char[] nextCharacters)
        {
            this.ValidOptions = validOptions;
            this.NextCharacters = nextCharacters;
        }

        /// <summary>
        /// Gets the valid options.
        /// </summary>
        /// <value>
        /// The valid options.
        /// </value>
        public string[] ValidOptions { get; }

        /// <summary>
        /// Gets the next characters.
        /// </summary>
        /// <value>
        /// The next characters.
        /// </value>
        public char[] NextCharacters { get; }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Next characters");
            sb.AppendLine(string.Join(",", this.NextCharacters).Replace(" ", "(space)"));
            sb.AppendLine("Valid options");
            sb.AppendLine(string.Join(",", this.ValidOptions));
            return sb.ToString();
        }
    }
}