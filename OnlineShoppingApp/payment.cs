using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class Payment
    {
        #region details 
        public string name  { get; set; }
        public int cardno { get; set; }
        public int CVV { get; set; }
        public string validDate { get; set; }

        #endregion details
    }
}
