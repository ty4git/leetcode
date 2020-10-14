using System.Collections.Generic;

namespace _10_regular_expression_matching {

    public class Solution 
    {
        private readonly Dictionary<(string s, string p), bool> _memo = new Dictionary<(string s, string p), bool>();

        public bool IsMatch(string s, string p) 
        {
            if (string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p)) {
                return true;
            }

            if (string.IsNullOrEmpty(p)) {
                return false;
            }

            if (_memo.TryGetValue((s, p), out var r)) {
                return r;
            }

            var sl = s.Length;
            var ch = sl > 0 ? s[0].ToString() : "";
            var pch = p[0].ToString();
            var isRepeat = p.Length > 1 && p[1] == '*';
            var pchni = isRepeat ? 2 : 1;
            var isAny = pch == ".";
            
            var result = ch == pch || isAny
                ? (sl > 0 && IsMatch(s.Substring(1), p.Substring(pchni)))
                    || (sl > 0 && isRepeat && IsMatch(s.Substring(1), p))
                    || (isRepeat && IsMatch(s, p.Substring(pchni)))
                : (isRepeat && IsMatch(s, p.Substring(pchni)));
            
            _memo.Add((s, p), result);
            return result;
        }
    }
}