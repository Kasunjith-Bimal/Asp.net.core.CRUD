using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crudoperations.Interface;
using Crudoperations.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Crudoperations.Controllers
{
    public class EmployeeController : Controller
    {
        public IEmployeeData _employeeData;

        public IDepartmentData _departmentData;

        public EmployeeController(IEmployeeData employeeData, IDepartmentData departmentData)
        {
            _employeeData = employeeData;
            _departmentData = departmentData;
        }
        // GET: /<controller>/
        public IActionResult Index(string sortOrder)
        {
            string EmployeeNameSort = "";

            if (string.IsNullOrEmpty(sortOrder))
            {
                EmployeeNameSort = "";
            }
            else
            {
                EmployeeNameSort = "name_desc";
              
            }
            if(EmployeeNameSort != null)
            {
                return View(_employeeData.SortByDesendingOrder(sortOrder));
              

            }
            else
           return View(_employeeData.GetAllData());

        }
        [HttpPost]
        public IActionResult Index(string Search,string SearchOptions)
        {
            if(Search != "" && SearchOptions != "")
            {
                if (SearchOptions == "EmployeeName")
                    return View(_employeeData.SearchByEmployeeName(Search));
                else
                    return View(_employeeData.SearchByDepartmentName(Search));
            }
            else
            {
                return View(_employeeData.EmptyEmployeeList());
            } 
        }
        [HttpGet]
        public IActionResult Create()
        {
            List<Department> ListDepartment = new List<Department>();

            ListDepartment = _departmentData.GetAllDepartmentList();

            ViewBag.DepartmentListData = ListDepartment;
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("EmployeeId,EmployeeName,EmployeeAge,EmployeeSalary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeData.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            List<Department> ListDepartment = new List<Department>();

            ListDepartment = _departmentData.GetAllDepartmentList();

            ViewBag.DepartmentListData = ListDepartment;
            Employee employee = _employeeData.getEmployeeeByID(id);
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit([Bind("EmployeeId,EmployeeName,EmployeeAge,EmployeeSalary,DepartmentId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeData.updateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee employee = _employeeData.getEmployeeeByID(id);
            return View(employee);

        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteForm(int id)
        {
            Employee employeeobj = _employeeData.getEmployeeeByID(id);
            _employeeData.deleteEmployee(employeeobj);
            return RedirectToAction("Index");
        }
    }
}
