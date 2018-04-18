using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Entities;

namespace Checkout.Services
{
    public interface ICheckout
    {
        int Scan(string sku);
        int GetTotal(int a, int b, int c, int d);
    }
    
}
