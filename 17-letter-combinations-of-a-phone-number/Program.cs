using System;
using System.Collections.Generic;
using System.Linq;

namespace _17_letter_combinations_of_a_phone_number
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = new Solution().LetterCombinations("23");
            Console.WriteLine(string.Join(", ", result));
            result = new Solution().LetterCombinations("");
            Console.WriteLine(string.Join(", ", result));
            result = new Solution().LetterCombinations("2");
            Console.WriteLine(string.Join(", ", result));
        }
    }

    public class Solution {
        public IList<string> LetterCombinations(string digits) {
            if (string.IsNullOrEmpty(digits)) {
                return new string[] {};
            }

            var map = new Dictionary<int, string>() {
                { 2, "abc" },
                { 3, "def" },
                { 4, "ghi" },
                { 5, "jkl" },
                { 6, "mno" },
                { 7, "pqrs" },
                { 8, "tuv" },
                { 9, "wxyz" }
            };

            var ints = digits.Select(d => int.Parse(d.ToString()));

            var result = ints.Aggregate(new string[] { "" }, (acc, digit) => {
                var chars = map[digit];
                return chars.SelectMany(ch => acc.Select(accCh => $"{accCh}{ch}")).ToArray();
            });

            return result;
        }
    }
}
