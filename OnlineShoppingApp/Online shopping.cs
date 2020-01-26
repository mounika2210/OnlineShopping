using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    static class OnlineShopping
    {
        /// <summary>
        /// factory class  to create new account 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="mobileNo"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public static Account CreateAccount(string userName,
            string mobileNo,
            string email,
            string address)
        {
            // Object Initalising
            var myAccount = new Account (userName)
            {
                MobileNo = mobileNo,
                Email = email,
                Address = address
            };

            return myAccount;
        }

        public static Cart AddToCart(string item,
            int quantity,
            string size)
        {
            var cart = new Cart
            {
                Item = item,
                Quantity = quantity,
                Size = size
            };

            cart.Price = 100; // ToDo: add a method to get price for every item
            return cart;
        }
        public static OrderDetails Checkout(Account account,
            Cart myCart)
        {
            var finalCheck = new OrderDetails(account)
            {
                MyCart = myCart,
                DeliveryAddress = account.Address,
                DeliveryDate = DateTime.Now.AddDays(5) // Delivery in 5 days
            };
            return finalCheck;
        }
          


    }

        
}    

