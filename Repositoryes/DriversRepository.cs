using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Helpers;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    class DriversRepository : IDriversRepository
    {
        private const string INSERT_DRIVER = "insert into Drivers(Name, Surname, PhoneNumber, DriversLicenseNumber) values('{0}', '{1}', '{2}', '{3}'); ";
        private const string IMPORT_DRIVER = "insert into Drivers(IDDriver, Name ,Surname, PhoneNumber, DriversLicenseNumber, Deleted) values('{0}', '{1}', '{2}', '{3}', '{4}', {5}); ";
        private const string SELECT_DRIVERS = "select IDDriver, Name, Surname, PhoneNumber, DriversLicenseNumber from Drivers where Deleted = 0; ";
        private const string DELETE_DRIVER = "update Drivers set Deleted = 1 where IDDriver = {0}; ";
        private const string UPDATE_DRIVER = "update Drivers set Name = '{0}', SurName = '{1}', PhoneNumber = '{2}', DriversLicenseNumber = '{3}' where IDDriver = {4}; ";

        private const string ID = "IDDriver";
        private const string NAME = "Name";
        private const string SURNAME = "Surname";
        private const string PHONE_NUMBER = "PhoneNumber";
        private const string DRIVERS_LICENSE_NUMBER = "DriversLicenseNumber";


        private string cs { get; }
        public DriversRepository(string connectionString) => cs = connectionString;

        public bool CreateDriver(Driver driver)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText =
                        string.Format(
                            INSERT_DRIVER,
                    driver.Name, driver.Surname, driver.PhoneNumber, driver.DriversLicenseNumber);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public bool DeleteDriver(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = string.Format(DELETE_DRIVER, id);
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public IEnumerable<Driver> GetDrivers()
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = SELECT_DRIVERS;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return new Driver()
                            {
                                IDDriver = int.Parse(reader[ID].ToString()),
                                Name = reader[NAME].ToString(),
                                Surname = reader[SURNAME].ToString(),
                                PhoneNumber = reader[PHONE_NUMBER].ToString(),
                                DriversLicenseNumber = reader[DRIVERS_LICENSE_NUMBER].ToString()
                            };
                        }
                    }
                }
            }
        }

        public bool UpdateDriver(Driver driver)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = string.Format(UPDATE_DRIVER,
                        driver.Name, driver.Surname, driver.PhoneNumber, driver.DriversLicenseNumber, driver.IDDriver);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public void ImportDrivers(IEnumerable<Driver> drivers)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(XmlHelper.SetIdentityInsert(true, "Drivers"));
            drivers.ToList().ForEach(d =>
                sb.AppendLine(string.Format(IMPORT_DRIVER,
                d.IDDriver,
                d.Name,
                d.Surname,
                d.PhoneNumber,
                d.DriversLicenseNumber,
                d.Deleted.ToLower() == "true" ? 1 : 0))
            );
            sb.AppendLine(XmlHelper.SetIdentityInsert(false, "Drivers"));
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlCommand command = connection.CreateCommand())
                {
                    connection.Open();
                    command.CommandText = sb.ToString();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}

