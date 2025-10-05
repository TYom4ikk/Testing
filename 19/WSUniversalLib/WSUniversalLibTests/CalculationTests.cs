using Microsoft.VisualStudio.TestTools.UnitTesting;
using WSUniversalLib;
using System;
using System.IO;
using System.Globalization;

namespace WSUniversalLibTests
{
    [TestClass]
    public class CalculationTests
    {
        private readonly string basePath = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "TestingData");

        [TestMethod]
        public void Test_All_Easy_Cases()
        {
            // создаем объект класса, который тестируем
            var calc = new Calculation();

            // цикл по всем файлам InputData_Easy_01.txt ... InputData_Easy_20.txt
            for (int i = 1; i <= 20; i++)
            {
                string inputFile = Path.Combine(basePath, $"InputData_Easy_{i:00}.txt");
                string outputFile = Path.Combine(basePath, $"OutputData_Easy_{i:00}.txt");

                // читаем входные данные
                string[] input = File.ReadAllLines(inputFile);
                int productType = int.Parse(input[0]);
                int materialType = int.Parse(input[1]);
                int count = int.Parse(input[2]);

                float width = float.Parse(input[3], CultureInfo.InvariantCulture);
                float length = float.Parse(input[4], CultureInfo.InvariantCulture);

                // читаем ожидаемый результат
                int expected = int.Parse(File.ReadAllText(outputFile).Trim());

                // выполняем тестируемый метод
                int actual = calc.GetQuantityForProduct(productType, materialType, count, width, length);

                // сравниваем
                Assert.AreEqual(expected, actual, $"Ошибка в наборе InputData_Easy_{i:00}.txt");
            }
        }

        [TestMethod]
        public void Test_All_Hard_Cases()
        {
            // создаем объект класса, который тестируем
            var calc = new Calculation();

            // цикл по всем файлам InputData_Hard_01.txt ... InputData_Hard_10.txt
            for (int i = 1; i <= 10; i++)
            {
                string inputFile = Path.Combine(basePath, $"InputData_Hard_{i:00}.txt");
                string outputFile = Path.Combine(basePath, $"OutputData_Hard_{i:00}.txt");

                // читаем входные данные
                string[] input = File.ReadAllLines(inputFile);
                int productType = int.Parse(input[0]);
                int materialType = int.Parse(input[1]);
                int count = int.Parse(input[2]);

                float width = float.Parse(input[3], CultureInfo.InvariantCulture);
                float length = float.Parse(input[4], CultureInfo.InvariantCulture);

                // читаем ожидаемый результат
                int expected = int.Parse(File.ReadAllText(outputFile).Trim());

                // выполняем тестируемый метод
                int actual = calc.GetQuantityForProduct(productType, materialType, count, width, length);

                // сравниваем
                Assert.AreEqual(expected, actual, $"Ошибка в наборе InputData_Hard_{i:00}.txt");
            }
        }
    }
}
