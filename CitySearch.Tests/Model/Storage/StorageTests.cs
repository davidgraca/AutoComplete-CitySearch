// <copyright file="StorageTests.cs" company="me">
//    MIT License
// </copyright>
// <author>David Graca</author>
namespace CitySearch.Tests
{
    using System;
    using Core.Model.Storage;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Storage tests
    /// </summary>
    [TestClass]
    public class StorageTests
    {
        /// <summary>
        /// Cities storage data tests.
        /// </summary>
        [TestMethod]
        public void CityStorageDataTests()
        {
            CityStorage cs = new CityStorage();

            Assert.IsNull(cs.Find(null), "Result should be null.");
            var result = cs.Find(new int[] { 1, 2, 3 });
            Assert.IsNotNull(result, "Cities should be exist.");
            Assert.AreEqual(result.Count, 3, "Should return 3 cities.");

            var resultRaw = cs.GetData();
            Assert.IsNotNull(resultRaw, "Cities dictionary should be exist.");
            Assert.AreNotEqual(resultRaw.Count, 0, "Cities dictionary is not filled.");
        }
    }
}
