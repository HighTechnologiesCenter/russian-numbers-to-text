using System;
using Xunit;
using Xunit.Extensions;

namespace Humanizer.Russian.Tests
{
    public class NumberToWordsExtensionTests
    {
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
        public void ToWordsMusculine(int number, string expected)
        {
            Assert.Equal(expected, number.ToWords(Gender.Musculine));
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
        public void ToWordsFeminine(int number, string expected)
        {
            Assert.Equal(expected, number.ToWords(Gender.Feminine));
        }

        [InlineData(1, "одно")]
        [InlineData(10, "десять")]
        [InlineData(11, "одиннадцать")]
        [InlineData(122, "сто двадцать два")]
        [InlineData(3501, "три тысячи пятьсот одно")]
        [InlineData(101, "сто одно")]
        [InlineData(100000001, "сто миллионов одно")]
        [InlineData(2001, "две тысячи одно")]
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
        public void ToWordsNeuter(int number, string expected)
        {
            Assert.Equal(expected, number.ToWords(Gender.Neuter));
        }

        [InlineData(1, new[] { "мальчик", "мальчика", "мальчиков" }, "один мальчик")]
        [InlineData(2, new[] { "мальчик", "мальчика", "мальчиков" }, "два мальчика")]
        [InlineData(5, new[] { "мальчик", "мальчика", "мальчиков" }, "пять мальчиков")]
        [InlineData(2151, new[] { "мальчик", "мальчика", "мальчиков" }, "две тысячи сто пятьдесят один мальчик")]
        [Theory]
        public void ToWordsMusculineWithTitle(int number, string[] titles, string expected)
        {
            Assert.Equal(expected, number.ToWords(Gender.Musculine, titles));
        }


        [InlineData(1, new[] { "девушка", "девушки", "девушек" }, "одна девушка")]
        [InlineData(2, new[] { "девушка", "девушки", "девушек" }, "две девушки")]
        [InlineData(5, new[] { "девушка", "девушки", "девушек" }, "пять девушек")]
        [InlineData(2151, new[] { "девушка", "девушки", "девушек" }, "две тысячи сто пятьдесят одна девушка")]
        [Theory]
        public void ToWordsFeminineWithTitle(int number, string[] titles, string expected)
        {
            Assert.Equal(expected, number.ToWords(Gender.Feminine, titles));
        }


        [InlineData(1, new[] { "яблоко", "яблока", "яблок" }, "одно яблоко")]
        [InlineData(2, new[] { "яблоко", "яблока", "яблок" }, "два яблока")]
        [InlineData(5, new[] { "яблоко", "яблока", "яблок" }, "пять яблок")]
        [InlineData(2151, new[] { "яблоко", "яблока", "яблок" }, "две тысячи сто пятьдесят одно яблоко")]
        [Theory]
        public void ToWordsNeuterWithTitle(int number, string[] titles, string expected)
        {
            Assert.Equal(expected, number.ToWords(Gender.Neuter, titles));
        }

        [Fact]
        public void ToWordsError()
        {
            2.ToWords(Gender.Feminine);

            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => 2.ToWords(Gender.Musculine, new[] { "яблоко" }));
            Assert.Equal(exception.ParamName, "titles");
        }
    }
}
