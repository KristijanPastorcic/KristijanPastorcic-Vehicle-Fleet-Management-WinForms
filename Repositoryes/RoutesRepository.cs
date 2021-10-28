using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Vehicle_Fleet_Management.Extensions;
using Vehicle_Fleet_Management.Helpers;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    class RoutesRepository : IRoutesRepository
    {
        private const string USP = "usp";
        private const string ROUTES = "Routes";
        //uspInsertRoutes is used for crateing 1 rout and many routes

        private string cs { get; set; }

        public RoutesRepository(string connectionString) => this.cs = connectionString;

        public bool CreateRoute(Route route)
        {
            SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure, USP + nameof(InsertRoutes),
                new SqlParameter() { ParameterName = "@" + nameof(route), Value = route.ModelToDataTable() });
            return true;
        }

        public bool DeleteRoute(int id)
        {
            SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure, USP + nameof(DeleteRoute),
                new SqlParameter() { ParameterName = "@" + nameof(id), Value = id });
            return true;
        }

        public IEnumerable<Route> GetRoutes()
        {
            return
            SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, USP + nameof(GetRoutes))
                .Tables[ROUTES].TableToEnumerableModel<Route>();
        }

        public bool InsertRoutes(IEnumerable<Route> routes)
        {
            SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure, USP + nameof(InsertRoutes),
                new SqlParameter() { ParameterName = "@route", Value = routes.ToDataTable() });
            return true;
        }

        public bool UpdateRoute(Route route)
        {
            SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure, USP + nameof(UpdateRoute),
            new SqlParameter() { ParameterName = "@" + nameof(route), Value = route.ModelToDataTable() });
            return true;
        }

        public IEnumerable<Route> GetRoutes(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, USP + nameof(GetRoutes),
            new SqlParameter() { ParameterName = "@" + nameof(id), Value = id });

            DataTable dt = ds.Tables[0];
            return dt?.TableToEnumerableModel<Route>();
        }

        public string GetRoutesXml(int id)
        {
            string xml;
            using (SqlConnection connection = new SqlConnection(cs))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    adapter.TableMappings.Add("Routes", "Routes");
                    connection.Open();
                    SqlCommand command = new SqlCommand()
                    {
                        CommandText = USP + nameof(GetRoutes),
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Connection = connection;
                    command.Parameters.Add(new SqlParameter()
                    {

                        ParameterName = "@" + nameof(id),
                        Value = id
                    });

                    adapter.SelectCommand = command;
                    using (DataSet ds = new DataSet("RoutesDataSet"))
                    {
                        adapter.Fill(ds);
                        xml = ds.GetXml();
                    }
                }
            }
            return xml;
        }

        public void InsertRoutesXml(string xmlFileName)
        {
            using (StreamReader streamReader = new StreamReader(xmlFileName))
            {
                using (XmlReader reader = XmlReader.Create(streamReader))
                {
                    using (DataSet ds = new DataSet())
                    {
                        var routes = new List<Route>();
                        ds.ReadXml(reader);
                        DataTable dataTable = ds.Tables[0];
                        foreach (DataRow row in dataTable.Rows)
                        {
                            routes.Add(new Route()
                            {
                                IDRoute = int.Parse(row[0].ToString()),
                                StartDate = DateTime.Parse(row[1].ToString()),
                                EndDate = DateTime.Parse(row[2].ToString()),
                                StartLocation = row[3].ToString(),
                                EndLocation = row[4].ToString(),
                                Distance = int.Parse(row[5].ToString()),
                                FuelSpent = double.Parse(row[6].ToString()),
                                FK_TravelWarrents = int.Parse(row[7].ToString())
                            });
                        }
                        InsertRoutes(routes);
                    }
                }
            }
        }

        public bool ImportRoutes(IEnumerable<Route> routes)
        {
            SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure, USP + nameof(ImportRoutes),
                 new SqlParameter() { ParameterName = "@route", Value = routes.ToDataTable() });
            return true;
        }
    }
}
