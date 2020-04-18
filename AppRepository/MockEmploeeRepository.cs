using System.Collections.Generic;
using System.Linq;
using FirstRazorApp.Models;

namespace FirstRazorApp.AppRepository
{
    public class MockEmploeeRepository : IEmpoyeeRepository
    {
        private List<Employee> _peopleList;

        public MockEmploeeRepository()
        {
            _peopleList = new List<Employee>()
            {
                new Employee()
                    {Id = 0, Name = "Mary", Email = "example@example.com", PotoPath = "avatar2.png", Department = Dept.Hr},
                new Employee()
                    {Id = 1, Name = "Mark", Email = "example1@example.com", PotoPath = "avatar.png", Department = Dept.It},
                new Employee()
                    {Id = 2, Name = "Kolyan", Email = "demonick@example.com", PotoPath = "avatar4.png", Department = Dept.It},
                new Employee()
                    {Id = 3, Name = "Shawn", Email = "example2@example.com", PotoPath = "avatar5.png", Department = Dept.Payroll},
                new Employee()
                    {Id = 4, Name = "Jeniffer", Email = "example3@example.com", PotoPath = "avatar3.png", Department = Dept.Hr},
                new Employee()
                    {Id = 5, Name = "Sten", Email = "example4@example.com", Department = Dept.Payroll}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _peopleList;
        }

        public Employee GetEmployee(int id)
        {
            return _peopleList.FirstOrDefault(x => x.Id == id);
        }
    }
}
