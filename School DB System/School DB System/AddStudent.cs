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

//SCHOOL DATABASE SYSTEM NAMESPACE
namespace School_DB_System
{
    //The used abbreviations in the format (abbreviation -> word) 
    //(std -> student) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //ADD STUDENT USERCONTROL
    public partial class AddStudent : StudentAUD //inherits from the base usercontrol which contains the main design and functions (AUDSTUDENTPARENT)
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        public AddStudent(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            //intiallizing years list comboobox with years (1, 2, 3, ...etc)
            DataTable yearsList = controllerObj.getYears(); //retrieving years datatable (1, 2, 3, ...etc)
            StdYear_CBox.DisplayMember = "std_Year"; //displaying std_Year column from the datatable "yearsList"
            StdYear_CBox.ValueMember = "std_Year"; //linking value to std_Year column from the datatable "yearsList"
            StdYear_CBox.DataSource = yearsList; //linking yearlist comboobox and yearlist datable
            //StdYear_CBox.SelectedIndex = 0; //intially selecting item at index = 0 which is "1"
            //intiallizing student nationality comboobox (Egyptian, American ...etc)
            StdNation_CBox.DataSource = GetNationalityList(); //linking StdNationality with Nationalities list
            //StdNation_CBox.SelectedIndex = 0; //intilly selecting the first item in the comboobox which is "Egyptian"
            //intiallizing student second language comboobox (French, German)
            Std2ndLang_CBox.Items.Add("French"); //adding French item at row index = 0  
            Std2ndLang_CBox.Items.Add("German"); //adding German item at row index = 1 
            Std2ndLang_CBox.SelectedIndex = 0; //intially selecting item at index = 0 which is "French"
        }

