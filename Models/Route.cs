using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vehicle_Fleet_Management.Extensions;

namespace Vehicle_Fleet_Management.Models
{
    public class Route
    {


        public int IDRoute { get; set; }
        [XmlIgnore]
        public DateTime StartDate { get; set; }
        [XmlIgnore]
        public DateTime EndDate { get; set; }
        [XmlElement("StartDate")]
        [SkipProperty]
        public string StartDateString
        {
            get { return this.StartDate.ToString(); }
            set { this.StartDate = DateTime.Parse(value); }
        }
        [XmlElement("EndDate")]
        [SkipProperty]
        public string EndDateString
        {
            get { return EndDate.ToString(); }
            set { this.EndDate = DateTime.Parse(value); }
        }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int Distance { get; set; }
        public Double FuelSpent { get; set; }
        public int FK_TravelWarrents { get; set; }



        public override string ToString()
        {
            return $"{StartLocation}-{EndLocation}";
        }
    }
}
