using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorApp.AppRepository;
using FirstRazorApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstRazorApp.ViewComponents
{
    public class HeadCountViewComponent : ViewComponent
    {
        private readonly IEmpoyeeRepository _empoyeeRepository;

        public HeadCountViewComponent(IEmpoyeeRepository empoyeeRepository)
        {
            _empoyeeRepository = empoyeeRepository;
        }

        public IViewComponentResult Invoke(Dept? department = null)
        {
            var result = _empoyeeRepository.EmployeeCountByDept(department);
            return View(result);
        }
    }
}
