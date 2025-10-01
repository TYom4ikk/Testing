using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;
using PhoneNumberValidatorLibrary;

namespace PhoneNumberValidatorTests
{
    [TestClass]
    public class UnitTest1
    {
        // 1. Позитивный тест (корректный номер)
        [TestMethod]
        public void IsValidPhoneNumber_ValidNumber_ReturnsTrue()
        {
            Assert.IsTrue(PhoneNumberValidator.IsValidPhoneNumber("+71234567890"));
            Assert.IsTrue(PhoneNumberValidator.IsValidPhoneNumber("81234567890"));
        }

        // 2. Негативный тест (некорректный номер)
        [TestMethod]
        public void IsValidPhoneNumber_InvalidNumber_ReturnsFalse()
        {
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("1234-56-78"));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("abcde"));
        }

        // 3. Тест различных форматов (наш метод ожидает только строгие правила)
        [TestMethod]
        public void IsValidPhoneNumber_DifferentFormats_ReturnsFalse()
        {
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("+7-123-456-7890"));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("+7 (123) 456-7890"));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("+7 123 456 7890"));
        }

        // 4. Тест на обработку некорректных символов
        [TestMethod]
        public void IsValidPhoneNumber_InvalidCharacters_ReturnsFalse()
        {
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("+7@123456789"));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("8#1234567890"));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("++71234567890"));
        }

        // 5. Тесты на граничные случаи
        [TestMethod]
        public void IsValidPhoneNumber_BoundaryCases_ReturnsFalse()
        {
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber(""));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("   "));
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("+7123"));             // слишком короткий
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber("+71234567890123"));   // слишком длинный
        }

        // 6. Тест на обработку исключений
        [TestMethod]
        public void IsValidPhoneNumber_NullInput_ReturnsFalse()
        {
            Assert.IsFalse(PhoneNumberValidator.IsValidPhoneNumber(null));
        }
    }
}
