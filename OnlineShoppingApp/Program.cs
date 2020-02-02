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

            myAccount.AddToCart("Shirt", 1, "XL");
            myAccount.AddToCart("Pant", 1, "XL");
            var myOrder = myAccount.Checkout("Bellevue, WA 98007");
            Console.WriteLine("Your order will be delivered on " + myOrder.DeliveryDate);


            Console.WriteLine("welcome to online shopping");
            while (true)
            {

                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Add items to the Cart");
                Console.WriteLine("3. Check the orderdetails");
                Console.WriteLine("4. Checkout");

                // write: stays on sameline and readline, takes the input from user
                Console.Write("select an option: ");
                var option = Console.ReadLine();


               #region collections
                switch (option)
                {
                    case "0":
                        Console.WriteLine("Thank You for shopping! Visit Again");
                        return;

                    case "1":
                        // Begin: User details
                        Console.WriteLine("UserName");
                        var Username = Console.ReadLine();

                        Console.WriteLine("Mobile No: ");
                        var mobileno = Console.ReadLine();

                        Console.WriteLine("Email Id: ");
                        var emailid = Console.ReadLine();

                        Console.WriteLine("Address: ");
                        var address = Console.ReadLine();
                        // END: User details

                        var userAccount = OnlineShopping.CreateAccount(Username, mobileno, emailid, address);

                        // Begin: payment details
                        Console.WriteLine("select an option for payment: ");
                        var paymenttypes = Enum.GetNames(typeof(PaymentMethod));
                        for (var i = 0; i < paymenttypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{paymenttypes[i]}");
                        }
                        var payment = Enum.Parse<PaymentMethod>(Console.ReadLine());

                        Console.WriteLine("CardNo");
                        var Cardname = Console.ReadLine();

                        Console.WriteLine ("CardNo");
                        var cardNo = Console.ReadLine();

                        Console.WriteLine("CVV");
                        var cvv = Console.ReadLine();
                       
                        Console.WriteLine("ValidDate");
                        var validDate = Console.ReadLine();

                        var carddetails = new Payment(Cardname,Int32.Parse(cardNo), Int32.Parse(cvv),validDate,payment);
                        userAccount.Payment = carddetails;

                        //END payment details

                       break;

                    case "2":
                        // case 2 job is to add items to the cart 
                       
                        break;
                    default:
                        Console.Write("Invalid Option!,select the coorect one: ");
                        Console.ReadLine();
                        break;




                }


            }

            #endregion collections 

             





        }
    }
}

      
