using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudOnSingleView.Models
{
    public class EmployeeDTO
    {
        public Employee EmployeeData { get; set; }
        public List<Employee> EmployeeList { get; set; }
    }
}