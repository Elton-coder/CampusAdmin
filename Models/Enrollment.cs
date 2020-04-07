using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusAdmin.Models
{
    public class Enrollment
    {
        public enum Grade
        {
            A, B, C, D, F
        }

        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? grade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }


    }
}
