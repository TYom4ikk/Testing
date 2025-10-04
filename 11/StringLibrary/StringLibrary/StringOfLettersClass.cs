using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringLibrary
{
    public class StringOfLettersClass
    {

        /// <summary>
        /// Проверяет, состоит ли строка только из букв (русских или латинских),
        /// используя обычный цикл foreach.
        /// </summary>
        public bool StringOfLettersForeach(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return false;

            foreach (char c in textString)
            {
                if (!char.IsLetter(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет, состоит ли строка только из букв (русских или латинских),
        /// используя предикат All().
        /// </summary>
        public bool StringOfLettersAllRpedicat(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return false;

            return textString.All(char.IsLetter);
        }

        /// <summary>
        /// Проверяет, состоит ли строка только из букв (русских или латинских),
        /// используя предикат Any() (обратная логика).
        /// </summary>
        public bool StringOfLettersAnyRpedicat(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return false;

            // если есть хотя бы один не-буквенный символ → false
            return !textString.Any(ch => !char.IsLetter(ch));
        }

        /// <summary>
        /// Проверяет, состоит ли строка только из букв,
        /// используя шаблонную строку с допустимыми символами.
        /// </summary>
        public bool StringOfLettersStringPattern(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return false;

            string pattern = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZабвгдеёжзийклмнопрстуфхцчшщъыьэюяАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";

            foreach (char c in textString)
            {
                if (!pattern.Contains(c))
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Проверяет, состоит ли строка только из букв,
        /// используя регулярное выражение.
        /// </summary>
        public bool StringOfLettersRegex(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return false;

            // ^ и $ — начало и конец строки; + — одна или более букв
            return Regex.IsMatch(textString, @"^[a-zA-Zа-яА-ЯёЁ]+$");
        }

        /// <summary>
        /// Проверяет, состоит ли строка только из букв,
        /// используя диапазоны кодов ASCII (и Юникода для кириллицы).
        /// </summary>
        public bool StringOfLettersCodeAscii(string textString)
        {
            if (string.IsNullOrEmpty(textString))
                return false;

            foreach (char c in textString)
            {
                // латиница: A–Z (65–90), a–z (97–122)
                // кириллица: а–я (1072–1103), А–Я (1040–1071), ё (1105), Ё (1025)
                if (!((c >= 'A' && c <= 'Z') ||
                      (c >= 'a' && c <= 'z') ||
                      (c >= 'А' && c <= 'Я') ||
                      (c >= 'а' && c <= 'я') ||
                      c == 'ё' || c == 'Ё'))
                    return false;
            }

            return true;
        }
    }
}
