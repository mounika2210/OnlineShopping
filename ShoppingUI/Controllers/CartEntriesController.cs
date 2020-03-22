using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp;

namespace ShoppingUI.Controllers

{
    [Authorize]
    public class accountController : Controller
    {
        private readonly ShoppingApp _context;

        public accountController(ShoppingApp context)
        {
            _context = context;
        }

        public accountController()
        {
        }

        // GET: CartEntries
        public IActionResult Index()
        {           
            return View(OnlineShopping.GetCartItems(HttpContext.User.Identity.Name));
        }

        // GET: CartEntries/payment/5
       

        // GET: CartEntries/Create
        public IActionResult Create()
        {
           
            return View();
        }

        // POST: CartEntries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Item,Quantity,Size,ItemId,UserName")] CartEntry cartEntry)
        {
            if (ModelState.IsValid)
            {
                var userName = OnlineShopping.GetUserNameByEmailId(HttpContext.User.Identity.Name);
                OnlineShopping.AddToCart(userName, cartEntry.Item, cartEntry.Quantity, cartEntry.Size);
                return RedirectToAction(nameof(Index));
            }
            
            return View(cartEntry);
        }

        // GET: CartEntries/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartEntry = OnlineShopping.GetItemByID(id);
            if (cartEntry == null)
            {
                return NotFound();
            }
            
            return View(cartEntry);
        }

        // POST: CartEntries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Item,Quantity,Size,Price,ItemId,UserName")] CartEntry icartEntry)
        {
            if (id != icartEntry.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                OnlineShopping.UpdateCart(icartEntry.ItemId,icartEntry.Item,icartEntry.Quantity,icartEntry.Size);
                return RedirectToAction(nameof(Index));
            }
           
            return View(icartEntry);
        }

        // GET: CartEntries/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cartEntry =  OnlineShopping.GetItemByID(id);          
            return View(cartEntry);
        }

        // POST: CartEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            OnlineShopping.RemoveItembyId(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CartEntryExists(int id)
        {
            return _context.Cart.Any(e => e.ItemId == id);
        }
    }
}
