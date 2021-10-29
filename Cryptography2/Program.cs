using System;
using System.Linq;
using System.Numerics;
using System.Text;

namespace Cryptography2
{
    class Program
    {
        static bool IsSimple(uint a)
        {
            for (long i = 2; i * i <= a; i++)
                if (a % i == 0)
                    return false;
            return true;
        }

        static string ToBinary(ulong num)
        {
            var res = new StringBuilder();
            var binary = new StringBuilder();
            ulong ost;
            while (num > 1)
            {
                ost = num % 2;
                num = num / 2;
                if (ost == 1)
                {
                    res.Append('1');
                }
                else
                {
                    res.Append('0');
                }
            }

            if (num == 1)
            {
                res.Append('1');
            }
            res.ToString();
            for (var i = res.Length - 1; i >= 0; i--)
            {
                binary.Append(res[i]);
            }
            
            return binary.ToString();
        }

        static BigInteger Power(ulong a, ulong n, ulong mod)
        {
            var m = ToBinary(n);
            BigInteger res = a;
            int k = m.Count();
            if (mod != 0)
                for (int i = 1; i < k; i++)
                {
                    res = res * res;
                    if (m[i] == '1')
                        res *= a;
                    res %= mod;
                }
            else
                for (int i = 1; i < k; i++)
                {
                    res = res * res;
                    if (m[i] == '1')
                        res *= a;
                }

            return res;
        }

        static ulong Gcd(ulong a, ulong b, out ulong x, out ulong y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            var d = Gcd(b % a, a, out var x1, out var y1);
            x = y1 - (b / a) * x1;
            y = x1;
            return d;
        }

        static void Generate()
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

            ulong n = (ulong) p * q;
            ulong x, y;
            ulong gcd = Gcd(p - 1, q - 1, out x, out y);
            ulong phi = (ulong) (p - 1) * (q - 1) / gcd;


            ulong e, d;
            do
            {
                Console.WriteLine($"Введите e, такое что 1 < e < {phi} и взаимно простое с {phi}");
                e = Convert.ToUInt64(Console.ReadLine());
            } while (e <= 1 || e >= phi || Gcd(e, phi, out d, out x) != 1);
            
            d = phi + d;

            Console.WriteLine($"Открытый ключ: ( {e} , {n} )");
            Console.WriteLine($"Закрытый ключ: ( {d} , {n} )");
        }

        static void Encrypt()
        {
            ulong e, n, m;
            Console.Write("Введите e: ");
            e = Convert.ToUInt64(Console.ReadLine());
            Console.Write("Введите n: ");
            n = Convert.ToUInt64(Console.ReadLine());
            Console.Write($"Введите сообщение m, такое что 0 <= m < {n}: ");
            m = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"Зашифрованное сообщение: {Power(m, e, n)}");
            
        }

        static void Decrypt()
        {
            ulong d, n, c;
            Console.Write("Введите d: ");
            d = Convert.ToUInt64(Console.ReadLine());
            Console.Write("Введите n: ");
            n = Convert.ToUInt64(Console.ReadLine());
            Console.Write("Введите зашифрованное сообщение: ");
            c = Convert.ToUInt64(Console.ReadLine());
            Console.WriteLine($"Расшифрованное сообщение: {Power(c, d, n)}");
        }


        static void Main(string[] args)
        {
            int choose;
            do
            {
                Console.WriteLine("Генерация ключей - 1");
                Console.WriteLine("Зашифровка сообщения - 2");
                Console.WriteLine("Расшифровка сообщения - 3");
                Console.WriteLine("Выход - 0");
                choose = Convert.ToInt32(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        Generate();
                        break;
                    case 2:
                        Encrypt();
                        break;
                    case 3:
                        Decrypt();
                        break;
                    default:
                        break;
                }
            } while (choose != 0);
        }
    }
}