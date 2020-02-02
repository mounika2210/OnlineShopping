using System.Collections.Generic;

namespace OnlineShoppingApp
{
    class CartEntry
    {
        #region properties
        public string Item { get; set; }
        public int Quantity { get; set; }
        public  string Size { get; set; }
        public int Price { get; set; }
        #endregion properties
    }

    class Cart
    {
        private List<CartEntry> CartEntries;

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
    }
}
