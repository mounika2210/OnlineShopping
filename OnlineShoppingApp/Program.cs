namespace OnlineShoppingApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var myAccount = new Account();

            myAccount.username = "kristina";
            myAccount.mobileno = "206 - 623 - 9856";
            myAccount.email = "kristina@yahoo.com";
            myAccount.address = " Redmond,Bellvue";

            var myCart = new Cart();
            myCart.item = "top";
            myCart.price = 26;
            myCart.quantity = 2;
            myCart.size = "medium";

            var myPayment = new Payment();
            myPayment.cardno = 45689;
            myPayment.CVV = 678;
            myPayment.name = "Kristin Joseph";
            myPayment.validDate = "22-10-2024";

            var myOrder = new Checkout();
            myOrder.myCart = myCart;
            myOrder.deliveryAddress = myAccount.address;
            myOrder.deliveryDate = "2-1-2020";
            

        }
    }
}

      
