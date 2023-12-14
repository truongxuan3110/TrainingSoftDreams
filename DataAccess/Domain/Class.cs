using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Domain
{
    public class Class
    {
        public Class() { }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public Teacher teacher { get; set; }
    }
}
