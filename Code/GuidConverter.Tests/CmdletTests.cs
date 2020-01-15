using System;
using GuidConverter.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GuidConverter.Tests
{
    [TestClass]
    public class CmdletTests
    {
        [TestMethod]
        public void ShouldCreateCmdLet()
        {
            var cmdlet = new NewGuidCommand();

            Assert.IsNotNull(cmdlet);
            Assert.IsTrue(cmdlet is System.Management.Automation.Cmdlet);
        }

        [TestMethod]
        public void ShouldCreateGuid()
        {
            var cmdlet = new NewGuidCommand();

            var result = cmdlet.Invoke().GetEnumerator();
            
            Assert.IsTrue(result.MoveNext());
            Assert.IsTrue(result.Current is Guid);
        }
    }
}
