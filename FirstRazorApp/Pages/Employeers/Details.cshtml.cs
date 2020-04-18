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
        private readonly IEmpoyeeRepository _employeeRepository;

        public DetailsModel(IEmpoyeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public Employee Employee { get; private set; }

        // Теперь метод возвращает результат обработки, поэтому меняем тип с void на IActionResult
        public IActionResult OnGet(int id)
        {
            Employee = _employeeRepository.GetEmployee(id);

            // Добавляем проверку на null и делаем обработчик исключения
            if (Employee == null)
            {
                // Если модель пустая, то возвращаем в ответ на GET запрос страницу НЕ НАЙДЕНО
                return RedirectToPage("/NotFound");
            }
            // В противном случаи, возвращаем страницу
            return Page();
        }
    }
}