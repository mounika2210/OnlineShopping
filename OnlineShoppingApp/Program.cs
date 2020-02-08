using System;

namespace OnlineShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("welcome to online shopping");
            while (true)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Create an account");
                Console.WriteLine("2. Add items to the Cart");
                Console.WriteLine("3. View Cart");
                Console.WriteLine("4. Set Payment");
                Console.WriteLine("5. Checkout Cart");
                Console.WriteLine("6. Order History");
                Console.WriteLine("==============================\n");

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

                        OnlineShopping.CreateAccount(Username, mobileno, emailid, address);
                        break;

                    case "2":
                        Console.Write("Username: ");
                        var userName = Console.ReadLine();

                        Console.Write("Item: ");
                        var item = Console.ReadLine();

                        Console.Write("Quantity: ");
                        int quantity =Int32.Parse(Console.ReadLine());
                        // add extra quantity

                        Console.Write("select Size: ");
                        var sizes = Enum.GetNames(typeof(ItemSize));
                        for (var i = 0; i < sizes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{sizes[i]}");
                        }
                        var size = Enum.Parse<ItemSize>(Console.ReadLine());

                        OnlineShopping.AddToCart(userName, item, quantity, size);
                        break;
                    case "3":
                        Console.Write("Username: ");
                        userName = Console.ReadLine();

                        PrintCart(userName);

                        break;

                    case "4":
                        // Begin: payment details
                        Console.WriteLine("Username");
                        var username = Console.ReadLine();

                        Console.WriteLine("select an option for payment: ");
                        var paymenttypes = Enum.GetNames(typeof(PaymentMethod));
                        for (var i = 0; i < paymenttypes.Length; i++)
                        {
                            Console.WriteLine($"{i}.{paymenttypes[i]}");
                        }
                        var payment = Enum.Parse<PaymentMethod>(Console.ReadLine());

                        Console.WriteLine("CardName");
                        var Cardname = Console.ReadLine();

                        Console.WriteLine ("CardNo");
                        var cardNo = Console.ReadLine();

                        Console.WriteLine("CVV");
                        var cvv = Console.ReadLine();
                       
                        Console.WriteLine("ValidDate");
                        var validDate = Console.ReadLine();

                        var carddetails = new Payment(Cardname,Int32.Parse(cardNo), Int32.Parse(cvv),validDate,payment);
                        OnlineShopping.SetPayment(username, carddetails);
                       
                        //END payment details                        
                       break;
                      
                    case "5":
                        Console.WriteLine("Username");
                        userName = Console.ReadLine();
                        Console.WriteLine("Delivery Address: ");
                        var deliveryaddress = Console.ReadLine();

                        var orderDetails = OnlineShopping.CheckOut(userName, deliveryaddress);
                        if (orderDetails != null)
                        {
                            Console.WriteLine("\n-----------------------------");
                            orderDetails.PrintOrderDetails();
                            Console.WriteLine("-----------------------------\n");
                        }

                        break;
                    case "6":
                        Console.WriteLine("Username");
                        userName = Console.ReadLine();
                        var account = OnlineShopping.GetAccountByUserName(userName);
                        foreach (var order in account.OrderHistory)
                        {
                            Console.WriteLine("\n-----------------------------");
                            order.PrintOrderDetails();
                        }
                        Console.WriteLine("-----------------------------\n");

                        break;

                    default:
                        Console.Write("Invalid Option!,select the coorect one: ");
                        Console.ReadLine();
                        break;

                }


            }

            #endregion collections 
        }

        private static void PrintCart(string userName)
        {
            var account = OnlineShopping.GetAccountByUserName(userName);
            if (account == null)
            {
                Console.WriteLine("No account with this username");
            }
            else 
            {
                var cart = account.MyCart;
                cart.PrintCart();
            }
        }
    }
}

      
