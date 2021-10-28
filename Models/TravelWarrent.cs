using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vehicle_Fleet_Management.Extensions;

namespace Vehicle_Fleet_Management.Models
{
    public class TravelWarrent
    {


        public int IDTravelWarrent { get; set; }
        public string RouteDescription { get; set; }

        [XmlIgnore]
        public DateTime DateCreated { get; set; }

        [XmlElement("DateCreated")]
        [SkipProperty]
        public string Date
        {
            get { return this.DateCreated.ToString(); }
            set { this.DateCreated = DateTime.Parse(value); }
        }
        public int FK_Drivers { get; set; }
        public int FK_Vehicles { get; set; }
        public int FK_TravelWarrantStates { get; set; }

        public override string ToString()
        {
            return DateCreated + ": " + RouteDescription;
        }
    }
}
