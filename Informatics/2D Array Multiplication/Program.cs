using System;

namespace _2D_Array_Multiplication
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] arrA = {
         { 1, 1, 1 },
         { 1, 0, 1 },
         { 1, 1, 1 },
     };

            double[,] arrB = {
         { 10},{15},{5},
     };

            double[,] product = UmnojiDvuizmerniteMasivi(arrA, arrB);

            if (product != null)
            {
                PrintMatrix(arrA);
                Console.WriteLine();
                Console.WriteLine("*");
                Console.WriteLine();
                Console.WriteLine();
                PrintMatrix(arrB);
                Console.WriteLine();
                Console.WriteLine("=");
                Console.WriteLine();
                Console.WriteLine();
                PrintMatrix(product);
            }
        }

        static void PrintMatrix(double[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", arr[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

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

            int rowsA = arrA.GetLength(0);
            int colsA = arrA.GetLength(1);
            int rowsB = arrB.GetLength(0);
            int colsB = arrB.GetLength(1);

            // Po definiciq kolonite ot purviq mnojitel trqbva da sa ravni s broq na redovte ot
            // vtoriq mnojitel
            if (colsA != rowsB)
            {
                Console.WriteLine("Nevalidni dvuizmerni masivi, kolonite na masivA trqbva da sa ravni s redovte na masivB");
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
                    double sum = 0;

                    // 3. Tuk v posledniq cikul se izvurshva samoto umnojenie tui kato vseki red zaedno s vsqka kolono se umnojavat
                    // s vsekq kolonka ot matrica2
                    for (int colsAK = 0; colsAK < colsA; ++colsAK)
                    {
                        // tova se dobavq kato suma (po definiciq taka se umnojavat matrici)
                        sum += arrA[rowsAI, colsAK] * arrB[colsAK, colsBJ];
                    }
                    product[rowsAI, colsBJ] = sum;
                }
            }
            return product;
        }
    }
}
