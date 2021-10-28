using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Vehicle_Fleet_Management.Extensions;

namespace Vehicle_Fleet_Management.Models
{
    class Item
    {
        public Item() { }
        public int IDItem { get; set; }
        public string ProductName { get; set; }
        public int Amont { get; set; }

        [XmlIgnore]
        public System.Decimal ItemPrice { get; set; }




        [XmlElement("Price")]
        [SkipProperty]
        public string PriceString
        {
            get { return ItemPrice.ToString(); }
            set { this.ItemPrice = Decimal.Parse(value); }
        }
    }
}
