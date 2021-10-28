using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Fleet_Management.Models
{
    public class Vehicle
    {


        public int IDVehicle { get; set; }
        public string Type { get; set; }
        public string Manufacturer { get; set; }
        public int Year { get; set; }
        public int Kilometers { get; set; }

        public override string ToString() => $"{Type}, {Manufacturer}";
    }
}
