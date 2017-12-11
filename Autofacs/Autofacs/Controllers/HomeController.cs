using Autofacs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Autofacs.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentQuery repository;

        public HomeController(IStudentQuery repository)
        {
            this.repository = repository;
        }

        // GET: Home
        public ActionResult Index()
        {
            var data = repository.FindStudents();
            return View(data);
        }
    }
}