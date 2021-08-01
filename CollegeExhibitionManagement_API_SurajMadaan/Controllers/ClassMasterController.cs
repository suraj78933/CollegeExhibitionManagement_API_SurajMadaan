using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CollegeExhibitionManagement_API_SurajMadaan.Controllers
{
    public class ClassMasterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
