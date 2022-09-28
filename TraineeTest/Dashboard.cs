using Guna.UI2.WinForms;
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
    public partial class Dashboard : Form, IDashboard
    {
        public PictureBox PbWeather { get => pbWeather; set => pbWeather = value; }
        public Guna2DataGridView Dgv { get => dgv; set => dgv = value; }
        public string LblTemp { get => lblTemp.Text; set => lblTemp.Text = value; }
        public string LblWeather { get => lblWeather.Text; set => lblWeather.Text = value; }
        public string LblDesc { get => lblDesc.Text; set => lblDesc.Text = value; }

        private DashboardPresenter dashboardPresenter;

        public Dashboard()
        {
            InitializeComponent();
        }


        private async void Dashboard_Load(object sender, EventArgs e)
        {
            dashboardPresenter = new DashboardPresenter(this);
            combBoxTown.SelectedIndex = 0;
            await dashboardPresenter.LoadWeatherByTown(combBoxTown.Text);
            dashboardPresenter.LoadDataBarang();

        }

        private async void combBoxTown_SelectedIndexChanged(object sender, EventArgs e)
        {
            await dashboardPresenter.LoadWeatherByTown(combBoxTown.Text);
        }

        private void btnAddData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var addData = new AddData();
            addData.ShowDialog();
            dashboardPresenter.LoadDataBarang();
        }

        private void btnEditData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var editData = new EditData();
            editData.Id = dgv.SelectedRows[0].Cells["id"].Value.ToString();
            editData.ShowDialog();
            dashboardPresenter.LoadDataBarang();
        }

        private void btnDeleteData_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            var result = msgBox.Show("Apakah kamu yakin ingin menghapus data ini ?");
            if(result == DialogResult.Yes)
            {
                dashboardPresenter.DeleteBarang(dgv.SelectedRows[0].Cells["id"].Value.ToString());
                dashboardPresenter.LoadDataBarang();
            }
        }
    }
}
