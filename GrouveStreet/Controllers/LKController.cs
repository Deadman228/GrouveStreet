using GrouveStreet.Database.ContextDb;
using GrouveStreet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrouveStreet.Controllers
{
    public class LKController : Controller
    {
        private AutoServiceContext _context = new AutoServiceContext();
        public IActionResult Index()
        {
            if (AuthorizedUser.user.RoleId == 1)
            {
                ViewBag.orders = _context.Orderrs.Include(x=>x.StatusNavigation).Where(x => x.Number.Equals(AuthorizedUser.user.Phone)).ToList();
                ViewBag.orderServices = _context.Orderservices.Include(x=>x.IdServiceNavigation).ToList();
                return View("Client", AuthorizedUser.user);
            }
            if (AuthorizedUser.user.RoleId == 2)
            {
                ViewBag.Workers = _context.Users.Where(x => x.RoleId != 1).ToList();
                ViewBag.Roles = _context.Roles.Where(x=>x.Id!=1).ToList();
                return View("Manager", AuthorizedUser.user);
            }
            if (AuthorizedUser.user.RoleId == 3)
            {
                ViewBag.orders = _context.Orderrs.Include(x => x.StatusNavigation).Where(x => x.Emploer==AuthorizedUser.user.Id&&x.Status==2).ToList();
                ViewBag.orderServices = _context.Orderservices.Include(x => x.IdServiceNavigation).ToList();
                return View("Worker", AuthorizedUser.user);
            }
            return null;
        }
        public IActionResult ChangeUserData(string phone, string name, string surname,string patronymic,string login,string password)
        {
            if(string.IsNullOrEmpty(phone)||string.IsNullOrEmpty(name)||string.IsNullOrEmpty(surname)||string.IsNullOrEmpty(login)||string.IsNullOrEmpty(patronymic)||string.IsNullOrEmpty(password))
            {
                ViewBag.error = "Не все поля заполнены";
                return Index();
            }
            if (AuthorizedUser.user.Login != login)
            {
                var userFinded = _context.Users.FirstOrDefault(x => x.Login == login);
                if (userFinded != null)
                {
                    ViewBag.error = "Нельзя сменить логин - пользователь с таким логином уже существует";
                    return Index();
                }
            }
            var user = _context.Users.FirstOrDefault(x => x.Login == AuthorizedUser.user.Login);
            user.Phone = phone;
            user.Name = name;
            user.Familia = surname;
            user.Patronomyc = patronymic;
            user.Login = login;
            user.Password = password;
            _context.SaveChanges();
            AuthorizedUser.user = user;
            ViewBag.error = "Данные успешно изменены";
            return Index();
        }
        public IActionResult AddWorker(string phone, string name, string surname, string patronymic, string login, string password,string role)
        {
            if (string.IsNullOrEmpty(phone) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname) || string.IsNullOrEmpty(login) || string.IsNullOrEmpty(patronymic) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                ViewBag.errorAdd = "Не все поля заполнены";
                return Index();
            }
            var userFinded = _context.Users.FirstOrDefault(x => x.Login == login);
            if (userFinded != null)
            {
                ViewBag.errorAdd = "Пользователь с таким логином уже существует";
                return Index();
            }
            _context.Users.Add(new User()
            {
                Familia = surname,
                Login = login,
                Password = password,
                Name = name,
                Patronomyc = patronymic,
                Phone = phone,
                RoleId = int.Parse(role)
            });
            _context.SaveChanges();
            AuthorizedUser.user = _context.Users.FirstOrDefault(x => x.Login==login);
            ViewBag.errorAdd = "Сотрудник успешно добавлен";
            return Index();
        }
        public IActionResult WorkerRemove(int workerId)
        {
            var worker = _context.Users.FirstOrDefault(x => x.Id == workerId);
            _context.Users.Remove(worker);
            _context.SaveChanges();
            ViewBag.result = $"Сотрудник с табельным номером №{worker.Id.ToString("d7")} удалён";
            return Index();
        }
    }
}
