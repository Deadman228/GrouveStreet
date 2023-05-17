using GrouveStreet.Database.ContextDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrouveStreet.Controllers
{
    public class AccountController : Controller
    {
        private readonly AutoServiceContext _context;
        public AccountController(AutoServiceContext context)
        {
            _context = context;
        }
        // GET: AccountController
        public IActionResult AccountView()
        {
            var orders = _context.Orderrs.ToList();
            ViewBag.OrderServices = _context.Orderservices.ToList();
            ViewBag.Services=_context.Services.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            return View(orders);
        }
        public IActionResult OrderChangesSave(int orderId, List<int> services, int status)
        {
            var order = _context.Orderrs.FirstOrDefault(x => x.Orderid == orderId);
            var orderServices = _context.Orderservices.Where(x => x.IdOrder == orderId);
            foreach (var orderService in orderServices)
                _context.Orderservices.Remove(orderService);
            _context.SaveChanges();
            foreach(var serviceId in services)
            {
                _context.Orderservices.Add(new Orderservice()
                {
                    IdOrder = orderId,
                    IdService = serviceId
                });
            }
            order.Status = (short)status;
            _context.SaveChanges();
            return Redirect("/Account/AccountView");
        }
        // GET: AccountController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AccountController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccountController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
