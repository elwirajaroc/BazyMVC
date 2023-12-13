using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        public int AccountID { get; set; }
        public string Content { get; set; }
        public DateTime Date_published { get; set; }
        public virtual ApplicationUser SenderAccount { get; set; }
    }
}