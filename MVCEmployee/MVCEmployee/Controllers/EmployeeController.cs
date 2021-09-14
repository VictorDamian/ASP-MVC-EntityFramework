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
                                 id = i.IDEMP,
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
        // GET DATA
        public ActionResult Update(int id)
        {
            EmployeeModel model = new EmployeeModel();
            using (var db = new PRACTICAMVCEntities())
            {
                var oEmployee = db.EMPLOYEE.Find(id);
                model.Id = oEmployee.IDEMP;
                model.Name = oEmployee.NAME;
                model.Age = oEmployee.AGE;
                model.Email = oEmployee.MAIL;
                model.Position = oEmployee.POSITION;
            }

            return View(model);
        }
        [HttpPost]
        public ActionResult Update(EmployeeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            using (var db = new PRACTICAMVCEntities())
            {
                var oEmployee = db.EMPLOYEE.Find(model.Id);
                oEmployee.NAME = model.Name;
                oEmployee.AGE = model.Age;
                oEmployee.MAIL = model.Email;
                oEmployee.POSITION = model.Position;
                db.Entry(oEmployee).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return Redirect(Url.Content("~/Employee/"));
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            using (var db = new PRACTICAMVCEntities())
            {
                var ob = db.EMPLOYEE.Find(id);
                db.Entry(ob).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
            return Content("1");
        }
    }
}