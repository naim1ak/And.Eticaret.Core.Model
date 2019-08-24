using And.Eticaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace And.Eticaret.UI.WEB.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult GetMenu()
        {
            var db = new AndDB();
            var menus = db.Categories.Where(x => x.ParentID == 0).ToList();
            return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]
        public ActionResult Login(string Email, string Password)
        {
            var db = new AndDB();
            var users = db.Users.Where(x => x.Email == Email
            && x.Password == Password
            && x.IsActive == true
            && x.IsAdmin == false).ToList();
            if (users.Count == 1)
            {
                //giriş ok
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Hatalı Kullanıcı veya Şifre!!!";
                return View();
            }

        }
    }
}