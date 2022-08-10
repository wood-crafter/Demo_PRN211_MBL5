using System;

namespace DelegateLambdaEventDemo
{
    internal class Program
    {
        delegate void myDelegate(int a, int b);
        delegate int tich(int a, int b);

        static void Main(string[] args)
        {
            // Without delegate
            tong(4, 6);
            ucln(4, 6);
            sosanh(4, 6);
            tong(24, 16);
            ucln(24, 16);
            sosanh(24, 16);

            // Delegate
            Console.WriteLine("Using Delegate");
            myDelegate my = new myDelegate(tong);
            my += ucln;
            my += sosanh;

            my(4, 6);
            my -= ucln;
            my(24, 16);

            // Advances:
            // 1.Lambda
            Console.WriteLine("Without lambda: " + nhan(4, 6));
            Console.WriteLine("Using lambda: " + nhan2(4, 6));

            // tich t = new tich(nhan);
            tich t2 = delegate (int a, int b)
            {
                return a / b;
            };
            Console.WriteLine("Cach 2: " + t2(4, 6));

            // Cach 2 -> cach 3
            tich t3 = (a, b) => a / b;
            t3 += (a, b) =>
            {
                Console.WriteLine("Some thing here");
                return a + b;
            };
            t3 += (a, b) =>
            {
                Console.WriteLine("Some thing here");
                return a * b;
            };
            Console.WriteLine("Cach 3: " + t3(4, 6));

            // Note that delegate will run all 3 function but return the newest one
        }

        static int nhan(int a, int b)
        {
            return a * b;
        }

        static int nhan2(int a, int b) => a * b;

        static void tong(int a, int b)
        {
            Console.WriteLine("a + b = " + (a + b));
        }

        static void ucln(int m, int n)
        {
            while (m != n)
            {
                if (m > n)
                {
                    m = m - n;
                } else
                {
                    n = n - m;
                }
            }

            Console.WriteLine("UCLN = " + m);
        }

        static void sosanh(int k, int l)
        {
            if (k == l)
            {
                Console.WriteLine("k == l");
            } else
            {
                Console.WriteLine("k != l");
            }
        }
    }
}
