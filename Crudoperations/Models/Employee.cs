using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crudoperations.Models
{
   
    public class Employee
    {
        public int EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeAge { get; set; }

        public decimal EmployeeSalary { get; set; }

        public Department department;

        public int DepartmentId { get; set; }
    }
}
