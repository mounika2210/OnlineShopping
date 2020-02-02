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
        public static void AddToCart(string userName, string item)
        {
            var account = accounts.Where(a => a.UserName == userName);
        
        }
    }

        
}    

