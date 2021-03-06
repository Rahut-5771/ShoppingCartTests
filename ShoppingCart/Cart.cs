﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Common
{
    public class Cart
    {
        public List<CartItem> Items { get; private set; }

        public Cart()
        {
            Items = new List<CartItem>();
        }

        public void AddItem(CartItem item)
        {
            if (Items.Contains(item))
                return;
            Items.Add(item);
        }

        public void RemoveItem(CartItem item)
        {
            Items.Remove(item);
        }

        public decimal GetShoppingCartTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
            {
                total += item.GetItemPrice();
            }
            return total;
        }
    }
}
