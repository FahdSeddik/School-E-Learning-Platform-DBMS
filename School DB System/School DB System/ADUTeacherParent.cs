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
    public partial class ADUTeacherParent : BaseAUD //inherits from usercontrol
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
            TeachSub_Pnl.Visible = true;
            TeachSub_Pnl.BringToFront();
            this.Controls.Remove(StdSub_Pnl);
        }

        //adds the needed controls to the usercontrol i.e adding combooboxes and labels and textboxes...etc
        protected override void PrepareControls()
        {
            this.TeachSalary_Txt.TextChanged += new System.EventHandler(this.TeachSalary_Txt_TextChanged);
            this.TeachSalary_Txt.Leave += new System.EventHandler(this.TeachSalary_Txt_TextChanged);
            this.TeachPNum_Txt.TextChanged += new System.EventHandler(this.TeachPNum_txt_TextChanged);
            this.TeachPNum_Txt.Leave += new System.EventHandler(this.TeachPNum_txt_TextChanged);
            this.TeachName_Txt.TextChanged += new System.EventHandler(this.TeachName_Txt_TextChanged);
            this.TeachName_Txt.Leave += new System.EventHandler(this.TeachName_Txt_TextChanged);
            this.TeachSSN_Txt.TextChanged += new System.EventHandler(this.TeachSSN_txt_TextChanged);
            this.TeachSSN_Txt.Leave += new System.EventHandler(this.TeachSSN_txt_TextChanged);
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

            TeachName_Txt.Text = TeacherInformation.Rows[0][0].ToString();//filling Teacher name textbox with the selectd Teacher name
            TeachID_Txt.Text = TeacherInformation.Rows[0][1].ToString();//filling Teacher ID textbox with the selectd Teacher ID
            TeachEmail_Txt.Text = TeacherInformation.Rows[0][2].ToString();//filling Teacher email textbox with the selectd Teacher email
            TeachSSN_Txt.Text = TeacherInformation.Rows[0][3].ToString();//filling Teacher SSN textbox with the selectd Teacher SSN
            TeachAdress_Txt.Text = TeacherInformation.Rows[0][4].ToString();//filling Teacher ID textbox with the selectd Teacher ID
            TeachPNum_Txt.Text = TeacherInformation.Rows[0][5].ToString();//filling Teacher phone number textbox with the selectd Teacher phone number
            TeachSalary_Txt.Text = TeacherInformation.Rows[0][6].ToString();//filling Teacher phone number textbox with the selectd Teacher phone number
            TeachFullTime_CHBox.Checked = bool.Parse(TeacherInformation.Rows[0][7].ToString());
            TeachDep_CBox.Items.Add(TeacherInformation.Rows[0][8].ToString());//
            TeachDep_CBox.SelectedIndex = 0;
        }
        private void TeachSalary_Txt_TextChanged(object sender, EventArgs e)
        {
            if (TeachSalary_Txt.Text.ToString() == "") //if name text is equal to "" i.e there is no data entered (empty textbox)
            {
                //informing the user with the Error
                showErrorMessage("invalid Salary, please inert a valid salary"); //informing the user with a suitable message
                TeachSalary_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else if (TeachSalary_Txt.Text.Any(char.IsLetter)) //if name text contains digits (this is invalid)
            {
                showErrorMessage("invalid Salary, salary can't contain characters, please inert a valid salary"); //informing the user with a suitable message
                TeachSalary_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no digits) or empty textboxs
            {
                //if valid data (no digits or empty textboxs) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                TeachSalary_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
        private void TeachPNum_txt_TextChanged(object sender, EventArgs e)
        {
            //if number text length is not out of range (from 8 to 15 digit) this is invalid
            if (TeachPNum_Txt.TextLength < 8 || TeachPNum_Txt.TextLength > 15 || TeachPNum_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid phone number, please inert a valid 8 - 15 numbers"); //informing the user with a suitable message
                TeachPNum_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or invalid mobile number length)
            {
                //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                TeachPNum_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
        private void TeachName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (TeachName_Txt.Text.ToString() == "") //if name text is equal to "" i.e there is no data entered (empty textbox)
            {
                //informing the user with the Error
                showErrorMessage("invalid name, please inert a valid name"); //informing the user with a suitable message
                TeachName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else if (TeachName_Txt.Text.Any(char.IsDigit)) //if name text contains digits (this is invalid)
            {
                showErrorMessage("invalid name, names can't contain numbers, please inert a valid name"); //informing the user with a suitable message
                TeachName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no digits) or empty textboxs
            {
                //if valid data (no digits or empty textboxs) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                TeachName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
        protected virtual void TeachSSN_txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (TeachSSN_Txt.TextLength < 9 || TeachSSN_Txt.TextLength > 20 || TeachSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 9 - 20 numbers SSN"); //informing the user with a suitable message
                TeachSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                TeachSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

    }
}
