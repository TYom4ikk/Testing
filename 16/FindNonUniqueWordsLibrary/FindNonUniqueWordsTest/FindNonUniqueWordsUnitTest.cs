using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using FindNonUniqueWordsLibrary;

namespace FindNonUniqueWordsTest
{
    [TestClass]
    public class FindNonUniqueWordsUnitTest
    {
        [TestMethod]
        public void FindNonUniqueWords_TextWithRepeats_ReturnsCorrectList()
        {
            string text = "Привет мир! Привет друг, мир прекрасен.";
            var result = FindNonUniqueWordsClass.FindNonUniqueWords(text);

            CollectionAssert.AreEqual(new List<string> { "мир", "привет" }, result);
        }

        [TestMethod]
        public void FindNonUniqueWords_TextWithoutRepeats_ReturnsEmptyList()
        {
            string text = "Один два три четыре";
            var result = FindNonUniqueWordsClass.FindNonUniqueWords(text);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FindNonUniqueWords_EmptyText_ReturnsEmptyList()
        {
            string text = "";
            var result = FindNonUniqueWordsClass.FindNonUniqueWords(text);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void FindNonUniqueWords_TextWithDifferentCases_ReturnsLowercaseList()
        {
            string text = "Hello hello HeLLo world WORLD";
            var result = FindNonUniqueWordsClass.FindNonUniqueWords(text);

            CollectionAssert.AreEqual(new List<string> { "hello", "world" }, result);
        }

        [TestMethod]
        public void FindNonUniqueWords_TextWithPunctuationAndNewLines_ReturnsCorrectList()
        {
            string text = "Дом, дом.\nСолнце! дом? Солнце светит.";
            var result = FindNonUniqueWordsClass.FindNonUniqueWords(text);

            CollectionAssert.AreEqual(new List<string> { "дом", "солнце" }, result);
        }
    }
}
