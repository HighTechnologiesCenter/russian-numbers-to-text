using System;
using System.Collections.Generic;
using Xunit;

namespace Humanizer.Russian.Tests;

public class HumanizerExtensionTests
{
    private static readonly HumanizerOptions MasculineOptions = new()
    {
        Gender = Gender.Masculine,
        Singular = "мальчик",
        Genitive = "мальчика",
        Plural = "мальчиков"
    };

    private static readonly HumanizerOptions FeminineOptions = new()
    {
        Gender = Gender.Feminine,
        Singular = "девушка",
        Genitive = "девушки",
        Plural = "девушек"
    };

    private static readonly HumanizerOptions NeuterOptions = new()
    {
        Gender = Gender.Neuter,
        Singular = "яблоко",
        Genitive = "яблока",
        Plural = "яблок"
    };

    public static IEnumerable<object[]> MasculineWithTitle =>
        new List<object[]>
        {
            new object[] { 1, MasculineOptions, "один мальчик"},
            new object[] { 2, MasculineOptions, "два мальчика"},
            new object[] { 5, MasculineOptions, "пять мальчиков"},
            new object[] { 2151, MasculineOptions, "две тысячи сто пятьдесят один мальчик"}
        };

    public static IEnumerable<object[]> FeminineWithTitle =>
        new List<object[]>
        {
            new object[] { 1, FeminineOptions, "одна девушка"},
            new object[] { 2, FeminineOptions, "две девушки"},
            new object[] { 5, FeminineOptions, "пять девушек"},
            new object[] { 2151, FeminineOptions, "две тысячи сто пятьдесят одна девушка" }
        };

    public static IEnumerable<object[]> NeuterWithTitle =>
        new List<object[]>
        {
            new object[] { 1, NeuterOptions, "одно яблоко"},
            new object[] { 2, NeuterOptions, "два яблока"},
            new object[] { 5, NeuterOptions, "пять яблок"},
            new object[] { 2151, NeuterOptions, "две тысячи сто пятьдесят одно яблоко" }
        };

    public static IEnumerable<object[]> PartialTitle =>
        new List<object[]>
        {
            new object[] { new HumanizerOptions(){ Gender = Gender.Masculine, Genitive = "мальчика", Plural = "мальчиков"}},
            new object[] { new HumanizerOptions(){ Gender = Gender.Masculine, Singular = "мальчик",Plural = "мальчиков"}},
            new object[] { new HumanizerOptions(){ Gender = Gender.Masculine, Singular = "мальчик", Genitive = "мальчика"}},
            new object[] { new HumanizerOptions(){ Gender = Gender.Masculine, Plural = "мальчиков" }},
            new object[] { new HumanizerOptions(){ Gender = Gender.Masculine, Singular = "мальчик"}},
            new object[] { new HumanizerOptions(){ Gender = Gender.Masculine, Genitive = "мальчика"}}
        };

