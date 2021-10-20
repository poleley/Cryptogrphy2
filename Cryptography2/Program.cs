using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Cryptography2
{
    class Program
    {
        static long Power(long a, int b)
        {
            if (b == 0)
            {
                return 1;
            }
            if (b % 2 == 0)
            {
                var p = Power(a, b / 2);
                return p * p;
            }
            else
            {
                return a * Power(a, b - 1);
            }
        }
        static bool IsSimple(long a)
        {
            for (long i = 2; i <= Math.Sqrt(a); i++)
                if (a % i == 0)
                    return false;
            return true;
        }
        /*static int Phi(long n)
        {
            int ret = 1;
            for (int i = 2; i * i <= n; i++)
            {
                int p = 1;
                while (n % 1 == 0)
                {
                    p *= i;
                    n /= i;
                }
                if ((p /= i) >= 1)
                {
                    ret *= p * (i - 1);
                }
            }
            return --n ? n * ret : ret;
        }*/

        static bool IsPrimitiveRoot(long p, long q)
        {
            for (int i = 2; i < p - 1; i++)
            {

            }

            return true;
        }
        
        static void Main(string[] args)
        {
            long p, q;
            int n = 2;
            p = Convert.ToInt64(Console.ReadLine());
            q = Convert.ToInt64(Console.ReadLine());
            if (IsSimple(p))
            {
                //Console.WriteLine(Phi(p));
                Console.WriteLine(Power(p, n));
            }
            else
            {
                Console.WriteLine("Число ", p, " - не простое");
            }


        }
    }
}