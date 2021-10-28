using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml;
using Vehicle_Fleet_Management.Extensions;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Helpers
{
    static class XmlHelper
    {
        private const string GET_DATABASE = "GetDataBase";
        private const string CLEAN_DB = "uspCleanDb";
        private const string VEHICLE_MANAGEMENT_DB = "VehicleManagementDB";
        private const string SELECT_TABLE_NAMES = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='VehicleFleetManagement'";
        private static readonly string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public static bool CreateBackupXml(string file)
        {
            using (DataSet db = SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, GET_DATABASE))
            {
                using (XmlWriter writer = CreateWriter(file))
                {
                    writer.WriteStartDocument();
                    writer.WriteStartElement(VEHICLE_MANAGEMENT_DB);
                    foreach (DataTable table in db.Tables)
                    {
                        writer.WriteStartElement(table.Columns[0].ColumnName.Substring(2) + "s");
                        foreach (DataRow row in table.Rows)
                        {
                            writer.WriteStartElement(table.Columns[0].ColumnName.Substring(2));
                            for (int i = 0; i < table.Columns.Count; i++)
                            {
                                writer.WriteElementString(table.Columns[i].ColumnName, row[i].ToString());
                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                }
                return true;
            }
        }

        private static XmlWriter CreateWriter(string file)
        {
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true
            };
            return XmlWriter.Create(file, settings);
        }

        public static bool RestoreDbFromXml(string file)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(cs, CommandType.Text, "EXEC sp_msforeachtable 'ALTER TABLE ? NOCHECK CONSTRAINT all'");
                    SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure, CLEAN_DB);
                    XmlDocument document = LoadDocument(file);

                    XmlElement root = document.DocumentElement;
                    root.ChildNodes.Cast<XmlNode>().ToList()
                        .ForEach(node => InsertXmlDataToTable(node));
                    SqlHelper.ExecuteNonQuery(cs, CommandType.Text, "EXEC sp_msforeachtable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT all'");
                    transaction.Complete();
                    return true;
                }
                catch (Exception)
                {
                    transaction.Dispose();
                    throw;
                }
            }
        }

        private static void InsertXmlDataToTable(XmlNode node)
        {
            if (!node.HasChildNodes) return;
            switch (node.Name)
            {
                case "Drivers":
                    IEnumerable<Driver> drivers = node.ChildNodes.XmlNodeListToEnumerableModel<Driver>();
                    Factories.RepositoryFactory.GetDriversRepository(cs).ImportDrivers(drivers);
                    break;
                case "Vehicles":
                    IEnumerable<Vehicle> vehicles = node.ChildNodes.XmlNodeListToEnumerableModel<Vehicle>();
                    Factories.RepositoryFactory.GetVehiclesRepository(cs).ImportVehicles(vehicles);
                    break;
                case "Routes":
                    IEnumerable<Route> routes = node.ChildNodes.XmlNodeListToEnumerableModel<Route>();
                    Factories.RepositoryFactory.GetRoutesRepository(cs).ImportRoutes(routes);
                    break;
                case "TravelWarrents":
                    IEnumerable<TravelWarrent> warrents = node.ChildNodes.XmlNodeListToEnumerableModel<TravelWarrent>();
                    Factories.RepositoryFactory.GetTravelWarrentsRepository(cs).ImportWarrents(warrents);
                    break;
                case "TravelWarrantStates":
                    IEnumerable<TravelWarrantState> states = node.ChildNodes.XmlNodeListToEnumerableModel<TravelWarrantState>();
                    TravelWarrantState.ImportTravelWarrentStates(states);
                    break;
                case "TravelExpences":
                    IEnumerable<TravelExpence> expences = node.ChildNodes.XmlNodeListToEnumerableModel<TravelExpence>();
                    Factories.RepositoryFactory.GetTravelExpenceRepository(cs).ImportTravelExpence(expences);
                    break;
                case "Items":
                    IEnumerable<Item> items = node.ChildNodes.XmlNodeListToEnumerableModel<Item>();
                    Factories.RepositoryFactory.GetItemsRepository(cs).ImportItems(items);
                    break;
                case "VehicleServices":
                    //entitiy
                    IEnumerable<VehicleService> services = node.ChildNodes.XmlNodeListToEnumerableModel<VehicleService>();
                    using (var db = new Repositoryes.entity.VehicleFleetManagementEntities())
                    {
                        foreach (var service in services)
                        {
                            db.VehicleServices.Add(new Repositoryes.entity.VehicleService()
                            {
                                IDVehicleService = service.IDVehicleService,
                                Description = service.Description,
                                Date = service.Date,
                                Price = service.Price,
                                FK_Vehicles = service.FK_Vehicles
                            });
                        }
                        db.SaveChanges();
                    }
                    break;
                default:
                    break;
            }
        }

        public static string SetIdentityInsert(bool state, string table)
        {
            string sss = state ? "on" : "off";
            string sql = $"SET IDENTITY_INSERT {table} {sss}; ";
            return sql;
        }

        private static XmlDocument LoadDocument(string file)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            return doc;
        }
    }
}
