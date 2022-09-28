using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraineeTest.API;
using TraineeTest.Model;
using TraineeTest.View;

namespace TraineeTest.Presenter
{
    public class DashboardPresenter
    {
        private IDashboard dashboardView;

        public DashboardPresenter(IDashboard view)
        {
            dashboardView = view;
        }

        public async Task LoadWeatherByTown(string town)
        {
            var weatherAPI = new WeatherAPI();
            var result = await weatherAPI.GetCurrentWeather(town);
            dashboardView.LblTemp = $"{result.main.temp}℃";
            dashboardView.LblWeather = result.weather[0].main;
            dashboardView.LblDesc = result.weather[0].description;
            dashboardView.PbWeather.ImageLocation = $"http://openweathermap.org/img/w/{result.weather[0].icon}.png";
        }

        public void LoadDataBarang()
        {
            var barang = new Barang();
            dashboardView.Dgv.Rows.Clear();
            foreach (DataRow dr in barang.LoadBarang())
            {
                dashboardView.Dgv.Rows.Add(new object[]
                {
                    dr["id"], dr["nama"], $"Rp {Convert.ToInt32(dr["harga"]):n0}", dr["created_at"]
                });
            }
        }

        public void DeleteBarang(string id)
        {
            var barang = new Barang();
            barang.id = id;
            barang.DeleteBarang();
        }
    }
}
