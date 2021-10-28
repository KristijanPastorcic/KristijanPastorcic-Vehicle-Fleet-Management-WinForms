using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicle_Fleet_Management.Models;

namespace Vehicle_Fleet_Management.Repositoryes
{
    class ItemsRepository : IItemsRepository
    {
        private string cs;
        private const string CREATE_ITEM = "insert into Items(ProductName, Amont, ItemPrice) values('{0}', {1}, {2}); ";
        private const string IMPORT_ITEM = "insert into Items(IDItem ,ProductName, Amont, ItemPrice) values({0}, '{1}', {2}, {3}); ";
        private const string DELETE_ITEM = "delete Items where IDItem = {0}; ";
        private const string UPDATE_ITEM = "update Items set ProductName = '{1}', Amont = {2}, ItemPrice = {3} where IDItem = {0}; ";
        private const string SELECT_ITEMS = "select * from Items; ";
        public ItemsRepository(string connectionString) => cs = connectionString;

        public bool CreateItem(Item item)
        {
            return
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text,
                string.Format(CREATE_ITEM, item.ProductName, item.Amont, item.ItemPrice)) == 1;
        }

        public bool DeleteItem(int id)
        {
            return
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text, string.Format(DELETE_ITEM, id)) == 1;
        }

        public IEnumerable<Item> GetItems()
        {
            IList<Item> items = new List<Item>();
            DataSet ds = SqlHelper.ExecuteDataset(cs, CommandType.Text, SELECT_ITEMS);
            ds?.Tables[0].Rows.Cast<DataRow>().ToList().ForEach(dr =>
                   items.Add(new Item()
                   {
                       IDItem = int.Parse(dr["IDItem"].ToString()),
                       ProductName = dr["ProductName"].ToString(),
                       Amont = (int)dr["Amont"],
                       ItemPrice = decimal.Parse(dr["ItemPrice"].ToString())
                   })
                );
            ds.Dispose();
            return items;
        }

        public void ImportItems(IEnumerable<Item> items)
        {
            StringBuilder sb = new StringBuilder();
            items.ToList().ForEach(i =>
                sb.AppendLine(string.Format(IMPORT_ITEM, i.IDItem, i.ProductName, i.Amont, i.ItemPrice))
            );
        }

        public bool UpdateItem(Item item)
        {
            return
            SqlHelper.ExecuteNonQuery(cs, CommandType.Text,
                string.Format(UPDATE_ITEM, item.IDItem, item.ProductName, item.Amont, item.ItemPrice)) == 1;
        }
    }
}
