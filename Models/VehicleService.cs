using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vehicle_Fleet_Management.Extensions;

namespace Vehicle_Fleet_Management.Models
{
    public class VehicleService
    {

        public int IDVehicleService { get; set; }
        public string Description { get; set; }

        [XmlIgnore]
        public DateTime Date { get; set; }

        [XmlElement("Date")]
        [SkipProperty]
        public string DateString
        {
            get { return Date.ToString(); }
            set { this.Date = DateTime.Parse(value); }
        }

        [XmlIgnore]
        public Decimal Price { get; set; }

        [XmlElement("Price")]
        [SkipProperty]
        public string PriceString
        {
            get { return Price.ToString(); }
            set { this.Price = Decimal.Parse(value); }
        }

        public int FK_Vehicles { get; set; }
    }
}
