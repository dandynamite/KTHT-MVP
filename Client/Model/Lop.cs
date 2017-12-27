using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Model
{
    class Lop
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public ICollection<Student> student { get; set; }
    }
}
