// <copyright file="CityBuilderTests.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Tests.Model.Processing
{
    using System;
    using Core.Model.Processing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// City builder tests
    /// </summary>
    [TestClass]
    public class CityBuilderTests
    {
        /// <summary>
        /// Builds the workflow test.
        /// </summary>
        [TestMethod]
        public void BuildWFTest()
        {
            CityTreeBuilder cs = new CityTreeBuilder();

            Assert.IsNotNull(cs.GetData(), "Shoudn't be null");
            try
            {
                new CityTreeBuilder().LoadTree();
                Assert.Fail("Shouldn't be able to load tree when data is not loaded");
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
            }

            try
            {
                new CityTreeBuilder().Build();
                Assert.Fail("Shouldn't be able to build tree when data and tree is not loaded");
            }
            catch (NullReferenceException)
            {
                Assert.IsTrue(true);
            }

            Assert.IsNotNull(cs.GetData().LoadTree().Build(), "Shoudn't be null");
        }
    }
}
