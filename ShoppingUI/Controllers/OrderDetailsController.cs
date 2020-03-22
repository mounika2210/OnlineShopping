using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp;

namespace ShoppingUI.Controllers
{
    public class OrderDetailsController : Controller
    {
        private readonly ShoppingApp _context;

        public OrderDetailsController(ShoppingApp context)
        {
            _context = context;
        }

        // GET: OrderDetails
        public IActionResult Index()
        {
            var userName = OnlineShopping.GetUserNameByEmailId(HttpContext.User.Identity.Name);
            return View(OnlineShopping.GetOrderHistory(userName));
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Account)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserName,DeliveryAddress,DeliveryDate")] OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                var userName = OnlineShopping.GetUserNameByEmailId(HttpContext.User.Identity.Name);
                OnlineShopping.CheckOut(userName, orderDetails.DeliveryAddress);
                return RedirectToAction(nameof(Index));
            }

            return View(orderDetails);
        }
    }
}
