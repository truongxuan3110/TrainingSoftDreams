using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class Student
    {
        public Student() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public Class classroom { get; set; }
    }
}
