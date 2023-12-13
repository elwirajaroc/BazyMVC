using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class Teacher
    {
        public int TeacherID { get; set; }
        public Guid AccountID { get; set; }
        public virtual ICollection<Course> TaughtCourses { get; set; }
        public virtual ICollection<TestResult> TestResults { get; set; }
    }
}