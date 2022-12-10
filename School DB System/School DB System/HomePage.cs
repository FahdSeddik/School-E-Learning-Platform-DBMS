using Guna.UI2.WinForms;
using School_DB_System.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_DB_System
{
    public partial class HomePage : UserControl
    {
        UserControl Home;
        ViewController ViewController;
        private bool IsCollapsed; //minimum size
        public HomePage(ViewController ViewController, String Username,UserControl home)
        {
            InitializeComponent();
            this.ViewController = ViewController;
            Profile_Btn.Text = Username;
            Home = home;
            Home_pnl.Controls.Clear();
            Home_pnl.Controls.Add(Home);
            Home.Dock = DockStyle.Fill;
            IsCollapsed = true;

        }

        private void Logout_Btn_Click(object sender, EventArgs e)
        {
            ViewController.Logout();
        }

        private void Profile_DBtn_Click(object sender, EventArgs e)
        {
            if(IsCollapsed)
            {
                profile_Pnl.Size = profile_Pnl.MaximumSize;
                IsCollapsed = false;
                Profile_Btn.Image = null;
            }
            else
            {
                profile_Pnl.Size = profile_Pnl.MinimumSize;
                IsCollapsed = true;
                Profile_Btn.Image = Properties.Resources.Down_Arrow;
            }
            
        }

       
    }
}
