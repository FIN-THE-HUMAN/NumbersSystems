using System;
using System.Numerics;
using MatrixLibrary;
using System.Collections.Generic;

namespace JustTesting
{
    class Program
    {
        //public static int Log(int lbase, int number)
        //{
        //    if (lbase <= 1  || number < 1 || lbase > number && number != 1) return -1; //invalid
        //    if (number == 1) return 0;
        //    int result = 0;
        //    int _number = 1;
        //    while (number >= _number)
        //    {
        //        _number *= lbase;
        //        result++;
        //    }
        //    return result - 1;
        //}

        public static int Log(int lbase, int number)
        {
            return (int)Math.Log(number, lbase);
        }

        public static Dictionary<int, int> getPowers(Number n)
        {
            int numberSystem = n.NumberSystem;
            int number = n.Value;
            Dictionary<int, int> result = new Dictionary<int, int>();
            int i = 0;
            int value = number;
            while(number > numberSystem)
            {
                i = Log(numberSystem, number);
                int poweredNumberSystem = (int)Math.Pow(numberSystem, i);
                value = number / poweredNumberSystem;
                number = number - poweredNumberSystem * value;
                result.Add(i, value);  
            }
            result.Add(0, number);

            return result;
        }

        static void Main(string[] args)
        {
            int ns = 32;
            int i = 31*ns*ns + 31*ns + 31;
            var n = new Number(ns, i);
            Console.WriteLine(i + $"[{10}] = " + n + $"[{n.NumberSystem}]");
            Console.WriteLine(n.GetNumberSystemInfo());
            Console.ReadKey();
        }
    }
}
