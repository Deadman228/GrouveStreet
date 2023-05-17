using GrouveStreet.Database.ContextDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GrouveStreet.Controllers
{
    
    public class ZapisController : Controller
    {
        private readonly AutoServiceContext _context;
        public ZapisController(AutoServiceContext context)
        {
            _context = context;
        }
        // GET: Zapis
        public IActionResult ZapisView()
        {
            ViewBag.ku = _context.Services.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Zapi(string marka, string number,List<int> workType, DateTime date)
        {
            _context.Orderrs.Add(new Orderr
            {
                Emploer=null,
                Mark=marka,
                Status=1,
                Number=number,
                Date=date
            });
            _context.SaveChanges();
            var order = _context.Orderrs.OrderBy(x=>x.Orderid).LastOrDefault(x => x.Number.Equals(number));
            foreach (var service in workType)
            {
                _context.Orderservices.Add(new Orderservice()
                {
                    IdOrder = order.Orderid,
                    IdService = service
                });
            }
            _context.SaveChanges();
            ViewBag.ku = _context.Services.ToList();
            return View("ZapisView");
        }
        // GET: Zapis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Zapis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zapis/Create
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

        // GET: Zapis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Zapis/Edit/5
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

        // GET: Zapis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Zapis/Delete/5
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
