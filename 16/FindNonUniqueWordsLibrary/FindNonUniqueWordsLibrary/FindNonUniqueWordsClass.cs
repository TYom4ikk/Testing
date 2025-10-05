using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindNonUniqueWordsLibrary
{
    public class FindNonUniqueWordsClass
    {
        /// <summary>
        /// Возвращает список слов, которые встречаются в тексте более одного раза.
        /// </summary>
        /// <param name="text">Исходный текст (может быть пустым)</param>
        /// <returns>Список неуникальных слов в нижнем регистре, отсортированный по алфавиту</returns>
        public static List<string> FindNonUniqueWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return new List<string>();

            // оставляем только буквы и пробелы
            string cleaned = Regex.Replace(text.ToLower(), @"[^a-zа-яё\s]", " ");

            // разбиваем на слова
            var words = cleaned
                .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            // считаем частоту каждого слова
            var duplicates = words
                .GroupBy(w => w)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .OrderBy(w => w)
                .ToList();

            return duplicates;
        }
    }
}
