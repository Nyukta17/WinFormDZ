using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    internal class DB
    {
        SqlConnection connection = new SqlConnection(@"Data Source=МАКСИМ-ПК;Initial Catalog=MyUsers;Integrated Security=True;Encrypt=False");

        public void open_connection() 
        {
            if(connection.State== System.Data.ConnectionState.Closed) 
            {
                connection.Open();
            }
        }
        public void close_connection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public SqlConnection get_connection() 
        {
            return connection;
        }
    }
    
}
