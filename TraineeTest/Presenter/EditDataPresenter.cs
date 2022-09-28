using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTest.Model;
using TraineeTest.View;

namespace TraineeTest.Presenter
{
    public class EditDataPresenter
    {
        IEditData editDataView;
        public EditDataPresenter(IEditData view)
        {
            editDataView = view;
        }

        public void LoadDataToEdit()
        {
            var barang = new Barang();
            barang.id = editDataView.Id;
            foreach (DataRow dr in barang.LoadBarangById())
            {
                editDataView.TbNamaBarang = dr["nama"].ToString();
                editDataView.TbPrice = dr["harga"].ToString();
            }
        }

        public bool EditData()
        {
            var barang = new Barang();
            barang.id = editDataView.Id;
            barang.nama = editDataView.TbNamaBarang;
            barang.harga = editDataView.TbPrice;
            if (barang.LoadBarangByUsernameAndNotId().Count > 0) return false;
            barang.EditBarang();
            return true;
        }
    }
}
