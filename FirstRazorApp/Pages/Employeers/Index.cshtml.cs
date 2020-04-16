using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Models;

namespace FirstRazorApp.Pages.Employeers
{
    public class IndexModel : PageModel
    {
        private readonly IEmpoyeeRepository employeeRepository;
        public IEnumerable<Employee> Employees { get; set; }
        public IndexModel(IEmpoyeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        public void OnGet()
        {
            Employees = employeeRepository.GetAllEmployees();
        }
    }
}