/*
* https://leetcode.com/problems/find-common-characters/submissions/
* Runtime: 248 ms, faster than 75.44% of C# online submissions for Find Common Characters.
* Memory Usage: 33.2 MB, less than 66.67% of C# online submissions for Find Common Characters.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace FindCommonCharacters
{
    class Program
    {
        public static IList<string> CommonChars(string[] A) {
            List<int[]> counts = new List<int[]>();
            foreach (var w in A) {
                counts.Add(new int[26]);
                foreach (var c in w) {
                    counts[counts.Count - 1][c - 97]++;
                }
            }

            int[] minimums = new int[26];
            Array.Fill<int>(minimums, int.MaxValue);

            for (int i = 0; i < 26; i++) {
                foreach (var c in counts) {
                    if (c[i] < minimums[i])
                        minimums[i] = c[i];
                }
            }

            List<string> output = new List<string>();
            for (int i = 0; i < 26; i++) {
                for (int m = 0; m < minimums[i]; m++) {
                    output.Add(((char)(i + 97)).ToString());
                }
                    
            }
            return output;
        }
        static void Main(string[] args)
        {
            string str1 = "ajkdhfajhfsdfsdiuhnasid";
            string str2 = "sndndknowlkwnsh";
            string str3 = "laksjdfnjionakdfkjnasdf";

            System.Console.WriteLine($"str1: {str1}");
            System.Console.WriteLine($"str2: {str2}");
            System.Console.WriteLine($"str3: {str3}");

            string[] words = {str1, str2, str3};

            List<string> response = (List<string>)CommonChars(words);

            StringBuilder sb = new StringBuilder();
            foreach (var letter in response) {
                sb.Append($"{letter}, ");
            }
            System.Console.WriteLine(sb.ToString().Substring(0, sb.Length-2));
        }
    }
}
