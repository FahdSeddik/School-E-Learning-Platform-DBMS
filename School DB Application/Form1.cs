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
namespace School_DB_Application
{
    public partial class App_Base : Form
    {
        public App_Base() // Default Constructor
        {
            InitializeComponent(); //initiallize
            Login_Page loginPage = new Login_Page() { Dock = DockStyle.Fill};//creates login page usercontrol
            //uses fill dock to fill the panel in form panel
            Home homePage = new Home() { Dock = DockStyle.Fill };//creates home page usercontrol
            //uses fill dock to fill the panel in form panel
            Login_Panel.Controls.Add(loginPage); //Adds login page to login panel
            Home_Panel.Controls.Add(homePage);  //Adds home page to home panel
            Home_Panel.Hide(); //initially hide home panel (homepage)
            //initially viewing login page only
        }

        //BUTTONS CLICK EVENT

        //application X (EXIT) button click
        private void App_X_Btn_Click(object sender, EventArgs e)
        {
            this.Close(); //closes this form (closes the program)
        }

        //BUTTONS MOUSE HOVER EVENT

        //application X (EXIT) mouse hover
        private void App_X_Btn_MouseHover(object sender, EventArgs e)
        {
            App_X_Btn.BackColor = Color.DarkRed; //change X (EXIT) button backcolor to dark red
        }


        //BUTTONS MOUSE LEAVE EVENT

        //application X (EXIT) mouse leave
        private void App_X_Btn_MouseLeave(object sender, EventArgs e)
        {
            App_X_Btn.BackColor = Color.FromName("AppWorkspace"); //Resets X (EXIT) button color back to "AppWorkspace"
        }

    }//APPLICATION END
}
