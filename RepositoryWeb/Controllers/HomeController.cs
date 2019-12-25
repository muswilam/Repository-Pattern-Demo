using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Core.Domain;
using Core;

namespace RepositoryWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController()
        {
            _unitOfWork = Factory.GetUnitOfWork;
        }

        public ActionResult Index()
        {
            var courses = _unitOfWork.Courses.GetAll();

            return View(courses);
        }

        [HttpPost]
        public ActionResult Add()
        {
            var course = new Course
            {
                Name = "New Course",
                Description = "No Descrition",
                FullPrice = 22,
                AuthorId = 6
            };

            _unitOfWork.Courses.Add(course);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}