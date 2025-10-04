using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringLibrary
{
    public class StringCheck
    {
        /// <summary>
        /// Возвращает список уникальных букв из переданной строки.
        /// Буквы переводятся в верхний регистр и сортируются по алфавиту.
        /// </summary>
        /// <param name="textString">Входная строка, содержащая произвольные символы.</param>
        /// <returns>Отсортированный список уникальных букв в верхнем регистре.</returns>
        public static List<char> GetLetters(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return new List<char>();

            return textString
                .Where(char.IsLetter)           // оставляем только буквы
                .Select(char.ToUpper)           // приводим к верхнему регистру
                .Distinct()                     // убираем повторы
                .OrderBy(c => c)                // сортируем
                .ToList();                      // превращаем в список
        }
    }
}
