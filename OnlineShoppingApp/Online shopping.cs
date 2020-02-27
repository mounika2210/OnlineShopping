using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShoppingApp
{
    static class OnlineShopping

    {
        private static ShoppingApp db = new ShoppingApp();
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
                throw new ArgumentException("UserName Already exists! Try Again.");
                
            }

            // Object Initalising
            var myAccount = new Account(userName)
            {
                MobileNo = mobileNo,
                Email = email,
                Address = address
            };
            db.Accounts.Add(myAccount);
            db.SaveChanges();
            return myAccount;
        }
        public static void AddToCart(string userName, string item, int quantity, ItemSize size)
        {
            var account = GetAccountByUserName(userName);
            if (account == null)
            {
                throw new ArgumentException("No account with this UserName");
            }

            var cartItem = new CartEntry
            {
                Item = item,
                Quantity = quantity,
                Size = size,
                Price = 10, // Fixed price for all items
                UserName = userName
            };

            db.CartEntries.Add(cartItem);
            db.SaveChanges();
        }

        public static IEnumerable<CartEntry> GetCartItems(string UserName)
        {
            var account = GetAccountByUserName(UserName);
            if (account == null)
            {
                throw new ArgumentException("No account with this UserName");
            }
            IEnumerable<CartEntry> cartItems = db.CartEntries.Where(cartItem => cartItem.UserName == UserName);
            return cartItems;
        }

        public static void PrintCart(string UserName)
        {
            IEnumerable<CartEntry> cartItems = GetCartItems(UserName);
            if (cartItems.Any() == false)
            {
                Console.WriteLine("Cart is empty. Keep Shopping!!!!");
            }
            else 
            {
                Console.WriteLine("------------------------");
                foreach (var item in cartItems)
                {
                    Console.WriteLine($"Item: {item.Item}, Quantity: {item.Quantity}, Size: {item.Size}, Price: {item.Price}");
                }
                Console.WriteLine("------------------------");
            }

        }

        public static void SetPayment(string UserName, Payment payment)
        {
            var account = GetAccountByUserName(UserName);
            if (account == null)
            {
                throw new ArgumentException("No account with this UserName");
            }
            payment.UserName = UserName;
            db.Payments.Add(payment);
            db.SaveChanges();
        }

        public static Account GetAccountByUserName(string UserName)
        {
            return db.Accounts.SingleOrDefault(a => a.UserName ==UserName);
        }
       
        public static void CheckOut(string UserName, string deliveryaddress)
        {
            var account = GetAccountByUserName(UserName);
            if (account==null)
            {
                throw new ArgumentException("No account with this UserName");
            }

            IEnumerable<Payment> paymentDetails = db.Payments.Where(p => p.UserName == UserName);
            if (paymentDetails.Any() == false)
            {
                throw new ArgumentException("Payment is null, Please add the Payment Details!");
            }

            IEnumerable<CartEntry> cartItems = GetCartItems(UserName);
            if (cartItems.Any() == false)
            {
                throw new ArgumentException("Cart is Empty!,Please add items to cart.");
            }


            OrderDetails orderDetails = new OrderDetails
            {
                UserName = UserName,
                DeliveryAddress = deliveryaddress,
                DeliveryDate = DateTime.Now.AddDays(5) // Delivery in 5 days 
            };

            db.OrderDetails.Add(orderDetails);
            db.SaveChanges();
            // Move cartItems to OrderedItems
            foreach (var cartItem in cartItems)
            {
                var orderedItem = new OrderedItem
                {
                    Item = cartItem.Item,
                    Quantity = cartItem.Quantity,
                    Size = cartItem.Size,
                    Price = cartItem.Price,
                    UserName = cartItem.UserName,
                    OrderId = orderDetails.OrderId
                };
                db.OrderedItems.Add(orderedItem);
                db.CartEntries.Remove(cartItem);
            }
            db.SaveChanges();

            PrintOrderDetails(orderDetails);
        }

        public static void PrintOrderHistory(string UserName)
        {
            var account = GetAccountByUserName(UserName);
            if (account == null)
            {
                throw new ArgumentException("No account with this UserName");
            }

            IEnumerable<OrderDetails> orderHistory = db.OrderDetails.Where(order => order.UserName == UserName);
            if (orderHistory.Any() == false)
            {
                Console.WriteLine("No Orders yet. Kepp Shopping!!!!");
            }
            else
            {
                Console.WriteLine("\n================================");
                foreach (var orderDetails in orderHistory)
                {
                    PrintOrderDetails(orderDetails);
                }
                Console.WriteLine("================================\n");
            }
        }

        public static void PrintOrderDetails(OrderDetails orderDetails)
        {
            IEnumerable<OrderedItem> orderedItems = db.OrderedItems.Where(oi => oi.OrderId == orderDetails.OrderId);
            Console.WriteLine("\n-----------------------------");
            Console.WriteLine("OrderId: " + orderDetails.OrderId);
            Console.WriteLine("Username: " + orderDetails.UserName);
            Console.WriteLine("DeliveryAddress: " + orderDetails.DeliveryAddress);
            Console.WriteLine("DeliveryDate: " + orderDetails.DeliveryDate);
            Console.WriteLine("Ordered Items:");
            foreach (var item in orderedItems)
            {
                Console.WriteLine($"Item: {item.Item}, Quantity: {item.Quantity}, Size: {item.Size}, Price: {item.Price}");
            }
            Console.WriteLine("-----------------------------\n");
        }

    }
}

        


