using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class Account
    {
        #region properties
        public string  UserName { get; private set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string  Address { get; set; }
        public Payment Payment { get; set; }
        
        #endregion properties
        public Account(string userName)
        {
            // UserName once created cannot be modified
            UserName = userName;
        }
    }
}
