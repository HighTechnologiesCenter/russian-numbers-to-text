using System;
using System.Text;
using System.Globalization;

/// <summary>
/// Вывод чисел прописью.
/// </summary>
public static class RuNumbersToText
{
    /*
     * Массивы titles состоят из трёх форм слова, которое идёт после числа.
     * Например: { [один] "кит", [два] "кита", [пять] "китов" }
     */

    public enum Gender
    {
        Neuter = 0,
        Musculine = 1,
        Feminine = 2
    }

    /// <summary>
    /// По числу получить соответствующую ему форму слова из массива titles.
    /// </summary>
    public static String TitleByInt64(Int64 value, String[] titles)
    {
        value %= 100;
        if (value > 19)
            value %= 10;

        Int32 titleIndex;

        if (value == 1)
            titleIndex = 0;
        else if (value >= 2 && value <= 4)
            titleIndex = 1;
        else
            titleIndex = 2;

        return titles[titleIndex];
    }

    /// <summary>
    /// Число прописью. Можно указать слово, которое идёт после числа.
    /// </summary>
    /// <param name="value">Переводимое в текст число.</param>
    /// <param name="gender">Род слова, которое стоит после числа.</param>
    /// <param name="titles">Слово, которое стоит после числа в различных формах (Один кит, Два кита, Пять китов).</param>
    public static String Int64AsText(Int64 value, Gender gender, String[] titles)
    {
        var powers = new Int64[] { 
            1000L, // 10^3
            1000 * 1000L, // 10^6
            1000 * 1000 * 1000L, // 10^9
            1000 * 1000 * 1000 * 1000L, // 10^12
            1000 * 1000 * 1000 * 1000L * 1000L, // 10^15
        };
        var powerTitles = new String[][] { 
            new String[] { "тысяча", "тысячи", "тысяч" },
            new String[] { "миллион", "миллиона", "миллионов" },
            new String[] { "миллиард", "миллиарда", "миллиардов" },
            new String[] { "триллион", "триллиона", "триллионов" },
            new String[] { "квадриллион", "квадриллиона", "квадриллионов" }
        };

        var result = new StringBuilder();
        var tmpValue = value;

        for (int i = powers.Length - 1; i >= 0; i--)
        {
            if (tmpValue >= powers[i])
            {
                if (result.Length > 0)
                    result.Append(" ");
                result.Append(ThreeDigitAsText(tmpValue / powers[i], i == 0 ? Gender.Feminine : Gender.Musculine, powerTitles[i]));
                tmpValue %= powers[i];
            }            
        }

        if (result.Length > 0)
            result.Append(" ");
        result.Append(ThreeDigitAsText(tmpValue, gender, titles, value != 0));

        return result.ToString();
    }

    /// <summary>
    /// Число прописью.
    /// </summary>
    /// <param name="value">Переводимое в текст число.</param>
    /// <param name="gender">Род слова, которое стоит после числа.</param>
    public static String Int64AsText(Int64 value, Gender gender)
    {
        return Int64AsText(value, gender, null);
    }

    /// <summary>
    /// Число прописью. Первая буква заглавная.
    /// </summary>
    /// <param name="value">Переводимое в текст число.</param>
    /// <param name="gender">Род слова, которое стоит после числа.</param>
    public static String Int64AsTextFU(Int64 value, Gender gender)
    {
        var result = new StringBuilder(Int64AsText(value, gender));
        result[0] = Char.ToUpper(result[0], CultureInfo.GetCultureInfo("ru-RU"));
        return result.ToString();
    }

    /// <summary>
    /// Число прописью. Можно указать слово, которое идёт после числа. Первая буква заглавная.
    /// </summary>
    /// <param name="value">Переводимое в текст число.</param>
    /// <param name="gender">Род слова, которое стоит после числа.</param>
    public static String Int64AsTextFU(Int64 value, Gender gender, String[] titles)
    {
        var result = new StringBuilder(Int64AsText(value, gender, titles));
        result[0] = Char.ToUpper(result[0], CultureInfo.GetCultureInfo("ru-RU"));
        return result.ToString();
    }

    /// <summary>
    /// Перевести в текст число, меньше тысячи.
    /// </summary>
    static String ThreeDigitAsText(Int64 value, Gender gender, String[] titles, Boolean ignoreZero = true)
    {
        var result = new StringBuilder();
        Int32 titleIndex;

        if (value > 99)
        {
            var hundreds = new String[] { "", "сто", "двести", "триста", "четыреста", "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот" };
            result.Append(hundreds[value / 100]);
            value = value % 100;
        }

        if (value > 19)
        {
            var tens = new String[] { "", "", "двадцать", "тридцать", "сорок", "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто" };
            if (result.Length > 0)
                result.Append(" ");
            result.Append(tens[value / 10]);
            value = value % 10;
        }

        if (value == 0)
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

            if (value == 1)
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
            else if (value == 2)
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
                var numbers = new String[] { 
                "0", "1", "2", "три", "четыре", "пять", "шесть", "семь", "восемь", "девять", 
                "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать", "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать" };
                result.Append(numbers[value]);
            }
        }

        // Добавить слово после числа
        if (value == 1)
            titleIndex = 0;
        else if (value >= 2 && value <= 4)
            titleIndex = 1;
        else
            titleIndex = 2;

        if (titles != null)
        {
            if (result.Length > 0)
                result.Append(" ");
            result.Append(titles[titleIndex]);
        }

        return result.ToString();
    }
}

