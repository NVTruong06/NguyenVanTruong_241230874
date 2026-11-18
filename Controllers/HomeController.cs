using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NguyenVanTruong_241230874.Models;
using System.Diagnostics;

namespace NguyenVanTruong_241230874.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlnhaSachContext db;
        public HomeController(QlnhaSachContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var sach = db.Saches.Where(s => s.Gia != null && s.Gia >= 100).ToList();
            return View(sach);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Sach sach)
        {
            if(ModelState.IsValid)
            {
                db.Saches.Add(sach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(db.TheLoais, "MaTl", "TenTl", sach.MaTl);
            return View(sach);
        }
    }
}
