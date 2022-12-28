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
    //(Staff -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //AUDSTUDENTPARENT USERCONTROL (BASE USERCONTROL FOR ADD STUDENT, UPDATE STUDENT, VIEW STUDENT)
    public partial class AUVStaffBase : BaseAUV //inherits from usercontrol
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object
                                  //non default constructor
        public AUVStaffBase(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
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
            this.StaffSalary_Txt.TextChanged += new System.EventHandler(this.StaffSalary_Txt_TextChanged);
            this.StaffSalary_Txt.Leave += new System.EventHandler(this.StaffSalary_Txt_TextChanged);
            this.StaffPNum_Txt.TextChanged += new System.EventHandler(this.StaffPNum_txt_TextChanged);
            this.StaffPNum_Txt.Leave += new System.EventHandler(this.StaffPNum_txt_TextChanged);
            this.StaffName_Txt.TextChanged += new System.EventHandler(this.StaffName_Txt_TextChanged);
            this.StaffName_Txt.Leave += new System.EventHandler(this.StaffName_Txt_TextChanged);
            this.StaffSSN_Txt.TextChanged += new System.EventHandler(this.StaffSSN_txt_TextChanged);
            this.StaffSSN_Txt.Leave += new System.EventHandler(this.StaffSSN_txt_TextChanged);
        }

        protected override void FillData(string StaffID)
        {
            DataTable StaffInformation;//creating datatable object to retrive Staffs information
            //to fill textboxes with Staffinformation (View Staff information or update Staff information)
            StaffInformation = controllerObj.getStaffData(StaffID);
            DataTable TeacherInformation;//creating datatable object to retrive Teachers information
            //to fill textboxes with Teacherinformation (View Teacher information or update Teacher information)
            TeacherInformation = controllerObj.getTeacherData(StaffID);
            //query to check if this Staff is graduated or current Staff
            //note that getGradStaffData and getCurrentStaffData retrives Staff information in datatable that differs only in the last column
            //last column of getCurrentStaffData is StaffYear as current Staff doesn't have university yet
            //last column of getGradStaffData is university as graduate Staff doesn't have a year (graduated) 
            //filling the common data between both

            StaffName_Txt.Text = StaffInformation.Rows[0][0].ToString();//filling Staff name textbox with the selectd Staff name
            StaffID_Txt.Text = StaffInformation.Rows[0][1].ToString();//filling Staff ID textbox with the selectd Staff ID
            StaffEmail_Txt.Text = StaffInformation.Rows[0][2].ToString();//filling Staff email textbox with the selectd Staff email
            StaffSSN_Txt.Text = StaffInformation.Rows[0][3].ToString();//filling Staff SSN textbox with the selectd Staff SSN
            StaffAdress_Txt.Text = StaffInformation.Rows[0][4].ToString();//filling Staff ID textbox with the selectd Staff ID
            StaffPNum_Txt.Text = StaffInformation.Rows[0][5].ToString();//filling Staff phone number textbox with the selectd Staff phone number
            StaffSalary_Txt.Text = StaffInformation.Rows[0][6].ToString();//filling Staff phone number textbox with the selectd Staff phone number
            StaffFullTime_CHBox.Checked = bool.Parse(StaffInformation.Rows[0][7].ToString());
            if(TeacherInformation != null)
            {

                DataTable Departmentslist = controllerObj.getDepartmentslist();
                StaffDep_CBox.DisplayMember = "dep_Name"; //displaying std_Year column from datatable "Yearslist"
                StaffDep_CBox.ValueMember = "dep_ID"; //linking value to std_year column from datatable "YearsList"
                StaffDep_CBox.DataSource = Departmentslist; //linking yearslist comboobox and yearlist datatable
                StaffDep_CBox.SelectedIndex = StaffDep_CBox.FindString(TeacherInformation.Rows[0][8].ToString()); //initially selecting the first element which is "All"
                                                                                   //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
                DataTable PositonsList = controllerObj.getStaffPostionslist();
                StaffPos_CBox.DisplayMember = "staff_Position"; //displaying std_Year column from datatable "Yearslist"
                StaffPos_CBox.ValueMember = "staff_LevelAuth"; //linking value to std_year column from datatable "YearsList"
                StaffPos_CBox.DataSource = PositonsList; //linking yearslist comboobox and yearlist datatable
                StaffPos_CBox.SelectedIndex = StaffPos_CBox.FindString("teacher"); //initially selecting the first element which is "All"
                                                                                                                //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)
            }
            else
            {
                DataTable PositonsList = controllerObj.getStaffPostionslist();
                StaffPos_CBox.DisplayMember = "staff_Position"; //displaying std_Year column from datatable "Yearslist"
                StaffPos_CBox.ValueMember = "staff_LevelAuth"; //linking value to std_year column from datatable "YearsList"
                StaffPos_CBox.DataSource = PositonsList; //linking yearslist comboobox and yearlist datatable
                StaffPos_CBox.SelectedIndex = StaffPos_CBox.FindString(StaffInformation.Rows[0][8].ToString()); //initially selecting the first element which is "All"
                                                 //adding SelectedIndexChanged event to the template comboobox which will be (StateList_CBox)

            }
        }
        private void StaffSalary_Txt_TextChanged(object sender, EventArgs e)
        {
            if (StaffSalary_Txt.Text.ToString() == "") //if name text is equal to "" i.e there is no data entered (empty textbox)
            {
                //informing the user with the Error
                showErrorMessage("invalid Salary, please inert a valid salary"); //informing the user with a suitable message
                StaffSalary_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else if (StaffSalary_Txt.Text.Any(char.IsLetter)) //if name text contains digits (this is invalid)
            {
                showErrorMessage("invalid Salary, salary can't contain characters, please inert a valid salary"); //informing the user with a suitable message
                StaffSalary_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no digits) or empty textboxs
            {
                //if valid data (no digits or empty textboxs) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StaffSalary_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
        private void StaffPNum_txt_TextChanged(object sender, EventArgs e)
        {
            //if number text length is not out of range (from 8 to 15 digit) this is invalid
            if (StaffPNum_Txt.TextLength < 8 || StaffPNum_Txt.TextLength > 15 || StaffPNum_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid phone number, please inert a valid 8 - 15 numbers"); //informing the user with a suitable message
                StaffPNum_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or invalid mobile number length)
            {
                //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StaffPNum_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
        private void StaffName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (StaffName_Txt.Text.ToString() == "") //if name text is equal to "" i.e there is no data entered (empty textbox)
            {
                //informing the user with the Error
                showErrorMessage("invalid name, please inert a valid name"); //informing the user with a suitable message
                StaffName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else if (StaffName_Txt.Text.Any(char.IsDigit)) //if name text contains digits (this is invalid)
            {
                showErrorMessage("invalid name, names can't contain numbers, please inert a valid name"); //informing the user with a suitable message
                StaffName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no digits) or empty textboxs
            {
                //if valid data (no digits or empty textboxs) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StaffName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
        protected virtual void StaffSSN_txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (StaffSSN_Txt.TextLength < 9 || StaffSSN_Txt.TextLength > 20 || StaffSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 9 - 20 numbers SSN"); //informing the user with a suitable message
                StaffSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StaffSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
    }
}
