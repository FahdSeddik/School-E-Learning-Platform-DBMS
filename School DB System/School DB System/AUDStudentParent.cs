using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //ADD, UPDATE, DELETE STUDENT USERCONTROL BASE USERCONTROL
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //AUDSTUDENTPARENT USERCONTROL (BASE USERCONTROL FOR ADD STUDENT, UPDATE STUDENT, VIEW STUDENT)
    public partial class AUDStudentParent : UserControl //inherits from usercontrol
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        public AUDStudentParent(ViewController viewController, Controller controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
        }


        //Graduate student view
        //depending on the active page type
        //in view and update it hides student year and textbox and shows graduated student university lbl and textbox
        //in addit hides graduated student university lbl and textbox and shows student year and textbox
        //because we are always adding a current student
        protected void graduatedStudentView()
        {
            //the default is current student view
            //in view and update it hides student year and textbox and shows graduated student university lbl and textbox
            StdYear_CBox.Visible = false;//hide student year comboo box
            StdYear_Lbl.Visible = false;//hide student year label
            University_Txt.Visible = true;//shows student university text
            University_Lbl.Visible = true;//shows student university label
            PayedTuition_CBox.Visible = false;//hide Payed tuition year comboobox
            //by default properties student year label and comboobox are visible so hide them
            //and unviersity label and textbox are not visible so show them
            return; //return;
        }

        

        //Student SSN Textbox text changed event
        //also used for Student SSN Textbox leave event
        protected virtual void StdSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (StdSSN_Txt.TextLength < 9 || StdSSN_Txt.TextLength > 20 || StdSSN_Txt.Text.Any(char.IsLetter))
            {
                //showErrorMessage("invalid SSN, please inert a valid 9 - 20 numbers SSN"); //informing the user with a suitable message
                StdSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
               // hideErrorMessage(); //hide error message
                StdSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        //Student phone number Textbox text changed event
        //also used for student phone number Textbox leave event
        protected virtual void StdPNumber_Txt_TextChanged(object sender, EventArgs e)
        {
            //if number text length is not out of range (from 8 to 15 digit) this is invalid
            if (StdPNumber_Txt.TextLength < 8 || StdPNumber_Txt.TextLength > 15 || StdPNumber_Txt.Text.Any(char.IsLetter))
            {
               // showErrorMessage("invalid phone number, please inert a valid 8 - 15 numbers"); //informing the user with a suitable message
                StdPNumber_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or invalid mobile number length)
            {
                //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
              //  hideErrorMessage(); //hide error message
                StdPNumber_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        //Parent phone number Textbox text changed event
        //also used for student phone number Textbox leave event
        protected virtual void ParPNumber_Txt_TextChanged(object sender, EventArgs e)
        {
            //if number text length is not out of range (from 8 to 15 digit) this is invalid
            if (ParPNumber_Txt.TextLength < 8 || ParPNumber_Txt.TextLength > 15 || ParPNumber_Txt.Text.Any(char.IsLetter))
            {
              //  showErrorMessage("invalid phone number, please inert a valid 8 - 15 numbers"); //informing the user with a suitable message
                ParPNumber_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or invalid mobile number length)
            {
                //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
               // hideErrorMessage(); //hide error message
                ParPNumber_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }


        //Parent SSN Textbox text changed event
        //also used for Parent SSN Textbox leave event
        protected virtual void ParSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range(from 14 to 20 digit) this is invalid
            if (ParSSN_Txt.TextLength < 14 || StdSSN_Txt.TextLength > 20 || StdSSN_Txt.Text.Any(char.IsLetter))
            {
              //  showErrorMessage("invalid SSN, please inert a valid 9 - 20 numbers SSN"); //informing the user with a suitable message
                ParSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
             //   hideErrorMessage(); //hide error message
                ParSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        //Parent Name Textbox text changed event
        //also used for Parent Name Textbox leave event
        protected virtual void ParName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (ParName_Txt.Text.Any(char.IsDigit)) //if name text contains digits (this is invalid)
            {
                //informing the user with the Error
              //  showErrorMessage("invalid name, names can't contain numbers, please inert a valid name");//informing the user with a suitable message
                ParName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            {
                //if valid data (no digits) inform the user that the entered data is valid
              //  hideErrorMessage(); //hide error message
                ParName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        

        

        //Student Email Textbox text changed event
        //also used for Student Email Textbox leave event      
        protected virtual void StdEmail_Txt_TextChanged(object sender, EventArgs e)
        {
            //if empty textbox
            if (StdEmail_Txt.Text.ToString() == "")
            {
               // showErrorMessage("invalid email adress please enter a valid email adress"); //informing the user with a suitable message
                StdEmail_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data
            {
                //if valid data inform the user that the entered data is valid
              //  hideErrorMessage(); //hide error message
                StdEmail_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        //University name Textbox text changed event
        //also used for university name Textbox leave event      
        protected virtual void University_Txt_TextChanged(object sender, EventArgs e)
        {
            //if empty textbox
            if (University_Txt.Text.ToString() == "")
            {
               // showErrorMessage("invalid univesity name, please insert a valid name"); //informing the user with a suitable message
                University_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data
            {
                //if valid data inform the user that the entered data is valid
              //  hideErrorMessage(); //hide error message
                University_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }
    }
}

