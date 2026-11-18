using Microsoft.AspNetCore.Mvc;
using NguyenVanTruong_241230874.Models;

namespace NguyenVanTruong_241230874.ViewComponents
{
    public class TheLoaiViewComponent : ViewComponent
    {
        private readonly QlnhaSachContext db;

        public TheLoaiViewComponent(QlnhaSachContext context)
        {
            db = context;
        }

        public IViewComponentResult Invoke()
        {
            var theLoai = db.TheLoais.ToList();
            return View(theLoai);
        }
    }
}
