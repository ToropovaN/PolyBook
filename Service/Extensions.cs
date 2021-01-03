using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace PolyBook.Service
{
    public static class Extensions
    {
        public static string CutController(this string str) 
        {
            return str.Replace("Controller", "");
        }
    }
}
