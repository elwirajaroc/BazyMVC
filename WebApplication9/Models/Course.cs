using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebApplication9.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Subject_name { get; set; }
        public string Description { get; set; }
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        //andministrator:
        public int AccountID { get; set; }
        public virtual ApplicationUser Acccount { get; set; }
        public DateTime Start_date { get; set; }
        public DateTime End_date { get; set; }
        public virtual ICollection<Group> Groups { get; set; }
    }
}