using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        GiftCard
    }

    class Payment
    {
        #region details 
        public string Name  { get; private set; }
        public int CardNo { get; private set; }
        public int CVV { get; private set; }
        public string ValidDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }

        #endregion details
        // constructor
        public Payment(string name, int cardNo, int cVV, string validDate, PaymentMethod paymentMethod)
        {
            Name = name;
            CardNo = cardNo;
            CVV = cVV;
            ValidDate = validDate;
            PaymentMethod = paymentMethod;
        }
    }
}
