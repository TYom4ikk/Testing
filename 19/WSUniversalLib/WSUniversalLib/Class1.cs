using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSUniversalLib
{
    public class Calculation
    {
        /// <summary>
        /// Рассчитывает количество необходимого сырья для производства указанного количества продукции
        /// с учетом коэффициента типа продукции и процента брака материала.
        /// </summary>
        /// <param name="productType">Тип продукции (1, 2, 3)</param>
        /// <param name="materialType">Тип материала (1, 2)</param>
        /// <param name="count">Количество продукции</param>
        /// <param name="width">Ширина продукции</param>
        /// <param name="length">Длина продукции</param>
        /// <returns>Целое количество необходимого сырья; -1, если данные некорректны</returns>
        public int GetQuantityForProduct(int productType, int materialType, int count, float width, float length)
        {
            // Проверка входных параметров
            if (productType < 1 || productType > 3 ||
                materialType < 1 || materialType > 2 ||
                count <= 0 || width <= 0 || length <= 0)
            {
                return -1;
            }

            // Коэффициент типа продукции
            double productCoefficient;
            switch (productType)
            {
                case 1:
                    productCoefficient = 1.1;
                    break;
                case 2:
                    productCoefficient = 2.5;
                    break;
                case 3:
                    productCoefficient = 8.43;
                    break;
                default:
                    return -1;
            }

            // Процент брака материала
            double defectPercent;
            switch (materialType)
            {
                case 1:
                    defectPercent = 0.3; // %
                    break;
                case 2:
                    defectPercent = 0.12; // %
                    break;
                default:
                    return -1;
            }

            // Площадь одной единицы продукции
            double square = width * length;

            // Количество качественного сырья
            double rawMaterial = square * productCoefficient * count;

            // Расчёт общего количества с учетом брака
            double totalWithDefect = rawMaterial * 100 / (100 - defectPercent);

            // Округляем в большую сторону и возвращаем
            return (int)Math.Ceiling(totalWithDefect);
        }
    }
}
