using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTest
{
    public class Connection
    {
        public SQLiteConnection con;
        public SQLiteCommand cmd;
        SQLiteDataAdapter da;
        DataTable dt;
        DataSet ds;
        private int scollVal = 0;
        private int temp = 0;

        public Connection()
        {
            con = new SQLiteConnection(LoadConnectionString(), true);
            OpenConnection();
            //con.ChangePassword("8a81a26bbc2301b26176f1023af64023ca6c389adb82e94a222e72964801ef86");
        }

        public void OpenConnection()
        {
            if (con.State != System.Data.ConnectionState.Open)
                con.Open();
        }

        public void CloseConnection()
        {
            if (con.State != System.Data.ConnectionState.Closed)
                con.Close();
        }

        public void Query(string query)
        {
            cmd = new SQLiteCommand(query, con);
        }

        public DataTable QueryEx()
        {
            da = new SQLiteDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void NonQueryEx()
        {
            cmd.ExecuteNonQuery();
        }

        public string NonQueryExRet()
        {
            return cmd.ExecuteScalar().ToString();
        }

        private static string LoadConnectionString()
        {
            return @"Data Source=.\TraineeTest.db; providerName= System.Data.SqlClient";
        }
    }
}
