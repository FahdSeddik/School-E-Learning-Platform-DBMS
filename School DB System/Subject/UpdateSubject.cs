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
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //VIEW STUDENT USERCONTROL
    public partial class UpdateSubject : AUVSubject
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
        int oldRoomNum;
        string oldStartTime, oldEndTime, oldDay,oldTeacherID;

        //NON DEFAULT CONSTRUCTOR
        public UpdateSubject(ViewController viewController, Controller controllerObj, string subjID, int buildingNum, int floorNum, int roomID, String Day, string Time) : base(viewController, controllerObj) //sends base class parameters
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            FillData(subjID, buildingNum, floorNum, roomID, Day, Time); //filling textboxes with the selected student data
            //it send query to retrive selected student data
            //and fills textboxes with selected student information
            oldRoomNum = int.Parse(SubjRoom_CBox.SelectedValue.ToString());
            oldStartTime = SubjStartT_CBox.SelectedValue.ToString();
            oldEndTime = SubjEndT_CBox.SelectedValue.ToString();
            oldDay = SubjDay_CBox.SelectedValue.ToString();
            oldTeacherID = SubjTeach_CBox.SelectedValue.ToString();
            EditControls();
        }
       protected override void EditControls()
        {
            Tittle_Lbl.Text = "Update Subject"; //changes control title text to update student
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
            AddRoom_Btn.Enabled = false;

            SubjDep_CBox.Enabled = false;
            SubjYear_CBox.Enabled = false;

        }
        protected override void SubjTAndLocNext_Btn_Click(object sender, EventArgs e)
        {
            int res;
            if (int.Parse(SubjRoom_CBox.SelectedValue.ToString()) == oldRoomNum && SubjStartT_CBox.SelectedValue.ToString() == oldStartTime && SubjEndT_CBox.SelectedValue.ToString() == oldEndTime && SubjDay_CBox.SelectedValue.ToString() == oldDay)
            {
                res = 0;
            }
            else
            {
                res = controllerObj.checkTimeAndLocation(int.Parse(SubjRoom_CBox.SelectedValue.ToString()), SubjStartT_CBox.SelectedValue.ToString(), SubjEndT_CBox.SelectedValue.ToString(), SubjDay_CBox.SelectedValue.ToString());
            }
           
            if (res == 0)
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
       
        protected override void SubjTeachNext_Btn_Click(object sender, EventArgs e)
        {
            int res;
            if (int.Parse(SubjRoom_CBox.SelectedValue.ToString()) == oldRoomNum && SubjStartT_CBox.SelectedValue.ToString() == oldStartTime && SubjEndT_CBox.SelectedValue.ToString() == oldEndTime && SubjDay_CBox.SelectedValue.ToString() == oldDay && SubjTeach_CBox.SelectedValue.ToString() == oldTeacherID)
            {
                res = 0;
            }
            else
            {
                res = controllerObj.checkSubjectTeacher(SubjTeach_CBox.SelectedValue.ToString(), SubjStartT_CBox.SelectedValue.ToString(), SubjEndT_CBox.SelectedValue.ToString(), SubjDay_CBox.SelectedValue.ToString());
            }
               
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

        protected override void SubjDep_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable TeachersList = controllerObj.getteachersOfDepartment(SubjDep_CBox.SelectedValue.ToString());
            SubjTeach_CBox.DisplayMember = "staff_Name";//displaying std_Year column from datatable "Yearslist"
            SubjTeach_CBox.ValueMember = "staff_ID"; //linking value to std_year column from datatable "YearsList"
            SubjTeach_CBox.DataSource = TeachersList; //linking yearslist comboobox and yearlist datatable
           
        }


        //Submit button click event
        //submits the updated information
        //sends query to database to update student information
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            //checks if there a empty required data (empty textboxs)
            //loops on each textbox in the control
            //if the all the data entered by the user is valid
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres
                int queryRes = 0;//intially = 0
                int oldRoomBuildingNum,RoomBuildingNum,oldRoomFLoor,roomFLoor;
                DataTable oldRoomData = controllerObj.getRoomData(oldRoomNum);
                DataTable newRoomData = controllerObj.getRoomData(int.Parse(SubjRoom_CBox.SelectedValue.ToString()));
                oldRoomBuildingNum = int.Parse(oldRoomData.Rows[0][0].ToString());
                oldRoomFLoor = int.Parse(oldRoomData.Rows[0][1].ToString());
                RoomBuildingNum = int.Parse(newRoomData.Rows[0][0].ToString());
                roomFLoor = int.Parse(newRoomData.Rows[0][1].ToString());

                queryRes = controllerObj.UpdateSubject(SubjID_Txt.Text.ToString(), SubjName_Txt.Text.ToString(), SubjDep_CBox.Text.ToString(),int.Parse(SubjYear_CBox.SelectedValue.ToString()), SubjTeach_CBox.SelectedValue.ToString(),oldRoomBuildingNum,RoomBuildingNum,oldRoomFLoor,roomFLoor,oldRoomNum, int.Parse(SubjRoom_CBox.SelectedValue.ToString()),oldStartTime, SubjStartT_CBox.SelectedValue.ToString(), oldEndTime, SubjEndT_CBox.SelectedValue.ToString(), oldDay, SubjDay_CBox.SelectedValue.ToString());

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Student Information couldn't be updated, revise student information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Student information updated successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    viewController.CloseSubTab();
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
