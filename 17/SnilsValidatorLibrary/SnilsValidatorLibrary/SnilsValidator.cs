using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnilsValidatorLibrary
{
    public class SnilsValidator
    {
        /// <summary>
        /// Проверяет корректность контрольного числа СНИЛС.
        /// </summary>
        /// <param name="textString">Строка, содержащая СНИЛС (только цифры или с разделителями)</param>
        /// <returns>true — если СНИЛС валиден; false — если невалиден</returns>
        public bool CheckPersonakCode(string textString)
        {
            if (string.IsNullOrWhiteSpace(textString))
                return false;

            // Оставляем только цифры
            string digits = new string(textString.Where(char.IsDigit).ToArray());

            // Должно быть ровно 11 цифр
            if (digits.Length != 11)
                return false;

            // Разделяем номер и контрольное число
            string numberPart = digits.Substring(0, 9);
            string controlPart = digits.Substring(9, 2);

            // Номера <= 001001998 не проверяются — сразу false
            if (long.Parse(numberPart) <= 1001998)
                return false;

            // Расчет контрольного числа
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                int digit = digits[i] - '0';
                int weight = 9 - i;
                sum += digit * weight;
            }

            int control = 0;
            if (sum < 100)
                control = sum;
            else if (sum == 100 || sum == 101)
                control = 0;
            else
            {
                sum = sum % 101;
                if (sum == 100)
                    control = 0;
                else
                    control = sum;
            }

            // Форматируем контрольное число с ведущим нулем
            string calculatedControl = control.ToString("D2");

            return calculatedControl == controlPart;
        }
    }
}
