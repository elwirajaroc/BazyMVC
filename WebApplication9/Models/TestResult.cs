using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class TestResult
    {
        public int TestResultID { get; set; }
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
        public int Score { get; set; }
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
        public int GroupID { get; set; }
        public virtual Group Group { get; set; }
    }
}