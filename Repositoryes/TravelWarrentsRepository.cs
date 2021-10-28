using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Vehicle_Fleet_Management.Extensions;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes

{

    class TravelWarrentsRepository : ITravelWarrentsRepository
    {
        private const string USP = "usp";
        private const string TRAVEL_WARRENTS = "TravelWarrents";

        public event InfoMessageDelegate TravelWarrents_InfoMessage;

        private void Connection_InfoMessage(object sender, SqlInfoMessageEventArgs e)
        {
            TravelWarrents_InfoMessage.Invoke(sender, e);
        }

        private string cs { get; }

        public TravelWarrentsRepository(string connectionString) => cs = connectionString;


        //CRUD
        public bool CreateTravelWarrent(TravelWarrent travelWarrent)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure,
                        USP + nameof(CreateTravelWarrent), new SqlParameter()
                        {
                            ParameterName = "@" + nameof(travelWarrent),
                            Value = travelWarrent.ModelToDataTable()
                        }
                        );
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

        public bool DeleteTravelWarrent(int id)
        {
            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();
                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = USP + nameof(DeleteTravelWarrent);
                            command.Parameters.AddWithValue("@" + nameof(id), id);
                            command.Transaction = transaction;
                            command.ExecuteNonQuery();
                            transaction.Commit();
                            return true;
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public IEnumerable<TravelWarrent> GetTravelWarrents()
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    DataSet ds = SqlHelper.ExecuteDataset(cs, CommandType.StoredProcedure, USP + nameof(GetTravelWarrents));
                    DataTable dt = ds.Tables[0];
                    IEnumerable<TravelWarrent> warrents = dt.TableToEnumerableModel<TravelWarrent>();
                    transaction.Complete();
                    return warrents;
                }
                catch (Exception)
                {
                    transaction.Dispose();
                    throw;
                }
            }
        }

        public bool UpdateTravelWarrent(TravelWarrent travelWarrent)
        {
            using (TransactionScope transaction = new TransactionScope())
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(cs))
                    {
                        connection.Open();
                        using (SqlCommand command = connection.CreateCommand())
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.CommandText = USP + nameof(UpdateTravelWarrent);
                            command.Parameters.Add(new SqlParameter()
                            {
                                ParameterName = "@" + nameof(travelWarrent),
                                Value = travelWarrent.ModelToDataTable()
                            });
                            command.ExecuteNonQuery();
                        }
                    }
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

        public void ImportWarrents(IEnumerable<TravelWarrent> travelWarrents)
        {
            var table = travelWarrents.ToDataTable();
            SqlHelper.ExecuteNonQuery(cs, CommandType.StoredProcedure,
                USP + nameof(ImportWarrents), new SqlParameter()
                {
                    ParameterName = "@travelWarrent",
                    Value = table
                });
        }
    }
}
