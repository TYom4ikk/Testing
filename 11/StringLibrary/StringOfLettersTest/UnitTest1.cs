using Microsoft.VisualStudio.TestTools.UnitTesting;
using StringLibrary;
using System;

namespace StringOfLettersTest
{
    [TestClass]
    public class StringOfLettersTests
    {
        private readonly StringOfLettersClass _checker = new StringOfLettersClass();

        // -------------------------------
        // 1. StringOfLettersForeach
        // -------------------------------

        [TestMethod]
        public void StringOfLettersForeach_OnlyLetters_ReturnsTrue()
        {
            Assert.IsTrue(_checker.StringOfLettersForeach("привет"));
            Assert.IsTrue(_checker.StringOfLettersForeach("Hello"));
            Assert.IsTrue(_checker.StringOfLettersForeach("ПрИвЕт"));
            Assert.IsTrue(_checker.StringOfLettersForeach("тестTest"));
        }

        [TestMethod]
        public void StringOfLettersForeach_ContainsDigitsOrSymbols_ReturnsFalse()
        {
            Assert.IsFalse(_checker.StringOfLettersForeach("привет123"));
            Assert.IsFalse(_checker.StringOfLettersForeach("hi!"));
            Assert.IsFalse(_checker.StringOfLettersForeach("test test"));
            Assert.IsFalse(_checker.StringOfLettersForeach(""));
        }

        // -------------------------------
        // 2. StringOfLettersAllRpedicat
        // -------------------------------

        [TestMethod]
        public void StringOfLettersAllRpedicat_OnlyLetters_ReturnsTrue()
        {
            Assert.IsTrue(_checker.StringOfLettersAllRpedicat("Привет"));
            Assert.IsTrue(_checker.StringOfLettersAllRpedicat("world"));
        }

        [TestMethod]
        public void StringOfLettersAllRpedicat_ContainsNonLetters_ReturnsFalse()
        {
            Assert.IsFalse(_checker.StringOfLettersAllRpedicat("123abc"));
            Assert.IsFalse(_checker.StringOfLettersAllRpedicat("abc!"));
            Assert.IsFalse(_checker.StringOfLettersAllRpedicat(""));
        }

        // -------------------------------
        // 3. StringOfLettersAnyRpedicat
        // -------------------------------

        [TestMethod]
        public void StringOfLettersAnyRpedicat_OnlyLetters_ReturnsTrue()
        {
            Assert.IsTrue(_checker.StringOfLettersAnyRpedicat("Привет"));
            Assert.IsTrue(_checker.StringOfLettersAnyRpedicat("HELLO"));
        }

        [TestMethod]
        public void StringOfLettersAnyRpedicat_ContainsNonLetters_ReturnsFalse()
        {
            Assert.IsFalse(_checker.StringOfLettersAnyRpedicat("Привет123"));
            Assert.IsFalse(_checker.StringOfLettersAnyRpedicat("hi!"));
            Assert.IsFalse(_checker.StringOfLettersAnyRpedicat(""));
        }

        // -------------------------------
        // 4. StringOfLettersStringPattern
        // -------------------------------

        [TestMethod]
        public void StringOfLettersStringPattern_OnlyLetters_ReturnsTrue()
        {
            Assert.IsTrue(_checker.StringOfLettersStringPattern("abcXYZ"));
            Assert.IsTrue(_checker.StringOfLettersStringPattern("Привет"));
        }

        [TestMethod]
        public void StringOfLettersStringPattern_ContainsNonLetters_ReturnsFalse()
        {
            Assert.IsFalse(_checker.StringOfLettersStringPattern("abc123"));
            Assert.IsFalse(_checker.StringOfLettersStringPattern("тест!"));
            Assert.IsFalse(_checker.StringOfLettersStringPattern(""));
        }

        // -------------------------------
        // 5. StringOfLettersRegex
        // -------------------------------

        [TestMethod]
        public void StringOfLettersRegex_OnlyLetters_ReturnsTrue()
        {
            Assert.IsTrue(_checker.StringOfLettersRegex("тест"));
            Assert.IsTrue(_checker.StringOfLettersRegex("AbCdEf"));
        }

        [TestMethod]
        public void StringOfLettersRegex_ContainsNonLetters_ReturnsFalse()
        {
            Assert.IsFalse(_checker.StringOfLettersRegex("hello123"));
            Assert.IsFalse(_checker.StringOfLettersRegex("Привет!"));
            Assert.IsFalse(_checker.StringOfLettersRegex(""));
        }

        // -------------------------------
        // 6. StringOfLettersCodeAscii
        // -------------------------------

        [TestMethod]
        public void StringOfLettersCodeAscii_OnlyLetters_ReturnsTrue()
        {
            Assert.IsTrue(_checker.StringOfLettersCodeAscii("abcXYZ"));
        }
    }
}
