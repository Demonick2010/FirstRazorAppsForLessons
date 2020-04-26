using System.Collections.Generic;
using FirstRazorApp.Models;

namespace FirstRazorApp.AppRepository
{
    public interface IEmpoyeeRepository
    {
        IEnumerable<Employee> Search(string searchTerm);
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployee(int id);
        Employee Update(Employee updatedEmployee);
        Employee Add(Employee newEmployee);
        Employee Delete(int id);

        // Подключаем свойство отслеживания количества
        IEnumerable<DeptHeadCount> EmployeeCountByDept(Dept? dept);
    }
}
