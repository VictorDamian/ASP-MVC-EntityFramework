using MVCEmployee.Controllers;
using MVCEmployee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEmployee.Filters
{
    public class VerifySession:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var objUser = (USERS)HttpContext.Current.Session["USERS"];
            if(objUser == null)
            {
                if (filterContext.Controller is LoginController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Login/Index");
                }
            }
            else
            {
                if (filterContext.Controller is LoginController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}