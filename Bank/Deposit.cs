using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class Deposit
    {
        public string Title { get; }
        public decimal Income { get; }
        public decimal Sum { get; }
        public decimal FinalSum { get; }
        public double InterestRate { get; }
        public double EffectiveRate { get; set; }
        public int Term { get; }
        public Deposit(string title, decimal income, decimal finalSum, double interestRate, int term, decimal sum)
        {
            Title = title;
            Income = income;
            FinalSum = finalSum;
            InterestRate = interestRate;
            Term = term;
            GetEffectiveRate();
            Sum = sum;
        }
        private void GetEffectiveRate()
        {
            EffectiveRate = (Math.Pow(1 + InterestRate / 12, Term / 30) - 1) * 12/(Term / 30);
        }
    }
}
