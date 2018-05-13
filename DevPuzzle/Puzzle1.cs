using System;
using System.Linq;
using NUnit.Framework;

namespace DevPuzzle
{
    /*
     * You are given an array of integers (n) and a positive integer (k).
     * Find and print the number of pairs (i,j) where i<j and n[i]+n[j] is divisible by k.
     */
    public class Puzzle1
    {
        [Test]
        public void Sample0()
        {
            var res = Solve(3, new[] {1, 3, 2, 6, 1, 2});
            Assert.AreEqual(5, res);
        }

        [Test]
        public void Sample1()
        {
            var input = "20 40 78 58 88 84 49 10 75 49 99 30 7 15 80 29 43 94 99 58 23 57 84 65 63 86 37 10 44 79 45 79 17 40 7 27 74 70 92 76 52 73 18 49 29 19 7 43 11 41 7 26 49 61 75 37 33 28 6 5 70 47 58 74 66 26 22 90 25 15 91 96 8 17 83 10 67 13 62 63 98 5 94 1 32 46 22 5 16 62 56 57 51 19 15 65 44 72 59 20";
            var res = Solve(41, input.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray());
            Assert.AreEqual(116, res);
        }

        public int Solve(int k, int[] n)
        {
            if (n.Length < 2 || k < 1) return 0;

            int result = 0;
            for (int i = 0; i < n.Length - 1; i++)
            {
                for (int j = i + 1; j < n.Length; j++)
                {
                    if ( (n[i] + n[j]) % k == 0) result++;
                }
            }
            return result;
        }
    }
}