using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraineeTest.Presenter;
using TraineeTest.View;

namespace TraineeTest
{
    public partial class EditData : Form, IEditData
    {
        public string Id { get; set; }
        public string TbNamaBarang { get => tbNamaBarang.Text; set => tbNamaBarang.Text = value; }
        public string TbPrice { get => tbHargaBarang.Text; set => tbHargaBarang.Text = value; }
        private EditDataPresenter editDataPresenter;

        public EditData()
        {
            InitializeComponent();
        }

        private void EditData_Load(object sender, EventArgs e)
        {
            editDataPresenter = new EditDataPresenter(this);
            editDataPresenter.LoadDataToEdit();
            tbNamaBarang.SelectionStart = tbNamaBarang.Text.Length;
        }

        private void pnlClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEditData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            if (!editDataPresenter.EditData())
            {
                msgBox.Show("Nama barang sudah ada");
                return;
            }
            Close();
        }

        private void tbHargaBarang_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = e.KeyChar == ' ';
            e.Handled = !char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar);
            if (tbHargaBarang.Text.Length == 0 && e.KeyChar == '0')
                e.Handled = true;
        }

        private void tbNamaBarang_KeyUp(object sender, KeyEventArgs e)
        {
            btnEditData.Enabled = !string.IsNullOrEmpty(tbNamaBarang.Text) && !string.IsNullOrEmpty(tbHargaBarang.Text);
        }

        private void tbHargaBarang_KeyUp(object sender, KeyEventArgs e)
        {
            btnEditData.Enabled = !string.IsNullOrEmpty(tbNamaBarang.Text) && !string.IsNullOrEmpty(tbHargaBarang.Text);
        }
    }
}
