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
    //The used abbreviations in the format(abbreviation -> word)
    //(Teach -> teacher) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //ADD teacher USERCONTROL
    public partial class AddTeacher : ADUTeacherParent //inherits from the base usercontrol which contains the main design and functions (AUDteacherPARENT)
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        public AddTeacher(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            //intiallizing years list comboobox with years (1, 2, 3, ...etc)
            TeachDep_CBox.DisplayMember = "dep_Name";
            TeachDep_CBox.ValueMember = "dep_ID";
            TeachDep_CBox.DataSource = controllerObj.getDepartmentslist();
            this.TeachDep_CBox.SelectedIndexChanged += new System.EventHandler(this.TeachDep_CBox_SelectedIndexChanged);
        }

        //overriding onPaint function to change derived class (Add teacher) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "Add Teacher"; //changes control title text to update teacher
            Tittle_Lbl.TextAlignment = ContentAlignment.MiddleCenter; //changes tittle text alignment to center
            TeachName_Txt.Select();//initially selecting teacher name textbox
        }

        //METHODS

        //updates teacher ID
        //teacher ID is generated automaticlly to ensure its uniqueness
        //teacher ID is in the format 7 digits{Graduation year tenth digit, graduation year unit digit, SSN first digit, SSN second digit, 5 digits for teachers count}
        //i.e if the teacher went to the school at year 5 and SSN = 11342124124123 and this the 21th teacher in the school and we are in 2022 and last year is 12
        //then ID will be  (291100021) (29) stands for 2029 (graduation year last 2 digits) and 11 stands for the first two letters in SSN and 00021 stands for the 21th teacher
        //teacher ID depends on SSN and year so this method is called when selected year changed or SSN text changed (only when adding teacher in the first time)
        //Note that in updating teacher information teacher id is not changed even if selected year and SSN changed
        private void updateTeacherID()
        {
            if (TeachSSN_Txt.TextLength < 2)
            {
                TeachID_Txt.Text = ""; //empty teacher ID (reset)
                return; //return (do nothing)
            }
            if (TeachSSN_Txt.BorderColor == Color.Gray) //if SSN textbox bordercolor is gray means enetered Valid SSN generate teacher ID
            {
                int TeachsCount = controllerObj.getTeachersCount(); //retrieves teacher count
                TeachsCount++; //increments teacher count by 1 i.e if teachers count is = 3 means the teacher that will be added is the 4th teacher no the 3th
                string formattedTeachCount = string.Format("{0:00000}", TeachsCount); //formatting teachers count to 5 digits and padding with zeros if needed i teachers count is 300 it will be 00300 and if 45000 it will be 45000
                char[] SSNFirst2digits = TeachSSN_Txt.Text.ToCharArray(); //converting SSN to array of characters to access characters (first 2 digits)
                char[] DepID = (TeachDep_CBox.SelectedValue.ToString()).ToCharArray(); //converting graduation year textbox text to integer to use to calculate graduation year
                //note that this calculates depending on the real year in the world (datetime.now.year) so its updated with the real time year (only when adding a new teacher not in updating teacher information)
                //created teacher ID with the specfied format
                TeachID_Txt.Text = DepID[0].ToString() + SSNFirst2digits[0].ToString() + SSNFirst2digits[1].ToString() + formattedTeachCount.ToString();
                return; //return (do nothing)
            }
            else //if SSN textbox bordercolor is red means enetered invalid SSN so don't generate teacher ID and return
            {
                TeachID_Txt.Text = ""; //empty teacher ID (reset)
                return; //return (do nothing)
            }
        }

        //Reset add panel
        private void resetAddPanel()
        {
            //looping on each item on the panel (Add Panel)
            foreach (Control item in TeachSub_Pnl.Controls)
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
            TeachName_Txt.Select();
            hideErrorMessage();
        }

        //EVENTS
        //add teacher year comboobox selection changed event
        //if the selected year changed change teacher ID as it depeneds on the selected year
        //(first 2 digits of the ID are the last 2 digits of the graduation year that depends on the year the teacher enrolled in the school) 
        private void TeachDep_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTeacherID(); //Call update teacher ID that updates ID and handles uniqness of the ID
        }

        //Submit button click event
        //sends query to database to insert a new teacher
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            //checks if there a empty required data (empty textboxs)
            //loops on each textbox in the control
            foreach (Control item in TeachSub_Pnl.Controls) //loop on each item in the panel
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
                int queryRes = controllerObj.AddTeacher(TeachID_Txt.Text.ToString(), TeachName_Txt.Text.ToString(), TeachSSN_Txt.Text.ToString(), Int64.Parse(TeachSalary_Txt.Text), TeachAdress_Txt.Text.ToString(), TeachEmail_Txt.Text.ToString(), TeachPNum_Txt.Text.ToString(), TeachDep_CBox.SelectedValue.ToString(), TeachFullTime_CHBox.Checked, TeachID_Txt.Text.ToString(), "0000");

                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new teacher failed, revise teacher information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Insertion a new teacher Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    resetAddPanel();//reset the panel to be ready for the next insertion
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete teacher
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

        //teacher SSN Textbox text changed event
        //also used for teacher SSN Textbox leave event
        protected override void TeachSSN_txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (TeachSSN_Txt.TextLength < 14 || TeachSSN_Txt.TextLength > 20 || TeachSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                TeachSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                updateTeacherID();
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                TeachSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                updateTeacherID();
                return; //return
            }
        }
    }
}
