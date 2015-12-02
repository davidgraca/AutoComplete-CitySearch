// <copyright file="ITreeNode.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Interfaces
{
    using System.Collections.Generic;
    using Classes;

    /// <summary>
    /// Interface of the tree node
    /// </summary>
    public interface ITreeNode
    {
        /// <summary>
        /// Gets or sets the current character.
        /// </summary>
        /// <value>
        /// The current character.
        /// </value>
        char CurrentCharacter { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        string Name { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is final node.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is final node; otherwise, <c>false</c>.
        /// </value>
        bool IsFinalNode { get; }

        /// <summary>
        /// Searches the childs.
        /// </summary>
        /// <param name="nextCharacter">The next character.</param>
        /// <returns>I TreeNode</returns>
        ITreeNode SearchChild(char nextCharacter);

        /// <summary>
        /// Gets the possible results.
        /// </summary>
        /// <returns>Auto Complete Result</returns>
        AutoCompleteResult GetPossibleResults();

        /// <summary>
        /// Gets the valid options.
        /// </summary>
        /// <param name="dataIds">The data ids.</param>
        /// <returns> List of string</returns>
        List<string> GetValidOptions(int[] dataIds);

        /// <summary>
        /// Updates the tree children.
        /// </summary>
        /// <param name="node">The node.</param>
        void UpdateTreeChildren(ITreeNode node);

        /// <summary>
        /// Initializes the specified current character.
        /// </summary>
        /// <param name="currentChar">The current character.</param>
        /// <param name="currentString">The current string.</param>
        /// <param name="node">The node.</param>
        /// <param name="dataIds">The data ids.</param>
        void Init(char currentChar, string currentString, ITreeNode node, int[] dataIds);
    }
}