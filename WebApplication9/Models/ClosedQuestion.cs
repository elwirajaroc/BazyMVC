using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class ClosedQuestion
    {
        public int ClosedQuestionID { get; set; }   
        public int AdministratorID { get; set; }
        public int AccountID { get; set; }
        public virtual ICollection<Course> ManagedCourses { get; set; }
    }
}