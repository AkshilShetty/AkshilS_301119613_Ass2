using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkshilS_301119613_Ass2.Models
{
    public interface IFacultyRepository
    {
        IQueryable<Faculty> Faculties { get; }

        void SaveFaculty(Faculty faculty);

        Faculty DeleteFaculty(int facultyId);
        Faculty GetFaculty(int facultyId);
        IEnumerable<Faculty> GetFaculty();



    }
}
