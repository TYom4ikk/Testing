using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using StringLibrary;

namespace StringLibraryTests
{
    [TestClass]
    public class StringCheckTests
    {
        /// <summary>
        /// Проверяет корректную обработку слова с повторяющимися буквами и разным регистром.
        /// Ожидается список уникальных букв в верхнем регистре в алфавитном порядке.
        /// </summary>
        [TestMethod]
        public void GetLetters_Ananas_Returns_A_N_S()
        {
            // Arrange
            string input = "Ананас.";
            var expected = new List<char> { 'А', 'Н', 'С' };

            // Act
            var actual = StringCheck.GetLetters(input);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверяет обработку строки с буквами и посторонними символами (нижнее подчёркивание, цифры).
        /// Ожидается список только букв в верхнем регистре.
        /// </summary>
        [TestMethod]
        public void GetLetters_DifferentSymbols_Returns_SortedLetters()
        {
            // Arrange
            string input = "дгвба_дгвба";
            var expected = new List<char> { 'А', 'Б', 'В', 'Г', 'Д' };

            // Act
            var actual = StringCheck.GetLetters(input);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверяет корректную работу метода на английском слове с повторяющимися буквами.
        /// </summary>
        [TestMethod]
        public void GetLetters_Bob_Returns_B_O()
        {
            // Arrange
            string input = "Bob";
            var expected = new List<char> { 'B', 'O' };

            // Act
            var actual = StringCheck.GetLetters(input);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверяет, что метод корректно обрабатывает строку без букв.
        /// </summary>
        [TestMethod]
        public void GetLetters_NoLetters_Returns_EmptyList()
        {
            // Arrange
            string input = "123 @#$%^&*()";
            var expected = new List<char>();

            // Act
            var actual = StringCheck.GetLetters(input);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверяет поведение метода при передаче пустой строки.
        /// </summary>
        [TestMethod]
        public void GetLetters_EmptyString_Returns_EmptyList()
        {
            // Arrange
            string input = string.Empty;
            var expected = new List<char>();

            // Act
            var actual = StringCheck.GetLetters(input);

            // Assert
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Проверяет, что метод правильно объединяет кириллицу и латиницу, убирая повторы.
        /// </summary>
        [TestMethod]
        public void GetLetters_MixedLanguages_Returns_CombinedSorted()
        {
            // Arrange
            string input = "AбвAaБ";
            var expected = new List<char> { 'A', 'A', 'A' }; // ← временно неверно, нужно исправить

            // Act
            var actual = StringCheck.GetLetters(input);

            // Assert
            CollectionAssert.AreEqual(new List<char> { 'A', 'Б', 'В' }, actual);
        }
    }
}
