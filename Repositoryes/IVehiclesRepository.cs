using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    interface IVehiclesRepository
    {
        IEnumerable<Vehicle> GetVehicles();
        bool CreateVehicle(Vehicle vehicle);
        bool UpdateVehicle(Vehicle vehicle);
        bool DeleteVehicle(int id);
        void ImportVehicles(IEnumerable<Vehicle> vehicles);
    }
}
