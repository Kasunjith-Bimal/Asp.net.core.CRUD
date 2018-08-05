using Crudoperations.Interface;
using Crudoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crudoperations.baseServise
{
    public class DepartmentData : IDepartmentData
    {

        private readonly EmployeeDbContext _db;
        public DepartmentData(EmployeeDbContext db)
        {
            _db = db;
        }
        public List<Department> GetAllDepartmentList()
        {
            return _db.Departments.ToList();
        }
    }
}
