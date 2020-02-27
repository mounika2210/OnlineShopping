using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class OrderedItem
    {
        #region properties
        public string Item { get; set; }
        public int Quantity { get; set; }
        public ItemSize Size { get; set; }
        public int Price { get; set; }
        public int ItemId { get; set; }

        public string UserName { get; set; }
        public Account Account { get; set; }

        public int OrderId { get; set; }
        public OrderDetails OrderDetails { get; set; }
        #endregion properties
    }

    class OrderDetails
    {
        public int OrderId { get; set; }
        public string UserName { get; set; }

        public OrderedItem OrderedItem { get; set; }
        public Account Account { get; set; }

        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
}
