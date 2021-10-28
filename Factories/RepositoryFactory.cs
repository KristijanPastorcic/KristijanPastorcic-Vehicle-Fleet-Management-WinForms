using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Repositoryes;

namespace Vehicle_Fleet_Management.Factories
{
    static class RepositoryFactory
    {
        public static IDriversRepository GetDriversRepository(string connectionString)
            => new DriversRepository(connectionString);

        public static IVehiclesRepository GetVehiclesRepository(string connectionString)
            => new VehiclesRepository(connectionString);

        public static ITravelWarrentsRepository GetTravelWarrentsRepository(string connectionString)
            => new TravelWarrentsRepository(connectionString);

        public static IRoutesRepository GetRoutesRepository(string connectionString)
            => new RoutesRepository(connectionString);

        public static ITravelExpenceRepository GetTravelExpenceRepository(string connectionString)
            => new TravelExpenceRepository(connectionString);

        public static IItemsRepository GetItemsRepository(string connectionString)
            => new ItemsRepository(connectionString);
    }
}
