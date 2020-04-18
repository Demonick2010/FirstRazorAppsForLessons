using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FirstRazorApp
{
    // Реализуем интерфейс IRouteConstraint
    public class EvenConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values,
            RouteDirection routeDirection)
        {
            // Объявляем переменную ID для сопоставления
            int id;

            // Пробуем распарсить значение словаря из строки в число
            if (Int32.TryParse(values["id"].ToString(), out id))
            {
                // Если получилось распарсить, то проверяем, чётное ли число
                if (id % 2 == 0)
                    // Если чётное, возвращаем true
                    return true;
            }
            // Иначе, возвращаем false
            return false;
        }
    }
}
