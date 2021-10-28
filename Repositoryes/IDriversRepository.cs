using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    interface IDriversRepository
    {
        IEnumerable<Driver> GetDrivers();

        bool UpdateDriver(Driver driver);
        bool DeleteDriver(int id);
        bool CreateDriver(Driver driver);
        void ImportDrivers(IEnumerable<Driver> drivers);
    }
}
