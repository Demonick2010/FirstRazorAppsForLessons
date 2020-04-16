using System;
using System.Collections;
using System.Collections.Generic;
using Models;

namespace AppRepository
{
    public interface IEmpoyeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
