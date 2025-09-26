using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckDataLibrary
{
    public class VinCheck
    {
        public bool CheckVin(string vin, int year)
        {
            if (string.IsNullOrEmpty(vin) || vin.Length != 17)
                return false;

            if (!vin.All(c => char.IsLetterOrDigit(c) && !"IOQ".Contains(c)))
                return false;

            if (!CorrectYear(vin, year))
                return false;

            return CalculateCheckSum(vin) == GetCheckDigit(vin);
        }
        public string GetVINCountry(string vin)
        {
            if (string.IsNullOrEmpty(vin))
                return "Unknown";
            char firstChar = vin[0];
            char secondChar = vin[1];

            // Африка
            if (firstChar == 'A')
            {
                if (secondChar >= 'A' && secondChar <= 'H') return "ЮАР";
                if (secondChar >= 'J' && secondChar <= 'N') return "Кот-д’Ивуар";
                if (secondChar >= 'P' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'B')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Ангола";
                if (secondChar >= 'F' && secondChar <= 'K') return "Кения";
                if (secondChar >= 'L' && secondChar <= 'R') return "Танзания";
                if (secondChar >= 'S' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'C')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Бенин";
                if (secondChar >= 'F' && secondChar <= 'K') return "Мадагаскар";
                if (secondChar >= 'L' && secondChar <= 'R') return "Тунис";
                if (secondChar >= 'S' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'D')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Египет";
                if (secondChar >= 'F' && secondChar <= 'K') return "Марокко";
                if (secondChar >= 'L' && secondChar <= 'R') return "Замбия";
                if (secondChar >= 'S' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'E')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Эфиопия";
                if (secondChar >= 'F' && secondChar <= 'K') return "Мозамбик";
                if (secondChar >= 'L' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'F')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Гана";
                if (secondChar >= 'F' && secondChar <= 'K') return "Нигерия";
                if (secondChar >= 'L' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'G' || firstChar == 'H')
            {
                return "Не используется";
            }



            // Азия (J-R)

            if (firstChar == 'J')
            {
                if (secondChar >= 'A' && secondChar <= 'T') return "Япония";
            }
            if (firstChar == 'K')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Шри Ланка";
                if (secondChar >= 'F' && secondChar <= 'K') return "Израиль";
                if (secondChar >= 'L' && secondChar <= 'R') return "Южная Корея";
                if (secondChar >= 'S' && secondChar <= '0') return "Казахстан";
            }
            if (firstChar == 'L')
            {
                if (secondChar >= 'A' && secondChar <= '0') return "Китай";
            }
            if (firstChar == 'M')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Индия";
                if (secondChar >= 'F' && secondChar <= 'K') return "Индонезия";
                if (secondChar >= 'L' && secondChar <= 'R') return "Таиланд";
                if (secondChar >= 'S' && secondChar <= '0') return "Мьянма";
            }
            if (firstChar == 'N')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Иран";
                if (secondChar >= 'F' && secondChar <= 'K') return "Пакистан";
                if (secondChar >= 'L' && secondChar <= 'R') return "Турция";
                if (secondChar >= 'T' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'P')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Филиппины";
                if (secondChar >= 'F' && secondChar <= 'K') return "Сингапур";
                if (secondChar >= 'L' && secondChar <= 'R') return "Малайзия";
                if (secondChar >= 'S' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'R')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "ОАЭ";
                if (secondChar >= 'F' && secondChar <= 'K') return "Тайвань";
                if (secondChar >= 'L' && secondChar <= 'R') return "Вьетнам";
                if (secondChar >= 'S' && secondChar <= '0') return "Саудовская Аравия";
            }

            // Европа (S-Z)
            if (firstChar == 'S')
            {
                if (secondChar >= 'A' && secondChar <= 'M') return "Великобритания";
                if (secondChar >= 'N' && secondChar <= 'T') return "Восточная Германия";
                if (secondChar >= 'U' && secondChar <= 'Z') return "Польша";
                if (secondChar >= '1' && secondChar <= '4') return "Латвия";
            }
            if (firstChar == 'T')
            {
                if (secondChar >= 'A' && secondChar <= 'H') return "Швейцария";
                if (secondChar >= 'J' && secondChar <= 'P') return "Чехия";
                if (secondChar >= 'R' && secondChar <= 'V') return "Венгрия";
                if (secondChar >= 'W' && secondChar <= '1') return "Португалия";
                if (secondChar >= '2' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'U')
            {
                if (secondChar >= 'A' && secondChar <= 'G') return "Не используется";
                if (secondChar >= 'H' && secondChar <= 'M') return "Дания";
                if (secondChar >= 'N' && secondChar <= 'T') return "Ирландия";
                if (secondChar >= 'U' && secondChar <= 'Z') return "Румыния";
                if (secondChar >= '1' && secondChar <= '4') return "Не используется";
                if (secondChar >= '5' && secondChar <= '7') return "Словакия";
                if (secondChar >= '8' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == 'V')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Австрия";
                if (secondChar >= 'F' && secondChar <= 'R') return "Франция";
                if (secondChar >= 'S' && secondChar <= 'W') return "Испания";
                if (secondChar >= 'X' && secondChar <= '2') return "Сербия";
                if (secondChar >= '3' && secondChar <= '5') return "Хорватия";
                if (secondChar >= '6' && secondChar <= '0') return "Эстония";
            }
            if (firstChar == 'W')
            {
                return "Германия";
            }
            if (firstChar == 'X')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Болгария";
                if (secondChar >= 'F' && secondChar <= 'K') return "Греция";
                if (secondChar >= 'L' && secondChar <= 'R') return "Нидерланды";
                if (secondChar >= 'S' && secondChar <= 'W') return "СССР/СНГ";
                if (secondChar >= 'X' && secondChar <= '2') return "Люксембург";
                if (secondChar >= '3' && secondChar <= '0') return "Россия";
            }
            if (firstChar == 'Y')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Бельгия";
                if (secondChar >= 'F' && secondChar <= 'K') return "Финляндия";
                if (secondChar >= 'L' && secondChar <= 'R') return "Мальта";
                if (secondChar >= 'S' && secondChar <= 'W') return "Швеция";
                if (secondChar >= 'X' && secondChar <= '2') return "Норвегия";
                if (secondChar >= '3' && secondChar <= '5') return "Беларусь";
                if (secondChar >= '6' && secondChar <= '0') return "Украина";
            }
            if (firstChar == 'Z')
            {
                if (secondChar >= 'A' && secondChar <= 'R') return "Италия";
                if (secondChar >= 'S' && secondChar <= 'W') return "Не используется";
                if (secondChar >= 'X' && secondChar <= '2') return "Словения";
                if (secondChar >= '3' && secondChar <= '5') return "Литва";
                if (secondChar >= '6' && secondChar <= '0') return "Россия";
            }


            // Северная Америка (1-5)
            if (firstChar == '1')
            {
                if (secondChar >= 'A' && secondChar <= '0') return "США";
            }
            if (firstChar == '2')
            {
                if (secondChar >= 'A' && secondChar <= '0') return "Канада";
            }
            if (firstChar == '3')
            {
                if (secondChar >= 'A' && secondChar <= 'W') return "Мексика";
                if (secondChar >= 'X' && secondChar <= '7') return "Коста Рика";
                if (secondChar >= '8' && secondChar <= '0') return "Каймановы острова";
            }
            if (firstChar == '4')
            {
                if (secondChar >= 'A' && secondChar <= '0') return "США";
            }
            if (firstChar == '5')
            {
                if (secondChar >= 'A' && secondChar <= '0') return "США";
            }

            // Океания (6-7)
            if (firstChar == '6')
            {
                if (secondChar >= 'A' && secondChar <= 'W') return "Австралия";
                if (secondChar >= 'X' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == '7')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Новая Зеландия";
                if (secondChar >= 'F' && secondChar <= '0') return "Не используется";
            }

            // Южная Америка (8-9)
            if (firstChar == '8')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Аргентина";
                if (secondChar >= 'F' && secondChar <= 'K') return "Чили";
                if (secondChar >= 'L' && secondChar <= 'R') return "Эквадор";
                if (secondChar >= 'S' && secondChar <= 'W') return "Перу";
                if (secondChar >= 'X' && secondChar <= '2') return "Венесуэла";
                if (secondChar >= '3' && secondChar <= '0') return "Не используется";
            }
            if (firstChar == '9')
            {
                if (secondChar >= 'A' && secondChar <= 'E') return "Бразилия";
                if (secondChar >= 'F' && secondChar <= 'K') return "Колумбия";
                if (secondChar >= 'L' && secondChar <= 'R') return "Парагвай";
                if (secondChar >= 'S' && secondChar <= 'W') return "Уругвай";
                if (secondChar >= 'X' && secondChar <= '2') return "Тринидад и Тобаго";
                if (secondChar >= '3' && secondChar <= '9') return "Бразилия";
                if (secondChar == '0') return "Не используется";
            }



            return "Unknown";
        }
        public bool CorrectYear(string vin, int year)
        {
            if (string.IsNullOrEmpty(vin) || vin.Length < 10)
                return false;

            char yearChar = vin[9];
            List<int> vinYears = GetYearFromChar(yearChar);

            return vinYears.Contains(year);
        }
        private char CalculateCheckSum(string vin)
        {
            var letterToNumber = new Dictionary<char, int>
            {
                {'A', 1}, {'B', 2}, {'C', 3}, {'D', 4}, {'E', 5}, {'F', 6}, {'G', 7}, {'H', 8},
                {'J', 1}, {'K', 2}, {'L', 3}, {'M', 4}, {'N', 5}, {'P', 7}, {'R', 9}, {'S', 2},
                {'T', 3}, {'U', 4}, {'V', 5}, {'W', 6}, {'X', 7}, {'Y', 8}, {'Z', 9}
            };

            // Веса для каждой позиции VIN
            int[] weights = { 8, 7, 6, 5, 4, 3, 2, 10, 0, 9, 8, 7, 6, 5, 4, 3, 2 };

            int sum = 0;
            string NumberEq = string.Empty;
            for (int i = 0; i < vin.Length; i++)
            {
                char currentChar = vin[i];
                int numericValue;
                if (char.IsLetter(currentChar))
                {
                    if (!letterToNumber.TryGetValue(currentChar, out numericValue))
                        throw new ArgumentException($"Недопустимый символ в VIN: {currentChar}");
                }
                else if (char.IsDigit(currentChar))
                {
                    numericValue = currentChar - '0';
                }
                else
                {
                    throw new ArgumentException($"Недопустимый символ в VIN: {currentChar}");
                }

                sum += numericValue * weights[i];
            }

            int remainder = sum % 11;
            int checkDigit = remainder == 10 ? 'X' : remainder;
            return checkDigit == 'X' ? 'X' : char.Parse(checkDigit.ToString());
        }

        private char GetCheckDigit(string vin)
        {
            char checkSum = CalculateCheckSum(vin);
            int remainder = int.Parse(checkSum.ToString()) % 11;
            return remainder == 10 ? 'X' : (char)(remainder + '0');
        }

        private List<int> GetYearFromChar(char yearChar)
        {
            List<int> lst = new List<int>();
            if (yearChar == 'A') lst.Add(1980);
            if (yearChar == 'B') lst.Add(1981);
            if (yearChar == 'C') lst.Add(1982);
            if (yearChar == 'D') lst.Add(1983);
            if (yearChar == 'E') lst.Add(1984);
            if (yearChar == 'F') lst.Add(1985);
            if (yearChar == 'G') lst.Add(1986);
            if (yearChar == 'H') lst.Add(1987);
            if (yearChar == 'J') lst.Add(1988);
            if (yearChar == 'K') lst.Add(1989);
            if (yearChar == 'L') lst.Add(1990);
            if (yearChar == 'M') lst.Add(1991);
            if (yearChar == 'N') lst.Add(1992);
            if (yearChar == 'P') lst.Add(1993);
            if (yearChar == 'R') lst.Add(1994);
            if (yearChar == 'S') lst.Add(1995);
            if (yearChar == 'T') lst.Add(1996);
            if (yearChar == 'V') lst.Add(1997);
            if (yearChar == 'W') lst.Add(1998);
            if (yearChar == 'X') lst.Add(1999);
            if (yearChar == 'Y') lst.Add(2000);
            if (yearChar == '1') lst.Add(2001);
            if (yearChar == '2') lst.Add(2002);
            if (yearChar == '3') lst.Add(2003);
            if (yearChar == '4') lst.Add(2004);
            if (yearChar == '5') lst.Add(2005);
            if (yearChar == '6') lst.Add(2006);
            if (yearChar == '7') lst.Add(2007);
            if (yearChar == '8') lst.Add(2008);
            if (yearChar == '9') lst.Add(2009);
            if (yearChar == 'A') lst.Add(2010); // Повторяется для нового цикла
            if (yearChar == 'B') lst.Add(2011);
            if (yearChar == 'C') lst.Add(2012);
            if (yearChar == 'D') lst.Add(2013);
            if (yearChar == 'E') lst.Add(2014);
            if (yearChar == 'F') lst.Add(2015);
            if (yearChar == 'G') lst.Add(2016);
            if (yearChar == 'H') lst.Add(2017);
            if (yearChar == 'J') lst.Add(2018);
            if (yearChar == 'K') lst.Add(2019);
            if (yearChar == 'L') lst.Add(2020);
            if (yearChar == 'M') lst.Add(2021);
            if (yearChar == 'N') lst.Add(2022);
            if (yearChar == 'P') lst.Add(2023);
            if (yearChar == 'R') lst.Add(2024);
            if (yearChar == 'S') lst.Add(2025);
            if (yearChar == 'T') lst.Add(2026);
            if (yearChar == 'V') lst.Add(2027);
            if (yearChar == 'W') lst.Add(2028);
            if (yearChar == 'X') lst.Add(2029);
            if (yearChar == 'Y') lst.Add(2030);

            return lst;
        }
    }
}
