using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmployee.Models;

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
                using (PRACTICAMVCEntities db = new PRACTICAMVCEntities())
                {
                    var lst = from i in db.USERS
                              where i.USERNAME == user && i.PASSWORD == pass && i.IDSTATE == 1
                              orderby i.USERNAME
                              select i;
                    if (lst.Count() > 0)
                    {
                        USERS objUser = lst.First();
                        Session["USERS"] = objUser;
                        return Content("1");
                    }
                    else
                    {
                        return Content("Ha ocurrido un error...");
                    }
                }
                
            }
            catch(Exception e)
            {
                return Content("Error al entrar al sistema" + e.Message);
            }
        }
    }
}