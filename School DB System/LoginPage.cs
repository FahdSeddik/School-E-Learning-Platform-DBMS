using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_DB_System
{
    public partial class LoginPage : UserControl
    {
        private ViewController ViewController; //View Handler
        private Controller controller;
        public LoginPage(ViewController ViewController, Controller controller)
        {
            InitializeComponent();
            this.ViewController = ViewController;
            this.controller = controller;
            Username_Txt.Select();
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            string Username = Convert.ToString(Username_Txt.Text);
            string Password = Convert.ToString(Password_Txt.Text);
            int authority;
            try
            {
                authority = controller.Login(Username, Password); //return null if user does not exist.

            }
            catch (Exception error)
            {
                LoginError_Lbl.Show();
                Username_Txt.Clear();
                Password_Txt.Clear();
                Username_Txt.Select();
                return;
            }
  
            int res = ViewController.ViewHomePage(authority, Username);//view homepage function takes authority to view the sutiable view for this user
            if (res == 0)
            {
                LoginError_Lbl.Show();
                Username_Txt.Clear();
                Password_Txt.Clear();
                Username_Txt.Select();
                return;
            }
        }

        private void LoginPage_Pnl_MouseDown(object sender, MouseEventArgs e)
        {
            ViewController.ApplicationMouseDown(sender, e);
        }

        private void LoginPage_Pnl_MouseMove(object sender, MouseEventArgs e)
        {
            ViewController.ApplicationMouseMove(sender, e);
        }

        private void LoginPage_Pnl_MouseUp(object sender, MouseEventArgs e)
        {
            ViewController.ApplicationMouseUp(sender, e);
        }

        private void Username_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login_Btn_Click(sender, e);
            }
        }

        private void Password_Txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_Btn_Click(sender, e);
            }
        }
    }
}
