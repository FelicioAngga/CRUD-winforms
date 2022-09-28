using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraineeTest.Model
{
    public class Barang
    {
        public string id { get; set; }
        public string nama { get; set; }
        public string harga { get; set; }

        Connection con;
        public void AddBarang()
        {
            con = new Connection();
            con.Query("INSERT INTO tbl_barang (nama, harga) VALUES(@nama, @harga)");
            con.cmd.Parameters.AddWithValue("@nama", nama);
            con.cmd.Parameters.AddWithValue("@harga", harga);
            con.NonQueryEx();
            con.CloseConnection();
        }

        public void EditBarang()
        {
            con = new Connection();
            con.Query("UPDATE tbl_barang SET nama = @nama, harga = @harga WHERE id = @id");
            con.cmd.Parameters.AddWithValue("@id", id);
            con.cmd.Parameters.AddWithValue("@nama", nama);
            con.cmd.Parameters.AddWithValue("@harga", harga);
            con.NonQueryEx();
            con.CloseConnection();
        }

        public void DeleteBarang()
        {
            con = new Connection();
            con.Query("DELETE FROM tbl_barang WHERE id = @id");
            con.cmd.Parameters.AddWithValue("@id", id);
            con.NonQueryEx();
            con.CloseConnection();
        }

        public DataRowCollection LoadBarang()
        {
            con = new Connection();
            con.Query("SELECT * FROM tbl_barang");
            con.CloseConnection();
            return con.QueryEx().Rows;
        }

        public DataRowCollection LoadBarangByUsername()
        {
            con = new Connection();
            con.Query("SELECT * FROM tbl_barang WHERE nama = @nama");
            con.cmd.Parameters.AddWithValue("@nama", nama);
            con.CloseConnection();
            return con.QueryEx().Rows;
        }

        public DataRowCollection LoadBarangByUsernameAndNotId()
        {
            con = new Connection();
            con.Query("SELECT * FROM tbl_barang WHERE nama = @nama AND id != @id");
            con.cmd.Parameters.AddWithValue("@nama", nama);
            con.cmd.Parameters.AddWithValue("@id", id);
            con.CloseConnection();
            return con.QueryEx().Rows;
        }

        public DataRowCollection LoadBarangById()
        {
            con = new Connection();
            con.Query("SELECT * FROM tbl_barang WHERE id = @id");
            con.cmd.Parameters.AddWithValue("@id", id);
            con.CloseConnection();
            return con.QueryEx().Rows;
        }


    }
}
