﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {
        //
        public delegate void MentionDiscount(decimal subTotal);
        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal(MentionDiscount mentionDiscount,
            Func<List<ProductModel>,decimal,decimal> calculateDiscountedTotal,
            Action<string> alertDiscount)
        {
            decimal subTotal = Items.Sum(x => x.Price);
            mentionDiscount(subTotal);
            alertDiscount("You have discount.");
            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}
