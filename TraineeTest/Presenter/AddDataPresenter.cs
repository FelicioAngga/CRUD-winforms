using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTest.Model;
using TraineeTest.View;

namespace TraineeTest.Presenter
{
    public class AddDataPresenter
    {
        private IAddData addDataView;
        public AddDataPresenter(IAddData view)
        {
            addDataView = view;
        }

        public bool AddDataBarang()
        {
            var barang = new Barang();
            barang.nama = addDataView.TbNamaBarang;
            barang.harga = addDataView.TbPrice;
            if (barang.LoadBarangByUsername().Count > 0) return false;
            barang.AddBarang();
            return true;
        }
    }
}
