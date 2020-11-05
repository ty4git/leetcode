using System;
using System.Collections.Generic;
using System.Linq;

namespace _23._Merge_k_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            //lists = [[1,4,5],[1,3,4],[2,6]]
            var lists = new[] { new[] { 1, 4, 5 }, new[] { 1, 3, 4 }, new[] { 2, 6 } }
                .Select(arr => {
                    var head = new ListNode();
                    var _ = arr.Select(x => new ListNode(x)).Aggregate(head, (acc, item) => acc.next = item);
                    return head.next;
                })
                .ToArray();

            var result = new Solution().MergeKLists(lists);
            
            var r = new List<int>();
            while (result != null)
            {
                r.Add(result.val);
                result = result.next;
            }
            Console.WriteLine(string.Join(", ", r));
        }
    }

    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }
    }
    
    public class Solution {
        public ListNode MergeKLists(ListNode[] lists) {
            ListNode accum = null;
            foreach (var list in lists) {
                accum = Merge2Lists(accum, list);
            }
            return accum;
        }
        
        private ListNode Merge2Lists(ListNode l1, ListNode l2) {
            var result = new ListNode();
            var head = result;
            
            while (l1 != null && l2 != null) {
                head = (head.next = new ListNode(l1.val < l2.val ? l1.val : l2.val));
                var _ = l1.val < l2.val ? l1 = l1.next : l2 = l2.next;
            }
            
            head.next = l1 == null ? l2 : l1;
            return result.next;
        }
    }
}
