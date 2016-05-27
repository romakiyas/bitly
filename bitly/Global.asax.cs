using bitly.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace bitly
{
    public class MvcApplication : System.Web.HttpApplication
    {
        const string COOKIE_NAME = "bitly";
        public const string SS_USER_ID = "userid";
        public const string BASE_DOMAIN = "http://test.the3dm.ru";

        // Алфавит объявим глобально для приложения, чтоюы не генерить его опри каждом запрсое
        public static UrlMinificator Minificator = new UrlMinificator(BASE_DOMAIN, new UrlPossibleAlphabet());


        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
           // ControllerBuilder.Current.SetControllerFactory(new BitlyControllerFactory());
        }

        protected void Session_Start()
        {
            /*  Пытаемся определить через Cookies пользвоателя,
                или создать/запомнить его, когда он заходит в первый раз */

            var cookies = Request.Cookies[COOKIE_NAME];

            using (var db = new bitContext())
            {
                User currUser = null;
                if (cookies != null)
                    currUser = db.Users.Where(x => x.guid == cookies.Value).FirstOrDefault();

                if (currUser == null)
                { 
                    currUser = new User(){ guid = Guid.NewGuid().ToString()};
                    db.Users.Add(currUser);
                    db.SaveChanges();

                    cookies = new HttpCookie(COOKIE_NAME, currUser.guid);
                    cookies.Expires = DateTime.Now.AddYears(1);
                }
                else
                    cookies.Expires = DateTime.Now.AddYears(1);

                Session[SS_USER_ID] = currUser.id;
                Response.Cookies.Add(cookies);
            }
        }
    }
}
