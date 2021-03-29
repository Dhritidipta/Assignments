using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            BOB bOB;
            Citibank citi;
            ICICI iCICI;
            SBI sBI;

            Console.WriteLine("Bank Account Number = ");
            int bAN = int.Parse(Console.ReadLine());
            Console.WriteLine("Account Holder Name = ");
            string aHN = Console.ReadLine();
            Console.WriteLine("Loan amount = ");
            double lA = double.Parse(Console.ReadLine());
            Console.WriteLine("Loan tenure = ");
            double lT = double.Parse(Console.ReadLine());
            Console.WriteLine("Bank Name = ");
            string bN = Console.ReadLine().ToUpper();
            Console.WriteLine("CIBIL score = ");
            int cS = int.Parse(Console.ReadLine());
           
            switch (bN)
            {
                case "BOB":
                    bOB = new BOB(aHN, lA, lT, cS);
                    bOB.Output();
                    break;


                case "CITIBANK":
                    citi = new Citibank(aHN, lA, lT, cS);
                    citi.Output();
                    break;

                case "ICICI":
                    iCICI = new ICICI(aHN, lA, lT, cS);
                    iCICI.Output();
                    break;

                case "SBI":
                    sBI = new SBI(aHN, lA, lT, cS);
                    sBI.Output();
                    break;

                default: 
                    Console.WriteLine("Give valid Bank Name");
                    break;
            }

        }
    }
}
