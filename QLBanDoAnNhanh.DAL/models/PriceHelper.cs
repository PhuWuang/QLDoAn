using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanDoAnNhanh.DAL.Models
{
    public static class PriceHelper
    {
        public static decimal CalculateTotal(decimal price, int qty, decimal discount = 0)
        {
            if (price < 0 || qty < 0) throw new ArgumentOutOfRangeException();
            var subtotal = price * qty;
            if (discount < 0) discount = 0;
            if (discount > subtotal) discount = subtotal;
            return subtotal - discount;
        }
    }
}
