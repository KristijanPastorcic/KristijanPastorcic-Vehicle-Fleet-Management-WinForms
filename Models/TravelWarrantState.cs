using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Helpers;

namespace Vehicle_Fleet_Management.Models
{
    public class TravelWarrantState
    {
        private const string IMPORT_STATES = "insert into TravelWarrantStates(IDTravelWarrantState, State) values({0}, '{1}');";
        private const string SELECT_STATES = "select * from TravelWarrantStates";

        public TravelWarrantState(int id) => IDTravelWarrantState = id;

        public TravelWarrantState()
        {
        }

        public int IDTravelWarrantState { get; set; }
        public string State { get; set; }
        private static string cs { get; } =  ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        public override string ToString() => State;
        public static IEnumerable<TravelWarrantState> GetTravelWarrantStates()
        {

            using (SqlDataReader reader
                = SqlHelper.ExecuteReader(cs, CommandType.Text, SELECT_STATES))
            {
                while (reader.Read())
                {
                    yield return new TravelWarrantState(int.Parse(reader[nameof(IDTravelWarrantState)].ToString()))
                    {
                        State = reader[nameof(State)].ToString()
                    };
                }
            }
        }

        public enum EnumState { Open = 1, Closed = 2, Future = 3};

        internal static void ImportTravelWarrentStates(IEnumerable<TravelWarrantState> states)
        {
            var sb = new StringBuilder();
            sb.AppendLine(XmlHelper.SetIdentityInsert(true, "TravelWarrantStates"));
            states.ToList().ForEach(s =>
                sb.AppendLine(string.Format(IMPORT_STATES, s.IDTravelWarrantState, s.State))
            );
            sb.AppendLine(XmlHelper.SetIdentityInsert(false, "TravelWarrantStates"));
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text, sb.ToString());
        }
    }
}
