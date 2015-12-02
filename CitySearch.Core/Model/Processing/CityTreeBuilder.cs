// <copyright file="CityTreeBuilder.cs" company="me">
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
    using Storage;

    /// <summary>
    /// Tree builder pattern for cities
    /// </summary>
    public class CityTreeBuilder
    {
        /// <summary>
        /// The private  _tree
        /// </summary>
        private readonly Tree<CityTreeNode> _tree;

        /// <summary>
        /// The data _items
        /// </summary>
        private Dictionary<int, ISearchableItem> _items;

        /// <summary>
        /// Initializes a new instance of the <see cref="CityTreeBuilder"/> class.
        /// </summary>
        public CityTreeBuilder()
        {
            this._tree = new Tree<CityTreeNode>();
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns>Tree of City Tree Node</returns>
        public Tree<CityTreeNode> Build()
        {
            if (this._items == null || this._tree == null)
            {
                throw new NullReferenceException("Please load data first.");
            }

            return this._tree;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns>City Tree Builder</returns>
        public CityTreeBuilder GetData()
        {
            this._items = CityStorage.Instance.GetData();
            return this;
        }

        /// <summary>
        /// Loads the tree.
        /// </summary>
        /// <returns>City Tree Builder</returns>
        /// <exception cref="System.NullReferenceException">Please load data first.</exception>
        public CityTreeBuilder LoadTree()
        {
            if (this._items == null)
            {
                throw new NullReferenceException("Please load data first.");
            }

            int maxLength = this._items.Max(w => w.Value.Name.Length);

            for (int length = 1; length < maxLength; length++)
            {
                var lengthlocal = length;

                var items = this._items
                    .Where(w => w.Value.Name.Length >= lengthlocal)
                    .GroupBy(pair => pair.Value.Name.ToLower().Substring(0, lengthlocal));

                foreach (var item in items)
                {
                    string str = item.Key;
                    List<ISearchableItem> cities = new List<ISearchableItem>();
                    foreach (KeyValuePair<int, ISearchableItem> pair in item)
                    {
                        cities.Add(pair.Value);
                    }

                    this._tree.AddNode(str, cities);
                }
            }

            return this;
        }
    }
}
