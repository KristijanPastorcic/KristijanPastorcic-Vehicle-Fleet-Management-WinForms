using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    interface ITravelExpenceRepository
    {
        IEnumerable<TravelExpence> GetTravelExpences();

        bool UpdateTravelExpence(TravelExpence expence);
        bool DeleteTravelExpence(int id);
        bool CreateTravelExpence(TravelExpence expence);
        void ImportTravelExpence(IEnumerable<TravelExpence> expences);
    }
}
