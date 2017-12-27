using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVP.Models
{
    public class Lop
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Student> student {get;set;}
    }
}