    [InlineData(1, "один")]
    [InlineData(10, "десять")]
    [InlineData(11, "одиннадцать")]
    [InlineData(122, "сто двадцать два")]
    [InlineData(3501, "три тысячи пятьсот один")]
    [InlineData(100, "сто")]
    [InlineData(1000, "одна тысяча")]
    [InlineData(100000, "сто тысяч")]
    [InlineData(1000000, "один миллион")]
    [InlineData(10000000, "десять миллионов")]
    [InlineData(100000000, "сто миллионов")]
    [InlineData(2001, "две тысячи один")]
    [InlineData(2002, "две тысячи два")]
    [InlineData(2020, "две тысячи двадцать")]
    [InlineData(1000000000, "один миллиард")]
    [InlineData(111, "сто одиннадцать")]
    [InlineData(1111, "одна тысяча сто одиннадцать")]
    [InlineData(111111, "сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(1111111, "один миллион сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(11111111, "одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(111111111, "сто одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(1111111111, "один миллиард сто одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(123, "сто двадцать три")]
    [InlineData(1234, "одна тысяча двести тридцать четыре")]
    [InlineData(12345, "двенадцать тысяч триста сорок пять")]
    [InlineData(123456, "сто двадцать три тысячи четыреста пятьдесят шесть")]
    [InlineData(1234567, "один миллион двести тридцать четыре тысячи пятьсот шестьдесят семь")]
    [InlineData(12345678, "двенадцать миллионов триста сорок пять тысяч шестьсот семьдесят восемь")]
    [InlineData(123456789, "сто двадцать три миллиона четыреста пятьдесят шесть тысяч семьсот восемьдесят девять")]
    [InlineData(1234567890, "один миллиард двести тридцать четыре миллиона пятьсот шестьдесят семь тысяч восемьсот девяносто")]
    [InlineData(0, "ноль")]
    [Theory]
    public void HumanizeMasculine(int number, string expected)
    {
        Assert.Equal(expected, number.Humanize(new HumanizerOptions()
        {
            Gender = Gender.Masculine
        }));
    }

    [InlineData(1, "одна")]
    [InlineData(10, "десять")]
    [InlineData(11, "одиннадцать")]
    [InlineData(122, "сто двадцать две")]
    [InlineData(3501, "три тысячи пятьсот одна")]
    [InlineData(100, "сто")]
    [InlineData(1000, "одна тысяча")]
    [InlineData(100000, "сто тысяч")]
    [InlineData(1000000, "один миллион")]
    [InlineData(10000000, "десять миллионов")]
    [InlineData(100000000, "сто миллионов")]
    [InlineData(2001, "две тысячи одна")]
    [InlineData(2002, "две тысячи две")]
    [InlineData(2020, "две тысячи двадцать")]
    [InlineData(1000000000, "один миллиард")]
    [InlineData(111, "сто одиннадцать")]
    [InlineData(1111, "одна тысяча сто одиннадцать")]
    [InlineData(111111, "сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(1111111, "один миллион сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(11111111, "одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(111111111, "сто одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(1111111111, "один миллиард сто одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(123, "сто двадцать три")]
    [InlineData(1234, "одна тысяча двести тридцать четыре")]
    [InlineData(12345, "двенадцать тысяч триста сорок пять")]
    [InlineData(123456, "сто двадцать три тысячи четыреста пятьдесят шесть")]
    [InlineData(1234567, "один миллион двести тридцать четыре тысячи пятьсот шестьдесят семь")]
    [InlineData(12345678, "двенадцать миллионов триста сорок пять тысяч шестьсот семьдесят восемь")]
    [InlineData(123456789, "сто двадцать три миллиона четыреста пятьдесят шесть тысяч семьсот восемьдесят девять")]
    [InlineData(1234567890, "один миллиард двести тридцать четыре миллиона пятьсот шестьдесят семь тысяч восемьсот девяносто")]
    [InlineData(0, "ноль")]
    [Theory]
    public void HumanizeFeminine(int number, string expected)
    {
        Assert.Equal(expected, number.Humanize(new HumanizerOptions()
        {
            Gender = Gender.Feminine
        }));
    }

    [InlineData(1, "одно")]
    [InlineData(10, "десять")]
    [InlineData(11, "одиннадцать")]
    [InlineData(122, "сто двадцать два")]
    [InlineData(3501, "три тысячи пятьсот одно")]
    [InlineData(101, "сто одно")]
    [InlineData(100000001, "сто миллионов одно")]
    [InlineData(2001, "две тысячи одно")]
    [InlineData(2002, "две тысячи два")]
    [InlineData(2020, "две тысячи двадцать")]
    [InlineData(1000000000, "один миллиард")]
    [InlineData(111, "сто одиннадцать")]
    [InlineData(1111, "одна тысяча сто одиннадцать")]
    [InlineData(111111, "сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(1111111, "один миллион сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(11111111, "одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(111111111, "сто одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(1111111111, "один миллиард сто одиннадцать миллионов сто одиннадцать тысяч сто одиннадцать")]
    [InlineData(123, "сто двадцать три")]
    [InlineData(1234, "одна тысяча двести тридцать четыре")]
    [InlineData(12345, "двенадцать тысяч триста сорок пять")]
    [InlineData(123456, "сто двадцать три тысячи четыреста пятьдесят шесть")]
    [InlineData(1234567, "один миллион двести тридцать четыре тысячи пятьсот шестьдесят семь")]
    [InlineData(12345678, "двенадцать миллионов триста сорок пять тысяч шестьсот семьдесят восемь")]
    [InlineData(123456789, "сто двадцать три миллиона четыреста пятьдесят шесть тысяч семьсот восемьдесят девять")]
    [InlineData(1234567890, "один миллиард двести тридцать четыре миллиона пятьсот шестьдесят семь тысяч восемьсот девяносто")]
    [InlineData(0, "ноль")]
    [Theory]
    public void HumanizeNeuter(int number, string expected)
    {
        Assert.Equal(expected, number.Humanize(new HumanizerOptions()
        {
            Gender = Gender.Neuter
        }));
    }

    [MemberData(nameof(MasculineWithTitle))]
    [Theory]
    public void HumanizeMasculineWithTitle(int number, HumanizerOptions options, string expected)
    {
        Assert.Equal(expected, number.Humanize(options));
    }
    
    [MemberData(nameof(FeminineWithTitle))]
    [Theory]
    public void HumanizeFeminineWithTitle(int number, HumanizerOptions options, string expected)
    {
        Assert.Equal(expected, number.Humanize(options));
    }
    
    [MemberData(nameof(NeuterWithTitle))]
    [Theory]
    public void HumanizeNeuterWithTitle(int number, HumanizerOptions options, string expected)
    {
        Assert.Equal(expected, number.Humanize(options));
    }

    [MemberData(nameof(PartialTitle))]
    [Theory]
    public void HumanizeError(HumanizerOptions options)
    {
         Assert.Throws<ArgumentException>(() => 2.Humanize(options));
    }
}