using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //ADD, UPDATE, DELETE STUDENT USERCONTROL BASE USERCONTROL
    //The used abbreviations in the format (abbreviation -> word) 
    //(Teach -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //AUDSTUDENTPARENT USERCONTROL (BASE USERCONTROL FOR ADD STUDENT, UPDATE STUDENT, VIEW STUDENT)
    public partial class ADUTeacherParent : AUVStaffBase //inherits from usercontrol
    {

        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public ADUTeacherParent(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            PrepareControls();
        }
        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "Teacher";
            StaffSub_Pnl.Visible = true;
            StaffSub_Pnl.BringToFront();
            this.Controls.Remove(StdSub_Pnl);
            StaffPos_CBox.Visible = false;
            StaffPosReq_Lbl.Visible = false;
            StaffPos_Lbl.Visible = false;
            StaffDepReq_Lbl.Location = StaffPos_Lbl.Location;
            StaffDep_CBox.Location = StaffPos_CBox.Location;
            StaffDep_Lbl.Location = StaffPos_Lbl.Location;
        }

        protected override void FillData(string TeachID)
        {
            DataTable TeacherInformation;//creating datatable object to retrive Teachers information
            //to fill textboxes with Teacherinformation (View Teacher information or update Teacher information)
            TeacherInformation = controllerObj.getTeacherData(TeachID);
            //query to check if this Teacher is graduated or current Teacher
            //note that getGradTeacherData and getCurrentTeacherData retrives Teacher information in datatable that differs only in the last column
            //last column of getCurrentTeacherData is TeacherYear as current Teacher doesn't have university yet
            //last column of getGradTeacherData is university as graduate Teacher doesn't have a year (graduated) 
            //filling the common data between both

            StaffName_Txt.Text = TeacherInformation.Rows[0][0].ToString();//filling Teacher name textbox with the selectd Teacher name
            StaffID_Txt.Text = TeacherInformation.Rows[0][1].ToString();//filling Teacher ID textbox with the selectd Teacher ID
            StaffEmail_Txt.Text = TeacherInformation.Rows[0][2].ToString();//filling Teacher email textbox with the selectd Teacher email
            StaffSSN_Txt.Text = TeacherInformation.Rows[0][3].ToString();//filling Teacher SSN textbox with the selectd Teacher SSN
            StaffAdress_Txt.Text = TeacherInformation.Rows[0][4].ToString();//filling Teacher ID textbox with the selectd Teacher ID
            StaffPNum_Txt.Text = TeacherInformation.Rows[0][5].ToString();//filling Teacher phone number textbox with the selectd Teacher phone number
            StaffSalary_Txt.Text = TeacherInformation.Rows[0][6].ToString();//filling Teacher phone number textbox with the selectd Teacher phone number
            StaffFullTime_CHBox.Checked = bool.Parse(TeacherInformation.Rows[0][7].ToString());
            DataTable Departmentslist = controllerObj.getDepartmentslist();
            StaffDep_CBox.DisplayMember = "dep_Name"; //displaying std_Year column from datatable "Yearslist"
            StaffDep_CBox.ValueMember = "dep_ID"; //linking value to std_year column from datatable "YearsList"
            StaffDep_CBox.DataSource = Departmentslist; //linking yearslist comboobox and yearlist datatable
            StaffDep_CBox.SelectedIndex = StaffDep_CBox.FindString(TeacherInformation.Rows[0][8].ToString()); //initially selecting the first element which is "All"
                                                                                                              //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
        }


    }
}
