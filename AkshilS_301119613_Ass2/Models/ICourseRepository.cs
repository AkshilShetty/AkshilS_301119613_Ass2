using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkshilS_301119613_Ass2.Models
{
    public interface ICourseRepository
    {
        ////void AddCourse(Course course);
        //IEnumerable<Course> GetCourses();
        //IEnumerable<Course> GetCourses(string facultyName);
        //Course GetCourse(string courseName);
        //void AddCourse(Course course);

        //IQueryable<Course> Courses { get; }

        //void SaveCourse(Course course);
        //Course DeleteCourse(int courseId);
        //Course GetCourse(int courseId);


        IQueryable<Courses> Courses { get; }

        void SaveCourse(Courses course);

        Courses DeleteCourse(int courseId);
        Courses GetCourse(string courseName);
        IEnumerable<Courses> GetCourses(string courseName);







    }
}
