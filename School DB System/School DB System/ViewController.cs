using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace School_DB_System
{
    public class ViewController //View Class
    {
        //PRIVATE DATA MEMBERS
        private Application Application_Handler; //Application Handler
        private UserControl MainPage;
        private SSSTPageParent MainTab;
        private BaseAUD SubTab;
        private UserControl TempTab;
        private Controller controller; //contoller object

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
        public int ViewHomePage(int Authority, string Username)
        {
            UserControl SubHome;
            switch (Authority)
            {
                case 1:
                    SubHome = new Adminstrator(this);
                    break;
                case 2:
                    SubHome = new HR(this);
                    break;
                case 3:
                    SubHome = new Accountant(this);
                    break;
                default:
                    return 0;
            }
            HomePage Homepage = new HomePage(this, Username, SubHome);//creating the home page
            MainPage = Homepage;
            Application_Handler.ViewOnMainPage(Homepage);//viewing homepage on the main application window
            return 1;
        }

        public void viewLoginPage()
        {
            LoginPage Loginpage = new LoginPage(this, controller);//creating the login page
            MainPage = Loginpage;
            Application_Handler.ViewOnMainPage(Loginpage);//viewing homepage on the main application window
        }

        public void Logout()
        {
            viewLoginPage();
        }

        public void ViewAddStudent()
        { 
            AddStudent AddStudent = new AddStudent(this, controller);
            SubTab = AddStudent;
            Application_Handler.ViewOnSubTab(AddStudent);//viewing homepage on the main application window
        }
        public void ViewUpdateStudent(string StdID)
        {
            UpdateStudent UpdateStudent = new UpdateStudent(this, controller,StdID);
            SubTab = UpdateStudent;
            Application_Handler.ViewOnSubTab(UpdateStudent);//viewing homepage on the main application window
        }
        public void ViewViewStudent(string StdID)
        {
            ViewStudent ViewStudent = new ViewStudent(this, controller, StdID);
            SubTab = ViewStudent;
            Application_Handler.ViewOnSubTab(ViewStudent);//viewing homepage on the main application window
        }
        public void ViewAddTeacher()
        {
            AddTeacher Addteacher = new AddTeacher(this, controller);
            SubTab = Addteacher;
            Application_Handler.ViewOnSubTab(Addteacher);//viewing homepage on the main application window
        }
        public void ViewUpdateTeacher(string StdID)
        {
            UpdateTeacher Updateteacher = new UpdateTeacher(this, controller, StdID);
            SubTab = Updateteacher;
            Application_Handler.ViewOnSubTab(Updateteacher);//viewing homepage on the main application window
        }
        public void ViewViewTeacher(string StdID)
        {
            ViewTeacher ViewTeacher = new ViewTeacher(this, controller, StdID);
            SubTab = ViewTeacher;
            Application_Handler.ViewOnSubTab(ViewTeacher);//viewing homepage on the main application window
        }

        public void refreshDatagridView()
        {
            MainTab.refreshDatagridView(); //refresh datagrid view after insert or delete student
        } //refresh datagrid view after insert or delete student

        public void viewStudent()
        {
            SSSTPageParent StudentPage = new Student(this, controller);//creating the login page
            MainTab = StudentPage;
            Application_Handler.ViewOnMainTab(StudentPage);//viewing homepage on the main application window
        }

        public void CloseMainTab()
        {
            Application_Handler.CloseMainTab();
        }
        public void CloseSubTab()
        {
            Application_Handler.CloseSubTab();
        }
        public void CloseTempTab()
        {
            Application_Handler.CloseTempTab();
        }

        public void viewTeacher()
        {
            SSSTPageParent TeacherPage = new Teacher(this, controller);//creating the login page
            MainTab = TeacherPage;
            Application_Handler.ViewOnMainTab(TeacherPage);//viewing homepage on the main application window
        }

        public void viewStaff()
        {
            //SSSTPageParent StaffPage = new Staff(this, controller);//creating the login page
           // SSSTPageParent MainTab = StaffPage;
           // Application_Handler.ViewOnMainTab(StaffPage);//viewing homepage on the main application window
        }

        public void viewBus()
        {
           // SSSTPageParent BusPage = new Bus(this, controller);//creating the login page
           // SSSTPageParent MainTab = BusPage;
           // Application_Handler.ViewOnMainTab(BusPage);//viewing homepage on the main application window
        }

        public void viewMail()
        {
            //SSSTPageParent MailPage = new Mail(this, controller);//creating the login page
            // SSSTPageParent MainTab = MailPage;
            // Application_Handler.ViewOnMainTab(MailPage);//viewing homepage on the main application window
        }

        public void viewStatistics()
        {
            //SSSTPageParent StatisticsPage = new Statistics(this, controller);//creating the login page
            // SSSTPageParent MainTab = StatisticsPage;
            // Application_Handler.ViewOnMainTab(StatisticsPage);//viewing homepage on the main application window
        }

        public void viewSubject()
        {
            //SSSTPageParent SubjectPage = new Subject(this, controller);//creating the login page
            // SSSTPageParent MainTab = SubjectPage;
            // Application_Handler.ViewOnMainTab(SubjectPage);//viewing homepage on the main application window
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

    }
}//View CLASS END
