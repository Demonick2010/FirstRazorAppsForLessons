using System;
using FirstRazorApp.Models;

namespace Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
