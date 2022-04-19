using System;
using System.Text;

namespace Humanizer.Russian
{
    /// <summary>
    /// Число прописью
    /// </summary>
    public static class NumberToWordsExtension
    {
        /// <summary>
        /// Число прописью
        /// </summary>
        /// <param name="number"> Число </param>
        /// <param name="gender">Род</param>
        /// <param name="titles">Три формы измерения. [один] "кит", [два] "кита", [пять] "китов" </param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <example>
        ///     2.ToWords(Gender.Musculine, new[] { "яблоко", "яблока", "яблок" }) // два яблока
        /// </example>
        public static string ToWords(this int number, Gender gender, string[] titles = null)
        {
            if (titles != null && titles.Length != 3)
            {
                throw new ArgumentOutOfRangeException("titles", "Массив должен содержать три формы");
            }
            var powers = new[] {
                1000L, // 10^3
                1000 * 1000L, // 10^6
                1000 * 1000 * 1000L, // 10^9
                1000 * 1000 * 1000 * 1000L, // 10^12
                1000 * 1000 * 1000 * 1000L * 1000L, // 10^15
            };
            var powerTitles = new[]
            {
                new[] { "тысяча", "тысячи", "тысяч" },
                new[] { "миллион", "миллиона", "миллионов" },
                new[] { "миллиард", "миллиарда", "миллиардов" },
                new[] { "триллион", "триллиона", "триллионов" },
                new[] { "квадриллион", "квадриллиона", "квадриллионов" }
            };

            var result = new StringBuilder();
            long tmpValue = number;

            for (var i = powers.Length - 1; i >= 0; i--)
            {
                if (tmpValue < powers[i]) continue;
                if (result.Length > 0)
                    result.Append(" ");
                result.Append(NumberLessThanThousandToWord(tmpValue / powers[i], i == 0 ? Gender.Feminine : Gender.Musculine, powerTitles[i]));
                tmpValue %= powers[i];
            }

            if (result.Length > 0)
                result.Append(" ");
            result.Append(NumberLessThanThousandToWord(tmpValue, gender, titles, number != 0));

            return result.ToString().Trim();
        }

        private static string NumberLessThanThousandToWord(long number, Gender gender, string[] titles, bool ignoreZero = true)
        {
            var result = new StringBuilder();
            int titleIndex;

            if (number > 99)
            {
                var hundreds = new[] { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
                result.Append(hundreds[number / 100]);
                number %= 100;
            }

            if (number > 19)
            {
                var tens = new[] { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
                if (result.Length > 0)
                    result.Append(" ");
                result.Append(tens[number / 10]);
                number %= 10;
            }

            if (number == 0)
            {
                if (!ignoreZero)
                {
                    if (result.Length > 0)
                        result.Append(" ");
                    result.Append("ноль");
                }
            }
            else
            {
                if (result.Length > 0)
                    result.Append(" ");

                if (number == 1)
                {
                    switch (gender)
                    {
                        case Gender.Neuter:
                            result.Append("одно");
                            break;
                        case Gender.Musculine:
                            result.Append("один");
                            break;
                        case Gender.Feminine:
                            result.Append("одна");
                            break;
                        default:
                            throw new Exception("Unknown gender: " + gender);
                    }
                }
                else if (number == 2)
                {
                    switch (gender)
                    {
                        case Gender.Neuter:
                        case Gender.Musculine:
                            result.Append("два");
                            break;
                        case Gender.Feminine:
                            result.Append("две");
                            break;
                        default:
                            throw new Exception("Unknown gender: " + gender);
                    }
                }
                else
                {
                    var numbers = new[] {
                                "0", "1", "2", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять",
                                "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать",
                                "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
                                };
                    result.Append(numbers[number]);
                }
            }

            // Добавить слово после числа
            if (number == 1)
                titleIndex = 0;
            else if (number >= 2 && number <= 4)
                titleIndex = 1;
            else
                titleIndex = 2;

            if (titles != null)
            {
                if (result.Length > 0) result.Append(" ");
                result.Append(titles[titleIndex]);
            }

            return result.ToString();
        }
    }
}