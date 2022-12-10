using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace School_DB_System
{
    public class ViewController //View Class
    {
        //PRIVATE DATA MEMBERS
        private Application Application_Handler; //Application Handler
        private UserControl MainPage;
        private UserControl SecondaryPage;
        private UserControl home;
        private Controller controller;

        //Non Default constructor
        public ViewController(Application Application_Handler, Controller controller)
        {
            this.Application_Handler = Application_Handler;//Connecting with Application base (the base form) 
            this.controller = controller;
            viewLoginPage();
        }

        //METHODS

        //View homepage function
        //mainly used on login button click to swtich from login page to homepage
        //takes integer to view the suitable homepage for this user depending on level of authority
        public void ViewHomePage(int Authority, string Username)
        {
            switch(Authority)
            {
                case 1:
                    home = new Adminstrator(this);
                    break;
                case 2:
                    home = new HR(this);
                    break;
                case 3:
                    home = new Accountant(this);
                    break;
            }
            MainPage = new HomePage(this,Username,home);//creating the home page
            Application_Handler.viewOnMainPage(MainPage);//viewing homepage on the main application window
        }

        public void viewLoginPage()
        {
            MainPage = new LoginPage(this,controller);//creating the login page
            Application_Handler.viewOnMainPage(MainPage);//viewing homepage on the main application window
        }

        public void viewStudent()
        {
            SecondaryPage = new Student(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewTeacher()
        {
            SecondaryPage = new Teacher(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewStaff()
        {
            SecondaryPage = new Staff(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewBus()
        {
            SecondaryPage = new Bus(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewMail()
        {
            SecondaryPage = new Mail(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewStatistics()
        {
            SecondaryPage = new Statistics(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewSubjects()
        {
            SecondaryPage = new Subject(this,controller);//creating the login page
            Application_Handler.viewOnSecondaryPage(SecondaryPage);//viewing homepage on the main application window
        }

        public void viewMainPage()
        {
            Application_Handler.viewMainPage();
        }
        public void ApplicationMouseDown(object sender, MouseEventArgs e)
        {
            Application_Handler.Application_MouseDown(sender, e);
        }
        public void ApplicationMouseMove(object sender, MouseEventArgs e)
        {
            Application_Handler.Application_MouseMove(sender, e);
        }
        public void ApplicationMouseUp(object sender, MouseEventArgs e)
        {
            Application_Handler.Application_MouseUp(sender, e);
        }
        public void Logout()
        {
            MainPage = new LoginPage(this,controller);//creating the login page
            Application_Handler.viewOnMainPage(MainPage);//viewing homepage on the main application window
        }

    }//View CLASS END
}
