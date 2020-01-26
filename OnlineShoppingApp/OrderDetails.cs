using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class OrderDetails
    {
        public Account Account { get; private set; }
        public Cart MyCart { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; set; }

        public OrderDetails(Account account)
        {
            Account = account;
        }
    }
}
