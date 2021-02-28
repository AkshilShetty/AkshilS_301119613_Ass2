using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace AkshilS_301119613_Ass2.Models
{
    public class Faculty
    {
        [Key] public int FacultyId { get; set; }
        
        public string Name { get; set; }
        
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Department { get; set; }
       
        public IEnumerable<Courses> Courses = new List<Courses>();


    }
}
