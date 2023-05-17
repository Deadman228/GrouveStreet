using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using GrouveStreet.DataBase;
using System.Linq;

namespace GrouveStreet.Controllers
{
    
    public class ZapisController : Controller
    {
        private readonly AppDbContext _context;
        public ZapisController(AppDbContext context)
        {
            _context = context;
        }
        // GET: Zapis
        public IActionResult ZapisView()
        {
            ViewBag.ku = _context.services.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Zapi(int id, string , Orderr modik)
        {
            _context.orderr.Add(new Orderr
            {
                orderid = _context.orderr.Count() + 1,
                ordersostav = login,
                status = 1

            });

            _context.SaveChanges();
            return ZapisView();
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
