using System.Threading;
using System;

namespace _1116._Print_Zero_Even_Odd
{
    public class ZeroEvenOdd
    {
        private int n;
        public ZeroEvenOdd(int n)
        {
            this.n = n;
        }
        static AutoResetEvent _isZero = new AutoResetEvent(true);
        static AutoResetEvent _isEven = new AutoResetEvent(false);
        static AutoResetEvent _isOdd = new AutoResetEvent(false);

        // printNumber(x) outputs "x", where x is an integer.
        public void Zero(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i++)
            {
                _isZero.WaitOne();
                printNumber(0);
                if (i % 2 == 0) _isEven.Set();
                if (i % 2 == 1) _isOdd.Set();
            }
        }

        public void Even(Action<int> printNumber)
        {
            for (int i = 2; i <= n; i += 2)
            {
                _isEven.WaitOne();
                printNumber(i);
                _isZero.Set();
            }
        }

        public void Odd(Action<int> printNumber)
        {
            for (int i = 1; i <= n; i += 2)
            {
                _isOdd.WaitOne();
                printNumber(i);
                _isZero.Set();
            }
        }
    }
}