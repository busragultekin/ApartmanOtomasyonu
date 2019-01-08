using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanOtomasyonu
{
    class SqlHelper
    {
        private string ConnectionString { get; set; }
        private SqlConnection Connection { get; set; }
        public SqlHelper()
        {
            ConnectionString = "Data Source=WISSEN\\SQLEXPRESS;Initial Catalog=ApartmanDB; User ID=Section1; Integrated Security=True";
            Connection = new SqlConnection(ConnectionString);
        }
        public int ExecuteCommand(string query)
        {
            SqlCommand command = new SqlCommand(query, Connection);
            Connection.Open();
            int r = command.ExecuteNonQuery();
            Connection.Close();
            return r;
        }
        public void ExecutePro(string procName, params SqlParameter[] ps)
        {
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Parameters.AddRange(ps);
            command.Connection = Connection;
            Connection.Open();
            command.ExecuteNonQuery();
            Connection.Close();
        }
        public DataTable GetTable(string query)
        {
            SqlDataAdapter sda = new SqlDataAdapter(query, ConnectionString);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}
