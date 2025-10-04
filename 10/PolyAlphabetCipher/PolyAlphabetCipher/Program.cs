using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyAlphabetCipher
{
    internal class Program
    {
        private const string Alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        /// <summary>
        /// Шифрует текст полиалфавитной подстановкой с заданным ключом.
        /// </summary>
        public static string Encrypt(string key, string text)
        {
            return Process(key, text, encrypt: true);
        }

        /// <summary>
        /// Дешифрует текст полиалфавитной подстановкой с заданным ключом.
        /// </summary>
        public static string Decrypt(string key, string text)
        {
            return Process(key, text, encrypt: false);
        }

        private static string Process(string key, string text, bool encrypt)
        {
            if (string.IsNullOrWhiteSpace(key))
                throw new ArgumentException("Ключ не может быть пустым.");

            var result = new List<char>();
            int m = key.Length;

            for (int i = 0; i < text.Length; i++)
            {
                char symbol = text[i];

                // если символ не буква — оставляем как есть
                if (!Alphabet.Contains(symbol))
                {
                    result.Add(symbol);
                    continue;
                }

                // буква ключа для этой позиции
                char keyChar = key[i % m];

                // создаём сдвинутый алфавит
                int keyIndex = Alphabet.IndexOf(keyChar);
                string shiftedAlphabet = Alphabet.Substring(keyIndex) + Alphabet.Substring(0, keyIndex);

                if (encrypt)
                {
                    int idx = Alphabet.IndexOf(symbol);
                    result.Add(shiftedAlphabet[idx]);
                }
                else
                {
                    int idx = shiftedAlphabet.IndexOf(symbol);
                    result.Add(Alphabet[idx]);
                }
            }

            return new string(result.ToArray());
        }
        static void Main(string[] args)
        {
            string key = "мышь";
            string text = "от улыбки каждый день светлей";

            string encrypted = Encrypt(key, text);
            Console.WriteLine("Зашифровано: " + encrypted);

            string decrypted = Decrypt(key, encrypted);
            Console.WriteLine("Расшифровано: " + decrypted);
        }
    }
}