        //overriding onPaint function to change derived class (Add student) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "Add Student"; //changes control title text to update student
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            StdSub_Pnl.Visible = true;
            TeachSub_Pnl.Visible = false;
            StdSub_Pnl.BringToFront();
            this.Controls.Remove(TeachSub_Pnl);
            StdName_Txt.Select();//initially selecting student name textbox
            StdPayedTuition_CBox.Visible = false; //hiding payed tuition check box in add student panel
        }

        //METHODS

        //updates student ID
        //Student ID is generated automaticlly to ensure its uniqueness
        //student ID is in the format 7 digits{Graduation year tenth digit, graduation year unit digit, SSN first digit, SSN second digit, 5 digits for students count}
        //i.e if the student went to the school at year 5 and SSN = 11342124124123 and this the 21th student in the school and we are in 2022 and last year is 12
        //then ID will be  (291100021) (29) stands for 2029 (graduation year last 2 digits) and 11 stands for the first two letters in SSN and 00021 stands for the 21th student
        //student ID depends on SSN and year so this method is called when selected year changed or SSN text changed (only when adding student in the first time)
        //Note that in updating student information student id is not changed even if selected year and SSN changed
        private void updateStudentID()
        {
            if(StdSSN_Txt.TextLength < 2)
            {
                StdID_Txt.Text = ""; //empty student ID (reset)
                return; //return (do nothing)
            }
            if (StdSSN_Txt.BorderColor == Color.Gray) //if SSN textbox bordercolor is gray means enetered Valid SSN generate student ID
            {
                int stdsCount = controllerObj.getStudentsCount(); //retrieves student count
                stdsCount++; //increments student count by 1 i.e if students count is = 3 means the student that will be added is the 4th student no the 3th
                string formattedStdCount = string.Format("{0:00000}", stdsCount); //formatting students count to 5 digits and padding with zeros if needed i students count is 300 it will be 00300 and if 45000 it will be 45000
                char[] SSNFirst2digits = StdSSN_Txt.Text.ToCharArray(); //converting SSN to array of characters to access characters (first 2 digits)
                int gradYear = int.Parse(StdYear_CBox.Text); //converting graduation year textbox text to integer to use to calculate graduation year
                char[] gradYearLast2digits = ((DateTime.Now.Year) + (12 - gradYear)).ToString().ToCharArray(); //calculates graduation year depending on the current year and converting to characters array to acces its characters (last 2 digits)
                //note that this calculates depending on the real year in the world (datetime.now.year) so its updated with the real time year (only when adding a new student not in updating student information)
                //created Student ID with the specfied format
                StdID_Txt.Text = gradYearLast2digits[2].ToString() + gradYearLast2digits[3].ToString() + SSNFirst2digits[0].ToString() + SSNFirst2digits[1].ToString() + formattedStdCount.ToString();
                return; //return (do nothing)
            }
            else //if SSN textbox bordercolor is red means enetered invalid SSN so don't generate student ID and return
            {
                StdID_Txt.Text = ""; //empty student ID (reset)
                return; //return (do nothing)
            }
        }

        //Reset add panel
        private void resetAddPanel()
        {
            //looping on each item on the panel (Add Panel)
            foreach (Control item in StdSub_Pnl.Controls)
            {
                if (item is Guna2TextBox) //if item is textbox
                {
                    Guna2TextBox textBox = (Guna2TextBox)item; //cast item to textbox to use textbox functionalities
                    textBox.ResetText(); //reset textbox text (empty)
                    textBox.BorderColor = Color.Gray; //chnge bordercolor to gray in case te border color was red due to invalid entered data
                }
                if (item is Guna2ComboBox) //if item is comboobox
                {
                    Guna2ComboBox comboBox = (Guna2ComboBox)item; //cast item to comboobox to use comboobox functionalities 
                    comboBox.SelectedIndex = 0; //select the first item (reset selection)
                }
            }
            StdName_Txt.Select();
            hideErrorMessage();
        }


        //EVENTS
        //add student year comboobox selection changed event
        //if the selected year changed change student ID as it depeneds on the selected year
        //(first 2 digits of the ID are the last 2 digits of the graduation year that depends on the year the student enrolled in the school) 
        private void StdYear_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStudentID(); //Call update student ID that updates ID and handles uniqness of the ID
        }

        //Submit button click event
        //sends query to database to insert a new student
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            //checks if there a empty required data (empty textboxs)
            //loops on each textbox in the control
            foreach (Control item in StdSub_Pnl.Controls) //loop on each item in the panel
            {
                if (item is Guna2TextBox) //if the item is textbox
                {
                    Guna2TextBox textBox = (Guna2TextBox)item; //cast item to textbox to use textbox functionalities
                    textBox.Focus(); //focus on each textbox 
                    //means select the textbox
                    //next loop it selects the next textbox which performs the previously selected textbox leave event
                    //each textbox is responsible for validating the data in it using text changed event or leave event
                    //when there is a non valid in any textbox the textbox bordercolor is changed to red
                    //so when this loop ends every required textbox data if not valid this textbox border color will be red
                    if (textBox.BorderColor == Color.Red) //checks if this textbox border color is red (invalid data in textbox)
                    {
                        //inform the user to insert all required values
                        RJMessageBox.Show("Please insert all the required Values.",
                             "Error",
                         MessageBoxButtons.OK,
                         MessageBoxIcon.Error);
                        return;
                        //return (do nothing)
                    }
                }
            }
            //if the all the data entered by the user is valid
            try //handles any unexpected error while converting any string to string or query fail
            {
                //send a query and gets the result of the query in queryres
                int queryRes = controllerObj.AddStudent(StdParSSN_Txt.Text.ToString(), StdParName_Txt.Text.ToString(), StdParAdress_Txt.Text.ToString(), StdParPNum_Txt.Text.ToString(), StdParEmail_Txt.Text.ToString(),
                   StdID_Txt.Text.ToString(), StdName_Txt.Text.ToString(), StdSSN_Txt.Text.ToString(), StdEmail_Txt.Text.ToString(), StdPNum_Txt.Text.ToString(), StdDob_Dtp.Value.ToString(),
                   StdNation_CBox.Text.ToString(), StdAdress_Txt.Text.ToString(), Std2ndLang_CBox.Text.ToString(), int.Parse(StdYear_CBox.Text.ToString()));

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new student failed, revise student information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Insertion a new student Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    resetAddPanel();//reset the panel to be ready for the next insertion
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete student
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

        //Student SSN Textbox text changed event
        //also used for Student SSN Textbox leave event
        protected override void StdSSN_Txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (StdSSN_Txt.TextLength < 14 || StdSSN_Txt.TextLength > 20 || StdSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                StdSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                updateStudentID();
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StdSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                updateStudentID();
                return; //return
            }
        }

    }
}
