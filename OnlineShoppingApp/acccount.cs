using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    public class Account
    {
        #region properties
        public string UserName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Payment MyPayment { get; set; }
        public Cart MyCart { get; }
        public List<OrderDetails> OrderHistory { get; private set; }
        
        #endregion properties
        public Account()
        {
            // UserName once created cannot be modified
            MyCart = new Cart();
            OrderHistory = new List<OrderDetails>();
        }
    }
}
