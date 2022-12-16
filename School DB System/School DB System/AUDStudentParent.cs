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


        //METHODS

        //show Error Message method lbl with a suitable message informing the user with the problem
        protected void showErrorMessage(string ErrorMessage)
        {
            ErrorMessage_Lbl.Text = ErrorMessage; //display error message in the label location
            ErrorMessage_Lbl.Show(); //show error message label
        }

        //hide Error Message lbl method
        protected void hideErrorMessage()
        {
            ErrorMessage_Lbl.Hide(); //hide error message label
        }

        //Fill textboxes with a student data (the selected student data)
        //used with update and view to fill textboxes with the selected student data
        private void RetriveStudentData(Int64 StudentID)
        {
            //query to check if this student is graduated or current student
            if (true) //if selected student is current student not graduated student
            {
                DataTable studentInformation = controllerObj.getStudentData(StudentID);
                StdID_Txt.Text = (studentInformation.Rows[0][0]).ToString();
                StdName_Txt.Text = studentInformation.Rows[0][1].ToString();
                StdYear_CBox.Items.Add(studentInformation.Rows[0][2].ToString());
                StdYear_CBox.SelectedIndex = 0;
                StdPNumber_Txt.Text = studentInformation.Rows[0][3].ToString();
                StdSSN_Txt.Text = studentInformation.Rows[0][4].ToString();
                StdEmail_Txt.Text = studentInformation.Rows[0][5].ToString();
                ParPNumber_Txt.Text = studentInformation.Rows[0][6].ToString();
                StdDob_Dtp.Value = Convert.ToDateTime(studentInformation.Rows[0][7]);
                StdNationality_CBox.Items.Add(studentInformation.Rows[0][8].ToString());
                StdNationality_CBox.SelectedIndex = 0;
                StdAdress_Txt.Text = studentInformation.Rows[0][9].ToString();
                StdSecondLang_CBox.Items.Add(studentInformation.Rows[0][10].ToString());
                StdSecondLang_CBox.SelectedIndex = 0;
                ParSSN_Txt.Text = studentInformation.Rows[0][11].ToString();
                ParName_Txt.Text = studentInformation.Rows[0][12].ToString();
                ParAdress_Txt.Text = studentInformation.Rows[0][13].ToString();
                ParPNumber_Txt.Text = studentInformation.Rows[0][14].ToString();
                ParEmail_Txt.Text = studentInformation.Rows[0][15].ToString();
            }
            else //if selected student is Graduated student not Current student
            {
          
            }
            return; //return
        }

        //Get countires list to use in nationality comboobox
        // (Egyptian, American...etc)
        public static List<string> GetCountryList()
        {
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

            return cultures
                    .Select(cult => (new RegionInfo(cult.LCID)).DisplayName)
                    .Distinct()
                    .OrderBy(q => q)
                    .ToList();
        }

        //EVENTS

        //Student Name Textbox text changed event
        //also used for Student Name Textbox leave event
        protected virtual void StdName_Txt_TextChanged(object sender, EventArgs e)
        {
            if (StdName_Txt.Text.ToString() == "") //if name text is equal to "" i.e there is no data entered (empty textbox)
            {
                //informing the user with the Error
                showErrorMessage("invalid name, please inert a valid name"); //informing the user with a suitable message
                StdName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else if (StdName_Txt.Text.Any(char.IsDigit)) //if name text contains digits (this is invalid)
            {
                showErrorMessage("invalid name, names can't contain numbers, please inert a valid name"); //informing the user with a suitable message
                StdName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no digits) or empty textboxs
            {
                //if valid data (no digits or empty textboxs) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StdName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        //Student SSN Textbox text changed event
        //also used for Student SSN Textbox leave event
        protected virtual void StdSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (StdSSN_Txt.TextLength < 14 || StdSSN_Txt.TextLength > 20 || StdSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                StdSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
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
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                StdPNumber_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or invalid mobile number length)
            {
                //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
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
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                ParPNumber_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or invalid mobile number length)
            {
                //if valid data (no characters or invalid mobile number length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
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
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                ParSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
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
                showErrorMessage("invalid name, names can't contain numbers, please inert a valid name");//informing the user with a suitable message
                ParName_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                return; //return
            }
            {
                //if valid data (no digits) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                ParName_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                return; //return
            }
        }

        //Submit button click event
        //Add, Update Submit button
        protected virtual void Submit_Btn_Click(object sender, EventArgs e)
        {
            //do nothing in the base class as it depends on page type update or add
        }

        //Add, Update, View back button
        //closes the current opened page (Add, Updated, View)
        private void Back_btn_Click(object sender, EventArgs e)
        {
            //asking for confirmation
            var result = RJMessageBox.Show("Your unsaved progress maybe lost.",
             "Are you sure you want to close this window?",
             MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes) //if confirmed "Yes"
            {
                //viewController.closeSubMenu().Hide(); //closes page
            }
            else //if didn't confirm "No"
            {
                return; //keeps the current page opened
            }
        }
    }
}
