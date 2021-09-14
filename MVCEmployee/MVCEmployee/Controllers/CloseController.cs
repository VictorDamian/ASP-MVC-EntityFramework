using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Controllers
{
    public class CloseController : Controller
    {
        // GET: Close
        public ActionResult Close()
        {
            Session["USERS"] = null;
            return RedirectToAction("Index", "Login");
        }
    }
}