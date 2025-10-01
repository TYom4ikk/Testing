using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MinValueTest
{
    [TestClass]
    public class UnitTestMinValue
    {
        [TestMethod]
        public void AllPositiveInt()
        {
            int result = MinValueLibrary.MinValue.MinInt(3, 56, 1);
            Assert.AreEqual(1, result);
        }
        [TestMethod]
        public void AllNegativeInt()
        {
            int result = MinValueLibrary.MinValue.MinInt(-3, -56, -1);
            Assert.AreEqual(-56, result);
        }
        [TestMethod]
        public void AllPositiveAndNegativeInt()
        {
            int result = MinValueLibrary.MinValue.MinInt(3, -9, 1);
            Assert.AreEqual(-9, result);
        }
        [TestMethod]
        public void HaveHullInt()
        {
            int result = MinValueLibrary.MinValue.MinInt(3, 0, 1);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AllPositiveFloat()
        {
            float result = MinValueLibrary.MinValue.MinFloat(3.7f, 3.5f, 1.2f);
            Assert.AreEqual(1.2f, result);
        }
        [TestMethod]
        public void AllNegativeFloat()
        {
            float result = MinValueLibrary.MinValue.MinFloat(-3.1f, -56.5f, -1.6f);
            Assert.AreEqual(-56.5f, result);
        }
        [TestMethod]
        public void AllPositiveAndNegativeFloat()
        {
            float result = MinValueLibrary.MinValue.MinFloat(-3.1f, -3.2f, 1.3f);
            Assert.AreEqual(-3.2f, result);
        }
        [TestMethod]
        public void HaveHullFloat()
        {
            float result = MinValueLibrary.MinValue.MinFloat(3.2f, 0f, 1.6f);
            Assert.AreEqual(0, result);
        }
    }
}
