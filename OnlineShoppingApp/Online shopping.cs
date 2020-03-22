using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineShoppingApp
{

    public static class OnlineShopping

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
            var myAccount = new Account
            {
                UserName = userName,
                MobileNo = mobileNo,
                Email = email,
                Address = address
            };
            db.Accounts.Add(myAccount);
            db.SaveChanges();
            return myAccount;
        }
        public static void UpdateAccount(string userName,
            string mobileNo,
            string address)
        {
            var account = GetAccountByUserName(userName);
            if (account == null)
            {
                throw new ArgumentException("No account with this UserName.");
            }

            account.MobileNo = mobileNo;
            account.Address = address;
            db.SaveChanges();
        }

        public static void UpdatePayment(int id, string cardName, int cardNo, int cVV, string validDate, PaymentMethod paymentMethod)
        {
            var ipayment = GetPaymentByID(id);


            ipayment.CardName = cardName;
            ipayment.CardNo = cardNo;
            ipayment.CVV = cVV;
            ipayment.ValidDate = validDate;
            ipayment.PaymentMethod = paymentMethod;

            db.SaveChanges();
        }
        public static void UpdateCart(int itemid, string item, int quantity, ItemSize size)
        {
            var icartentry = GetItemByID(itemid);

            icartentry.Item = item;
            icartentry.Quantity = quantity;
            icartentry.Size = size;
            db.SaveChanges();
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

        public static IEnumerable<CartEntry> GetCartItems(string emailId)
        {
            var userName = GetUserNameByEmailId(emailId);
            IEnumerable<CartEntry> cartItems = db.CartEntries.Where(cartItem => cartItem.UserName == userName);
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
       
        public static string GetUserNameByEmailId(string EmailId)
        {
            var account = GetAccountByEmailId(EmailId);
            return db.Accounts.FirstOrDefault().UserName;
        }

        public static IEnumerable<Payment> GetPaymentByEmailId(string emailId)
        {
            string username = GetUserNameByEmailId(emailId);
            return db.Payments.Where(a => a.UserName == username);
        }
        public static Payment GetPaymentByID(int? id)
        {
            return db.Payments.SingleOrDefault(a => a.ID == id);
        }
        public static CartEntry GetItemByID(int? ItemID)
        {
            return db.CartEntries.SingleOrDefault(a => a.ItemId == ItemID);
        }

        public static void RemoveItembyId(int itemId)

        {
            var cartEntry = GetItemByID(itemId);
            db.CartEntries.Remove(cartEntry);        
        }
        
        

        public static IEnumerable<Account> GetAccountByEmailId(string emailId)
        {
            return db.Accounts.Where(a => a.Email == emailId);
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

        public static IEnumerable<OrderDetails> GetOrderHistory(string UserName)
        {
            var account = GetAccountByUserName(UserName);
            if (account == null)
            {
                throw new ArgumentException("No account with this UserName");
            }

            return db.OrderDetails.Where(order => order.UserName == UserName);
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

        


