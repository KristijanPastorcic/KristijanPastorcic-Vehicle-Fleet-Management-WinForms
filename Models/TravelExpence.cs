using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicle_Fleet_Management.Models
{
    public class TravelExpence
    {
        public int IDTravelExpence { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int FK_TravelWarrents { get; set; }
        public int FK_Items { get; set; }
    }
}
