// <copyright file="CityTreeNode.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Core.Model.Classes
{
    using System.Collections.Generic;
    using System.Linq;
    using Storage;

    /// <summary>
    /// Node of the tree that represents a city
    /// </summary>
    public class CityTreeNode : TreeNodeBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CityTreeNode"/> class.
        /// </summary>
        public CityTreeNode()
        {
        }

        /// <summary>
        /// Gets the valid options.
        /// </summary>
        /// <param name="dataIds">The data ids.</param>
        /// <returns>List of string </returns>
        public override List<string> GetValidOptions(int[] dataIds)
        {
            if (dataIds == null)
            {
                return null;
            }

            return CityStorage.Instance.Find(dataIds);
        }

        /// <summary>
        /// Gets the possible results.
        /// </summary>
        /// <returns>Auto Complete Result</returns>
        public override AutoCompleteResult GetPossibleResults()
        {
            if (this.ChildrenDictionary == null)
            {
                return null;
            }

            char[] validChars = ChildrenDictionary.Keys.ToArray();
            string[] validOptions = this.GetValidOptions(DataIds).ToArray();

            return new AutoCompleteResult(validOptions, validChars);
        }
    }
}
