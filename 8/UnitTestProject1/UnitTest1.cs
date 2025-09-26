using FractionFormLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FractionForm fractionFrom = new FractionForm();
            var result = fractionFrom.FixWrongResult("1/10");
            Assert.AreEqual("1/10", result);


        }
        [TestMethod]
        public void TestMethod2()
        {
            FractionForm fractionFrom = new FractionForm();
            var result = fractionFrom.FixWrongResult("251/100");
            Assert.AreEqual("100/100", result);
        }

        [TestMethod]
        public void TestMethod3()
        {
            FractionForm fractionFrom = new FractionForm();
            Assert.ThrowsException<ArgumentException>(() => fractionFrom.FixWrongResult("-10/10"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            FractionForm fractionFrom = new FractionForm();
            Assert.ThrowsException<ArgumentException>(() => fractionFrom.FixWrongResult(""));
        }

        [TestMethod]
        public void TestMethod5()
        {
            FractionForm fractionFrom = new FractionForm();
            Assert.ThrowsException<ArgumentException>(() => fractionFrom.FixWrongResult("/"));
        }

        [TestMethod]
        public void TestMethod6()
        {
            FractionForm fractionFrom = new FractionForm();
            Assert.ThrowsException<ArgumentException>(() => fractionFrom.FixWrongResult("35/10/10/25"));
        }

        [TestMethod]
        public void TestMethod7()
        {
            FractionForm fractionFrom = new FractionForm();
            Assert.ThrowsException<ArgumentException>(() => fractionFrom.FixWrongResult("10/1b"));
        }

        [TestMethod]
        public void TestMethod8()
        {
            FractionForm fractionFrom = new FractionForm();
            Assert.ThrowsException<ArgumentException>(() => fractionFrom.FixWrongResult("1010"));
        }
    }
}
