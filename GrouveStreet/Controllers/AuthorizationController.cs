using GrouveStreet.Database.ContextDb;
using GrouveStreet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GrouveStreet.Controllers
{
    public class AuthorizationController : Controller
    {
        // GET: AuthorizationController
        public IActionResult AuthorizationView()
        {
            return View();
        }

        // GET: AuthorizationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthorizationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthorizationController/Create
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

        // GET: AuthorizationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthorizationController/Edit/5
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

        // GET: AuthorizationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthorizationController/Delete/5
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
        [HttpPost]
        public ActionResult Auth(string login, string password)
        {
            GrouveStreet.Database.ContextDb.AutoServiceContext _context = new Database.ContextDb.AutoServiceContext();
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ViewBag.error = "Некоторые поля пустые";
                return View("AuthorizationView");
            }
            var user = _context.Users.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
            {
                ViewBag.error = "Пользователь не найден";
                return View("AuthorizationView");
            }
            AuthorizedUser.user = user;
            return Redirect("/Home/Index");
        }
    }
}
