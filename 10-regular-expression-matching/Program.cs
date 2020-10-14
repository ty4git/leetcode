using System;
using static System.Console;

namespace _10_regular_expression_matching
{
    class Program
    {
        static void Main(string[] args)
        {
            var solution = new Solution();
            var s = "aaaaaaaaaaaaab";
            var p = "a*a*a*a*a*a*a*a*a*a*c";
            WriteLine(@$"s = ""{s}"", p = ""{p}""");
            WriteLine(solution.IsMatch(s, p));
        }
    }
}
