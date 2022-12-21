﻿using Guna.UI2.WinForms;
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
{   //ADD, UPDATE, DELETE STUDENT USERCONTROL BASE USERCONTROL
    //The used abbreviations in the format (abbreviation -> word) 
    //(Teach -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //AUDSTUDENTPARENT USERCONTROL (BASE USERCONTROL FOR ADD STUDENT, UPDATE STUDENT, VIEW STUDENT)
    public partial class AUVSubject : BaseAUD //inherits from usercontrol
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
        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {

        }

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            this.SubjTAndLocNext_Btn.Click += new EventHandler(SubjTAndLocNext_Btn_Click);
            this.SubjTeachNext_Btn.Click += new EventHandler(SubjTeachNext_Btn_Click);
        }
       protected void  SubjTAndLocNext_Btn_Click(object sender, EventArgs e)
        {
            SubjTeach_Pnl.BringToFront();
            SubjTeach_Pnl.Visible = true;
            SubjTeach_Pnl.Dock = DockStyle.Top;
            LockTimeAndLoc();

        }
        protected void SubjTeachNext_Btn_Click(object sender, EventArgs e)
        {
            SubjInfo_Pnl.BringToFront();
            SubjInfo_Pnl.Visible = true;
            SubjInfo_Pnl.Dock = DockStyle.Top;
            LockTeacher();
            Submit_Btn.Visible = true;

        }

        protected void LockTimeAndLoc()
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
   
        protected void LockTeacher()
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

        protected virtual void FillData(string subjID, int roomID, String Day, string Time)
        {
            DataTable SubjInformation;//creating datatable object to retrive Subjs information
            //to fill textboxes with Subjinformation (View Subj information or update Subj information)
            SubjInformation = controllerObj.getSubjectData(subjID, roomID, Day, Time);
 

            SubjName_Txt.Text = SubjInformation.Rows[0][0].ToString();//filling Subj name textbox with the selectd Subj name
            SubjID_Txt.Text = SubjInformation.Rows[0][1].ToString();

            DataTable Yearslist = controllerObj.getYears();
            SubjYear_CBox.DisplayMember = "std_Year"; //displaying std_Year column from datatable "Yearslist"
            SubjYear_CBox.ValueMember = "std_Year"; //linking value to std_year column from datatable "YearsList"
            SubjYear_CBox.DataSource = Yearslist; //linking yearslist comboobox and yearlist datatable
            SubjYear_CBox.SelectedIndex = SubjYear_CBox.FindString(SubjInformation.Rows[0][2].ToString()); //in

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
            return DayTimes;

        }



    }
}