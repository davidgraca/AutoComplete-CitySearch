// <copyright file="TreeNodeBase.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Classes
{
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    /// <summary>
    /// Base class for tree nodes
    /// </summary>
    public abstract class TreeNodeBase : ITreeNode
    {
        /// <summary>
        /// The _children dictionary
        /// </summary>
        protected internal Dictionary<char, ITreeNode> ChildrenDictionary;

        /// <summary>
        /// The _data ids
        /// </summary>
        protected internal int[] DataIds;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeBase"/> class.
        /// </summary>
        public TreeNodeBase()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeNodeBase"/> class.
        /// </summary>
        /// <param name="currentChar">The current character.</param>
        /// <param name="currentString">The current string.</param>
        /// <param name="node">The node.</param>
        /// <param name="dataIds">The data ids.</param>
        internal TreeNodeBase(char currentChar, string currentString, ITreeNode node, int[] dataIds)
        {
            this.Init(currentChar, currentString, node, dataIds);
        }

        /// <summary>
        /// Initializes the specified current node.
        /// </summary>
        /// <param name="currentChar">The current character.</param>
        /// <param name="currentString">The current string.</param>
        /// <param name="node">The node.</param>
        /// <param name="dataIds">The data ids.</param>
        public void Init(char currentChar, string currentString, ITreeNode node, int[] dataIds)
        {
            this.CurrentCharacter = currentChar;
            this.Name = currentString;

            this.DataIds = dataIds;
            this.ComputeToDictionary(node);
        }

        /// <summary>
        /// Gets or sets the current character.
        /// </summary>
        /// <value>
        /// The current character.
        /// </value>
        public char CurrentCharacter { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is final node.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is final node; otherwise, <c>false</c>.
        /// </value>
        public bool IsFinalNode
        {
            get
            {
                return this.ChildrenDictionary == null;
            }
        }

        /// <summary>
        /// Searches the child.
        /// </summary>
        /// <param name="nextCharacter">The next character.</param>
        /// <returns>I TreeNode</returns>
        public ITreeNode SearchChild(char nextCharacter)
        {
            // Handle null field.
            if (this.ChildrenDictionary == null)
            {
                this.ChildrenDictionary = new Dictionary<char, ITreeNode>();
            }

            // Lookup and return if possible.
            ITreeNode result;
            if (this.ChildrenDictionary.TryGetValue(nextCharacter, out result))
            {
                return result;
            }

            return null;
        }

        /// <summary>
        /// Gets the possible results.
        /// </summary>
        /// <returns>Auto Complete Result</returns>
        public virtual AutoCompleteResult GetPossibleResults()
        {
            if (this.ChildrenDictionary == null)
            {
                return null;
            }

            char[] validChars = this.ChildrenDictionary.Keys.ToArray();
            string[] validOptions = this.DataIds.Select(s => s.ToString()).ToArray();

            return new AutoCompleteResult(validOptions, validChars);
        }

        /// <summary>
        /// Gets the valid options.
        /// </summary>
        /// <param name="dataIds">The data ids.</param>
        /// <returns>List strings</returns>
        public virtual List<string> GetValidOptions(int[] dataIds)
        {
            if (dataIds == null)
            {
                return null;
            }

            return dataIds.Select(s => s.ToString()).ToList();
        }

        /// <summary>
        /// Updates the tree children.
        /// </summary>
        /// <param name="nodes">The nodes.</param>
        public void UpdateTreeChildren(ITreeNode nodes)
        {
            this.ComputeToDictionary(nodes);
        }

        /// <summary>
        /// Computes to dictionary.
        /// </summary>
        /// <param name="node">The node.</param>
        private void ComputeToDictionary(ITreeNode node)
        {
            if (node == null)
            {
                return;
            }

            if (this.ChildrenDictionary == null)
            {
                this.ChildrenDictionary = new Dictionary<char, ITreeNode>();
            }

            if (!this.ChildrenDictionary.ContainsKey(node.CurrentCharacter))
            {
                this.ChildrenDictionary.Add(node.CurrentCharacter, node);
            }
        }
    }
}