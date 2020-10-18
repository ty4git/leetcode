using System;
using System.Collections.Generic;
using System.Linq;

namespace _18_4sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new [] { 1,0,-1,0,-2,2 };
            var target = 0;
            var solution = new Solution().FourSum(nums, target);
            var et = solution.Where(xs => xs.Sum() == target).ToList();
            Console.WriteLine(
                string.Join(" | ", 
                    et.Select(xs => string.Join(", ", xs))));
        }
    }

    public class Solution {
        public IList<IList<int>> FourSum(int[] nums, int target) {
            var sortedNums = nums.OrderBy(_ => _).ToArray();

            var result = kSum(sortedNums, new List<List<int>>() { new List<int>() }, 4);

            return result.Select(xs => xs as IList<int>).ToList();
        }

        public List<List<int>> kSum(int[] nums, List<List<int>> acc, int count) {
            var xs = nums.SelectMany(num => acc.Select(accNum => new List<int>(accNum) { num }))
                .ToList();
            
            if (--count < 1) {
                return xs;
            } else {
                return kSum(nums.Skip(1).ToArray(), xs, count);
            }
        }
    }
}
