using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkshilS_301119613_Ass2.Models
{
    public class EFCourseRepository:ICourseRepository
    {
        private ApplicationDbContext context;

        public EFCourseRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Courses> Courses => context.Course4;
        public Courses GetCourse(string courseName)
        {
            return context.Course4.FirstOrDefault(p => p.Name == courseName);
        }

        public IEnumerable<Courses> GetCourses(string courseName)
        {
            return context.Course4.Where(p => p.Name == courseName);
        }
        public void SaveCourse(Courses course)
        {
            if (course.CourseId == 0)
            {
                context.Course4.Add(course);
            }
            else
            {
                Courses dbEntry = context.Course4.FirstOrDefault(c => c.CourseId == course.CourseId);
                if (dbEntry != null)
                {
                    dbEntry.Name = course.Name;
                    dbEntry.degree= course.degree;
                    dbEntry.department = course.department;
                }
            }
            context.SaveChanges();
        }

        public Courses DeleteCourse(int courseId)
        {
            Courses dbEntry = context.Course4.FirstOrDefault(c => c.CourseId == courseId);
            if (dbEntry != null)
            {
                context.Course4.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}

