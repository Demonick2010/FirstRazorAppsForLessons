using System;
using System.Collections.Generic;
using System.Text;
using FirstRazorApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstRazorApp.Services
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees {get; set;}
    }
}
