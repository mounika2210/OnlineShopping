using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    public enum PaymentMethod
    {
        CreditCard,
        DebitCard,
        GiftCard
    }

    public class Payment
    {
        #region details   
        public int ID { get; set; }
        public string CardName { get; set; }
        public int CardNo { get; set; }
        public int CVV { get; set; }
        public string ValidDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
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
