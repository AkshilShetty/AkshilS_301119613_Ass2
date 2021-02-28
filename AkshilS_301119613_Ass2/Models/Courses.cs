using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AkshilS_301119613_Ass2.Models
{
    public class Courses
    {
        
       [Key] public int CourseId { get; set; }
        
        public string Name { get; set; }
        
       
        public string department { get; set; }
        public string degree { get; set; }
        public String FacultyName { get; set; }
    }
}
