using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuidConverter.Tests
{
    [TestClass]
    public class BasicTests 
    {
        private const string fixedString = "53F25E081D5449479C1342D82027E12B";
        private static readonly Guid fixedGuid = new Guid("085ef253-541d-4749-9c13-42d82027e12b");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLengthCheck()
        {
            var testGuid = GuidConverter.Core.GuidConverter.FromRaw("53F25E081D5449");
        }

        [TestMethod]
        public void TestFromRaw()
        {
            var testGuid = GuidConverter.Core.GuidConverter.FromRaw(fixedString);
            Assert.AreEqual(fixedGuid, testGuid);
        }

        [TestMethod]
        public void TestFromGuid()
        {
            var testString = GuidConverter.Core.GuidConverter.ToRaw(fixedGuid);
            Assert.AreEqual(fixedString, testString);
        }
    }
}
