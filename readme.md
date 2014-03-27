﻿###Число прописью
Пример:
```C#
1.ToWords(Gender.Musculine) => "один"
1.ToWords(Gender.Feminine) => "одна"
1.ToWords(Gender.Neuter) => "одно"
1234567.ToWords(Gender.Musculine) => "один миллион двести тридцать четыре тысячи пятьсот шестьдесят семь"
```

Примере с указание едениц измерения:
```C#
1.ToWords(Gender.Musculine, new[] { "мальчик", "мальчика", "мальчиков" }) => "один мальчик"
2.ToWords(Gender.Feminine, new[] { "девушка", "девушки", "девушек" }) => "две девушки "
5.ToWords(Gender.Neuter, new[] { "яблоко", "яблока", "яблок" }) => "пять яблок"
2151.ToWords(Gender.Neuter, new[] { "яблоко", "яблока", "яблок" }) => "две тысячи сто пятьдесят одно яблоко"
```
