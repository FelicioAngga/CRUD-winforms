using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraineeTest.View
{
    public interface IDashboard
    {
        PictureBox PbWeather { get; set; }
        Guna2DataGridView Dgv { get; set; }
        string LblTemp { get; set; }
        string LblWeather { get; set; }
        string LblDesc { get; set; }
    }
}
