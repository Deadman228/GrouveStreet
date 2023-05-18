using GrouveStreet.Database.ContextDb;
using GrouveStreet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace GrouveStreet.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: RegistrationController
        private readonly AutoServiceContext _context;
        public RegistrationController(AutoServiceContext context)
        {
            _context = context;
        }
        public IActionResult RegistrationView()
        {
            ViewBag.hell = _context.Roles.ToList();
            return View();
        }

        // GET: RegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
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

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
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

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
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
        public ActionResult Register(string firstname, string surname, string patronymic, string login, string password, string passwordChange)
        {
            ViewBag.hell = _context.Roles.ToList();
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(patronymic) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                ViewBag.error="Некоторые поля пустые";
                return View("RegistrationView");
            }
            var user = _context.Users.FirstOrDefault(x => x.Login == login);
            if (user != null)
            {
                ViewBag.error="Такой пользователь уже есть";
                return View("RegistrationView");
            }
            var userCreated = new User()
            {
                Familia = surname,
                Name = firstname,
                Patronomyc=patronymic,
                Login = login,
                Password = password,
                RoleId = 1
            };
            _context.Users.Add(userCreated);
            _context.SaveChanges();
            AuthorizedUser.user = (User)_context.Users.FirstOrDefault(x => x.Login == login);
            return Redirect("/Home/Index");
        }
    }
}
