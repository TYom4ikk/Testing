using Microsoft.VisualStudio.TestTools.UnitTesting;
using SnilsValidatorLibrary;
using System;

namespace StringLibraryTests
{
    [TestClass]
    public class SnilsValidatorUnitTest
    {
        private readonly SnilsValidator validator = new SnilsValidator();


        [TestMethod]
        public void EmptyString_ReturnsFalse()
        {
            Assert.IsFalse(validator.CheckPersonakCode(""));
        }

        [TestMethod]
        public void SnilsWithDashes_ReturnsFalse()
        {
            Assert.IsTrue(validator.CheckPersonakCode("112-233-445 95"));
        }

        [TestMethod]
        public void ShortNumber_ReturnsFalse()
        {
            Assert.IsFalse(validator.CheckPersonakCode("333"));
        }

        [TestMethod]
        public void TooLongNumber_ReturnsFalse()
        {
            Assert.IsFalse(validator.CheckPersonakCode("999999999999999999999"));
        }

        [TestMethod]
        [DataRow("15795916329", true)]
        [DataRow("20401330880", true)]
        [DataRow("17611432955", true)]
        [DataRow("19160771478", true)]
        [DataRow("16570395587", true)]
        [DataRow("17838689649", true)]
        [DataRow("16992402305", true)]
        [DataRow("20398397186", true)]
        [DataRow("19978255360", true)]
        [DataRow("16067055052", true)]
        [DataRow("20043715906", true)]
        [DataRow("20874913181", true)]
        [DataRow("15955163599", true)]
        [DataRow("19596091835", true)]
        [DataRow("16454064666", true)]
        [DataRow("15974550714", true)]
        [DataRow("20208120183", true)]
        [DataRow("20149847051", true)]
        [DataRow("17460248064", true)]
        [DataRow("20057830427", true)]
        [DataRow("20508756552", true)]
        public void ValidSnilsNumbers_ReturnTrue(string snils, bool expected)
        {
            Assert.AreEqual(expected, validator.CheckPersonakCode(snils));
        }
    }
}