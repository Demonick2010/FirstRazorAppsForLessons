using System.ComponentModel.DataAnnotations;

namespace FirstRazorApp.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name property is required! Type this!"), MinLength(3, ErrorMessage = "Name should contain at least 3 characters")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }
        public string PotoPath { get; set; }
        [Required]
        public Dept? Department { get; set; }
    }
}
