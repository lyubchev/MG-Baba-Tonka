using System;

namespace Zadacha_M1_36
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] a = new int[n];
            int[] b = new int[n];

            // Shte napulnim 2-ta masiva s nqkakvi chisla
            for (int i = 0; i < n; i++)
            {
                a[i] = int.Parse(Console.ReadLine());
                b[i] = int.Parse(Console.ReadLine());
            }

            int[] c = new int[n];

            // Shte napulnim masiva "c" kakto sa ni kazali, no ne sum siguren
            // kakvi trqbva da sa usloviqta zashtoto ne znam kakvo e "<>"
            for (int i = 0; i < n; i++)
            {
                // Predpolagam che sa imali predvid < 0
                if (a[i] != 0 && b[i] != 0)
                {
                    c[i] = a[i] * b[i];
                }
                else if (a[i] == 0 || b[i] == 0)
                {
                    c[i] = 1;
                }
            }

            // Posle izkarvame vsichki elementi ot masiva "c"
            // * strin.Join(" ", c) - tova ni pomaga da izkarame vsichki elementi
            // samo s edin red kod :DDD

            Console.WriteLine(string.Join(" ", c));
        }
    }
}