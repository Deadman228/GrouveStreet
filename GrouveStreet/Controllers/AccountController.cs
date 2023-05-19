using GrouveStreet.Database.ContextDb;
using GrouveStreet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Office.Interop.Word;
using System.Collections.Generic;
using System.IO;
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
            return View("AccountView",orders);
        }
        public IActionResult WorkerZapises()
        {
            var orders = _context.Orderrs.Where(x=>x.Emploer==AuthorizedUser.user.Id&&x.Status!=2).ToList();
            ViewBag.OrderServices = _context.Orderservices.ToList();
            ViewBag.Services = _context.Services.ToList();
            ViewBag.Statuses = _context.Statuses.ToList();
            return View("WorkerZapises", orders);
        }
        public IActionResult ChangeOrderStatusWorker(int orderId,int status)
        {
            var order = _context.Orderrs.FirstOrDefault(x => x.Orderid == orderId);
            order.Status = (short)status;
            _context.SaveChanges();
            ViewBag.result = "Запись изменена";
            return WorkerZapises();
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
        public IActionResult OrderRemove(int orderId)
        {
            var order = _context.Orderrs.FirstOrDefault(x => x.Orderid == orderId);
            _context.Orderrs.Remove(order);
            _context.SaveChanges();
            return AccountView();
        }
        public FileContentResult ChekCreate(int orderId)
        {
            var order = _context.Orderrs.FirstOrDefault(x => x.Orderid == orderId);
            Document document = null;
            Application application = new Application();
            String fileName = System.IO.Path.GetTempFileName();
            System.IO.File.WriteAllBytes(fileName, Properties.Resources.Chek);
            document = application.Documents.Open(fileName);
            document.Bookmarks["dateCheka"].Range.Text = DateTime.Now.ToShortDateString();
            document.Bookmarks["dateOrder"].Range.Text = order.Date.Value.ToShortDateString();
            document.Bookmarks["numberCheka"].Range.Text = (new Random()).Next(0, 100000).ToString();
            document.Bookmarks["numberOrder"].Range.Text = orderId.ToString("d7");
            var orderServices = _context.Orderservices.Include(x => x.IdServiceNavigation).Where(x => x.IdOrder == orderId).ToList();
            int EndCost = 0;
            for (int i = 2; i <= orderServices.Count() + 1; i++)
            {
                document.Tables[1].Rows[i].Cells[1].Range.Text = orderServices[i - 2].IdServiceNavigation.Name;
                document.Tables[1].Rows[i].Cells[2].Range.Text = orderServices[i - 2].IdServiceNavigation.Cost.ToString();
                EndCost += (int)orderServices[i - 2].IdServiceNavigation.Cost;
                if (i < orderServices.Count() + 1)
                {
                    Object oMissing = System.Reflection.Missing.Value;
                    document.Tables[1].Rows.Add(ref oMissing);
                }

            }
            document.Bookmarks["orderCost"].Range.Text = EndCost.ToString() + "руб.";
            var file = Path.GetTempFileName();
            document.SaveAs(file, WdSaveFormat.wdFormatPDF);
            document.Close();
            byte[] fileContent = System.IO.File.ReadAllBytes(file);
            return new FileContentResult(fileContent, "application/pdf");
        }
    }
}
