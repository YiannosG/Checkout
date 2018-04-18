using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkout.Entities;

namespace Checkout.Services
{
    public interface IDataContext
    {
        IEnumerable<Item> GetAllItems();
    }
}
