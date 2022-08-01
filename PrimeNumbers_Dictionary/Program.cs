using System;
using System.Collections.Generic;


namespace LiczbyPierwsze
{
    class Program
    {

        public static List<int> ErasthotenesSieve(int x, int y)
        {
            //a list that contains only the prime numbers in a given range
            List<int> Sieved = new List<int>();
            int l = y - x + 1;  // how many numbers we have to chceck in a given range
            bool[] AllNumbers = new bool[l + 1];
            // AllNumbers - array of bool, contains information whether a given number is a prime number.
            // AllNumbers[0] - first number from given range
            // true - means that number is prime

            for (int i = 0; i <= l; i++)
                AllNumbers[i] = true;

            int max_div = (int)(Math.Sqrt(y));
            // Erasthotenes Sieve
            for (int i = 2; i <= max_div; i++)
                for (int j = ((int)x / i) > 2 ? x / i : 2; j <= (y / i); j++)
                    if (i * j >= x)
                        AllNumbers[i * j - x] = false;// false means that the number is divisible 

            for (int i = 0; i < l; i++)
                if (AllNumbers[i])
                    Sieved.Add(i + x);
            return Sieved;
        }
        static void Main(string[] args)
        {
            bool RangeOK = false;
            int x;
            int y;
            do
            {
                Console.Write("please enter a lower range: ");
                x = int.Parse(Console.ReadLine());
                Console.Write("please enter a upper range: ");
                y = int.Parse(Console.ReadLine());
                if (x >= y)
                    Console.WriteLine("Lower  range is bigger than upper range, Please enter range numbers one more time\n\n\n  ");
                else if (x <= 2 || y <= 2)
                    Console.WriteLine("Both range numbers must be bigger than 2, Please enter range numbers one more time\n\n\n  ");
                else
                    RangeOK = true;
            }
            while (!RangeOK);

            int l = y - x + 1;  // how many numbers we have to chceck in a given range
            Dictionary<int, bool> PrimeNum = new Dictionary<int, bool>();

            for (int i = x; i <= y; i++)
                PrimeNum.Add(i,true);

            int max_div = (int)(Math.Sqrt(y));
            // Erasthotenes Sieve
            for (int i = 2; i <= max_div; i++)
                for (int j = ((int)x / i) > 2 ? x / i : 2; j <= (y / i); j++)
                    if (i * j >= x)
                         PrimeNum[i * j] = false;


            Console.WriteLine($"Prime numbers between {x} and {y} are:", x, y);
            for (int i = 0; i < l; i++)
                if (PrimeNum[x+i])
                    Console.Write(x+i + ", ");
            Console.WriteLine("\n\n");
      /*      foreach (var it in PrimeNum)
            {
                if (it.Value)
                    Console.Write(it.Key + ", ");
            }
       */   
            Console.ReadKey();
        }
    }
}
