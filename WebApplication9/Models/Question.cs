using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication9.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string Question_text { get; set; }
        public int Points { get; set; }
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
    }
}