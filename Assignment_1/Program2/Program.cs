using System;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            int i;
            int n = Int32.Parse(Console.ReadLine());
            string[] array = new string[n];
            for (i = 0; i < n; i++)
                array[i] = Console.ReadLine();

            BracketsCheck ob = new BracketsCheck();
            bool[] result = ob.IsValid(array, n);

            for (i = 0; i < n; i++)
                Console.WriteLine(result[i]);
        }
    }
}
