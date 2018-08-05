using Crudoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crudoperations.Interface
{
    public interface IEmployeeData
    {
        List<Employee> GetAllData();

        List<Employee> SearchByEmployeeName(string name);

        List<Employee> SearchByDepartmentName(string name);

        List<Employee> EmptyEmployeeList();

        void AddEmployee(Employee employee);

        Employee getEmployeeeByID(int id);

        void updateEmployee(Employee employee);

        void deleteEmployee(Employee employee);

        List<Employee> SortByDesendingOrder(string SortOrder);

    }
}
