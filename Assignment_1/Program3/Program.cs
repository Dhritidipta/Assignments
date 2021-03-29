using System;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = Int32.Parse(Console.ReadLine());
            byte[] inputArray = new byte[n];

            for (int i = 0; i < n; i++)
                inputArray[i] = byte.Parse(Console.ReadLine());

            var ob = new JumpCount(inputArray);
            int count = ob.MinJump();
            if (count == -1)
                Console.WriteLine("Couldn't reach last 0");
            else
                Console.WriteLine(count);

        }
    }
}
