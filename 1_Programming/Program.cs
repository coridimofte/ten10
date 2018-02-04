using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Example 1");
            Console.WriteLine("Input: [1, 4, 1, 4, 2, 1, 3, 5, 6, 2, 3, 7]");
            Console.WriteLine("Expected Output: 4");
            Console.WriteLine("Calculated longest subsequence lenght is: " +
                GetMaxLen(new int[] { 1, 4, 1, 4, 2, 1, 3, 5, 6, 2, 3, 7 }));


            Console.WriteLine("Example 2");
            Console.WriteLine("Input: [3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5]");
            Console.WriteLine("Expected Output: 3");
            Console.WriteLine("Calculated longest subsequence lenght is: " +
                GetMaxLen(new int[] { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5 }));

            Console.WriteLine("Example 3");
            Console.WriteLine("Input: [2, 7, 1, 8, 2, 8, 1]");
            Console.WriteLine("Expected Output: 2");
            Console.WriteLine("Calculated longest subsequence lenght is: " +
                GetMaxLen(new int[] { 2, 7, 1, 8, 2, 8, 1 }));

            while (true)
            {
                Console.WriteLine("---Test other array? y/n----");
                if ("n" == Console.ReadLine())
                    break;

                Console.WriteLine("The lenght of your array:");
                var l = int.Parse(Console.ReadLine());
                int[] v = new int[l];
                Console.WriteLine("Your values:");
                for (var i = 0; i < l; i++)
                    v[i] = int.Parse(Console.ReadLine());

                Console.WriteLine("Calculated longest subsequence lenght is: " + GetMaxLen(v));
            }
        }

        /// <summary>
        /// Given an unordered array of integers of length N > 0, 
        /// calculate the length of the longest ordered(ascending 
        /// from left[lower index] to right[higher index]) subsequence
        /// within the array.
        /// </summary>
        /// <returns></returns>
        public static int GetMaxLen(int[] v)
        {
            //the minimum possible len is 1
            var maxlen = 1;

            //holds the len of the current subsequence
            var currentLen = 1;
            var vLen = v.Length;

            //parsing the given array
            //i goes from first element till before last cause I compare current element with next one
            //also there should be enough elements to posible reach more than maxlen
            for (var i = 0; (i < vLen - 1) && (vLen - i > maxlen - currentLen); i++)
            {
                if (v[i] <= v[i + 1])
                    currentLen++;
                else
                    currentLen = 1;
                maxlen = maxlen > currentLen ? maxlen : currentLen;
            }
            return maxlen;
        }
    }
}
