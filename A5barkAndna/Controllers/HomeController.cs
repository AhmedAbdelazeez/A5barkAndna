using A5barkAndna.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace A5barkAndna.Controllers
{
    public class HomeController : Controller
    {
        NewsContext db;
        public HomeController(NewsContext context)
        {
            db = context;

        }
        [HttpGet]
        public IActionResult Index()
        {
         var resualt =   db.categories.ToList();
            return View(resualt);
        }

        public IActionResult Messages()
        {
            
            return View(db.contacts.ToList());
        }

        public IActionResult News(int id)
        {
            Category c =db.categories.Find(id);

            ViewBag.cat=    c.Name;
          var result=  db.News.Where(x => x.categoryId == id).OrderByDescending(d=>d.Date).ToList();
            return View(result);
        }

        public IActionResult Delete(int id)
        {
            var news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "welcome to my page pro ";
            return View();
        }
      
        public IActionResult Contact()
        {
         
            return View();
        }

        [HttpPost]
        public IActionResult SaveContact(Contactus model)
        {
            db.contacts.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
