using GrouveStreet.Database.ContextDb;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrouveStreet.Controllers
{
    public class ServicesController : Controller
    {
        private readonly AutoServiceContext _context;
        public ServicesController(AutoServiceContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var services = _context.Services.ToList();
            return View("Services",services);
        }
        public IActionResult AddService(int serviceId,string name,string description, int? cost)
        {
            if(string.IsNullOrEmpty(name)||string.IsNullOrEmpty(description)||!cost.HasValue)
            {
                ViewBag.result = "Некоторые поля были пустые";
                return Index();
            }
            var service = new Service();
            service.Name = name;
            service.Description = description;
            service.Cost = cost.Value;
            _context.Services.Add(service);
            _context.SaveChanges();
            ViewBag.result = "Услуга добавлена";
            return Index();
        }
        public IActionResult EditService(int serviceId, string name, string description, int? cost)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(description) || !cost.HasValue)
            {
                ViewBag.result = "Некоторые поля были пустые";
                return Index();
            }
            var service = _context.Services.FirstOrDefault(x => x.Id == serviceId);
            service.Name = name;
            service.Description = description;
            service.Cost = cost.Value;
            _context.SaveChanges();
            ViewBag.result = "Услуга изменена";
            return Index();
        }
        public IActionResult ServiceRemove(int serviceId)
        { 
            var service = _context.Services.FirstOrDefault(x => x.Id == serviceId);
            _context.Services.Remove(service);
            _context.SaveChanges();
            ViewBag.result = "Услуга удалена";
            return Index();
        }
    }
}
