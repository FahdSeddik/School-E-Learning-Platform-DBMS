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
{
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> Subject) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //VIEW Subject USERCONTROL
    public partial class AddSubject : AUVSubject
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //NON DEFAULT CONSTRUCTOR
        public AddSubject(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
                                                 //filling textboxes with the selected Subject data
                                                 //it send query to retrive selected Subject data
                                                 //and fills textboxes with selected Subject information
            DataTable Yearslist = getYearslist();
            SubjYear_CBox.DisplayMember = "std_Year"; //displaying std_Year column from datatable "Yearslist"
            SubjYear_CBox.ValueMember = "std_Year"; //linking value to std_year column from datatable "YearsList"
            SubjYear_CBox.DataSource = Yearslist; //linking yearslist comboobox and yearlist datatable

            DataTable BuildingList = controllerObj.getBuildingList();
            SubjBuilding_CBox.DisplayMember = "r_Building_Num";//displaying std_Year column from datatable "Yearslist"
            SubjBuilding_CBox.ValueMember = "r_Building_Num"; //linking value to std_year column from datatable "YearsList"
            SubjBuilding_CBox.DataSource = BuildingList; //linking yearslist comboobox and yearlist datatable

            DataTable FloorsList = controllerObj.getFloorsList();
            SubjFloor_CBox.DisplayMember = "r_Floor";//displaying std_Year column from datatable "Yearslist"
            SubjFloor_CBox.ValueMember = "r_Floor"; //linking value to std_year column from datatable "YearsList"
            SubjFloor_CBox.DataSource = FloorsList; //linking yearslist comboobox and yearlist datatable

            DataTable Roomslist = controllerObj.getRooms();
            SubjRoom_CBox.DisplayMember = "r_Num"; //displaying std_Year column from datatable "Yearslist"
            SubjRoom_CBox.ValueMember = "r_Num"; //linking value to std_year column from datatable "YearsList"
            SubjRoom_CBox.DataSource = Roomslist; //linking yearslist comboobox and yearlist datatable

            DataTable Dayslist = getWeekDays();
            SubjDay_CBox.DisplayMember = "Day"; //displaying std_Year column from datatable "Yearslist"
            SubjDay_CBox.ValueMember = "Day"; //linking value to std_year column from datatable "YearsList"
            SubjDay_CBox.DataSource = Dayslist; //linking yearslist comboobox and yearlist datatable

            DataTable DayTimes1 = getDayTimes();
            DataTable DayTimes2 = getDayTimes();
            SubjStartT_CBox.DisplayMember = "Time"; //displaying std_Year column from datatable "Yearslist"
            SubjStartT_CBox.ValueMember = "Time"; //linking value to std_year column from datatable "YearsList"
            SubjStartT_CBox.DataSource = DayTimes1; //linking yearslist comboobox and yearlist datatable
            SubjEndT_CBox.DisplayMember = "Time"; //displaying std_Year column from datatable "Yearslist"
            SubjEndT_CBox.ValueMember = "Time"; //linking value to std_year column from datatable "YearsList"
            SubjEndT_CBox.DataSource = DayTimes2; //linking yearslist comboobox and yearlist datatable

            DataTable DepartmentsList = controllerObj.getDepartmentslist();
            SubjDep_CBox.DisplayMember = "dep_Name"; //displaying std_Year column from datatable "Yearslist"
            SubjDep_CBox.ValueMember = "dep_ID"; //linking value to std_year column from datatable "YearsList"
            SubjDep_CBox.DataSource = DepartmentsList; //linking yearslist comboobox and yearlist datatable

            DataTable TeachersList = controllerObj.getteachersOfDepartment(SubjDep_CBox.SelectedValue.ToString());
            SubjTeach_CBox.DisplayMember = "staff_Name";//displaying std_Year column from datatable "Yearslist"
            SubjTeach_CBox.ValueMember = "staff_ID"; //linking value to std_year column from datatable "YearsList"
            SubjTeach_CBox.DataSource = TeachersList; //linking yearslist comboobox and yearlist datatable
            updateSubjectID();
            EditControls();
        }
       protected override void EditControls()
        {
            Tittle_Lbl.Text = "Add Subject"; //changes control title text to update Subject
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            Submit_Btn.Visible = false; //hides submit button as view doesn't use it
            StdSub_Pnl.Visible = false;
            StaffSub_Pnl.Visible = false;
            SubjSub_Pnl.BringToFront();
            this.Controls.Remove(StaffSub_Pnl);
            this.Controls.Remove(StdSub_Pnl);
            SubjInfo_Pnl.Visible = false;
            SubjTeach_Pnl.Visible = false;
            SubjTimeAndLoc_Pnl.Dock = DockStyle.Top;
        }
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            //checks if there a empty required data (empty textboxs)
            //loops on each textbox in the control
            //if the all the data entered by the user is valid
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres

                int queryRes = controllerObj.AddSubject(SubjID_Txt.Text.ToString(), SubjDep_CBox.Text.ToString(), SubjName_Txt.Text.ToString(), int.Parse(SubjYear_CBox.SelectedValue.ToString()), SubjTeach_CBox.SelectedValue.ToString(), int.Parse(SubjBuilding_CBox.SelectedValue.ToString()), int.Parse(SubjFloor_CBox.SelectedValue.ToString()), int.Parse(SubjRoom_CBox.SelectedValue.ToString()), SubjStartT_CBox.SelectedValue.ToString(),SubjEndT_CBox.SelectedValue.ToString(), SubjDay_CBox.SelectedValue.ToString());

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new Subject failed, revise Subject information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Inserted a new Subject Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    viewController.CloseSubTab();//reset the panel to be ready for the next insertion
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete Subject
                    //resets all textboxes text, clear error message...etc
                    return; //return
                }
            }
            catch (Exception error) //if any unexpected error while converting any string to string or query fail
            {
                //inform the user that the data is invalid
                RJMessageBox.Show("Invalid data, please correct entered data and try again.",
              "Error",
              MessageBoxButtons.OK,
              MessageBoxIcon.Error);
                return; //return
            }
        }

    }
}
