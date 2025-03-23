using System;
using System.Numerics;
using System.Diagnostics;

namespace MersennePrime
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxP, p;

            while (true)
            {
                Console.Write("Enter the starting exponent: ");
                if (int.TryParse(Console.ReadLine(), out p) && p > 0){

                    Console.Write("Enter the maximum exponent: ");
                    if(int.TryParse(Console.ReadLine(), out maxP))
                    {
                        Console.WriteLine("----------------------------------------");
                        break;
                    }
                }
            }

            Console.ForegroundColor = ConsoleColor.Red;

            while (p <= maxP)
            {
                if (IsPrime(p))
                {
                    BigInteger mersenne = BigInteger.Pow(2, p) - 1;
                    int digits = mersenne.ToString().Length;

                    Stopwatch stopwatch = Stopwatch.StartNew();
                    stopwatch.Restart();
                    bool isMersennePrime = LucasLehmerTest(p);
                    stopwatch.Stop();
                    long primeTestTime = stopwatch.ElapsedMilliseconds;

                    if (isMersennePrime)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"2^{p}-1 with {digits} digits IS a Mersenne Prime Number! => The corresponding perfect number is 2^{p - 1}×(2^{p}-1) [{primeTestTime}ms]");
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else Console.WriteLine($"2^{p}-1 is NOT a Mersenne Prime [{primeTestTime}ms]");
                }
                else Console.WriteLine($"2^{p}-1 is not tested (p is not prime)");

                p++;
            }
            Console.ReadLine();
        }
        
        static bool IsPrime(int num)
        {
            if (num == 2 || num == 3) return true;
            if (num < 2 || num % 2 == 0) return false;

            int sqrt = (int)Math.Sqrt(num);

            for (int i = 3; i <= sqrt; i += 2)
            {
                if (num % i == 0) return false;
            }

            return true;
        }

        static bool LucasLehmerTest(int p)
        {
            if (p == 2) return true;

            BigInteger s = 4, M = BigInteger.Pow(2, p) - 1;

            for (int i = 0; i < p - 2; i++)
            {
                s = (s * s - 2) % M;
            }

            return s == 0;
        }
    }
}