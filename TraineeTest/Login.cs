using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TraineeTest.API;

namespace TraineeTest
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void tbPass_IconRightClick(object sender, EventArgs e)
        {
            tbPass.PasswordChar = tbPass.PasswordChar == '●' ? '\0' : '●';
        }

        private void btnLogin_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;
            OnLogin();
        }

        private void OnLogin()
        {
            if (tbUsername.Text != "admin" || tbPass.Text != "admin") return;
            Hide();
            var dashboard = new Dashboard();
            dashboard.ShowDialog();
        }

        private void tbPass_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OnLogin();
        }
    }
}
