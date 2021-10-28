using System;
using System.Numerics;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Cryptography2
{
    class Program
    {
       static bool IsSimple(BigInteger a)
        {
            for (long i = 2; i * i <= a; i++)
                if (a % i == 0)
                    return false;
            return true;
        } 
       static ulong gcd(ulong a, ulong b, out ulong  x, out ulong y)
       {
           if (a == 0) {
               x = 0; y = 1;
               return b;
           }
           var d = gcd (b%a, a, out var x1, out var y1);
           x = y1 - (b / a) * x1;
           y = x1;
           return d;
       }

       static void generate()
       {
           uint p, q;
           do
           {
               Console.Write("Введите простое число p: ");
               p = Convert.ToUInt32(Console.ReadLine());
           } while (!IsSimple(p));
           
           do
           {
               Console.Write("Введите простое число q: ");
               q = Convert.ToUInt32(Console.ReadLine());
           } while (!IsSimple(q));
           
           ulong n = (ulong)p * q;
           ulong phi = (ulong)(p - 1) * (q - 1);
           ulong e, d, x;
           do
           {
               Console.WriteLine($"Введите e, такое что 1 < e < {phi}");
               e = Convert.ToUInt64(Console.ReadLine());
           } while (e <= 1 || e >= phi || gcd(e, phi, out d, out x) != 1);

           d = phi + d;
           
           Console.WriteLine($"Открытый ключ: ( {e} , {n} )");
           Console.WriteLine($"Закрытый ключ: ( {d} , {n} )");
       }
        

        static void Main(string[] args)
        {
            generate();
            

        }
    }
}