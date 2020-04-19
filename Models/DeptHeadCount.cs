using System;
using System.Collections.Generic;
using System.Text;

namespace FirstRazorApp.Models
{
    public class DeptHeadCount
    {
        // Первое свойство департамента
        public Dept Department { get; set; }
        // Второе свойство - счётчик
        public int Count { get; set; }
    }
}
