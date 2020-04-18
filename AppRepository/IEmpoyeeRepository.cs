using System.Collections.Generic;
using FirstRazorApp.Models;

namespace FirstRazorApp.AppRepository
{
    public interface IEmpoyeeRepository
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updatedEmployee);
    }
}
