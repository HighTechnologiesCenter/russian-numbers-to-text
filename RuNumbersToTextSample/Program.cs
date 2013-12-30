using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuNumbersToTextSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var debt = 17225411832208.11;
                var dollarTitles = new String[] { "доллар", "доллара", "долларов" };
                var centTitles = new String[] { "цент", "цента", "центов" };
                var centCount = (Int32)Math.Floor((debt * 100) % 100);

                Console.WriteLine("Госдолг США составляет примерно {0} {1}",
                    RuNumbersToText.Int64AsText((Int64)Math.Floor(debt), RuNumbersToText.Gender.Musculine, dollarTitles), 
                    RuNumbersToText.Int64AsText((Int64)centCount, RuNumbersToText.Gender.Musculine, centTitles));
                Console.WriteLine();

                var total = 499.51;
                var kopCount = (Int32)Math.Floor((total * 100) % 100);
                Console.WriteLine("Итого: {0} {1}",
                    RuNumbersToText.Int64AsText((Int64)Math.Floor(total), RuNumbersToText.Gender.Musculine, new String[] { "рубль", "рубля", "рублей" }),
                    RuNumbersToText.Int64AsText((Int64)kopCount, RuNumbersToText.Gender.Feminine, new String[] { "копейка", "копейки", "копеек" }));
                Console.WriteLine();

                var squirrelCount = 38;
                Console.WriteLine("В парке {0} {1}", 
                    RuNumbersToText.TitleByInt64(squirrelCount, new String[] { "обитает", "обитают", "обитают" } ),
                    RuNumbersToText.Int64AsText(squirrelCount, RuNumbersToText.Gender.Feminine, new String[] { "белочка", "белочки", "белочек" }));
                Console.WriteLine();

                var gopherCount = 1483;
                Console.WriteLine("На территории космодрома {0} {1}",
                    RuNumbersToText.TitleByInt64(gopherCount, new String[] { "живёт", "живут", "живут" }),
                    RuNumbersToText.Int64AsText(gopherCount, RuNumbersToText.Gender.Musculine, new String[] { "суслик", "суслика", "сусликов" }));
                Console.WriteLine();

                for (int i = 0; i <= 25; i++)
                {
                    Console.WriteLine(RuNumbersToText.Int64AsText(i, RuNumbersToText.Gender.Neuter, new String[] { "яблоко", "яблока", "яблок" }));
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
