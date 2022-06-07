using System;
using System.Text;

namespace Humanizer.Russian;

/// <summary>
///     Число прописью
/// </summary>
public static class HumanizerExtension
{
    private static readonly long[] Powers = 
    {
        1000L, // 10^3
        1000_000L, // 10^6
        1000_000_000L, // 10^9
        1000_000_000_000L, // 10^12
        1000_000_000_000_000L, // 10^15
    };

    private static readonly string[][] PowerTitles = 
    {
        new[] {"тысяча", "тысячи", "тысяч"},
        new[] {"миллион", "миллиона", "миллионов"},
        new[] {"миллиард", "миллиарда", "миллиардов"},
        new[] {"триллион", "триллиона", "триллионов"},
        new[] {"квадриллион", "квадриллиона", "квадриллионов"}
    };

    private static readonly string[] Numbers = 
    {
        string.Empty, string.Empty, string.Empty, "три", "четыре",
        "пять", "шесть", "семь", "восемь", "девять",
        "десять", "одиннадцать", "двенадцать", "тринадцать", "четырнадцать",
        "пятнадцать", "шестнадцать", "семнадцать", "восемнадцать", "девятнадцать"
    };

    private static readonly string[] Tens =
    {
        string.Empty, string.Empty, "двадцать", "тридцать", "сорок",
        "пятьдесят", "шестьдесят", "семьдесят", "восемьдесят", "девяносто"
    };

    private static readonly string[] Hundreds =
    {
        string.Empty, "сто", "двести", "триста", "четыреста",
        "пятьсот", "шестьсот", "семьсот", "восемьсот", "девятьсот"
    };

    /// <summary>
    ///     Число прописью
    /// </summary>
    /// <param name="number"> Число </param>
    /// <param name="options"> Настройки </param>
    /// <exception cref="ArgumentException"></exception>
    /// <example>
    ///     2.Humanize(new HumanizerOptions(){ Gender = Gender.Masculine, Singular = "мальчик",Genitive = "мальчика",Plural = "мальчиков"};}) // два мальчика
    /// </example>
    public static string Humanize(this int number, HumanizerOptions options)
    {
        if (options.Genitive is null && options.Plural is not null ||
            options.Singular is null && options.Plural is not null ||
            options.Singular is not null && options.Plural is null ||
            options.Genitive is not null && options.Plural is null)
        {
            throw new ArgumentException("Класс должен содержать все формы измерения", nameof(options));
        }

        var result = new StringBuilder();
        long tmpValue = number;
        for (var i = Powers.Length - 1; i >= 0; i--)

        {
            if (tmpValue < Powers[i])
                continue;

            if (result.Length > 0)
                result.Append(" ");

            result.Append(NumberLessThanThousandToWord(tmpValue / Powers[i], i == 0 ? new HumanizerOptions
            {
                Gender = Gender.Feminine,
                Singular = PowerTitles[i][0],
                Genitive = PowerTitles[i][1],
                Plural = PowerTitles[i][2]
            } : new HumanizerOptions
            {
                Gender = Gender.Masculine,
                Singular = PowerTitles[i][0],
                Genitive = PowerTitles[i][1],
                Plural = PowerTitles[i][2]
            }));
            tmpValue %= Powers[i];
        }

        if (result.Length > 0)
            result.Append(" ");

        result.Append(NumberLessThanThousandToWord(tmpValue, options, number != 0));

        return result.ToString().Trim();
    }

    private static string NumberLessThanThousandToWord(long number, HumanizerOptions options, bool ignoreZero = true)
    {
        var result = new StringBuilder();

        if (number > 99)
        {
            result.Append(Hundreds[number / 100]);
            number %= 100;
        }

        if (number > 19)
        {
            if (result.Length > 0)
                result.Append(" ");

            result.Append(Tens[number / 10]);
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

            switch (number)
            {
                case 1:
                    result.Append(options.Gender switch
                    {
                        Gender.Neuter => "одно",
                        Gender.Masculine => "один",
                        Gender.Feminine => "одна",
                        _ => throw new Exception($"Unknown gender: {options.Gender}")
                    });
                    break;
                case 2:
                    result.Append(options.Gender switch
                    {
                        Gender.Neuter or Gender.Masculine => "два",
                        Gender.Feminine => "две",
                        _ => throw new Exception($"Unknown gender: {options.Gender}")
                    });
                    break;
                default:
                    result.Append(Numbers[number]);
                    break;
            }
        }

        // Добавить слово после числа
        if (options.Singular is null || options.Genitive is null || options.Plural is null)
            return result.ToString();

        var title = number switch
        {
            1 => options.Singular,
            >= 2 and <= 4 => options.Genitive,
            _ => options.Plural
        };

        if (result.Length > 0)
            result.Append(" ");

        result.Append(title);

        return result.ToString();
    }
}