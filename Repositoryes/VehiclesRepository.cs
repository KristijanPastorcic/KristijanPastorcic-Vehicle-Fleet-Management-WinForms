using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Extensions;
using Vehicle_Fleet_Management.Helpers;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    class VehiclesRepository : IVehiclesRepository
    {
        private const string USP = "usp";
        private const string GET_VEHICLES = USP + nameof(GetVehicles);
        private const string DELETE_VEHICLE = USP + nameof(DeleteVehicle);
        private const string UPDATE_VEHICLE = USP + nameof(UpdateVehicle);
        private const string CREATE_VEHICLE = USP + nameof(CreateVehicle);
        private const string IMPORT_VEHICLES = USP + nameof(ImportVehicles);
        private readonly string VEHICLE = "@vehicle";

        private const string TYPE = "Type";
        private const string MANUFACTURER = "Manufacturer";
        private const string YEAR = "Year";
        private const string ID = "IDVehicle";
        private const string KILOMETERS = "Kilometers";


        private string cs { get; }

        public VehiclesRepository(string connectionString) => cs = connectionString;



        public bool CreateVehicle(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = CREATE_VEHICLE;
                    command.Parameters.Add(
                        new SqlParameter()
                        {
                            ParameterName = VEHICLE,
                            Value = vehicle.ModelToDataTable(),
                        });
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool DeleteVehicle(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = new SqlCommand() 
                { 
                    Connection = connection,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = DELETE_VEHICLE
                })
                {
                    command.Parameters.AddWithValue("@" + nameof(id), id);
                    connection.Open();
                    return command.ExecuteNonQuery() == 1;
                }
            }   
        }
        

        public IEnumerable<Vehicle> GetVehicles()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = GET_VEHICLES;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Vehicle()
                            {
                                IDVehicle = int.Parse(reader[ID].ToString()),
                                Type = reader[TYPE].ToString(),
                                Manufacturer = reader[MANUFACTURER].ToString(),
                                Year = (int)reader[YEAR],
                                Kilometers = (int)reader[KILOMETERS]
                            };
                        }
                    }
                }
            }
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = UPDATE_VEHICLE;
                    command.Parameters.Add(new SqlParameter()
                    {
                        ParameterName = VEHICLE,
                        Value = vehicle.ModelToDataTable(),
                    });
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public void ImportVehicles(IEnumerable<Vehicle> vehicles)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = XmlHelper.SetIdentityInsert(true, "Vehicles");
                    command.ExecuteNonQuery();
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = IMPORT_VEHICLES;
                    var table = vehicles.ToDataTable();
                        command.Parameters.Add(new SqlParameter()
                        {
                            ParameterName = VEHICLE,
                            Value = table,
                            TypeName = "dbo.VehicleModel"
                        });
                    command.ExecuteNonQuery();

                    command.CommandText = XmlHelper.SetIdentityInsert(false, "Vehicles");
                    command.CommandType = CommandType.Text;
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
