using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    interface IRoutesRepository
    {
        IEnumerable<Route> GetRoutes(int idWarrent);

        bool UpdateRoute(Route route);
        bool DeleteRoute(int id);
        bool CreateRoute(Route route);
        bool InsertRoutes(IEnumerable<Route> routes);
        bool ImportRoutes(IEnumerable<Route> routes);
        string GetRoutesXml(int id);
        void InsertRoutesXml(string fileName);
    }
}
