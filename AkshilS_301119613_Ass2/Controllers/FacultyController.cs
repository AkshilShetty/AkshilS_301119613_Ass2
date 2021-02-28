using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AkshilS_301119613_Ass2.Models;

namespace AkshilS_301119613_Ass2.Controllers
{
    public class FacultyController : Controller
    {
        private IFacultyRepository facultyRepository;
        private ICourseRepository courseRepository;

        public FacultyController(IFacultyRepository repo, ICourseRepository repo2)
        {
            facultyRepository = repo;
            courseRepository = repo2;
        }
        public ViewResult FacultyList()
        {
            IEnumerable<Faculty> faculties = facultyRepository.GetFaculty();
            return View(faculties);
        }

        [HttpPost]
        public ViewResult AddFaculties(Faculty faculty)
        {
            facultyRepository.SaveFaculty(faculty);

            Courses course = courseRepository.GetCourse(faculty.Name);

            if (course != null)
            {
                course.FacultyName = faculty.Name;
                courseRepository.SaveCourse(course);
            }

            TempData["message"] = $"Faculty {faculty.Name} saved!";

            return View(faculty);
        }

        [HttpGet]
        public ViewResult AddFaculties(int facultyId)
        {
            Faculty faculty = facultyRepository.GetFaculty(facultyId);
            return View(faculty);
        }



        public ViewResult AddFaculties()
        {
            return View();
        }

        public ViewResult FacultiesDisplay()
        {
            return View();
        }

        [HttpGet]
        public ViewResult FacultiesDisplay(int facultyId)
        {
            Faculty faculty = facultyRepository.GetFaculty(facultyId);
            faculty.Courses = courseRepository.GetCourses(faculty.Name);

            return View(faculty);
        }

        public ViewResult AssignFaculties()
        {
            return View();
        }

    }
}
