using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorApp.AppRepository;
using FirstRazorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorApp.Pages.Employeers
{
    public class DeleteModel : PageModel
    {
        private readonly IEmpoyeeRepository _employeeRepository;

        public DeleteModel(IEmpoyeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [BindProperty] 
        public Employee Employee { get; set; }


        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            if (Employee == null)
                return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            Employee deletedEmployee = _employeeRepository.Delete(Employee.Id);

            if (deletedEmployee == null)
                return RedirectToPage("/NotFound");

            return RedirectToPage("Index");
        }
    }
}