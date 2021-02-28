using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AkshilS_301119613_Ass2.Models;
namespace AkshilS_301119613_Ass2.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseRepository repository;

        public CoursesController(ICourseRepository courseRepo)
        {
            repository = courseRepo;
        }

        public ViewResult CoursesDisplay()
        {
            return View(repository.Courses);
        }

        public ViewResult Create() => View("AddCourses", new Courses());

        public ViewResult AddCourses(int courseId) => View(repository.Courses.FirstOrDefault(c => c.CourseId == courseId));

        [HttpPost]
        public IActionResult AddCourse(Courses course)
        {


            if (ModelState.IsValid)
            {
                repository.SaveCourse(course);
                TempData["message"] = $"{course.Name} has been saved";
                return RedirectToAction("Index");
            }
            else
            {

                return View(course);
            }

        }

        [HttpPost]
        public IActionResult Delete(int courseId)
        {
            Courses deletedCourse = repository.DeleteCourse(courseId);
            if (deletedCourse != null)
            {
                TempData["message"] = $"{deletedCourse.Name} was deleted";
            }
            return RedirectToAction("Index");
        }



    }
}
