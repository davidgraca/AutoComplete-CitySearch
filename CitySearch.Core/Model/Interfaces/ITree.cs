// <copyright file="ITree.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface of the trees
    /// </summary>
    public interface ITree
    {
        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        ITreeNode Root { get; }

        /// <summary>
        /// Gets or sets the current node.
        /// </summary>
        /// <value>
        /// The current node.
        /// </value>
        ITreeNode CurrentNode { get; set; }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="items">The items.</param>
        void AddNode(string str, List<ISearchableItem> items);

        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>I TreeNode</returns>
        ITreeNode Search(string query);
    }
}