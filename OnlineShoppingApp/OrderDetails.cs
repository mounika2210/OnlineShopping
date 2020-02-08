using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShoppingApp
{
    class OrderDetails
    {
        public string UserName { get; private set; }
        public List<CartEntry> OrderedItems { get; private set; }
        public string DeliveryAddress { get; set; }
        public DateTime DeliveryDate { get; private set; }

        public OrderDetails(string userName, List<CartEntry> cartEntries)
        {
            UserName = userName;
            OrderedItems = new List<CartEntry>(cartEntries);
            DeliveryDate = DateTime.Now.AddDays(5); // Delivery in 5 days
        }

        public void PrintOrderDetails()
        {
            Console.WriteLine("username: " + UserName);
            Console.WriteLine("DeliveryAddress: " + DeliveryAddress);
            Console.WriteLine("DeliveryDate: " + DeliveryDate);
            Console.WriteLine("Ordered Items:");
            foreach (var item in OrderedItems)
            {
                Console.WriteLine($"Item: {item.Item}, Quantity: {item.Quantity}, Size: {item.Size}, Price: {item.Price}");
            }
        }
    }
}
