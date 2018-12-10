using System;
using System.Linq;

namespace Zadacha_M1_45
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int m = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < arr.Length; i++)
            {
                if(arr[i] < m) {
                    arr[i] = 2 * arr[i];
                }
                if (arr[i] == m) {
                    arr[i] = -arr[i];
                }

                if(arr[i] > m) {
                    arr[i] = arr[i] - 1;
                }
            }
        }
    }
}
