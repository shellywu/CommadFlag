using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CommandFlagTest
{
    using CommandFlag;
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var command = "/StartedUri=Started://ASImporter /Auto";

            Assert.IsTrue(Flag.TryParse(command, out Flag flag),"splite entity error");

            Assert.IsTrue(flag.Exsit("auto"), "exsit error");
            Assert.IsTrue(flag.Exsit("Auto"), "exsit error");

            Assert.IsTrue(flag.TryGet<string>("StartedUri", out var value),"parseValue error");
            Assert.AreEqual(value, "Started://ASImporter","value error");
        }
    }
}
