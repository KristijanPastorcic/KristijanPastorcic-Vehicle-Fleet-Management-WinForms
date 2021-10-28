using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Extensions;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    class TravelExpenceRepository : ITravelExpenceRepository
    {
        private const string SELECT_EXPENCES = "select * from TravelExpences; ";
        private const string DELETE_EXPENCE = "delete from TravelExpences where IDTravelExpence = {0}; ";
        private const string CREATE_EXPENCE = "insert into TravelExpences(PurchaseDate, FK_TravelWarrents, FK_Items) values ('{0}', {1}, {2}); ";
        private const string UPDATE_EXPENCE = "update TravelExpences set PurchaseDate = '{1}', FK_TravelWarrents = {2}, FK_Items {3} where IDTravelExpence = {0}; ";
        private const string IMPORT_EXPENCE = "insert into TravelExpences(IDTravelExpence, PurchaseDate, FK_TravelWarrents, FK_Items) values ({0}, '{1}', {2}, {3}); ";
        private string cs;

        public TravelExpenceRepository(string connectionString)
        {
            cs = connectionString;
        }

        public bool CreateTravelExpence(TravelExpence expence)
        {
            return
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text,
                string.Format(CREATE_EXPENCE,
                expence.PurchaseDate.ToString(),
                expence.FK_TravelWarrents,
                expence.FK_Items)) == 1;
        }

        public bool DeleteTravelExpence(int id)
        {
            return
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text,
                string.Format(DELETE_EXPENCE, id)) == 1;
        }

        public IEnumerable<TravelExpence> GetTravelExpences()
        {
            using (var ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, SELECT_EXPENCES))
            {
                return ds.Tables?[0].TableToEnumerableModel<TravelExpence>();
            }
        }

        public void ImportTravelExpence(IEnumerable<TravelExpence> expences)
        {
            StringBuilder sb = new StringBuilder();
            expences.ToList().ForEach(e =>
                sb.AppendLine(string.Format(IMPORT_EXPENCE, 
                e.IDTravelExpence,
                e.PurchaseDate.ToString(),
                e.FK_TravelWarrents,
                e.FK_Items))
            );

            SqlHelper.ExecuteNonQuery(cs, CommandType.Text, sb.ToString());
        }

        public bool UpdateTravelExpence(TravelExpence expence)
        {
            return
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text, 
                string.Format(UPDATE_EXPENCE,
                    expence.IDTravelExpence,
                    expence.PurchaseDate.ToString(),
                    expence.FK_TravelWarrents,
                    expence.FK_Items
                )) == 1;
        }
    }
}
