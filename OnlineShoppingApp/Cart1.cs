using System.Collections.Generic;
using System;

namespace OnlineShoppingApp
{
    enum ItemSize
    {
       xsmall,
       small,
       medium,
       large,
       xlarge
    }
    class CartEntry
    {
        #region properties
        public string Item { get; set; }
        public int Quantity { get; set; }
        public ItemSize Size { get; set; }
        public int Price { get; set; }
        public int ItemId { get; set; }

        public string UserName { get; set; }
        public Account Account { get; set; }
        #endregion properties
    }

    class Cart
    {
        public List<CartEntry> CartEntries { get; }

        #region constructor
        public Cart()
        {
            CartEntries = new List<CartEntry>();
        }
        #endregion
        
        public void AddEntry(CartEntry cartEntry)
        {
            CartEntries.Add(cartEntry);
        }

        public void PrintCart()
        {
            foreach (var item in CartEntries)
            {
                Console.WriteLine($"Item: {item.Item}, Quantity: {item.Quantity}, Size: {item.Size}, Price: {item.Price}");
            }
        }
    }
}
