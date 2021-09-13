using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Access(string user, string pass)
        {
            try
            {
                return Content("1");
            }
            catch(Exception e)
            {
                return Content("Error al entrar al sistema" + e.Message);
            }
        }
    }
}