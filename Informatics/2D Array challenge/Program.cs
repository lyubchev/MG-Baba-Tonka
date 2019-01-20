using System;

namespace _2D_Array_challenge
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] pattern = {
         { 1, 1, 1},
         { 1, 5, 0 },
         { 1, 0, 0 },
     };
            int[,] containsPattern = {
         { 0, 1, 1, 1 },
         { 1, 1, 5, 0 },
         { 1, 1, 0, 0 },
     };
            int[,] lacksPattern = {
         { 1, 1, 0 },
         { 1, 2, 2 },
         { 5, 2, 2 },
     };

            Console.WriteLine(ContainsPattern(containsPattern, pattern)); // true
            Console.WriteLine(ContainsPattern(lacksPattern, pattern)); // false

        }
        static bool ContainsPattern(int[,] arr, int[,] pattern)
        {
            int patternWidth = pattern.GetLength(0);
            int patternHeight = pattern.GetLength(1);

            // testsFit is how many tests fit in x and y
            // for example a 2x2 in a 3x3 can be tested 2x2
            // for example a 3x3 in a 3x3 can be tested 1x1
            // for example a 2x2 in a 4x3 can be tested 3x2
            int testsFitWidth = arr.GetLength(0) - patternWidth + 1;
            int testsFitHeight = arr.GetLength(1) - patternHeight + 1;

            // For every possible location the pattern we run a check
            for (int tx = 0; tx < testsFitWidth; tx++)
            {
                for (int ty = 0; ty < testsFitHeight; ty++)
                {
                    // For each item in pattern
                    for (int px = 0; px < patternWidth; px++)
                    {
                        for (int py = 0; py < patternHeight; py++)
                        {
                            // avoid 0 at pattern
                            // if (pattern[px][py] == 0)
                            // {
                            //     continue;
                            // }

                            // If there is any item in pattern that doesn't
                            // match the array, stop, it's not a match.
                            if (pattern[px, py] != arr[tx + px, ty + py])
                                goto NextTest; // breaking from the nested loops the ugly way 🤷 
                        }
                    }

                    return true;
                NextTest: continue;
                }
            }

            return false;
        }
    }
}
