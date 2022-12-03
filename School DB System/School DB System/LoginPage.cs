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
            Username_Txt.Select();
            this.controller = controller;
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            string Username = Convert.ToString(Username_Txt.Text);
            string Password = Convert.ToString(Password_Txt.Text);
            int authority;
            try
            {
                authority = controller.Login(Username, Password);
            }
            catch (Exception error)
            {
                LoginError_Lbl.Show();
                return;
            }
            if(authority == 4 || authority == 5)
            {
                LoginError_Lbl.Show();
                return;
            }
                ViewController.ViewHomePage(authority, Username);//view homepage function takes authority to view the sutiable view for this user
        }

        private void ForgetPass_Lbl_MouseHover(object sender, EventArgs e)
        {
            ForgetPass_Lbl.ForeColor = Color.FromArgb(81, 93, 255);
        }

        private void ForgetPass_Lbl_MouseLeave(object sender, EventArgs e)
        {
            ForgetPass_Lbl.ForeColor = Color.FromArgb(94, 148, 255);
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
    }
}
