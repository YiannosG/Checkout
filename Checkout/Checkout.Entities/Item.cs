using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Checkout.Entities
{
    public class Item
    {
        public int Id { get; set; }

        /// <summary>
        /// Name of item
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Unit price
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Number of items required to qualify for special offer. O means no special offer associated with that item
        /// </summary>
        public int OfferItemCount { get; set; }

        /// <summary>
        /// Special Offer price achieved when a certain number of items is bought
        /// </summary>
        public int OfferPrice { get; set; }
    }
}