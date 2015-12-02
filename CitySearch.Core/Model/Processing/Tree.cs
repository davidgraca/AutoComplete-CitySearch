// <copyright file="Tree.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Processing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Classes;
    using Interfaces;

    /// <summary>
    /// Generic tree
    /// </summary>
    /// <typeparam name="T">Tree Node Base</typeparam>
    public class Tree<T> : ITree where T : TreeNodeBase, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Tree{T}"/> class.
        /// </summary>
        public Tree()
        {
            this.Root = new T();
            this.Root.Init(char.MinValue, string.Empty, null, null);
            this.CurrentNode = this.Root;
        }

        /// <summary>
        /// Gets the root.
        /// </summary>
        /// <value>
        /// The root.
        /// </value>
        public ITreeNode Root { get; }

        /// <summary>
        /// Gets or sets the current node.
        /// </summary>
        /// <value>
        /// The current node.
        /// </value>
        public ITreeNode CurrentNode { get; set; }

        /// <summary>
        /// Adds the node.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="items">The items.</param>
        public void AddNode(string str, List<ISearchableItem> items)
        {
            if (string.IsNullOrEmpty(str) || items == null || !items.Any())
            {
                throw new ArgumentNullException("Must pass filled arguments.");
            }

            ITreeNode node = null;

            T newNode = new T();
            newNode.Init(str.Substring(str.Length - 1, 1)[0], str, null, items.Select(s => s.Id).ToArray());

            if (str.Length == 1)
            {
                node = this.Root;
                this.CurrentNode = this.Root;
                this.CurrentNode.UpdateTreeChildren(newNode);
            }
            else
            {
                // Get parent
                node = this.Search(str.Substring(0, str.Length - 1));
                node.UpdateTreeChildren(newNode);
            }
        }

        /// <summary>
        /// Searches the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>I TreeNode</returns>
        public ITreeNode Search(string query)
        {
            int position = 0;

            this.CurrentNode = this.Root;
            return this.SearchRecursive(query, position, this.CurrentNode);
        }

        /// <summary>
        /// Searches the recursive.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="position">The position.</param>
        /// <param name="node">The node.</param>
        /// <returns>I Tree Node</returns>
        private ITreeNode SearchRecursive(string query, int position, ITreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Name == query)
            {
                return node;
            }

            if (position > query.Length - 1)
            {
                return null;
            }

            // couldn't find 
            if (node.IsFinalNode)
            {
                return node;
            }

            char currentChar = query[position];
            var nextNode = node.SearchChild(currentChar);

            // go to next character
            return this.SearchRecursive(query, ++position, nextNode);
        }
    }
}
