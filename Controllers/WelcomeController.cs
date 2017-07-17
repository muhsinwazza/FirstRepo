using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppFirst.Controllers
{
    public class WelcomeController : Controller
    {
        //
        // GET: /Welcome/

        public string Index()
        {
            return "<h3>Welcome</h3>";
        }

        public string WithParam(string name, int times = 1)
        {
            return "Name : " + name + " Times : " + times.ToString();
        }

    }
}
