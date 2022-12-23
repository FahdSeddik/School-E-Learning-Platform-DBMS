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

//SCHOOL DB APPLICATION NAMESPACE
namespace School_DB_System
{
    public partial class Application : Form
    {
        private ViewController ViewController;
        private Controller Controller; //making controller object
        private UserControl MainPage;
        private UserControl MainTab;
        private UserControl SubTab;
        private UserControl TempTab;
        bool drag;
        Point StartPoint;


        public Application()// Default Constructor
        {
            InitializeComponent();//initiallize
            Controller = new Controller();
            ViewController = new ViewController(this,Controller);
            drag = false;
            StartPoint = new Point(0, 0);
            MainTab_Pnl.Visible = false;
            SubTab_Pnl.Visible =false;
            TempTab_Pnl.Visible =false;
    }

        //METHODS

        //Function that displays the sutiable form view for a student

        public void ViewOnMainPage(UserControl Mainpage)
        {
            MainPage = Mainpage;
            MainPage_Pnl.Controls.Clear();
            MainPage_Pnl.Controls.Add(MainPage);
            MainPage_Pnl.Visible = true;
            MainPage_Pnl.BringToFront();
            Exit_Btn.BringToFront();
        }
        //logout w homepage w loginpage

        public void ViewOnMainTab(UserControl Maintab)
        {
            MainTab = Maintab;
            MainTab_Pnl.Controls.Clear();
            MainTab_Pnl.Controls.Add(Maintab);
            MainTab_Pnl.Visible = true;
            MainTab_Pnl.BringToFront();
            Exit_Btn.BringToFront();
        }
        //Student Teacher Bus ....etc

        public void CloseMainTab()
        {
            MainTab = null;
            MainTab_Pnl.Controls.Clear();
            MainTab_Pnl.Visible = false;
            CloseSubTab();
        }

        public void ViewOnSubTab(UserControl subtab)
        {
            SubTab_Pnl.Size = subtab.Size;
            SubTab_Pnl.Location = new Point(ClientSize.Width / 2 - SubTab_Pnl.Size.Width / 2, ClientSize.Height / 2 - SubTab_Pnl.Size.Height / 2);
            SubTab_Pnl.Anchor = AnchorStyles.None;
            SubTab = subtab;
            SubTab_Pnl.Controls.Clear();
            SubTab_Pnl.Controls.Add(subtab);
            SubTab_Pnl.Visible = true;
            SubTab_Pnl.BringToFront();
            Exit_Btn.BringToFront();
        }
        //Add ,update,view...etc....

        public void CloseSubTab()
        {
            SubTab = null;
            SubTab_Pnl.Controls.Clear();
            SubTab_Pnl.Visible = false;
            CloseTempTab();
        }

        public void ViewOnTempTab(UserControl Temptab)
        {
            TempTab_Pnl.Size = Temptab.Size;
            TempTab_Pnl.Location = new Point(ClientSize.Width / 2 - TempTab_Pnl.Size.Width / 2, ClientSize.Height / 2 - TempTab_Pnl.Size.Height / 2);
            TempTab_Pnl.Anchor = AnchorStyles.None;
            TempTab = Temptab;
            TempTab_Pnl.Controls.Clear();
            TempTab_Pnl.Controls.Add(TempTab);
            TempTab_Pnl.Visible = true;
            TempTab_Pnl.BringToFront();
            Exit_Btn.BringToFront();
        }
        //drivers list, students list...etc ....etc

        public void CloseTempTab()
        {
            TempTab = null;
            TempTab_Pnl.Controls.Clear();
            TempTab_Pnl.Visible = false;
        }


        private void Exit_Btn_Click(object sender, EventArgs e)
        {
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to exit?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

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
