using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Vehicle_Fleet_Management.Extensions
{
    // names of props must be the same as the type table columns on sql server
    public static class Extensions
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> data)
        {
            PropertyInfo[] props = typeof(T).GetFilteredProperties();
            DataTable table = new DataTable();
            for (int i = 0; i < props.Length; i++)
            {
                PropertyInfo prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Length];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static DataTable ModelToDataTable<T>(this T model)
        {
            PropertyInfo[] props = typeof(T).GetFilteredProperties();
            DataTable table = new DataTable();
            for (int i = 0; i < props.Length; i++)
            {
                table.Columns.Add(props[i].Name, props[i].PropertyType);
            }

            object[] values = new object[props.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = props[i].GetValue(model);
            }
            table.Rows.Add(values);
            return table;
        }

        public static IEnumerable<T> TableToEnumerableModel<T>(this DataTable dt)
        {
            IList<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                data.Add(DataRowToModel<T>(row));
            }
            return data;
        }
        public static T DataRowToModel<T>(this DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo property in temp.GetFilteredProperties())
                {
                    if (property.CanWrite && property.Name == column.ColumnName)
                        property.SetValue(obj, dr[column.ColumnName], null);
                }
            }
            return obj;
        }

        public static IEnumerable<T> XmlNodeListToEnumerableModel<T>(this XmlNodeList nodeList) where T : class
        {
            IList<T> data = new List<T>();
            foreach (XmlNode node in nodeList)
            {
                data.Add(XmlNodeToModel<T>(node));
            }
            return data;
        }

        private static T XmlNodeToModel<T>(this XmlNode node) where T : class
        {
            MemoryStream stm = new MemoryStream();

            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();

            stm.Position = 0;

            XmlSerializer ser = new XmlSerializer(typeof(T));
            T result = (ser.Deserialize(stm) as T);

            return result;
        }
    }
}
