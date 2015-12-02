// <copyright file="TreeTests.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Tests.Model.Processing
{
    using System;
    using Core.Model.Classes;
    using Core.Model.Processing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tree tests
    /// </summary>
    [TestClass]
    public class TreeTests
    {
        /// <summary>
        /// Trees the manipulation test.
        /// </summary>
        [TestMethod]
        public void TreeManipulationTest()
        {
            Tree<CityTreeNode> tree = new CityTreeBuilder()
                .GetData()
                .LoadTree()
                .Build();

            Assert.IsNotNull(tree, "Shouldn't be null");

            Assert.AreEqual(tree.CurrentNode, tree.Root, "Should be equal at start.");

            Assert.IsNotNull(tree.Search("kom"), "Should be able to find node.");

            try
            {
                tree.AddNode(string.Empty, null);
                Assert.Fail("Shouldn't be able to add empty name node.");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
