using MVCEmployee.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCEmployee.Models;
using MVCEmployee.Models.EmpModel;

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
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Add(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new PRACTICAMVCEntities())
            {
                EMPLOYEE oEmployee = new EMPLOYEE();
                oEmployee.NAME = model.Name;
                oEmployee.AGE = model.Age;
                oEmployee.MAIL = model.Email;
                oEmployee.POSITION = model.Position;

                db.EMPLOYEE.Add(oEmployee);
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Employee/"));
        }
    }
}