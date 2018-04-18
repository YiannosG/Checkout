using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Checkout.Services;

namespace Checkout.Business
{
    public class CheckOut : ICheckout
    {
        public int CalculateTotal(int numberOfAs)
        {
            return numberOfAs * 50;
        }

        public int Scan(string items)
        {
            // To store the items and their counts, of course we would have use a database table
            // for now, will just use integer counts
            int countA = 0;
            int countB = 0;
            int countC = 0;
            int countD = 0;
            foreach (char item in items)
            {
                switch (item)
                {
                    case 'A':
                        countA++;
                        break;
                    case 'B':
                        countB++;
                        break;
                    case 'C':
                        countC++;
                        break;
                    case 'D':
                        countD++;
                        break;
                    default:
                        break;
                }
            }
            var total = GetTotal(countA, countB, countC, countD);

            return total;
        }

        public int GetTotal(int countA, int countB, int countC, int countD)
        {
            int divA = countA / 3;
            int modA = countA % 3;
            int priceA = divA*130 + modA*50;

            int divB = countB / 2;
            int modB = countB % 2;
            int priceB = divB * 45 + modB * 30;

            int priceC = countC*20;

            int priceD = countD*15;

            var result = priceA + priceB + priceC + priceD;

            return result;
        }

    }
}