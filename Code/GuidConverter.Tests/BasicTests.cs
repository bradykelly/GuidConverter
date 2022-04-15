using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuidConverter.Tests;

[TestClass]
public class BasicTests 
{
    // These two strings are equivalent so do not ever change either of them.
    private const string FixedString = "53F25E081D5449479C1342D82027E12B";
    private static readonly Guid FixedGuid = new Guid("085ef253-541d-4749-9c13-42d82027e12b");

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FromRawThrowsOnInvalidLength()
    {
        var testGuid = GuidConverter.Core.GuidConverter.FromRaw("53F25E081D5449");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void FromRawThrowsOnInvalidChars()
    {
        var testGuid = GuidConverter.Core.GuidConverter.FromRaw("53G25E081H5449479C1342D8X027E12B");
    }

    [TestMethod]
    public void FromRawConvertsCorrectly()
    {
        var testGuid = GuidConverter.Core.GuidConverter.FromRaw(FixedString);
        Assert.AreEqual(FixedGuid, testGuid);
    }

    [TestMethod]
    public void ToRawConvertsCorrectly()
    {
        var testString = GuidConverter.Core.GuidConverter.ToRaw(FixedGuid);
        Assert.AreEqual(FixedString, testString);
    }
}