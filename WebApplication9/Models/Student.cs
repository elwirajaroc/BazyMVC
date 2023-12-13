using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public Guid AccountID { get; set; }
        public virtual ApplicationUser Account { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
    }
}