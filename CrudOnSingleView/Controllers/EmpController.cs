using CrudOnSingleView.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudOnSingleView.Controllers
{
    public class EmpController : Controller
    {
        DataContext _db = new DataContext();

        // GET: Emp

        [HttpGet]
        public ActionResult CreateUpdateEmp()
        {
            var empdata = new EmployeeDTO()
            {
                EmployeeList = _db.Employees.ToList()
            };
            return View(empdata);
        }

        [HttpPost]
        public ActionResult CreateUpdateEmp(EmployeeDTO employee)
        {

            _db.Employees.Add(employee.EmployeeData);
            _db.SaveChanges();
            return RedirectToAction("CreateUpdateEmp");
        }

    }
}