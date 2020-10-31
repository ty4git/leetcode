using System;
using System.Collections.Generic;
using System.Linq;

namespace _20._Valid_Parentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().IsValid("{[]}") == true);
        }
    }

    public class Solution {
        public bool IsValid(string s) {
            var brackets = new Stack<char>();
            var opened = new[] { '(', '[', '{' };
            var closed = new[] { ')', ']', '}' }; 
            
            for (var i = 0; i < s.Length; i++) {
                var ch = s[i];
                
                if (opened.Contains(ch)) {
                    brackets.Push(ch);
                    continue;
                }
                
                var closedIndex = Array.IndexOf(closed, ch);
                if (closedIndex > -1) {
                    if (!brackets.TryPop(out var bracket)) {
                        return false;
                    }
                    
                    if (bracket != opened[closedIndex]) {
                        return false;
                    }
                }
            }
            
            return brackets.Count == 0;
        }
    }
}
