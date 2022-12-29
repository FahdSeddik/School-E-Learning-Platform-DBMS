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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{   //ADD, UPDATE, DELETE Subject USERCONTROL BASE USERCONTROL
    //The used abbreviations in the format (abbreviation -> word) 
    //(Teach -> Subject) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //AUDSubjectPARENT USERCONTROL (BASE USERCONTROL FOR ADD Subject, UPDATE Subject, VIEW Subject)
    public partial class AUVSubject : AUVGeneralBase //inherits from usercontrol
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public AUVSubject(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            PrepareControls();
        }
        //overriding onPaint function to change derived class (Add Subject) design
       protected override void EditControls()
        {

        }

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            this.SubjTAndLocNext_Btn.Click += new EventHandler(SubjTAndLocNext_Btn_Click);
            this.SubjTeachNext_Btn.Click += new EventHandler(SubjTeachNext_Btn_Click);
            this.SubjYear_CBox.SelectedIndexChanged+= new EventHandler(SubjYear_CBox_SelectedIndexChanged);
            this.AddRoom_Btn.Click += new EventHandler(AddRoom_Btn_Click);
            this.SubjDep_CBox.SelectedIndexChanged += new EventHandler(SubjDep_CBox_SelectedIndexChanged);
        }


        protected virtual void AddRoom_Btn_Click(object sender, EventArgs e)
        {
            viewController.viewAddRoom();
        }

        protected void SubjYear_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateSubjectID();

        }
        protected void updateSubjectID()
        {
            string test = SubjDep_CBox.Text.ToString();
            if (test.Length < 3)
            {
                StdID_Txt.Text = ""; //empty Subject ID (reset)
                return; //return (do nothing)
            }
            int subjCount = controllerObj.getSubjectsCount(); //retrieves Subject count
                subjCount++; //increments Subject count by 1 i.e if Subjects count is = 3 means the Subject that will be added is the 4th Subject no the 3th
                string formattedSubjectCount = string.Format("{0:000}", subjCount); //formatting Subjects count to 5 digits and padding with zeros if needed i Subjects count is 300 it will be 00300 and if 45000 it will be 45000
            char[] Department = SubjDep_CBox.Text.ToCharArray();//converting SSN to array of characters to access characters (first 2 digits)
            string year = string.Format("{0:00}", SubjYear_CBox.SelectedValue); //converting graduation year textbox text to integer to use to calculate graduation year
                                                                                                       //calculates graduation year depending on the current year and converting to characters array to acces its characters (last 2 digits)
                                                                                                       //note that this calculates depending on the real year in the world (datetime.now.year) so its updated with the real time year (only when adding a new Subject not in updating Subject information)
                                                                                                       //created Subject ID with the specfied format
            SubjID_Txt.Text = Department[0].ToString()+ Department[1].ToString()+ Department[2].ToString() + year + formattedSubjectCount;
            return;
        }

        protected virtual void  SubjTAndLocNext_Btn_Click(object sender, EventArgs e)
        {
            int res = controllerObj.checkTimeAndLocation(int.Parse(SubjRoom_CBox.SelectedValue.ToString()), SubjStartT_CBox.SelectedValue.ToString(), SubjEndT_CBox.SelectedValue.ToString(), SubjDay_CBox.SelectedValue.ToString());
            if(res == 0)
            {
                SubjTeach_Pnl.BringToFront();
                SubjTeach_Pnl.Visible = true;
                SubjTeach_Pnl.Dock = DockStyle.Top;
                HideSubjTAndLocErrorMsg();
                LockTimeAndLoc();
               
            }
            else
            {
                showSubjTAndLocErrorMsg("the selected time and location are taken, please try again or add a new room");
            }
        }

        protected void showSubjTAndLocErrorMsg(string errorMsg)
        {
            SubjTimeAndLocErrorMsg_Lbl.Text = errorMsg;
            SubjTimeAndLocErrorMsg_Lbl.Show();
        }
        protected void HideSubjTAndLocErrorMsg()
        {
            SubjTimeAndLocErrorMsg_Lbl.Hide();
        }

        protected virtual void SubjTeachNext_Btn_Click(object sender, EventArgs e)
        {
            int res = controllerObj.checkSubjectTeacher(SubjTeach_CBox.SelectedValue.ToString(), SubjStartT_CBox.SelectedValue.ToString(), SubjEndT_CBox.SelectedValue.ToString(), SubjDay_CBox.SelectedValue.ToString());
            if (res == 0)
            {
                SubjInfo_Pnl.BringToFront();
                SubjInfo_Pnl.Visible = true;
                SubjInfo_Pnl.Dock = DockStyle.Top;
                HideSubjTeachMsg();
                LockTeacher();
                Submit_Btn.Visible = true;
            
            }
            else
            {
                showSubjTeachMsg("this teacher is not available at the selected time and location, please choose another teacher");
            }   
        }

        protected virtual void SubjDep_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable TeachersList = controllerObj.getteachersOfDepartment(SubjDep_CBox.SelectedValue.ToString());
            SubjTeach_CBox.DisplayMember = "staff_Name";//displaying std_Year column from datatable "Yearslist"
            SubjTeach_CBox.ValueMember = "staff_ID"; //linking value to std_year column from datatable "YearsList"
            SubjTeach_CBox.DataSource = TeachersList; //linking yearslist comboobox and yearlist datatable
            updateSubjectID();
        }

        protected void showSubjTeachMsg(string errorMsg)
        {
            SubjTeachErrorMsg_Pnl.Text = errorMsg;
            SubjTeachErrorMsg_Pnl.Show();
        }
        protected void HideSubjTeachMsg()
        {

            SubjTeachErrorMsg_Pnl.Hide();
        }

        protected virtual void LockTimeAndLoc()
        {
            SubjTimeAndLoc_Pnl.BackColor = Color.FromName("Control");
            foreach (Control item in SubjTimeAndLoc_Pnl.Controls) //loop on each item in the panel
            {
                if (item is Guna2TextBox) //if the item is textbox
                {
                    Guna2TextBox textBox = (Guna2TextBox)item; //cast item to textbox to use textbox functionalities
                    textBox.Enabled = false; //make all textboxes unenabled (read only)
                }
                else if (item is Guna2ComboBox)
                {
                    Guna2ComboBox comboobox = (Guna2ComboBox)item; //cast item to comboBox to use comboBox functionalities
                    comboobox.Enabled = false; //make all combooboxes unenabled (read only)
                }
                else if (item is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)item;
                    button.Enabled = false;
                }
             }
         }
   
        protected virtual void LockTeacher()
        {
            SubjTeach_Pnl.BackColor = Color.FromName("Control");
            foreach (Control item in SubjTeach_Pnl.Controls) //loop on each item in the panel
            {
                if (item is Guna2TextBox) //if the item is textbox
                {
                    Guna2TextBox textBox = (Guna2TextBox)item; //cast item to textbox to use textbox functionalities
                    textBox.Enabled = false; //make all textboxes unenabled (read only)
                }
                else if (item is Guna2ComboBox)
                {
                    Guna2ComboBox comboobox = (Guna2ComboBox)item; //cast item to comboBox to use comboBox functionalities
                    comboobox.Enabled = false; //make all combooboxes unenabled (read only)
                }
                else if (item is Guna2Button)
                {
                    Guna2Button button = (Guna2Button)item;
                    button.Enabled = false;
                }
            }
        }

        protected DataTable getYearslist()
        {
            DataTable yearsList = new DataTable(); //gets years in datatable column type int 
            yearsList.Columns.Add("std_Year"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("1"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("2"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("3"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("4"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("5"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("6"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("7"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("8"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("9"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("10"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("11"); //converting each row value to string and adding on the string list
            yearsList.Rows.Add("12"); //converting each row value to string and adding on the string list
            return yearsList; //returns the string list (All,1,2,3,4...etc)
        }

        protected virtual void FillData(string subjID, int BuildNum, int FloorNum, int roomID, String Day, string Time)
        {
            DataTable SubjInformation;//creating datatable object to retrive Subjs information
            //to fill textboxes with Subjinformation (View Subj information or update Subj information)
            SubjInformation = controllerObj.getSubjectData(subjID, BuildNum, FloorNum, roomID, Day, Time);
 

            SubjName_Txt.Text = SubjInformation.Rows[0][0].ToString();//filling Subj name textbox with the selectd Subj name
            SubjID_Txt.Text = SubjInformation.Rows[0][1].ToString();

            DataTable Yearslist = getYearslist();
            SubjYear_CBox.DisplayMember = "std_Year"; //displaying std_Year column from datatable "Yearslist"
            SubjYear_CBox.ValueMember = "std_Year"; //linking value to std_year column from datatable "YearsList"
            SubjYear_CBox.DataSource = Yearslist; //linking yearslist comboobox and yearlist datatable
            string test = SubjInformation.Rows[0][2].ToString();
            SubjYear_CBox.SelectedIndex = SubjYear_CBox.FindString(test); //in

            DataTable Roomslist = controllerObj.getRooms();
            SubjRoom_CBox.DisplayMember = "r_Num"; //displaying std_Year column from datatable "Yearslist"
            SubjRoom_CBox.ValueMember = "r_Num"; //linking value to std_year column from datatable "YearsList"
            SubjRoom_CBox.DataSource = Roomslist; //linking yearslist comboobox and yearlist datatable
            SubjRoom_CBox.SelectedIndex = SubjRoom_CBox.FindString(SubjInformation.Rows[0][3].ToString()); //in


            DataTable Dayslist = getWeekDays();
            SubjDay_CBox.DisplayMember = "Day"; //displaying std_Year column from datatable "Yearslist"
            SubjDay_CBox.ValueMember = "Day"; //linking value to std_year column from datatable "YearsList"
            SubjDay_CBox.DataSource = Dayslist; //linking yearslist comboobox and yearlist datatable
            SubjDay_CBox.SelectedIndex = SubjDay_CBox.FindString(SubjInformation.Rows[0][4].ToString()); //in

            DataTable DayTimes1 = getDayTimes();
            DataTable DayTimes2 = getDayTimes();
            SubjStartT_CBox.DisplayMember = "Time"; //displaying std_Year column from datatable "Yearslist"
            SubjStartT_CBox.ValueMember = "Time"; //linking value to std_year column from datatable "YearsList"
            SubjStartT_CBox.DataSource = DayTimes1; //linking yearslist comboobox and yearlist datatable
            SubjEndT_CBox.DisplayMember = "Time"; //displaying std_Year column from datatable "Yearslist"
            SubjEndT_CBox.ValueMember = "Time"; //linking value to std_year column from datatable "YearsList"
            SubjEndT_CBox.DataSource = DayTimes2; //linking yearslist comboobox and yearlist datatable
            SubjStartT_CBox.SelectedIndex = SubjStartT_CBox.FindString(SubjInformation.Rows[0][5].ToString()); //in
            SubjEndT_CBox.SelectedIndex = SubjEndT_CBox.FindString(SubjInformation.Rows[0][6].ToString()); //in

            DataTable DepartmentsList = controllerObj.getDepartmentslist();
            SubjDep_CBox.DisplayMember = "dep_Name"; //displaying std_Year column from datatable "Yearslist"
            SubjDep_CBox.ValueMember = "dep_ID"; //linking value to std_year column from datatable "YearsList"
            SubjDep_CBox.DataSource = DepartmentsList; //linking yearslist comboobox and yearlist datatable
            SubjDep_CBox.SelectedIndex = SubjDep_CBox.FindString(SubjInformation.Rows[0][7].ToString()); //in

            DataTable TeachersList = controllerObj.getteachersOfDepartment(SubjInformation.Rows[0][8].ToString());
            SubjTeach_CBox.DisplayMember = "staff_Name";//displaying std_Year column from datatable "Yearslist"
            SubjTeach_CBox.ValueMember = "staff_ID"; //linking value to std_year column from datatable "YearsList"
            SubjTeach_CBox.DataSource = TeachersList; //linking yearslist comboobox and yearlist datatable
            SubjTeach_CBox.SelectedIndex = SubjTeach_CBox.FindString(SubjInformation.Rows[0][9].ToString()); //in

            DataTable BuildingList = controllerObj.getBuildingList();
            SubjBuilding_CBox.DisplayMember = "r_Building_Num";//displaying std_Year column from datatable "Yearslist"
            SubjBuilding_CBox.ValueMember = "r_Building_Num"; //linking value to std_year column from datatable "YearsList"
            SubjBuilding_CBox.DataSource = BuildingList; //linking yearslist comboobox and yearlist datatable
            SubjBuilding_CBox.SelectedIndex = SubjBuilding_CBox.FindString(SubjInformation.Rows[0][11].ToString()); //in

            DataTable FloorsList = controllerObj.getFloorsList();
            SubjFloor_CBox.DisplayMember = "r_Floor";//displaying std_Year column from datatable "Yearslist"
            SubjFloor_CBox.ValueMember = "r_Floor"; //linking value to std_year column from datatable "YearsList"
            SubjFloor_CBox.DataSource = FloorsList; //linking yearslist comboobox and yearlist datatable
            SubjFloor_CBox.SelectedIndex = SubjFloor_CBox.FindString(SubjInformation.Rows[0][12].ToString()); //in

        }
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {

        }

            protected DataTable getWeekDays()
        {
            DataTable WeekDays = new DataTable();
            WeekDays.Columns.Add("Day");
            WeekDays.Rows.Add("Saturday");
            WeekDays.Rows.Add("Sunday");
            WeekDays.Rows.Add("Monday");
            WeekDays.Rows.Add("Tuesday");
            WeekDays.Rows.Add("Wednesday");
            WeekDays.Rows.Add("Thursday");
            return WeekDays;
        }

        protected DataTable getDayTimes()
        {
            DataTable DayTimes = new DataTable();
            DayTimes.Columns.Add("Time");
            DayTimes.Rows.Add("00:00:00");
            DayTimes.Rows.Add("01:00:00");
            DayTimes.Rows.Add("02:00:00");
            DayTimes.Rows.Add("03:00:00");
            DayTimes.Rows.Add("04:00:00");
            DayTimes.Rows.Add("05:00:00");
            DayTimes.Rows.Add("06:00:00");
            DayTimes.Rows.Add("07:00:00");
            DayTimes.Rows.Add("08:00:00");
            DayTimes.Rows.Add("09:00:00");
            DayTimes.Rows.Add("10:00:00");
            DayTimes.Rows.Add("11:00:00");
            DayTimes.Rows.Add("12:00:00");
            DayTimes.Rows.Add("13:00:00");
            DayTimes.Rows.Add("14:00:00");
            DayTimes.Rows.Add("15:00:00");
            DayTimes.Rows.Add("16:00:00");
            DayTimes.Rows.Add("17:00:00");
            DayTimes.Rows.Add("18:00:00");
            DayTimes.Rows.Add("19:00:00");
            DayTimes.Rows.Add("20:00:00");
            DayTimes.Rows.Add("21:00:00");
            DayTimes.Rows.Add("22:00:00");
            DayTimes.Rows.Add("23:00:00");
            DayTimes.Rows.Add("24:00:00");
            return DayTimes;

        }



    }
}
