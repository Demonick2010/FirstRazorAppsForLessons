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

        [BindProperty]
        public Employee Employee { get; set; }

        [BindProperty] 
        public IFormFile Photo { get; set; }

        [BindProperty] 
        public bool Notify { get; set; }

        public string Message { get; set; }

        public IActionResult OnGet(int id)
        {
            Employee = _empoyeeRepository.GetEmployee(id);

            if (Employee == null)
            {
                return RedirectToPage("/NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            // Проверяем модель на валидность
            if (ModelState.IsValid)
            {
                // Сохраняем изображение
                if (Photo != null)
                {
                    if (Employee.PotoPath != null)
                    {
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", Employee.PotoPath);

                        if (Employee.PotoPath != "noimage.png")
                            System.IO.File.Delete(filePath);
                    }

                    Employee.PotoPath = ProcessUploadedFile();
                }

                // Обноляем данные в базе
                Employee = _empoyeeRepository.Update(Employee);

                // Записываем сообщение в TemData
                TempData["SuccessMessage"] = $"Update {Employee.Name} success!";

                // Возвращаем представление Index
                return RedirectToPage("/Employeers/Index");
            }

            return Page();
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

        // Создаём метод обработки формы уведомлений
        public void OnPostUpdateNotificationPreferences(int id)
        {
            if (Notify)
            {
                Message = "Thank you for turning on notifications";
            }
            else
            {
                Message = "You have turned off email notifications";
            }

            Employee = _empoyeeRepository.GetEmployee(id);
        }
    }
}