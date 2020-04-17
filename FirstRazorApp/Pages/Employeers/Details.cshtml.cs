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
    public class DetailsModel : PageModel
    {
        private readonly IEmpoyeeRepository _empoyeeRepository;

        public DetailsModel(IEmpoyeeRepository empoyeeRepository)
        {
            _empoyeeRepository = empoyeeRepository;
        }

        public Employee Employee { get; private set; }
        public void OnGet(int id)
        {
            Employee = _empoyeeRepository.GetEmployee(id);
        }
    }
}