using MVCEmployee.Models.EmployeeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmployee.Models;

namespace MVCEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            List<Employee> employees = null;
            using (PRACTICAMVCEntities db = new PRACTICAMVCEntities())
            {
                employees = (from i in db.EMPLOYEE
                             orderby i.NAME
                             select new Employee
                              {
                                 name = i.NAME,
                                 age = i.AGE,
                                 email = i.MAIL,
                                 position = i.POSITION
                              }).ToList();
            }
                return View(employees);
        }
    }
}