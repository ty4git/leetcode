using System;
using System.Collections.Generic;
using System.Linq;

namespace _22._Generate_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var r = string.Join(",", new Solution().GenerateParenthesis(3));
            Console.WriteLine($"{r} | {r == string.Join(",", new[] { "((()))","(()())","(())()","()(())","()()()" })}");
        }
    }

    public class Solution {
        public IList<string> GenerateParenthesis(int n, List<(string parenthesis, int opened)> accum = null, int level = 0) {
            if (!accum?.Any() ?? true) {
                accum = new List<(string parenthesis, int opened)>() { (parenthesis: "", opened: 0) };
            }

            if (level == 2 * n) {
                return accum.Select(x => x.parenthesis).ToList();
            }

            var newAccum = new List<(string parenthesis, int opened)>();

            foreach(var item in accum) {
                var (parenthesis, opened) = item;
                if (opened < n) {
                    newAccum.Add((parenthesis + "(", opened + 1));
                }
                
                if (2 * opened > parenthesis.Length) {
                    newAccum.Add((parenthesis + ")", opened));
                }
            }
            
            return GenerateParenthesis(n, newAccum, level + 1);
        }
    }
}
