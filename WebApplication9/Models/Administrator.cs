using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class Administrator
    {
        public int AdministratorID { get; set; }
        public Guid AccountID { get; set; }
        public virtual ICollection<Course> ManagedCourses { get; set; }
    }
}