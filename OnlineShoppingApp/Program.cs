using System;

namespace OnlineShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var myAccount = OnlineShopping.CreateAccount("kristina", "2062062066", "alexa@google.com", "In The Cloud");

            // Add payment details to account. We are accepting only one payment method. It will replace old one, if any.
            var myPayment = new Payment("kristiuna", 123123, 176, "2020", PaymentMethod.GiftCard);
            myAccount.Payment = myPayment;

            Cart myCart = OnlineShopping.AddToCart("Shirt", 1, "XL");
            var myOrder = OnlineShopping.Checkout(myAccount, myCart);
            Console.WriteLine("Your order will be delivered on " + myOrder.DeliveryDate);            
        }
    }
}

      
