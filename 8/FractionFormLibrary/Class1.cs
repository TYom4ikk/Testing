using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FractionFormLibrary
{
    public class FractionForm
    {
        public string FixWrongResult(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("Строка не может быть пустой.");
            }

            string[] parts = text.Split('/');
            if (parts.Length != 2)
            {
                throw new ArgumentException("Строка должна иметь формат 'ЧИСЛО1/ЧИСЛО2'.");
            }

            if (!int.TryParse(parts[0], out int n) || !int.TryParse(parts[1], out int m))
            {
                throw new ArgumentException("Оба значения должны быть корректными числами.");
            }

            if (n <= 0 || m <= 0)
            {
                throw new ArgumentException("Оба числа должны быть положительными.");
            }

            if (n > m)
            {
                return $"{m}/{m}";
            }

            return text;

        }
    }
}
