using System;

namespace Bank
{
    abstract class Bank
    {
        protected int bankAccountNumber;
        protected string accountHolderName;
        protected double loanAmount;
        protected double loanTenure;
        protected double interestRate;
        protected double emiCalculate;
        protected double interestPayable;
        protected double totalPayable;
        protected int cibil;

        public double Emi()
        {
            emiCalculate = (loanAmount * interestRate * Math.Pow(1 + interestRate, (loanTenure * 12))) / (Math.Pow(1 + interestRate, (loanTenure * 12)) - 1);
            return emiCalculate;
        }

        public double InterestPayable()
        {
            interestPayable = (emiCalculate * (loanTenure * 12)) - loanAmount;
            return interestPayable;
        } 

        public double TotalPayableLoan()
        {
            totalPayable = loanAmount + interestPayable;
            return totalPayable;
        }

        public void Output() 
        {
            if (cibil > 700)
            {
                Console.WriteLine($"Monthly EMI = {this.Emi():F2}");
                Console.WriteLine($"Interest Payable = {this.InterestPayable():F2}");
                Console.WriteLine($"Total Payable = {this.TotalPayableLoan():F2}");
            }
            else
                Console.WriteLine($"Account Holder: {accountHolderName} is Not Eligible for Loan");

        }

    }

    class BOB : Bank
    {
        public BOB(string accountHolderName, double loanAmount, double loanTenure, int cibil)
        {
            this.loanAmount = loanAmount;
            this.loanTenure = loanTenure;
            this.cibil = cibil;
            this.accountHolderName = accountHolderName;
            interestRate = (6.85/12)/100;
        }
                    
    }
    class Citibank : Bank
    {
        public Citibank(string accountHolderName, double loanAmount, double loanTenure, int cibil)
        {
            this.loanAmount = loanAmount;
            this.loanTenure = loanTenure;
            this.cibil = cibil;
            this.accountHolderName = accountHolderName;
            interestRate = (6.75 / 12)/100;
        }
    }
    class ICICI : Bank
    {
        public ICICI(string accountHolderName, double loanAmount, double loanTenure, int cibil)
        {
            this.loanAmount = loanAmount;
            this.loanTenure = loanTenure;
            this.cibil = cibil;
            this.accountHolderName = accountHolderName;
            interestRate = (6.9 / 12)/100;
        }
    }
    class SBI : Bank
    {
        public SBI(string accountHolderName, double loanAmount, double loanTenure, int cibil)
        {
            this.loanAmount = loanAmount;
            this.loanTenure = loanTenure;
            this.cibil = cibil;
            this.accountHolderName = accountHolderName;
            interestRate = (6.7 / 12)/100;
        }
    }
}
