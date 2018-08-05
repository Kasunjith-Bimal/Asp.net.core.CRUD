using Crudoperations.Interface;
using Crudoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crudoperations.baseServise
{
    public class EmployeeData : IEmployeeData
    {
        private readonly EmployeeDbContext _db;
        public EmployeeData(EmployeeDbContext db)
        {
            _db = db;
        }
        public List<Employee> GetAllData()
        {
            List<Employee> EmployeeList = new List<Employee>();

            foreach (var item in _db.Employees.ToList())
            {
                Employee employeeobj = new Employee();

                employeeobj.EmployeeId = item.EmployeeId;
                employeeobj.EmployeeName = item.EmployeeName;
                employeeobj.EmployeeSalary = item.EmployeeSalary;
                employeeobj.EmployeeAge = item.EmployeeAge;
                int departmentId = item.DepartmentId;
                employeeobj.department = _db.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefault();

                EmployeeList.Add(employeeobj);

            }
                
                
                return EmployeeList;
        }

        public List<Employee> SearchByEmployeeName(string name)
        {
            return _db.Employees.Where(x => x.EmployeeName.Contains(name)).ToList();
        }

        public List<Employee> EmptyEmployeeList()
        {
            return null;
        }

        public void AddEmployee(Employee employee)
        {
            _db.Employees.Add(employee);
            _db.SaveChanges();
        }

        public Employee getEmployeeeByID(int id)
        {
            return _db.Employees.Where(x => x.EmployeeId.Equals(id)).FirstOrDefault();
        }

        public void updateEmployee(Employee employee)
        {
            _db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
        }

        public void deleteEmployee(Employee employee)
        {
            _db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();
        }

        public List<Employee> SearchByDepartmentName(string name)
        {
            List<Employee> EmployeeList = new List<Employee>();
            List<Employee> newEmployeeList = new List<Employee>();
            int departmentid =   _db.Departments.Where(x => x.DepartmentName == name).Select(x => x.DepartmentId).FirstOrDefault();

            if(departmentid != 0)
            {
                EmployeeList = _db.Employees.Where(x => x.DepartmentId.Equals(departmentid)).ToList();
            }

            foreach (var item in EmployeeList)
            {
                Employee employeeobj = new Employee();

                employeeobj.EmployeeId = item.EmployeeId;
                employeeobj.EmployeeName = item.EmployeeName;
                employeeobj.EmployeeSalary = item.EmployeeSalary;
                employeeobj.EmployeeAge = item.EmployeeAge;
                int departmentId = item.DepartmentId;
                employeeobj.department = _db.Departments.Where(x => x.DepartmentId == departmentId).FirstOrDefault();

                newEmployeeList.Add(employeeobj);

            }
            return newEmployeeList;
        }

        public List<Employee> SortByDesendingOrder(string SortOrder)
        {
            if(SortOrder == "name_desc")
            return _db.Employees.ToList().OrderByDescending(x => x.EmployeeName).ToList();
            else
           return _db.Employees.ToList().OrderBy(x => x.EmployeeName).ToList();
        }
    }
}
