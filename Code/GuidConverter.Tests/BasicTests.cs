using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuidConverter.Tests
{
    [TestClass]
    public class BasicTests 
    {
        private const string FixedString = "53F25E081D5449479C1342D82027E12B";
        private static readonly Guid FixedGuid = new Guid("085ef253-541d-4749-9c13-42d82027e12b");

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestLengthCheck()
        {
            // This should pass as is if the expected exception is always thrown for invalid input.
            var testGuid = GuidConverter.Core.GuidConverter.FromRaw("53F25E081D5449");
        }

        [TestMethod]
        public void TestFromRaw()
        {
            var testGuid = GuidConverter.Core.GuidConverter.FromRaw(FixedString);
            Assert.AreEqual(FixedGuid, testGuid);
        }

        [TestMethod]
        public void TestFromGuid()
        {
            var testString = GuidConverter.Core.GuidConverter.ToRaw(FixedGuid);
            Assert.AreEqual(FixedString, testString);
        }
    }
}
