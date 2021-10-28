using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Fleet_Management.Models
{
    public class Driver
    {


        public int IDDriver { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string DriversLicenseNumber { get; set; }
        public string Deleted { get; set; }

        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
