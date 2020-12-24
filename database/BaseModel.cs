using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace CN382_Project.database
{
    public abstract class BaseModel<T> where T: new()
    {
        public virtual string tableName { get; set; }
        public virtual string[] attributes { get; set; }
        
        SqlConnection conn;

        public BaseModel()
        {
            conn = DBConn.getConnection();
        }

        private string[] getColumnsFormatted(string[] attrs, bool withParen = true)
        {
            
            string paramsString = "";
            string columnsString = "";

            if (withParen)
            {
                paramsString += "(";
                columnsString += "(";
            }

            for (int i = 0; i < attrs.Length; i++)
            {
                if (i > 0)
                {
                    paramsString += ", ";
                    columnsString += ", ";
                }
                paramsString += "@" + (i + 1);
                columnsString += attrs[i];
            }

            if (withParen)
            {
                paramsString += ")";
                columnsString += ")";
            }

            return new string[] { paramsString, columnsString };
        }

        private string getQueryFormatted(Dictionary<string, string> query)
        {
            string result = "";
            for (int i = 0; i < query.Count; i++)
            {
                var item = query.ElementAt(i);
                if (i > 0) { result += " AND "; }
                result += "(" + item.Key + " = @" + (i+1) +")";
            }

            return result;
        }

        private string getSetFormatted(string[] values)
        {
            string result = "";
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0)
                {
                    result += ", ";
                }
                result += values[i] + " = @set" + (i + 1);
            }
            return result;
        }

        public abstract T[] Find(string[] select = null, Dictionary<string, string> query = null);
        protected T[] Find(Func<object[], T> factory, string[] select = null, Dictionary<string, string> query = null)
        {
            string sql = "SELECT ";
            string[] selectedColumns;
            if (select == null)
            {
                selectedColumns = getColumnsFormatted(attributes, false);
            }
            else
            {
                selectedColumns = getColumnsFormatted(select, false);
            }
            sql += selectedColumns[1] + " FROM ";

            if (query == null) {
                sql += tableName + ";"; 
            } else {
                sql += tableName + " WHERE " + getQueryFormatted(query) +";";
            }
            var cmd = new SqlCommand(sql, conn);
            if (query != null) {
                for (int i = 0; i < query.Count; i ++)
                {
                    cmd.Parameters.AddWithValue("@"+(i+1), query.Values.ElementAt(i));
                }
            }
            conn.Open();
            var reader = cmd.ExecuteReader();
            List<T> returningResult = new List<T>();

            while (reader.Read())
            {
                object[] row = new object[reader.FieldCount];
                reader.GetValues(row);
                returningResult.Add(factory(row));
            }

            conn.Close();

            return returningResult.ToArray<T>();
        }

        public void Add(Dictionary<string, string> entity) 
        {
            string sql = "INSERT INTO " + tableName + " ";
            string[] parameters = getColumnsFormatted(entity.Keys.ToArray());
            sql += parameters[1] + " VALUES " + parameters[0];

            var cmd = new SqlCommand(sql, conn);
            for (int i = 0; i < entity.Count; i++)
            {
                cmd.Parameters.AddWithValue("@" + (i+1), entity.Values.ElementAt(i));
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Patch(Dictionary<string, string> data, Dictionary<string, string> query = null)
        {
            string sql = "UPDATE " + tableName + " SET ";
            string[] keys = data.Keys.Select(x => "[" + x + "]").ToArray();
            sql += getSetFormatted(keys);

            if (query != null)
            {
                sql += " WHERE " + getQueryFormatted(query);
            }

            var cmd = new SqlCommand(sql, conn);

            for (int i = 0; i < data.Count; i++)
            {
                cmd.Parameters.AddWithValue("@set" + (i + 1), data.Values.ElementAt(i));
            }

            if (query != null)
            {
                for (int i = 0; i < query.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@" + (i + 1), query.Values.ElementAt(i));
                }
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(Dictionary<string, string> query = null)
        {
            string sql = "DELETE FROM " + tableName;
            if (query != null)
            {
                sql += " WHERE " + getQueryFormatted(query);
            }
            var cmd = new SqlCommand(sql, conn);
            if (query != null)
            {
                for (int i = 0; i < query.Count; i++)
                {
                    cmd.Parameters.AddWithValue("@" + (i + 1), query.Values.ElementAt(i));
                }
            }
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public DataTable ItemsDataTable()
        {
            DataTable table = new DataTable();
            table.Columns.AddRange(attributes.Select(x => new DataColumn(x)).ToArray());
            return table;
        }
        
    }

}