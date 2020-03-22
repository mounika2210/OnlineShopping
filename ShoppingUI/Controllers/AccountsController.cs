using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp;
using NToastNotify;

namespace ShoppingUI.Controllers
{
    [Authorize]
    public class AccountsController : Controller
    {
        private readonly IToastNotification _toastNotification;
        
        public AccountsController(IToastNotification toastNotification)
        {
            _toastNotification = toastNotification;
        }
        // GET: Accounts
        public IActionResult Index()
        {
            return View(OnlineShopping.GetAccountByEmailId(HttpContext.User.Identity.Name));
        }

        // GET: Accounts/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = OnlineShopping.GetAccountByUserName(id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("UserName,MobileNo,Email,Address")] Account account)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    IEnumerable<Account> iAccount = OnlineShopping.GetAccountByEmailId(HttpContext.User.Identity.Name);
                    if (iAccount.Any<Account>() == false)
                    {
                        OnlineShopping.CreateAccount(account.UserName, account.MobileNo, HttpContext.User.Identity.Name, account.Address);
                        _toastNotification.AddSuccessToastMessage("Account created successfully!");
                        return RedirectToAction(nameof(Index));
                    }

                }
            }
            catch (Exception e)
            {
                _toastNotification.AddErrorToastMessage("Invalid Account!");
                ModelState.AddModelError(string.Empty, e.Message);
            }
            return View(account);
        }

        // GET: Accounts/Edit/5
        public IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = OnlineShopping.GetAccountByUserName(id);
            if (account == null)
            {
                return NotFound();
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("UserName,MobileNo,Email,Address")] Account account)
        {
            if (id != account.UserName)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                OnlineShopping.UpdateAccount(account.UserName, account.MobileNo, account.Address);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }
    }
}

       
