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
        public int ID { get; set; }
        public string CardName { get; private set; }
        public int CardNo { get; private set; }
        public int CVV { get; private set; }
        public string ValidDate { get; private set; }
        public PaymentMethod PaymentMethod { get; private set; }
        public Account Account { get; set; }
        public string UserName { get; set; }

        public Payment() { }

        #endregion details
        // constructor
        public Payment(string name, int cardNo, int cVV, string validDate, PaymentMethod paymentMethod)
        {
            CardName = name;
            CardNo = cardNo;
            CVV = cVV;
            ValidDate = validDate;
            PaymentMethod = paymentMethod;
        }
    }
}
