using System;

namespace Program1
{
    class Program
    {

        static void Main(string[] args)
        {
            int i;
            int n= Int32.Parse(Console.ReadLine());
            string[] names = new string[n];
            for (i = 0; i < n; i++)
                names[i] = Console.ReadLine();

            var ob = new CountDistinctPairs(names,n);
            Console.WriteLine(ob.CountPairs());
        }
    }
}
