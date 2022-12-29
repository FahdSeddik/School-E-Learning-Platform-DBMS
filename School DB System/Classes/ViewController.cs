using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace School_DB_System
{
    public class ViewController //View Class
    {
        //PRIVATE DATA MEMBERS
        private Application Application_Handler; //Application Handler
        private UserControl MainPage;
        private SecondaryTabBase MainTab;
        private UserControl UCMainTab;
        private AUVGeneralBase SubTab;
        private UserControl UCSubTab;
        private UserControl TempTab;
        private Controller controllerobj; //contoller object

        //Non Default constructor
        public ViewController(Application Application_Handler, Controller controllerobj)
        {
            this.Application_Handler = Application_Handler;//Connecting with Application base (the base form) 
            this.controllerobj = controllerobj;
            viewLoginPage();
        }

        //METHODS

        //View homepage function
        //mainly used on login button click to swtich from login page to homepage
        //takes integer to view the suitable homepage for this user depending on level of authority
        public int ViewHomePage(int Authority, string username)
        {
            //DataTable IDDt = controllerobj.getIDFromUsername(Username);
            //string ID = IDDt.Rows[0][0].ToString();
            UserControl SubHome;
            switch (Authority)
            {
                case 1:
                    SubHome = new Adminstrator(this,controllerobj,username);
                    break;
                case 2:
                    SubHome = new HR(this, controllerobj, username);
                    break;
                case 3:
                    SubHome = new Accountant(this, controllerobj, username);
                    break;
                default:
                    return 0;
            }

            HomePage Homepage = new HomePage(this, username, SubHome);//creating the home page
            MainPage = Homepage;
            Application_Handler.ViewOnMainPage(Homepage);//viewing homepage on the main application window
            return 1;
        }

        public void viewLoginPage()
        {
            LoginPage Loginpage = new LoginPage(this, controllerobj);//creating the login page
            MainPage = Loginpage;
            Application_Handler.ViewOnMainPage(Loginpage);//viewing homepage on the main application window
        }

        public void Logout()
        {
            viewLoginPage();
        }

        public void ViewAddStudent()
        { 
            AddStudent AddStudent = new AddStudent(this, controllerobj);
            SubTab = AddStudent;
            Application_Handler.ViewOnSubTab(AddStudent);//viewing homepage on the main application window
        }
        public void ViewUpdateStudent(string StdID)
        {
            UpdateStudent UpdateStudent = new UpdateStudent(this, controllerobj,StdID);
            SubTab = UpdateStudent;
            Application_Handler.ViewOnSubTab(UpdateStudent);//viewing homepage on the main application window
        }
        public void ViewViewStudent(string StdID)
        {
            ViewStudent ViewStudent = new ViewStudent(this, controllerobj, StdID);
            SubTab = ViewStudent;
            Application_Handler.ViewOnSubTab(ViewStudent);//viewing homepage on the main application window
        }
        public void ViewAddTeacher()
        {
            AddTeacher Addteacher = new AddTeacher(this, controllerobj);
            SubTab = Addteacher;
            Application_Handler.ViewOnSubTab(Addteacher);//viewing homepage on the main application window
        }
        public void ViewUpdateTeacher(string StdID)
        {
            UpdateTeacher Updateteacher = new UpdateTeacher(this, controllerobj, StdID);
            SubTab = Updateteacher;
            Application_Handler.ViewOnSubTab(Updateteacher);//viewing homepage on the main application window
        }
        public void ViewViewTeacher(string StdID)
        {
            ViewTeacher ViewTeacher = new ViewTeacher(this, controllerobj, StdID);
            SubTab = ViewTeacher;
            Application_Handler.ViewOnSubTab(ViewTeacher);//viewing homepage on the main application window
        }

        public void ViewAddDepartment()
        {
            AddDepartment AddDepartment = new AddDepartment(this, controllerobj);
            SubTab = AddDepartment;
            Application_Handler.ViewOnSubTab(AddDepartment);//viewing homepage on the main application window
        }
        public void ViewUpdateDepartment(string DepID)
        {
            UpdateDepartment UpdateDepartment = new UpdateDepartment(this, controllerobj, DepID);
            SubTab = UpdateDepartment;
            Application_Handler.ViewOnSubTab(UpdateDepartment);//viewing homepage on the main application window
        }

        public void ViewViewDepartment(string DepID)
        {
            ViewDepartment ViewDepartment = new ViewDepartment(this, controllerobj, DepID);
            SubTab = ViewDepartment;
            Application_Handler.ViewOnSubTab(ViewDepartment);//viewing homepage on the main application window
        }

        public void ViewAddStaff()
        {
            AddStaff Addteacher = new AddStaff(this, controllerobj);
           SubTab = Addteacher;
            Application_Handler.ViewOnSubTab(Addteacher);//viewing homepage on the main application window
        }
        public void ViewUpdateStaff(string StdID)
        {
           UpdateStaff UpdateStaff = new UpdateStaff(this, controllerobj, StdID);
           SubTab = UpdateStaff;
           Application_Handler.ViewOnSubTab(UpdateStaff);//viewing homepage on the main application window
        }
        public void ViewViewStaff(string StdID)
        {
           ViewStaff ViewStaff = new ViewStaff(this, controllerobj, StdID);
           SubTab = ViewStaff;
           Application_Handler.ViewOnSubTab(ViewStaff);//viewing homepage on the main application window
        }

        public void ViewViewSubject(string subjID, int roomID, String Day, string Time)
        {
            ViewSubject ViewSubj = new ViewSubject(this, controllerobj,subjID, roomID, Day, Time);
            SubTab = ViewSubj;
            Application_Handler.ViewOnSubTab(ViewSubj);//viewing homepage on the main application window
        }
        public void ViewUpdateSubject(string subjID, int roomID, String Day, string Time)
        {
            UpdateSubject UpdateSubj = new UpdateSubject(this, controllerobj, subjID, roomID, Day, Time);
            SubTab = UpdateSubj;
            Application_Handler.ViewOnSubTab(UpdateSubj);//viewing homepage on the main application window
        }

        public void ViewAddSubject()
        {
            AddSubject AddSubj = new AddSubject(this, controllerobj);
            SubTab = AddSubj;
            Application_Handler.ViewOnSubTab(AddSubj);//viewing homepage on the main application window
        }

        public void ViewViewBus(int BusNum)
        {
            ViewBus ViewBus = new ViewBus(this, controllerobj, BusNum);
            UCSubTab = ViewBus;
            Application_Handler.ViewOnSubTab(ViewBus);//viewing homepage on the main application window
        }
        public void ViewUpdateBus(int BusNum)
        {
            UpdateBus UpdateBus = new UpdateBus(this, controllerobj, BusNum);
            UCSubTab = UpdateBus;
            Application_Handler.ViewOnSubTab(UpdateBus);//viewing homepage on the main application window
        }

        public void viewBusStudentsList(int busNum)
         {

            StudentsList studentsList = new StudentsList(this, controllerobj, busNum);
            UCSubTab = studentsList;
            Application_Handler.ViewOnSubTab(studentsList);//viewing homepage on the main application window

         }

        public void ViewAddBus()
        {
            AddBus AddBus = new AddBus(this, controllerobj);
            UCSubTab = AddBus;
            Application_Handler.ViewOnSubTab(AddBus);//viewing homepage on the main application window
        }

        public void refreshDatagridView()
        {
          MainTab.refreshDatagridView(); //refresh datagrid view after insert or delete student
        } //refresh datagrid view after insert or delete student

        public void viewStudent()
        {
            SecondaryTabBase StudentPage = new Student(this, controllerobj);//creating the login page
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
            SecondaryTabBase TeacherPage = new Teacher(this, controllerobj);//creating the login page
            MainTab = TeacherPage;
            Application_Handler.ViewOnMainTab(TeacherPage);//viewing homepage on the main application window
        }

        public void viewStaff()
        {
            SecondaryTabBase StaffPage = new Staff(this, controllerobj);//creating the login page
            MainTab = StaffPage;
            Application_Handler.ViewOnMainTab(StaffPage);//viewing homepage on the main application window
        }

        public void viewBus()
        {
            SecondaryTabBase BusPage = new Bus(this, controllerobj);//creating the login page
            SecondaryTabBase MainTab = BusPage;
            Application_Handler.ViewOnMainTab(BusPage);//viewing homepage on the main application window
        }

        public void viewRequest(string username)
        {
            Request ReqPage = new Request(this, controllerobj,username);//creating the login page
            MainTab = ReqPage;
            Application_Handler.ViewOnMainTab(ReqPage);//viewing homepage on the main application window
        }

        public void viewStatistics()
        {
            UserControl StatisticsPage = new Statistics(this, controllerobj);//creating the login page
            UCMainTab = StatisticsPage;
            Application_Handler.ViewOnMainTab(StatisticsPage);//viewing homepage on the main application window
        }

        public void viewDepartment()
        {
            SecondaryTabBase DepartmentPage = new Department(this, controllerobj);//creating the login page
            MainTab = DepartmentPage;
            Application_Handler.ViewOnMainTab(DepartmentPage);//viewing homepage on the main application window
        }

        public void viewSubject()
        {
            SecondaryTabBase SubjectPage = new Subject(this, controllerobj);//creating the login page
            MainTab = SubjectPage;
            Application_Handler.ViewOnMainTab(SubjectPage);//viewing homepage on the main application window
        }

        public void ViewRequest(string username)
        {
            Request RequestPage = new Request(this, controllerobj,username);//creating the login page
            UCMainTab = RequestPage;
            Application_Handler.ViewOnMainTab(RequestPage);//viewing homepage on the main application window
        }

        public void ViewViewRequest(string Email, string Title, string Message,int view)
        {
            Message ViewReq = new Message(this, controllerobj, Email, Title, Message, view);
            UCSubTab = ViewReq;
            Application_Handler.ViewOnSubTab(ViewReq);//viewing homepage on the main application window
        }

        public void RespondToReq(string senderID,string reciverEmail,string reqID)
        {
            Message RespondToReq = new Message(this, controllerobj, senderID,reciverEmail, reqID);
            UCSubTab = RespondToReq;
            Application_Handler.ViewOnSubTab(RespondToReq);//viewing homepage on the main application window
        }

        public void viewAddRoom()
        {
            AddRoom addRoom = new AddRoom(this, controllerobj);
            TempTab = addRoom;
            Application_Handler.ViewOnTempTab(addRoom);//viewing homepage on the main application window
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
