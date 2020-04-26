using System.Collections.Generic;
using FirstRazorApp.AppRepository;
using FirstRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorApp.Pages.Employeers
{
    public class IndexModel : PageModel
    {
        private readonly IEmpoyeeRepository employeeRepository;
        public IEnumerable<Employee> Employees { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IndexModel(IEmpoyeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        public void OnGet()
        {
            //Employees = employeeRepository.GetAllEmployees();
            Employees = employeeRepository.Search(SearchTerm);
        }
    }
}