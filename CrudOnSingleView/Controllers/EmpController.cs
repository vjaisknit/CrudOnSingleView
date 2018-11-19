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
            if(employee.EmployeeData.EmployeeId==0)
            {
                _db.Employees.Add(employee.EmployeeData);
                _db.SaveChanges();
            }
            else
            {
              var dataInDb=  _db.Employees.FirstOrDefault(a => a.EmployeeId == employee.EmployeeData.EmployeeId);
                dataInDb.Name = employee.EmployeeData.Name;
                dataInDb.Email = employee.EmployeeData.Email;
                _db.SaveChanges();
            }
            
            return RedirectToAction("CreateUpdateEmp");
        }

        public ActionResult Delete(int id)
        {
          var dataForDelete=  _db.Employees.FirstOrDefault(a => a.EmployeeId == id);
            _db.Employees.Remove(dataForDelete);
            _db.SaveChanges();
            return RedirectToAction("CreateUpdateEmp");
        }

        public ActionResult Edit(int id)
        {
            var empdata = new EmployeeDTO()
            {
                EmployeeList = _db.Employees.ToList(),
                EmployeeData= _db.Employees.FirstOrDefault(a => a.EmployeeId == id)
            };

            return View("CreateUpdateEmp", empdata);
        }

    }
}