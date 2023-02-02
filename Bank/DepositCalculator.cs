using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public static class DepositCalculator
    {
        public static decimal CalculateStablePlan (double sum, int term)
        {
            decimal stablePlan = (decimal)(sum * 8 * term / 365) / 100;
            return Math.Round(stablePlan, 2);
        }
        public static decimal CalculateOptimalPlan (double _sum, int term , double replenishment)
        {
            decimal temp = 0;
            decimal income = 0;
            decimal sum = Convert.ToDecimal(_sum);
            decimal percent = 5M;
            decimal addonSum = Convert.ToDecimal(replenishment);
            for (int i = 0; i < term / 30; i++)
            {
                temp = sum * (decimal)(1 + (percent / 100) / 12) - sum;
                income += temp;
                sum = sum + temp + addonSum;
            }
            return Math.Round(income, 2);
        }
        public static decimal CalculateStandartPlan(double _sum, int _term, double replenishment)
        {
            decimal temp = 0;
            decimal income = 0;
            decimal sum = Convert.ToDecimal(_sum);
            int term = Convert.ToInt32(_term);
            decimal percent = 5M;
            decimal addonSum = Convert.ToDecimal(replenishment);
            for (int i = 0; i < term / 30; i++)
            {
                temp = sum * (decimal)(1 + (percent / 100) / 12) - sum;
                income += temp;
                sum = sum + addonSum;
            }
            return Math.Round(income, 2);
        }
    }
}
