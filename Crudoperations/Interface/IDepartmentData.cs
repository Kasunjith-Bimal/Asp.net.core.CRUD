using Crudoperations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Crudoperations.Interface
{
    public interface IDepartmentData
    {
        List<Department> GetAllDepartmentList();
    }
}
