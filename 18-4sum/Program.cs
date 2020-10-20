using System;
using System.Collections.Generic;
using System.Linq;

namespace _18_4sum
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                var nums = new [] { 1,0,-1,0,-2,2 };
                var target = 0;
                var solution = new Solution().FourSum(nums, target);
                Print(solution);
            }

            {
                var nums = new int[] {};
                var target = 0;
                var solution = new Solution().FourSum(nums, target);
                Print(solution);
            }

            {
                var nums = new int[] { 0, 0 };
                var target = 0;
                var solution = new Solution().FourSum(nums, target);
                Print(solution);
            }

            {
                var nums = new [] { -2,-1,-1,1,1,2,2 };
                var target = 0;
                var solution = new Solution().FourSum(nums, target);
                Print(solution);
            }

            {
                var nums = new [] { -497,-494,-484,-477,-453,-453,-444,-442,-428,-420,-401,-393,-392,-381,-357,-357,-327,-323,-306,-285,-284,-263,-262,-254,-243,-234,-208,-170,-166,-162,-158,-136,-133,-130,-119,-114,-101,-100,-86,-66,-65,-6,1,3,4,11,69,77,78,107,108,108,121,123,136,137,151,153,155,166,170,175,179,211,230,251,255,266,288,306,308,310,314,321,322,331,333,334,347,349,356,357,360,361,361,367,375,378,387,387,408,414,421,435,439,440,441,470,492 };
                var target = 1682;
                var solution = new Solution().FourSum(nums, target);
                Print(solution);
            }
        }

        static void Print(IList<IList<int>> result) {
            Console.WriteLine(
                @$"[{string.Join(" | ", 
                    result.Select(xs => $"[{string.Join(", ", xs)}]"))}]");
        }
    }

    public class Solution {
        public IList<IList<int>> FourSum(int[] nums, int target) {
            Array.Sort(nums);

            var result = new List<IList<int>>();
            KSum(nums, 0, target, 4, new List<int>(), result);
            return result;
        }

        private void KSum(int[] nums, int startIndex, int target, int count, List<int> roots, IList<IList<int>> result) {
            for (int i = startIndex; i < nums.Length - count + 1; i++)
            {
                var item = nums[i];

                if (i > startIndex && item == nums[i - 1]) 
                    continue;

                var newRoots = new List<int>(roots) { item };
                if (count > 3) {
                    KSum(nums, i + 1, target - item, count - 1, newRoots, result);
                } else {
                    SumOf2(nums, i + 1, target - item, newRoots, result);
                }
            }
        }

        // public void SumOf2(int[] nums, int startIndex, int target, List<int> roots, IList<IList<int>> result) {
        //     var cache = new HashSet<int>();
        //     for (int i = startIndex; i < nums.Length; i++)
        //     {
        //         var item = nums[i];
        //         if ((i > startIndex + 1) && item == nums[i - 2]) {
        //             continue;
        //         }
                
        //         var other = target - item;

        //         if (i > startIndex && item == nums[i - 1] && item != other) {
        //             continue;
        //         }

        //         if (cache.TryGetValue(other, out var _)) {
        //             result.Add(new List<int>(roots) { other, item });
        //         }

        //         cache.Add(item);
        //     }
        // }

        private void SumOf2(int[] nums, int start, int target, List<int> roots, IList<IList<int>> result)
        {
            int lo = start, hi = nums.Length - 1;
            while (lo < hi)
            {
                var sum = nums[lo] + nums[hi];
                if (sum < target || (lo > start && nums[lo] == nums[lo - 1]))
                    lo++;
                else if (sum > target || (hi < nums.Length - 1 && nums[hi] == nums[hi + 1]))
                    hi--;
                else {
                    result.Add(new List<int>(roots) { nums[lo++], nums[hi--] });
                }
            }
        }
    }
}
