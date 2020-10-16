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

            var map = new Dictionary<int, string[]>() {
                { 2, new[] { "a", "b", "c" } },
                { 3, new[] { "d", "e", "f" } },
                { 4, new[] { "g", "h", "i" } },
                { 5, new[] { "j", "k", "l" } },
                { 6, new[] { "m", "n", "o" } },
                { 7, new[] { "p", "q", "r", "s" } },
                { 8, new[] { "t", "u", "v" } },
                { 9, new[] { "w", "x", "y", "z" } }
            };

            var ints = digits.Select(d => int.Parse(d.ToString())).ToArray();
            var result = ints.Aggregate(new string[] { "" }, (acc, digit) => {
                var chars = map[digit];
                var newAcc = chars.SelectMany(ch => acc.Select(accCh => $"{accCh}{ch}")).ToArray();
                return newAcc;
            });

            return result;
        }
    }
}
