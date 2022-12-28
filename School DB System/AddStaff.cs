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
    //(Staff -> Staff) (par -> parent) (obj -> object) (PNumber -> Phone Number)
    //(Txt -> TextBox) (CBox -> Comboobox) (Pnl -> Panel) (Lbl -> Label)

    //ADD Staff USERCONTROL
    public partial class AddStaff :AUVStaffBase
    {
        //DATA MEMBERS
        ViewController viewController; //viewcontroller object
        Controller controllerObj; // controller object

        //non default constructor
        public AddStaff(ViewController viewController, Controller controllerObj) : base(viewController, controllerObj)
        {
            InitializeComponent(); //initializing component
            this.viewController = viewController; //linking viewcontroller object with one viewcontroller object the whole applicaiton use
            this.controllerObj = controllerObj;  //linking controller object with one controller object the whole applicaiton use
            //intiallizing years list comboobox with years (1, 2, 3, ...etc)
            StaffPos_CBox.DisplayMember = "staff_Position";
            StaffPos_CBox.ValueMember = "staff_LevelAuth";
            StaffPos_CBox.DataSource = controllerObj.getStaffPostionslist();
            StaffDep_CBox.DisplayMember = "dep_Name";
            StaffDep_CBox.ValueMember = "dep_ID";
            StaffDep_CBox.DataSource = controllerObj.getDepartmentslist();
            this.StaffDep_CBox.SelectedIndexChanged += new System.EventHandler(this.StaffDep_CBox_SelectedIndexChanged);
            this.StaffPos_CBox.SelectedIndexChanged += new System.EventHandler(this.StaffPos_CBox_SelectedIndexChanged);
        }

        //overriding onPaint function to change derived class (Add Staff) design
        protected override void OnPaint(PaintEventArgs pe)
        {
            Tittle_Lbl.Text = "Add Staff";
            StaffSub_Pnl.Visible = true;
            StaffSub_Pnl.BringToFront();
            this.Controls.Remove(StdSub_Pnl);
            StaffDep_CBox.Visible = false;
            StaffDepReq_Lbl.Visible = false;
            StaffDep_Lbl.Visible = false;
        }

        //METHODS

        //updates Staff ID
        //Staff ID is generated automaticlly to ensure its uniqueness
        //Staff ID is in the format 7 digits{Graduation year tenth digit, graduation year unit digit, SSN first digit, SSN second digit, 5 digits for Staffs count}
        //i.e if the Staff went to the school at year 5 and SSN = 11342124124123 and this the 21th Staff in the school and we are in 2022 and last year is 12
        //then ID will be  (291100021) (29) stands for 2029 (graduation year last 2 digits) and 11 stands for the first two letters in SSN and 00021 stands for the 21th Staff
        //Staff ID depends on SSN and year so this method is called when selected year changed or SSN text changed (only when adding Staff in the first time)
        //Note that in updating Staff information Staff id is not changed even if selected year and SSN changed
        protected virtual void updateStaffID()
        {
            if (StaffSSN_Txt.TextLength < 2)
            {
                StaffID_Txt.Text = ""; //empty Staff ID (reset)
                return; //return (do nothing)
            }
            if (StaffSSN_Txt.BorderColor == Color.Gray) //if SSN textbox bordercolor is gray means enetered Valid SSN generate Staff ID
            {
                int StaffsCount = controllerObj.getStaffCount();//retrieves Staff count
                StaffsCount++; //increments Staff count by 1 i.e if Staffs count is = 3 means the Staff that will be added is the 4th Staff no the 3th
                string formattedStaffCount = string.Format("{0:00000}", StaffsCount); //formatting Staffs count to 5 digits and padding with zeros if needed i Staffs count is 300 it will be 00300 and if 45000 it will be 45000
                char[] SSNFirst2digits = StaffSSN_Txt.Text.ToCharArray(); //converting SSN to array of characters to access characters (first 2 digits)
                char[] DepID = (StaffDep_CBox.SelectedValue.ToString()).ToCharArray(); //converting graduation year textbox text to integer to use to calculate graduation year
                //note that this calculates depending on the real year in the world (datetime.now.year) so its updated with the real time year (only when adding a new Staff not in updating Staff information)
                //created Staff ID with the specfied format
                char first = '0';
                if(StaffDep_CBox.Visible == false)
                {
                    first = '1';
                }
                else
                {
                    first = '2';
                }
                StaffID_Txt.Text = first.ToString() + SSNFirst2digits[0].ToString() + SSNFirst2digits[1].ToString() + formattedStaffCount.ToString();
                return; //return (do nothing)
            }
            else //if SSN textbox bordercolor is red means enetered invalid SSN so don't generate Staff ID and return
            {
                StaffID_Txt.Text = ""; //empty Staff ID (reset)
                return; //return (do nothing)
            }
        }

        //Reset add panel
        protected void resetAddPanel()
        {
            //looping on each item on the panel (Add Panel)
            foreach (Control item in StaffSub_Pnl.Controls)
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
            StaffName_Txt.Select();
            hideErrorMessage();
        }

        //EVENTS
        //add Staff year comboobox selection changed event
        //if the selected year changed change Staff ID as it depeneds on the selected year
        //(first 2 digits of the ID are the last 2 digits of the graduation year that depends on the year the Staff enrolled in the school) 
        protected void StaffDep_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateStaffID(); //Call update Staff ID that updates ID and handles uniqness of the ID
        }
        protected void StaffPos_CBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(int.Parse(StaffPos_CBox.SelectedValue.ToString()) == 5)
            {
                StaffDep_CBox.Visible = true;
                StaffDepReq_Lbl.Visible = true;
                StaffDep_Lbl.Visible = true;
            }
            else
            {
                StaffDep_CBox.Visible = false;
                StaffDepReq_Lbl.Visible = false;
                StaffDep_Lbl.Visible = false;
            }
        }

        //Submit button click event
        //sends query to database to insert a new Staff
        protected override void Submit_Btn_Click(object sender, EventArgs e)
        {
            //checks if there a empty required data (empty textboxs)
            //loops on each textbox in the control
            foreach (Control item in StaffSub_Pnl.Controls) //loop on each item in the panel
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
                int queryRes;
                if (StaffDep_CBox.Visible == false)
                {
                    queryRes = controllerObj.AddStaff(StaffID_Txt.Text.ToString(), StaffName_Txt.Text.ToString(), StaffSSN_Txt.Text.ToString(), Int64.Parse(StaffSalary_Txt.Text), StaffAdress_Txt.Text.ToString(), StaffEmail_Txt.Text.ToString(), StaffPNum_Txt.Text.ToString(), StaffDep_CBox.SelectedValue.ToString(), StaffFullTime_CHBox.Checked, StaffID_Txt.Text.ToString(), "0000", StaffPos_CBox.Text.ToString(), int.Parse(StaffPos_CBox.SelectedValue.ToString()));

                }
                else
                {
                    queryRes = controllerObj.AddTeacher(StaffID_Txt.Text.ToString(), StaffName_Txt.Text.ToString(), StaffSSN_Txt.Text.ToString(), Int64.Parse(StaffSalary_Txt.Text), StaffAdress_Txt.Text.ToString(), StaffEmail_Txt.Text.ToString(), StaffPNum_Txt.Text.ToString(), StaffDep_CBox.SelectedValue.ToString(), StaffFullTime_CHBox.Checked, StaffID_Txt.Text.ToString(), "0000");
                }
                            
                if (queryRes == 0) //if queryres = 0 i.e query executing failed
                {
                    //inform the user that the insertion failed
                    RJMessageBox.Show("Insertion of new Staff failed, revise Staff information and try again.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                    return; //return
                }
                else
                {
                    //inform the user that the insertion succeded
                    RJMessageBox.Show("Insertion a new Staff Successfully",
                   "Successfully added",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    resetAddPanel();//reset the panel to be ready for the next insertion
                    viewController.refreshDatagridView(); //refresh datagrid view after insert or delete Staff
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

        //Staff SSN Textbox text changed event
        //also used for Staff SSN Textbox leave event
        protected override void StaffSSN_txt_TextChanged(object sender, EventArgs e)
        {
            //if name text contains length is out of range (from 14 to 20 digit) this is invalid
            if (StaffSSN_Txt.TextLength < 14 || StaffSSN_Txt.TextLength > 20 || StaffSSN_Txt.Text.Any(char.IsLetter))
            {
                showErrorMessage("invalid SSN, please inert a valid 14 - 20 numbers SSN"); //informing the user with a suitable message
                StaffSSN_Txt.BorderColor = Color.Red; //changing text border color to red informing the user that this is invalid data
                updateStaffID();
                return; //return
            }
            else //if valid data (no characters or ovalid SSN length)
            {
                //if valid data (no characters or ovalid SSN length) inform the user that the entered data is valid
                hideErrorMessage(); //hide error message
                StaffSSN_Txt.BorderColor = Color.Gray; //changing textbox color back to gray informing the user that it is a valid data
                updateStaffID();
                return; //return
            }
        }
    }
}
