using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Checkout.Entities;
using Checkout.Services;

namespace Checkout.Business
{
    public class DataContext : IDataContext
    {
        public IEnumerable<Item> GetAllItems()
        {
            var items = new List<Item>
            {
                new Item()
                {
                    Id = 1,
                    Name = "A",
                    Price = 50,
                    OfferItemCount = 3,
                    OfferPrice = 130
                },
                new Item()
                {
                    Id = 2,
                    Name = "B",
                    Price = 30,
                    OfferItemCount = 2,
                    OfferPrice = 45
                },
                new Item()
                {
                    Id = 3,
                    Name = "C",
                    Price = 20,
                    OfferItemCount = 0,
                    OfferPrice = 0
                },
                new Item()
                {
                    Id = 4,
                    Name = "D",
                    Price = 15,
                    OfferItemCount = 0,
                    OfferPrice = 0
                }
            };

            return items;
        }

        public void Scan(string sku)
        {
            
        }

        public int GetTotal()
        {
            return 0;
        }
    }
}