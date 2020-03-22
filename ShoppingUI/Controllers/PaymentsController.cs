using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp;



namespace ShoppingUI.Controllers
{
    public class PaymentsController : Controller
    {
        private readonly ShoppingApp _context;

        public PaymentsController(ShoppingApp context)
        {
            _context = context;
        }

        // GET: Payments
        public  IActionResult Index()
        {
            return View(OnlineShopping.GetPaymentByEmailId(HttpContext.User.Identity.Name));
        }

        // GET: Payments/Details/5
        public  ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = OnlineShopping.GetPaymentByID(id);
            if (payment == null)
            {
                return NotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,CardName,CardNo,CVV,ValidDate,PaymentMethod,UserName")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                IEnumerable<Payment>ipayments = OnlineShopping.GetPaymentByEmailId(HttpContext.User.Identity.Name);
                if (ipayments.Any<Payment>() == false)
                {
                    string userName = OnlineShopping.GetUserNameByEmailId(HttpContext.User.Identity.Name);
                    OnlineShopping.SetPayment(userName, payment);
                    return RedirectToAction(nameof(Index));
                }
                
            }
            
            return View(payment);
        }

        // GET: Payments/Edit/5
        public  IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = OnlineShopping.GetPaymentByID(id.Value);
                
            if (payment == null)
            {
                return NotFound();
            }
          
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,CardName,CardNo,CVV,ValidDate,PaymentMethod,UserName")] Payment ipayment)
        {
            if (id != ipayment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                OnlineShopping.UpdatePayment(ipayment.ID, ipayment.CardName, ipayment.CardNo,ipayment.CVV, ipayment.ValidDate, ipayment.PaymentMethod);
                return RedirectToAction(nameof(Index));

            }
            return View(ipayment);
        }

       
    }
}
