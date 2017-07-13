using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppFirst.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public string Index()
        {
            return "Hello World";
        }

        public string MVC()
        {
            return "This is done using MVC";
        }

        public ViewResult GetContent()
        {
            return View();
        }

    }
}
