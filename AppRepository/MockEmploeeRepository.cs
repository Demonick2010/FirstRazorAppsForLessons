﻿using System;
using System.Collections.Generic;
using System.Text;
using FirstRazorApp.Models;
using Models;

namespace AppRepository
{
    public class MockEmploeeRepository : IEmpoyeeRepository
    {
        private List<Employee> _peopleList;

        public MockEmploeeRepository()
        {
            _peopleList = new List<Employee>()
            {
                new Employee()
                    {Id = 0, Name = "Mary", Email = "example@example.com", PotoPath = "avatar2.png", Department = Dept.HR},
                new Employee()
                    {Id = 1, Name = "Mark", Email = "example1@example.com", PotoPath = "avatar.png", Department = Dept.IT},
                new Employee()
                    {Id = 2, Name = "Kolyan", Email = "demonick@example.com", PotoPath = "avatar4.png", Department = Dept.IT},
                new Employee()
                    {Id = 3, Name = "Shawn", Email = "example2@example.com", PotoPath = "avatar5.png", Department = Dept.Payroll},
                new Employee()
                    {Id = 4, Name = "Jeniffer", Email = "example3@example.com", PotoPath = "avatar3.png", Department = Dept.HR}
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _peopleList;
        }
    }
}