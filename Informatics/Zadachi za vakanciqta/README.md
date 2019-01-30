# Индивидуални задачи по Информатика - зимна ваканция 2019 - Любо Любчев $10^в$ клас - МГ Баба Тонка - Донка Сименова

## M1-36

Дадени са масивите A(N) и В(N). Образувайте масива С по следния начин: Сi = Ai.Bi при Ai <> 0 и Bi <> 0 и 1 при Ai = 0 или Bi = 0

```csharp
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
```

```
2
2
3
4
5
6 20
```

```
1
3
3
9
```

## Умножаване на матрици

Да се умножат 2 матрици като първо се вкара информация за тях през конзолата

```csharp
// izpolzvame sistemata
using System;

namespace _2D_Array_Multiplication
{
    class Program
    {
        // entry tochkata na programata ni
        static void Main(string[] args)
        {

            // zadavame nachalni stoinosti na 2te matrici

            Console.WriteLine("Vuvedete obshtiq broi redove za matrica1");
            int h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vuvedete obshtiq broi koloni za matrica1");
            int w = Convert.ToInt32(Console.ReadLine());

            double[,] arrA = new double[h, w];
            arrA = InitMatrix(h, w);

            Console.WriteLine("Vuvedete obshtiq broi redove za matrica2");
            h = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Vuvedete obshtiq broi koloni za matrica2");
            w = Convert.ToInt32(Console.ReadLine());

            double[,] arrB = new double[h, w];
            arrB = InitMatrix(h, w);

            // Poluchavame proizvedenieto ot 2te matrici
            double[,] product = UmnojiDvuizmerniteMasivi(arrA, arrB);

            // Ako proizedenieto ni e "null" tova oznachava che input-a e bil nevaliden
            if (product != null)
            {
                // Printirame purvata matrica
                PrintMatrix(arrA);
                // pravim nov red
                Console.WriteLine();
                // izvejdame simvola zvezdichka - "*"
                Console.WriteLine("*");
                // pravim nov red
                Console.WriteLine();
                // pravim nod red
                Console.WriteLine();
                // printirame vtorata matrica
                PrintMatrix(arrB);
                // pravim nov red
                Console.WriteLine();
                // izvejdame simvola ravno - "="
                Console.WriteLine("=");
                // pravim nov red
                Console.WriteLine();
                // pravim nov red
                Console.WriteLine();
                // printirame proizvedenieto na dvete matrici
                PrintMatrix(product);
            }
        }

        // Definirame funkciqta PrintMatrix koito priema matrica, kato posle q printira
        static void PrintMatrix(double[,] arr)
        {
            // Vzemame borq na redovete ot matricata
            int rows = arr.GetLength(0);
            // Vzemame borq na kolonite ot matricata
            int cols = arr.GetLength(1);

            // Zapochvame cikul koito shte produlji obshtiq broi na redovete
            for (int i = 0; i < rows; i++)
            {

                // Zapochvame cikul koito shte produlji obshtiq broi na kolonite
                for (int j = 0; j < cols; j++)
                {
                    // izvejdame vseki element
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                // izvejdame nov red
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

        // Definirame funkciqta UmnojiDvuizmerniteMasivi, koqto priema 2 matrici i vrushta proizvedenieto im
        static double[,] UmnojiDvuizmerniteMasivi(double[,] arrA,
  double[,] arrB)
        {
            // Kak se umnojvat matrici?
            //
            // Matrici umnojavame kato zapochnem da umnojavame vseki element ot tekushtiq red na matrica1
            // s vseki element ot tekushtata kolonka kato sled tova nie gi subirame i taka poluchavame
            // purviq si red ot proizvedenito, procesa se povtarq dokato ne svurshat redovete na matrica1.
            //
            // !! VAJNO !!
            // Matrici mojem da umnojavame samo togava kogato obshtiq broi kolonki na matrica1 e raven
            // na obshtiq broi redove ot matrica2 (poglednet gore v definiciqta zashto tova trqbva da e izpulneno)

            // vzemame broq na redovete ot arrA s metoda GetLength
            int rowsA = arrA.GetLength(0);
            // vzemame broq na kolonite ot arrA s metoda GetLength
            int colsA = arrA.GetLength(1);
            // vzemame broq na redovte ot arrB s metoda GetLength
            int rowsB = arrB.GetLength(0);
            // vzemame broq na kolonite ot arrB s metoda GetLength
            int colsB = arrB.GetLength(1);

            // Po definiciq kolonite ot purviq mnojitel trqbva da sa ravni s broq na redovte ot
            // vtoriq mnojitel

            // proverqvame za neravenstvo
            if (colsA != rowsB)
            {
                // izkravame greshka na potrebitelq
                Console.WriteLine("Nevalidni dvuizmerni masivi, kolonite na masivA trqbva da sa ravni s redovte na masivB");

                // vrushtame null
                return null;
            }

            // Rezultatut ot umnojavaneto na matrici vinagi vodi do suzdavaneto
            // na nova matrica s broi na redovete s tozi ot purviq mnojitel, a broqt na kolnite
            // s tozi ot vtoriq mnojitel
            double[,] product = new double[rowsA, colsB];

            // 1. Purvo zapochvame cikul koito shte premine prez vseki edin element ot purvata matrica
            for (int rowsAI = 0; rowsAI < rowsA; ++rowsAI)
            {
                // 2. Produljavame s vtori cikul koito preminava prez vsekq kolona na vtorata matrica
                // tui kato pri umnojenie na matrici vseki element ot reda na matrica1 se umnojava s vseki element
                // ot kolonata na matrica2 => shte trqbva da preminim prez vseki element ot kolonite na vtoriq masiv
                for (int colsBJ = 0; colsBJ < colsB; ++colsBJ)
                {
                    //pravim promenliva sum s intial value = 0
                    double sum = 0;

                    // 3. Tuk v posledniq cikul se izvurshva samoto umnojenie tui kato vseki red zaedno s vsqka kolono se umnojavat
                    // s vsekq kolonka ot matrica2
                    for (int colsAK = 0; colsAK < colsA; ++colsAK)
                    {
                        // tova se dobavq kato suma (po definiciq taka se umnojavat matrici)
                        sum += arrA[rowsAI, colsAK] * arrB[colsAK, colsBJ];
                    }
                    // setvame stoinosta pri x = rowsAI i y=colsBJ da e ravna na sum
                    product[rowsAI, colsBJ] = sum;
                }
            }
            // vrushtame matrica
            return product;
        }
        static double[,] InitMatrix(int h, int w)
        {
            double[,] temp = new double[h, w];

            for (int x = 0; x < h; ++x)
            {
                for (int y = 0; y < w; ++y)
                {
                    temp[x, y] = Convert.ToDouble(Console.ReadLine());
                }
            }

            return temp;
        }
    }
}

```

```
Vuvedete obshtiq broi redove za matrica1
3
Vuvedete obshtiq broi koloni za matrica1
3
1
1
1
1
0
1
1
1
1
Vuvedete obshtiq broi redove za matrica2
3
Vuvedete obshtiq broi koloni za matrica2
1
15
10
5
1 1 1

1 0 1

1 1 1


*


15

10

5


=


30

20

30
```

```
Vuvedete obshtiq broi redove za matrica1
3
Vuvedete obshtiq broi koloni za matrica1
3
1
1
1
1
0
1
1
1
1
Vuvedete obshtiq broi redove za matrica2
3
Vuvedete obshtiq broi koloni za matrica2
1
10
15
5
1 1 1

1 0 1

1 1 1


*


10

15

5


=


30

15

30
```
