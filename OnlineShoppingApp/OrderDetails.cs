using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class OrderDetails
    {
        public string UserName { get; private set; }
        public Cart MyCart { get; private set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; private set; }

        public OrderDetails(string userName, Cart myCart)
        {
            UserName = userName;
            MyCart = myCart;
            DeliveryDate = DateTime.Now.AddDays(5); // Delivery in 5 days
        }
    }
}
