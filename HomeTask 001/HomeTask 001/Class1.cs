using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask_001
{
    internal class User
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string  Gender { get; set; }
        public string FatherName { get; set; }
        public string Country {  get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string Birthday { get; set; }

        

        public override string ToString() => $"{Name},{Surname},{FatherName}{Country}{City}{PhoneNumber}{Birthday}{Gender}";






    }
}
