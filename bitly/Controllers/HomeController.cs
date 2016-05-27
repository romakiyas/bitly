using bitly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;



namespace bitly.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.MenuState = new MenuState()
            {
                title = "Мои ссылки",
                controller = "home",
                action = "storage"
            };
            return View();
        }

        public ActionResult Storage()
        {
            ViewBag.MenuState = new MenuState()
            {
                title = "На главную",
                controller = "home",
                action = "index"
            };

            using (var db = new bitContext())
            {
                var me = db.Users.Find(Session.currentUserID());
                if (me!=null)
                    return View(me.urls);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Minify(String url)
        {
            using (var db = new bitContext())
            {
                BitUrl nUrl = new BitUrl()
                {
                    appendDate = DateTime.Now,
                    author = db.Users.Find(Session.currentUserID()),
                    longUrl = url.Trim()
                };
                db.Urls.Add(nUrl);
                db.SaveChanges();
                return PartialView("~/Views/Home/_UrlResult.cshtml", nUrl);
            }
        }

        public ActionResult Remove(int id)
        {
            using (var db = new bitContext())
            {
                var me = db.Users.Find(Session.currentUserID());
                if (me != null)
                {
                    var u = me.urls.Where(x=>x.id==id).FirstOrDefault();
                    if (u != null)
                    {
                        db.Urls.Remove(u);
                        db.SaveChanges();
                    }
                }
            }
            return new EmptyResult();
        }



        public ActionResult Click(string urlId)
        {
            using (var db = new bitContext())
            {
                long id = MvcApplication.Minificator.Maxify(urlId);
                BitUrl bu = db.Urls.Find(id);
                if (bu != null)
                {
                    bu.clicks++;
                    db.SaveChanges();
                    return new RedirectResult(bu.longUrl);
                }
            }

            return RedirectToAction("Notfound");
        }


        public ActionResult Notfound()
        {
            return View();
        }


    }
}