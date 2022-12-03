using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//SCHOOL DB APPLICATION NAMESPACE
namespace School_DB_System
{
    public partial class Application : Form
    {
        private ViewController ViewController;
        private Controller Controller; //making controller object
        private UserControl MainPage;
        private UserControl SecondaryPage;
        bool drag;
        Point StartPoint;
        public Application()// Default Constructor
        {
            InitializeComponent();//initiallize
            Controller = new Controller();
            ViewController = new ViewController(this,Controller);
            drag = false;
            StartPoint = new Point(0, 0);
        }

        //METHODS

        //Function that displays the sutiable form view for a student

        public void viewOnMainPage(UserControl Mainpage)
        {
            MainPage = Mainpage;
            MainScreen_Pnl.Controls.Clear();
            MainScreen_Pnl.Controls.Add(MainPage);
            SecondaryScreen_Pnl.Hide();
            MainScreen_Pnl.Show();
        }
        public void viewOnSecondaryPage(UserControl Secondarypage)
        {
            SecondaryPage = Secondarypage;
            SecondaryScreen_Pnl.Controls.Clear();
            SecondaryScreen_Pnl.Controls.Add(SecondaryPage);
            MainScreen_Pnl.Hide();
            SecondaryScreen_Pnl.Show();
        }


        public void viewMainPage()
        {
            SecondaryScreen_Pnl.Hide();
            MainScreen_Pnl.Show();
        }

        private void Exit_Btn_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to exit?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Controller.TerminateConnection();
                this.Close();
            }
            else
            {
                return;
            }
        }

        public void Application_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            StartPoint = new Point(e.X, e.Y);
        }

        public void Application_MouseMove(object sender, MouseEventArgs e)
        {
            if(drag)
            {
                Point NextLocation = PointToScreen(e.Location);
                this.Location = new Point(NextLocation.X - StartPoint.X, NextLocation.Y - StartPoint.Y);
            }
        }

        public void Application_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }
    }

}
