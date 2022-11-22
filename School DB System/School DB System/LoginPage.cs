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
    public partial class LoginPage : UserControl
    {
        private ViewController ViewController; //View Handler
        public LoginPage(ViewController ViewController)
        {
            InitializeComponent();
            this.ViewController = ViewController;
            Username_Txt.Select();
        }

        private void Login_Btn_Click(object sender, EventArgs e)
        {
            string Username = Convert.ToString(Username_Txt.Text);
            int authority = 1;
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
    }
}
