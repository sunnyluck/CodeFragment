using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationTest.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult GetView()
        {
            return View("MyView");
        }

        public string GetString()
        {
            return "Hello World is old now. It’s time for wassup bro ;)";
        }
    }
}