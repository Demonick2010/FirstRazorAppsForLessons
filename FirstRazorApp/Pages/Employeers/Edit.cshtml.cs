using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FirstRazorApp.AppRepository;
using FirstRazorApp.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FirstRazorApp.Pages.Employeers
{
    public class EditModel : PageModel
    {
        private readonly IEmpoyeeRepository _empoyeeRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Подключаем наш репозиторий данных
        public EditModel(IEmpoyeeRepository empoyeeRepository, IWebHostEnvironment webHostEnvironment )
        {
            _empoyeeRepository = empoyeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public Employee Employee { get; set; }

        [BindProperty] 
        public IFormFile Photo { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _empoyeeRepository.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost(Employee employee)
        {
            // Сохраняем изображение
            if (Photo != null)
            {
                if (employee.PotoPath != null)
                {
                    string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", employee.PotoPath);

                    if (employee.PotoPath != "noimage.png")
                        System.IO.File.Delete(filePath);
                }
                employee.PotoPath = ProcessUploadedFile();
            }

            // Обноляем данные в базе
            Employee = _empoyeeRepository.Update(employee);

            // Записываем сообщение в TemData
            TempData["SuccessMessage"] = $"Update {employee.Name} success!";

            // Возвращаем представление Index
            return RedirectToPage("/Employeers/Index");
        }

        // Создаём метод обработки загруженных изображений
        private string ProcessUploadedFile()
        {
            string uniqueFileName = null;

            if (Photo != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}