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
        private UserControl MainPage;
        private UserControl SecondaryPage;
        Controller controllerObj; //making controller object
        public Application()// Default Constructor
        {
            InitializeComponent();//initiallize
            controllerObj = new Controller();
            ViewController = new ViewController(this);
        }

        //METHODS

        //Function that displays the sutiable form view for a student

        public void viewOnMainPage(UserControl Mainpage)
        {
            MainPage = Mainpage;
            Main_Screen_Pnl.Controls.Clear();
            Main_Screen_Pnl.Controls.Add(MainPage);
            Secondary_Screen_Pnl.Hide();
            Main_Screen_Pnl.Show();
        }
        public void viewOnSecondaryPage(UserControl Secondarypage)
        {
            SecondaryPage = Secondarypage;
            Secondary_Screen_Pnl.Controls.Clear();
            Secondary_Screen_Pnl.Controls.Add(SecondaryPage);
            Main_Screen_Pnl.Hide();
            Secondary_Screen_Pnl.Show();
        }

        public void viewMainPage()
        {
            Secondary_Screen_Pnl.Hide();
            Main_Screen_Pnl.Show();
        }

    }

}
