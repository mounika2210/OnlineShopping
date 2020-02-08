using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShoppingApp
{
    static class OnlineShopping

    {
        private static List<Account> accounts = new List<Account>();
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
            var account = GetAccountByUserName(userName);
            if (account != null)
            {
                Console.WriteLine("User already exists with UserName: " + userName);
                return null;
            }

            // Object Initalising
            var myAccount = new Account(userName)
            {
                MobileNo = mobileNo,
                Email = email,
                Address = address
            };
            accounts.Add(myAccount);

            return myAccount;
        }
        public static void AddToCart(string userName, string item, int quantity, ItemSize size)
        {
            var account = GetAccountByUserName(userName);
            if (account == null)
            {
                Console.WriteLine("No account with this username");
                return;
            }
            account.AddToCart(item, 1, size);
        }

        public static void SetPayment(string UserName, Payment payment)
        {
            var account = GetAccountByUserName(UserName);
            if (account == null)
            {
                Console.WriteLine("No account with this username");
                return;
            }
            account.MyPayment = payment;
        }

        public static Account GetAccountByUserName(string UserName)
        {
            return accounts.SingleOrDefault(a => a.UserName ==UserName);
        }

        public static OrderDetails CheckOut(string UserName)
        {
            var account = GetAccountByUserName(UserName);
            if (account==null)
            {
                Console.WriteLine("No account with this username");
                return null;
            }
            if (account.MyPayment==null)
            {
                Console.WriteLine("Payment is null, Please add the Payment Details!");
                return null;
            }
            
            if(account.MyCart.CartEntries.Count==0)
            {
                Console.WriteLine("Cart is Empty!,Please add items to cart.");
                return null;

            }
                        
            var MyOrderDetails = account.Checkout(account.Address);
            return MyOrderDetails;
        }


    }
}

        


