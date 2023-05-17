using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrouveStreet.Controllers
{
    public class zapis : Controller
    {
        // GET: zapis
        public ActionResult Index()
        {
            return View();
        }

        // GET: zapis/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: zapis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: zapis/Create
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

        // GET: zapis/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: zapis/Edit/5
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

        // GET: zapis/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: zapis/Delete/5
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
