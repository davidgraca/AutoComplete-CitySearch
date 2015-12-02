// <copyright file="InitTests.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Tests.Model.Classes
{
    using System;
    using Core.Model.Classes;
    using Core.Model.Enum;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Initialization Tests
    /// </summary>
    [TestClass]
    public class InitTests
    {
        /// <summary>
        /// Constructors the tests.
        /// </summary>
        [TestMethod]
        public void ContructorTests()
        {
            try
            {
                new CitySearchableItem(-23, string.Empty, LanguageEnum.English);
                Assert.Fail("No exception was thrown");
            }
            catch (ArgumentNullException)
            {
                Assert.IsTrue(true);
            }

            Assert.IsNotNull(new AutoCompleteResult(null, null), "Should be able to create when no results appear.");
        }
    }
}
