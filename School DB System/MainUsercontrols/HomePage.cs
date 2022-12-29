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
        ViewController viewController;
        private bool IsCollapsed; //minimum size
        public HomePage(ViewController viewController, String Username,UserControl home)
        {
            InitializeComponent();
            this.viewController = viewController;
            Profile_Btn.Text = Username;
            Home = home;
            Home_pnl.Controls.Clear();
            Home_pnl.Controls.Add(Home);
            Home.Dock = DockStyle.Fill;
            IsCollapsed = true;

        }

        private void Logout_Btn_Click(object sender, EventArgs e)
        {
            viewController.Logout();
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

        //title bar on click event
        private void HomePage_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            viewController.ApplicationMouseDown(sender,e);
        }

        //title bar mouse move event
        private void HomePage_Pnl_MouseMove(object sender, MouseEventArgs e)
        {
            viewController.ApplicationMouseMove(sender, e);
        }

        //title bar mouse up event
        private void HomePage_Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            viewController.ApplicationMouseUp(sender, e);
        }

    }
}
