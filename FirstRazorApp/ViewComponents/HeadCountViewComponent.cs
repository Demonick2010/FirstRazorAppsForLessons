using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorApp.AppRepository;
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

        public IViewComponentResult Invoke()
        {
            var result = _empoyeeRepository.EmployeeCountByDept();
            return View(result);
        }
    }
}
