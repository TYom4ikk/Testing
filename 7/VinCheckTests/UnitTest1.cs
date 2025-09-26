using CheckDataLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace VinCheckTests
{
    [TestClass]
    public class VinCheckTests
    {
        private VinCheck  vinCheck;

        [TestInitialize]
        public void Setup()
        {
            vinCheck = new VinCheck();
        }

        [TestMethod]
        public void Test1()
        {
            string vin = "JHMCM56557C404453";
            int year = 2007;
            bool result = vinCheck.CheckVin(vin, year);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void Test2()
        {
            string vin = "WBAZZZ8A9KA123456";
            string country = vinCheck.GetVINCountry(vin);
            Assert.AreEqual("Германия", country);
        }
        [TestMethod]
        public void Test3()
        {
            string vin = "JHMCM56557C404453";
            string result = vinCheck.GetVINCountry(vin);
            Assert.AreEqual("Япония", result);
        }

        [TestMethod]
        public void Test4()
        {
            string vin = "JHMCM56557C404453";
            int year = 2004;
            bool result = vinCheck.CorrectYear(vin, year);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test5()
        {
            string vin = "JHMCM5655AC404453";
            int year = 1980; 
            bool result = vinCheck.CorrectYear(vin, year);
            Assert.AreEqual(result, true);
        }

        [TestMethod]
        public void Test6()
        {
            string vin = "JHMCM5655AC40445I"; // Недопустимый символ 'I'
            int year = 1980;
            bool result = vinCheck.CheckVin(vin, year);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void Test7()
        {
            string vin = "WAWZZZ4G5C1111391";
            var result = vinCheck.CheckVin(vin, 1111);
            Assert.AreEqual(false, result);
        }
    }
}
