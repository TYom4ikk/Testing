using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PasswordCheckerLibrary;

namespace ValidatePasswordTest
{
    [TestClass]
    public class PasswordCheckerTests
    {
        [TestMethod]
        public void Check_8Symbols_ReturnsTrue()
        {
            // Arrange.
            string password = "ASqw12$$";
            bool expected = true;

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Check_4Symbols_ReturnsFalse()
        {
            // Arrange.
            string password = "Aq1$";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }
        [TestMethod]
        public void Check_WithoutDigit_ReturnsFalse()
        {
            // Arrange.
            string password = "ASqw$$aa";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_WithoutSpecialSymbol_ReturnsFalse()
        {
            // Arrange.
            string password = "ASqw1234";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_WithoutUppercase_ReturnsFalse()
        {
            // Arrange.
            string password = "asqw12$$";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_WithoutLowercase_ReturnsFalse()
        {
            // Arrange.
            string password = "ASQW12$$";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_TooShortPassword_ReturnsFalse()
        {
            // Arrange.
            string password = "A1$bc";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_TooLongPassword_ReturnsFalse()
        {
            // Arrange.
            string password = "Aa1$" + new string('x', 20); // длина > 20

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Check_ValidComplexPassword_ReturnsTrue()
        {
            // Arrange.
            string password = "QwEr12$#";

            // Act.
            bool actual = PasswordChecker.ValidatePassword(password);

            // Assert.
            Assert.IsTrue(actual);
        }
    }
}
