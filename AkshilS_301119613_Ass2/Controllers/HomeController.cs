using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AkshilS_301119613_Ass2.Models;
using Microsoft.AspNetCore.Mvc;

namespace AkshilS_301119613_Ass2.Controllers
{
    public class HomeController : Controller
    {
       
        public ViewResult Index()
        {
            return View();
        }
    }   
}
