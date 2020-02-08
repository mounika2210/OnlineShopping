using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class Account
    {
        #region properties
        public string UserName { get; private set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Payment MyPayment { get; set; }
        public Cart MyCart { get; }
        public List<OrderDetails> OrderHistory { get; private set; }
        
        #endregion properties
        public Account(string userName)
        {
            // UserName once created cannot be modified
            UserName = userName;
            MyCart = new Cart();
            OrderHistory = new List<OrderDetails>();
        }

        public void AddToCart(string item,
            int quantity,
            ItemSize size)
        {
            var cartItem = new CartEntry
            {
                Item = item,
                Quantity = quantity,
                Size = size,
                Price = 10 // Fixed price for all items
            };

            MyCart.AddEntry(cartItem);
        }

        public OrderDetails Checkout(string deliveryAddress)
        {
            var MyOrderDetails = new OrderDetails(UserName, MyCart.CartEntries)
            {
                DeliveryAddress = deliveryAddress
            };

            //adding order details to order history
            OrderHistory.Add(MyOrderDetails);
            //clearing the cart after checkout
            MyCart.CartEntries.Clear();

            return MyOrderDetails;
        }
    }
}
