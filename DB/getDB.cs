using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PKBNV
{
    class getDB
    {//Chuỗi kết nối

        /*public static String _connectionString = @"Server=ADMIN;Database=khamSKNV;Integrated Security = true;";*/
        public static String _connectionString = @"Data Source= HAILUA\SQLEXPRESS ;
                                                             Initial Catalog = khamSKNV;
                                                             Persist Security Info = True;
                                                             User ID = HaiLua;
                                                             Password = Hailua1302.";
        //ExecuteQuery : Select
        //ExecuteQuery : Select
        //ExecuteQuery : Select

        public static DataTable ExecuteQuery(String sql)
        {
                DataTable dt = new DataTable();
                SqlConnection connect = new SqlConnection(_connectionString);
                connect.Open();
                SqlCommand command = connect.CreateCommand();
                command.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = command;
                adapter.Fill(dt);
                if ((dt.Rows.Count > 0) && (dt.Rows[0][0] != DBNull.Value))
                    {
                        return dt;
                    }
               
                connect.Close();
                return null;
        }
        //lay id
        public static string get_valueSQL(String sql)
        {
            SqlConnection connect = new SqlConnection(_connectionString);
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Connection = connect;
            connect.Open();
            string value = Convert.ToString(command.ExecuteScalar());
            connect.Close();
            return value;
        }
        //check duplicate
        public static int checkDuplicate(String sql)
        {
            SqlConnection connect = new SqlConnection(_connectionString);
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            command.Connection = connect;
            connect.Open();
            int CustomerCount = Convert.ToInt32(command.ExecuteScalar());
            connect.Close();
            return CustomerCount;
        }
        //ExecuteNonQuery: Insert, Update, Delete
        public static bool ExecuteNonQuery(String sql)
        {
            bool kq;
            SqlConnection connect = new SqlConnection(_connectionString);
            connect.Open();
            SqlCommand command = connect.CreateCommand();
            command.CommandText = sql;
            int n = command.ExecuteNonQuery();
            if (n > 0)
            {
                kq = true;
            }
            else
            {
                kq = false;
            }
            connect.Close();
            return kq;
        }

        
    }
}
