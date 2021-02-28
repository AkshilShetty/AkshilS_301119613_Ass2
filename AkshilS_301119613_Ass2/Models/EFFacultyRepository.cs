using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkshilS_301119613_Ass2.Models
{
    public class EFFacultyRepository : IFacultyRepository
    {
        private ApplicationDbContext context;

        public EFFacultyRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Faculty> Faculties => context.Faculties4;
        public Faculty GetFaculty(int facultyId)
        {
            return context.Faculties4.FirstOrDefault(c => c.FacultyId == facultyId);
        }
        public IEnumerable<Faculty> GetFaculty()
        {
            IEnumerable<Faculty> faculty = context.Faculties4;
            return faculty;
        }
        public void SaveFaculty(Faculty faculty)
        {
            if (faculty.FacultyId == 0)
            {
                context.Faculties4.Add(faculty);
            }
            else
            {
                Faculty dbEntry = context.Faculties4.FirstOrDefault(f => f.FacultyId == faculty.FacultyId);
                if (dbEntry != null)
                {
                    dbEntry.Name = faculty.Name;
                    dbEntry.Department = faculty.Department;
                    dbEntry.Email = faculty.Email;
                    dbEntry.Phone = faculty.Phone;

                }
            }
            context.SaveChanges();
        }

        public Faculty DeleteFaculty(int facultyId)
        {
            Faculty dbEntry = context.Faculties4.FirstOrDefault(p => p.FacultyId == facultyId);
            if (dbEntry != null)
            {
                context.Faculties4.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
